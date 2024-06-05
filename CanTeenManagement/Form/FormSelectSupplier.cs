using CanTeenManagement.Model;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CanTeenManagement.Utils;
using System.Threading;
using static CanTeenManagement.Bussiness.ENUM.EnumSupplier;
using CanTeenManagement.Bussiness.SQLHelper;

namespace CanTeenManagement
{
    public partial class FormSelectSupplier : Form
    {
        public bool isUpdate;
        SupplierHelper _supplierHelper = new SupplierHelper();
        public FormSelectSupplier()
        {
            InitializeComponent();
            cbMonth.Text = DateTime.Now.Month.ToString();
            int yearNow = DateTime.Now.AddYears(1).Year;
            List<string> listYear = new List<string>();
            for (int i = 2020; i <= yearNow; i++)
            {
                listYear.Add(i.ToString());
            }
            cbYear.DataSource = listYear.OrderByDescending(o => o).ToList();
            cbYear.Text = DateTime.Now.Year.ToString();
            using (var ctx = new DBContext())
            {
                var listSupplier = ctx.Tbl_Supplier.ToList();
                cbSupplier.DisplayMember = "SupplierName";
                cbSupplier.DataSource = listSupplier;
            }
            cbSearch.SelectedIndex = 0;
            cbDateChange = true;
            dgvVolatilityPrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        bool cbDateChange = false;
        private void btnSearchIngredient_Click(object sender, EventArgs e)
        {
            FindInfomationPrice();
        }

        public void FindInfomationPrice()
        {           
            try
            {
                Common.StartFormLoading();
                //Common.UpdateSupplierPriority(DateTime.Now);
                DateTime dateTime = new DateTime(Int16.Parse(cbYear.Text), Int16.Parse(cbMonth.Text), 1);
                Common.UpdateEqualPrice(dateTime,UpdateType.Read);
                using (var ctx = new DBContext())
                {
                    DateTime inputDate = new DateTime(Int16.Parse(cbYear.Text), Int16.Parse(cbMonth.Text), 1);
                    this.Tag = inputDate;
                    var getData = ctx.Tbl_HistoryPrice.Where(w => w.ApprovalDate == inputDate).ToList();
                    if (getData.Count == 0)
                    {
                        Thread.Sleep(200);
                        Common.CloseFormLoading();
                        MessageBox.Show("Chưa cập nhật giá tháng " + Int16.Parse(cbMonth.Text) + "-" + Int16.Parse(cbYear.Text));
                        return;
                    }
                    btnSave.Tag = inputDate.ToString();
                    dgvSelectSupplier.Rows.Clear();
                    //txtTitel.Text = "Bảng Giá Tháng: " + cbMonth.Text + "/" + cbYear.Text;
                    //Tạo cột cho bảng
                    var listSupplier = ctx.Tbl_Supplier.ToList();
                    dgvSelectSupplier.ColumnCount = 4 + listSupplier.Count();
                    addColumn(0, "Code", "IngredientCode", "IngredientCode", false, dgvSelectSupplier, DataGridViewAutoSizeColumnMode.DisplayedCells);
                    addColumn(1, "Tên nguyên liệu", "IngredientName", "IngredientName", false, dgvSelectSupplier, DataGridViewAutoSizeColumnMode.NotSet);
                    addColumn(2, "Đơn vị", "Unit", "Unit", false, dgvSelectSupplier, DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader);
                    addColumn(3, "Thông số", "Spec", "Spec", false, dgvSelectSupplier, DataGridViewAutoSizeColumnMode.NotSet);
                    for (int i = 0; i < listSupplier.Count(); i++)
                    {
                        addColumn(i + 4, listSupplier[i].SupplierName, listSupplier[i].SupplierCode, listSupplier[i].SupplierCode, false, dgvSelectSupplier, DataGridViewAutoSizeColumnMode.NotSet);
                        dgvSelectSupplier.Columns[i+4].Width = 100;
                        dgvSelectSupplier.Columns[i + 4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    dgvSelectSupplier.Columns[1].Width = 200;
                    DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
                    dgvCmb.HeaderText = "CHỌN NCC";
                    dgvCmb.Width = 150;
                    dgvCmb.FlatStyle = FlatStyle.Flat;
                    DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
                    dataGridViewCellStyle.BackColor = Color.AliceBlue;
                    dgvCmb.DefaultCellStyle = dataGridViewCellStyle;
                    dgvCmb.DisplayMember = "SupplierName";
                    dgvSelectSupplier.Columns.Add(dgvCmb);

                    //load dữ liệu ra bảng
                    List<string> codeList = new List<string>();
                    List<string> ingredientExistInHistoryPriceList = ctx.Tbl_HistoryPrice.Where(w => w.ApprovalDate == inputDate).Select(s => s.IngredientCode).Distinct().ToList(); // lấy code nguyên liệu tại tháng đang chọn.

                    foreach (var item in ingredientExistInHistoryPriceList)
                    {
                        var existData = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == item).Select(s => s.IngredientName.Contains(txtSearchContent.Text) || s.IngredientCode.Contains(txtSearchContent.Text)).FirstOrDefault();
                        if (existData)
                        {
                            codeList.Add(item);
                        }
                    }
                    ViewInfoIngredient(codeList, inputDate, listSupplier);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi : " + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }

        private void ViewInfoIngredient(List<string> ingredientExistInHistoryPriceList, DateTime inputDate, List<Tbl_Supplier> listSupplier)
        {
            using(var ctx = new DBContext())
            {
                var listPriority = ctx.Tbl_Ingredient.Where(w => w.SupplierPriorityCode != null).Select(s=>s.IngredientCode).ToList();
                foreach(var code in ingredientExistInHistoryPriceList)
                {
                    var getIngredientExist = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == code).FirstOrDefault();
                    dgvSelectSupplier.Rows.Add();
                    int indexRow = dgvSelectSupplier.RowCount-1;
                    DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dgvSelectSupplier.Rows[indexRow].Cells[listSupplier.Count() + 4];
                    List<string> supplierNameList = new List<string>();
                    dgvSelectSupplier.Rows[indexRow].Cells[0].Value = code;
                    dgvSelectSupplier.Rows[indexRow].Cells[1].Value = getIngredientExist.IngredientName;
                    dgvSelectSupplier.Rows[indexRow].Cells[2].Value = getIngredientExist.Unit;
                    dgvSelectSupplier.Rows[indexRow].Cells[3].Value = getIngredientExist.Spec;
                    foreach (var supplier in listSupplier) // hiển thị giá tiền của các nhà cung cấp.
                    {
                        var cell = dgvSelectSupplier.Rows[indexRow].Cells[supplier.SupplierCode];
                        var price = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == code && w.ApprovalDate == inputDate && w.SupplierCode == supplier.SupplierCode).Select(s => s.Price).FirstOrDefault();
                        cell.Value = Common.ConvertText(price);
                        if(price != null)
                        {
                            supplierNameList.Add(supplier.SupplierName);
                        }
                    }
                    cbCell.DataSource = supplierNameList;
                    // Hiển thị ra nhà đang được chọn
                    var supplierPriceMain = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == code && w.ApprovalDate == inputDate && w.PriceMain == 1).FirstOrDefault();
                    if(supplierPriceMain != null) 
                    {
                        cbCell.Value =ctx.Tbl_Supplier.Find(supplierPriceMain.SupplierCode).SupplierName;
                        if (listPriority.Contains(code)) cbCell.ReadOnly = true;
                    }
                    else // nếu chưa có nhà nào được chọn làm nhà cung cấp chính thì tìm giá rẻ nhất để hiển thị.
                    {
                        string supplierNameMinPrice =findSupplierMinPrice(code, listSupplier, inputDate);
                        cbCell.Value = supplierNameMinPrice;
                        if (listPriority.Contains(code)) cbCell.ReadOnly = true;
                    }
                    // Tô màu cảnh báo
                    // nếu nhà cung cấp đang chọn ko phải rẻ nhất hoặc giá bằng nhau.

                    var supplierSelected = cbCell.Value.ToString();
                    var supplierIdSelectedCode = ctx.Tbl_Supplier.Where(w => w.SupplierName == supplierSelected).Select(s => s.SupplierCode).FirstOrDefault().Trim();
                    var priceSelected = ctx.Tbl_HistoryPrice.Where(w => w.ApprovalDate == inputDate && w.IngredientCode == code && w.SupplierCode == supplierIdSelectedCode).Select(s => s.Price).FirstOrDefault();
                    var numberSupplier = ctx.Tbl_HistoryPrice.Where(w => w.ApprovalDate == inputDate && w.IngredientCode == code).ToList();
                    if (numberSupplier.Count > 1)
                    {
                        var minPrice = numberSupplier.Min(o => o.Price);
                        var supplierNotSelectPrice = numberSupplier.Where(w => w.SupplierCode != supplierIdSelectedCode).Select(s => s.Price).FirstOrDefault();
                        if (priceSelected > minPrice)
                        {
                            dgvSelectSupplier.Rows[indexRow].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        if (priceSelected == supplierNotSelectPrice)
                        {
                            dgvSelectSupplier.Rows[indexRow].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                        }
                    }
                    if (priceSelected == null) // nếu 1 ngày nào đó nhà này nó không báo giá trong khi nó lại đang là nhà ưu tiên thì????????? Xóa khỏi danh sách ưu tiên.
                    {
                        var ingredientExist = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == code).FirstOrDefault();
                        ingredientExist.SupplierPriorityCode = null;
                        ctx.SaveChanges();
                        cbCell.Value = findSupplierMinPrice(code, listSupplier, inputDate);
                    }
                    // nếu là thực phẩm ưu tiên thì tô màu xanh.
                    if (listPriority.Contains(code))
                    {
                        dgvSelectSupplier.Rows[indexRow].DefaultCellStyle.BackColor = Color.Lime;
                    }
                }            
            }
        }

        private string findSupplierMinPrice(string code,List<Tbl_Supplier> supplierList, DateTime inputDate)
        {
            using(var ctx = new DBContext())
            {
                var ingredientPriority = ctx.Tbl_Ingredient.Where(w => w.SupplierPriorityCode != null).Select(s => s.IngredientCode).ToList();
                if (ingredientPriority.Contains(code))
                {
                    string today = DateTime.Now.DayOfWeek.ToString();
                    if (today == "Monday" || today == "Wednesday" || today == "Friday")
                    {
                        return "Đỗ Nguyên";
                    }
                    else
                    {
                        return "Hữu Xuất";
                    }
                }
                var historyPriceList = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == code && w.ApprovalDate == inputDate).ToList();
                return ctx.Tbl_Supplier.Find(historyPriceList.OrderBy(o => o.Price).FirstOrDefault().SupplierCode).SupplierName;                                         
            }
        }

        private void addColumn(int index, string headerText, string name, string dataPropertyName, bool frozen, DataGridView dgv, DataGridViewAutoSizeColumnMode sizeColumn)
        {
            dgv.Columns[index].HeaderText = headerText;
            dgv.Columns[index].Name = name;
            dgv.Columns[index].DataPropertyName = dataPropertyName;
            dgv.Columns[index].AutoSizeMode = sizeColumn;
            dgv.Columns[index].ReadOnly = true;
            dgv.Columns[index].Frozen = frozen;
        }

        private void btnImportExcelUpdatePrice_Click(object sender, EventArgs e)
        {
            List<Tbl_HistoryPrice> listIngredientErro = new List<Tbl_HistoryPrice>();
            //thêm nguyên liệu bằng file excel
            using (OpenFileDialog open = new OpenFileDialog())
            {
                // Set the filter to allow only Excel files
                open.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        
                        //đọc dữ liệu từ file excel
                        Workbook wbFromMaster = new Workbook();
                        wbFromMaster.LoadFromFile(open.FileName);
                        Worksheet sheet = wbFromMaster.Worksheets[0];
                        DateTime resultDateExel = new DateTime();
                        if(!DateTime.TryParse(sheet.Range["C1"].Value, out resultDateExel))
                        {
                            MessageBox.Show("Sai định dang thời gian tại ô C1: MM/dd/yyyy");
                            return;
                        }
                        DateTime dateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        if (resultDateExel.Month < dateNow.Month && resultDateExel.Year < dateNow.Year)
                        {
                            MessageBox.Show("Không được cập nhật giá tháng " + resultDateExel.Month + "/" + resultDateExel.Year + ". Chỉ có thể cập nhật tháng hiện tại và những tháng tiếp theo!", "Thông báo");
                            return;
                        }
                        DateTime dateSelect = new DateTime(Int16.Parse(cbYear.Text), Int16.Parse(cbMonth.Text), 1);
                        if (resultDateExel.Month != dateSelect.Month && resultDateExel.Year != dateSelect.Year)
                        {
                            MessageBox.Show("Thời gian cập nhật và thời gian trong file báo giá không chính xác", "Thông báo");
                            return;
                        }
                        var supplierCode = sheet.Range[3, 5].Value.Trim();
                        if (!IsExistSupplierCode(supplierCode))
                        {
                            MessageBox.Show($"Sai mã nhà cung cấp tại ô E[3]!");
                            return;
                        }
                        Common.StartFormLoading();
                        List<Tbl_HistoryPrice> getUpdateQuoteList = new List<Tbl_HistoryPrice>();
                        for (int i = 3; i <= sheet.Rows.Count(); i++)
                        {
                            Tbl_HistoryPrice historyPriceNew = UpdateQuote(sheet, i, dateSelect, supplierCode);
                            if (historyPriceNew == null)
                            {
                                Common.StartFormLoading();
                                MessageBox.Show("Cập nhật giá không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            getUpdateQuoteList.Add(historyPriceNew);
                        }
                        // Thêm và lọc lịch sử giá
                        if (getUpdateQuoteList.Count > 0)
                        {
                            AddAndFilterHistoryPrice(getUpdateQuoteList);
                        }
                        Common.CloseFormLoading();
                        btnSearchIngredient_Click(null, null);
                        MessageBox.Show("Cập nhật giá thành công, Hãy lưu lại cập nhật giá!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);                      
                        isUpdate = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi sảy ra.Vui lòng thử lại" + ex.Message, "Thông báo");
                    }
                    finally
                    {
                        Common.CloseFormLoading();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void AddAndFilterHistoryPrice(List<Tbl_HistoryPrice> getUpdateQuoteList)
        {
            try
            {
                using (var ctx = new DBContext())
                {
                    // xóa hết dữ liệu cập nhất của nhà cung cấp tại tháng cũ và bê nguyên cái mới vào.
                    // hoặc là sửa thay thế?
                    foreach (var dataNewUpdate in getUpdateQuoteList)
                    {
                        var findOldDataExist = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == dataNewUpdate.IngredientCode && w.ApprovalDate == dataNewUpdate.ApprovalDate && w.SupplierCode == dataNewUpdate.SupplierCode).FirstOrDefault();
                        if (findOldDataExist != null) // nếu tồn tại cái dữ liệu này thì ghi đè. nếu giá mới nhỏ hơn hoặc bằng 0 thì xóa đi.
                        {
                            if (dataNewUpdate.Price <= 0)
                            {
                                ctx.Tbl_HistoryPrice.Remove(findOldDataExist);
                            }
                            else
                            {
                                findOldDataExist.Price = dataNewUpdate.Price;
                                findOldDataExist.Comment = dataNewUpdate.Comment;
                                findOldDataExist.TimeUpdate = DateTime.Now;
                                findOldDataExist.PriceMain = null;
                            }
                        }
                        else
                        {
                            if (dataNewUpdate.Price <= 0) continue;
                            ctx.Tbl_HistoryPrice.Add(dataNewUpdate);
                        }
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi khi cập nhật giá "+ex.Message);
            }            
        }

        private Tbl_HistoryPrice UpdateQuote(Worksheet sheet, int row,DateTime dateSelect,string supplierCode )
        {
            Tbl_HistoryPrice getNewHistoryPrice = new Tbl_HistoryPrice();
            double resultNewPrice;
            string ingredientCode = sheet.Range[row,1].Value.Trim();
            string ingredientName = sheet.Range[row, 2].Value.Trim();
            string ingredientSpec = sheet.Range[row, 3].Value.Trim();
            string ingredientUnit = sheet.Range[row, 4].Value.Trim();
            double ingredientNewPrice = double.TryParse(sheet.Range[row, 7].Value.Trim(), out resultNewPrice) == false || string.IsNullOrEmpty(sheet.Range[row, 1].Value.Trim()) ? 0 : resultNewPrice;
            string comment = sheet.Range[row, 8].Value.Trim();
            
            if (!IsExistIngredientCode(ingredientCode))
            {
                MessageBox.Show($"Mã hàng tại ô A{row} không tồn tại!");
                return null;
            }           
            getNewHistoryPrice.ApprovalDate = dateSelect.Date;
            getNewHistoryPrice.Comment = comment;
            getNewHistoryPrice.IngredientCode = ingredientCode;
            getNewHistoryPrice.Price = (int)resultNewPrice;
            getNewHistoryPrice.SupplierCode = supplierCode;
            getNewHistoryPrice.TimeUpdate = DateTime.Now;
            return getNewHistoryPrice;
        }

        private int? GetIdSupplier(string supplierCode)
        {
            using(var ctx = new DBContext())
            {
                return ctx.Tbl_Supplier.Where(w => w.SupplierCode.Trim() == supplierCode).Select(s => s.Id).FirstOrDefault();
            }
        }

        private bool IsExistSupplierCode(string supplierCode)
        {
            using (var ctx = new DBContext())
            {
                var supplierCodeExist = ctx.Tbl_Supplier.Where(w => w.SupplierCode.Trim() == supplierCode.Trim()).FirstOrDefault();
                if (supplierCodeExist != null) return true;
                return false;
            }
        }

        private bool IsExistIngredientCode(string ingredientCode)
        {
            using(var ctx = new DBContext())
            {
                var ingredientExist = ctx.Tbl_Ingredient.Where(w => w.IngredientCode.Trim() == ingredientCode).FirstOrDefault();
                if (ingredientExist != null) return true;
                return false;
            }
        }

        public static int ConvertStringToInt(string numberString)
        {
            // Remove the commas from the number string using String.Replace method
            string withoutCommas = numberString.Replace(",", "");

            // Parse the string into an integer
            int result;
            if (int.TryParse(withoutCommas, out result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid number format.");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAndSelectPriceMain();
        }

        public void SaveAndSelectPriceMain()
        {
            if (dgvSelectSupplier.RowCount < 1)
            {
                MessageBox.Show("Hãy chọn tìm kiếm để hiển thị thông tin nhà cung cấp mới có thể lưu!");
                return;
            }
            try
            {
                Common.StartFormLoading();
                int countRow = dgvSelectSupplier.Rows.Count;
                int countColumns = dgvSelectSupplier.Columns.Count - 1;
                DateTime dateApproval = DateTime.Parse(btnSave.Tag.ToString());
                for (int i = 0; i < countRow; i++)
                {
                    var rowIndex = dgvSelectSupplier.Rows[i];
                    string ingredientCode = rowIndex.Cells[0].Value.ToString();
                    var supplierSelect = rowIndex.Cells[countColumns].Value;
                    if (supplierSelect == null) continue;
                    var supplierSelected = supplierSelect.ToString();
                    using (var ctx = new DBContext())
                    {
                        var supplier = ctx.Tbl_Supplier.Where(w => w.SupplierName == supplierSelected).FirstOrDefault();
                        var ingredient = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
                        var historyPrice = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingredientCode && w.ApprovalDate == dateApproval).ToList();
                        foreach (var item in historyPrice)
                        {
                            if (item.SupplierCode == supplier.SupplierCode) item.PriceMain = 1;
                            else item.PriceMain = 0;
                            ctx.Entry(item).State = System.Data.Entity.EntityState.Modified;
                            ctx.SaveChanges();
                        }
                        ctx.Entry(ingredient).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
                Common.CloseFormLoading();
                MessageBox.Show("Đã lưu thành công!", "Thông báo");
                Form1 form1 = FindFormLast();
                form1.isSavePriceMain = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }
        private Form1 FindFormLast()
        {
            List<Form> FormList = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                string formName = form.Name;
                if (formName == "Form1")
                {
                    FormList.Add(form);
                }
            }
            var LastForm = (Form1)FormList.Last();
            return LastForm;
        }
        string supplierCodeVolatility;
        private void btnSearchVolatility_Click(object sender, EventArgs e)
        {
            if (numberMonths.Value <= 0) return;
            try
            {
                Common.StartFormLoading();
                using (var ctx = new DBContext())
                {
                    dgvVolatilityPrice.ColumnCount = (int)(3 + numberMonths.Value);
                    var supplierSelect = (Tbl_Supplier)cbSupplier.SelectedItem;
                    DateTime inputDate = new DateTime(Int16.Parse(cbYear.Text), Int16.Parse(cbMonth.Text), 1);
                    dgvVolatilityPrice.Rows.Clear();
                    //Tạo cột cho bảng
                    var listSupplier = ctx.Tbl_Supplier.ToList();
                    addColumn(0, "Code", "IngredientCode", "IngredientCode", false, dgvVolatilityPrice, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                    addColumn(1, "Tên nguyên liệu", "IngredientName", "IngredientName", false, dgvVolatilityPrice, DataGridViewAutoSizeColumnMode.ColumnHeader);
                    addColumn(2, "Thông số", "Spec", "Spec", false, dgvVolatilityPrice, DataGridViewAutoSizeColumnMode.ColumnHeader);
                    List<DateTime> listMonth = new List<DateTime>();
                    for (int i = 0; i < numberMonths.Value; i++)
                    {
                        DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(i * -1).Month, 1);
                        listMonth.Add(date);
                        addColumn(i + 3, "Tháng " + listMonth[i].Month.ToString() + "/" + listMonth[i].Year.ToString(), listMonth[i].ToString("dd/MM/yyyy"), listMonth[i].ToString("dd/MM/yyyy"), false, dgvVolatilityPrice, DataGridViewAutoSizeColumnMode.NotSet);
                    }
                    //load dữ liệu ra bảng
                    var listIngredient = ctx.Tbl_Ingredient.ToList();
                    foreach (var item in listIngredient)
                    {
                        var index = dgvVolatilityPrice.Rows.Add();
                        List<string> valueList = new List<string>();
                        dgvVolatilityPrice.Rows[index].Cells[0].Value = item.IngredientCode;
                        dgvVolatilityPrice.Rows[index].Cells[1].Value = item.IngredientName;
                        dgvVolatilityPrice.Rows[index].Cells[2].Value = item.Spec;
                        foreach (var month in listMonth)
                        {
                            Tbl_HistoryPrice results = new Tbl_HistoryPrice();
                            if (cbSearch.SelectedIndex == 0)
                            {
                                results = item.Tbl_HistoryPrice.Where(w => w.SupplierCode == supplierSelect.SupplierCode && w.ApprovalDate == month).FirstOrDefault();
                                supplierCodeVolatility = supplierSelect.SupplierCode;
                            }
                            else
                            {
                                results = item.Tbl_HistoryPrice.Where(w => w.ApprovalDate == month && w.PriceMain == 1).FirstOrDefault();
                            }
                            if (results == null) continue;
                            int indexCell = dgvVolatilityPrice.Columns[month.ToString("dd/MM/yyyy")].Index;
                            string value = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", results.Price);
                            valueList.Add(value);
                            dgvVolatilityPrice.Rows[index].Cells[indexCell].Value = value;
                        }
                        if (valueList.Count >= 2)
                        {
                            var nearlyMonth = double.Parse(valueList[0]);
                            var old1Month = double.Parse(valueList[1]);
                            if(nearlyMonth > old1Month)
                            {
                                dgvVolatilityPrice.Rows[index].DefaultCellStyle.BackColor = Color.Orange;
                            }
                            else if(nearlyMonth < old1Month)
                            {
                                dgvVolatilityPrice.Rows[index].DefaultCellStyle.BackColor = Color.Lime;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }
        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                cbSupplier.Visible = true;
                txtTitleSupplier.Visible = true;
            }
            else
            {
                cbSupplier.Visible = false;
                txtTitleSupplier.Visible = false;
            }
        }

        private void cbSelectDate_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbDateChange == false) return;
            DateTime dateSelect = new DateTime(Int32.Parse(cbYear.Text), Int32.Parse(cbMonth.Text), 1);
            DateTime monthNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (dateSelect < monthNow) btnSave.Visible = false;
            else btnSave.Visible = true;                    
        }
        DataGridView dgv = new DataGridView();
        private void xuấtExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv == dgvSelectSupplier)
                {
                    if (dgvSelectSupplier.RowCount > 0)
                    {
                        Common.ExportExcel(dgv);
                    }
                }
                else if (dgv == dgvVolatilityPrice)
                {
                    if (dgvVolatilityPrice.RowCount > 0)
                    {
                        Common.ExportExcel(dgv);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void contextMenuStripExportExcel_Opened(object sender, EventArgs e)
        {
            DataGridView dataGridView = (sender as ContextMenuStrip).SourceControl as DataGridView;
            dgv = dataGridView;
            if(dgv == dgvVolatilityPrice)
            {
                contextMenuStripExportExcel.Items[2].Visible = false;
            }
            else
            {
                contextMenuStripExportExcel.Items[2].Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                int i = 1;
                var Iteml = ctx.Tbl_Ingredient.ToList();
                foreach (var item in Iteml)
                {
                    item.IndexNumber = i;
                    i++;
                    ctx.SaveChanges();
                }
                MessageBox.Show("ok");
            }
        }

        private void FormSelectSupplier_Load(object sender, EventArgs e)
        {
            //phân quyền
            List<Form> FormList = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                string formName = form.Name;
                if (formName == "FormLogin")
                {
                    FormList.Add(form);
                }
            }
            var LastForm = (FormLogin)FormList.Last();
            if (LastForm.accountTypeName == "MEMBER")
            {
                DisableAllButtons();
                txtSearchContent.Enabled = false;              
            }
            else if (LastForm.accountTypeName == "ReadOnly")
            {
                Common.DisableAllButtons(this);
            }
        }
        private void DisableAllButtons()
        {
            var buttons = GetAllButtons(this);
            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }
        }
        private static IEnumerable<Button> GetAllButtons(Control control)
        {
            var buttons = control.Controls.OfType<Button>();
            foreach (Control childControl in control.Controls)
            {
                buttons = buttons.Concat(GetAllButtons(childControl));
            }
            return buttons;
        }

        private void picNote_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Những nguyên liệu được chọn từ nhà cung cấp không phải là giá rẻ nhất!");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Những nguyên liệu được chọn từ nhà cung cấp có giá bằng nhau!");
        }

        private void picSearchType_Click(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == -1) return;
            else if(cbSearch.SelectedIndex == 0)
            {
                MessageBox.Show("Xem biến động giá của nhà cung cấp được chọn trong số lượng tháng nhất định!");
            }
            else if (cbSearch.SelectedIndex == 1)
            {
                MessageBox.Show("Xem biến động giá nguyên liệu đã được chọn để đặt mua qua các tháng!");
            }
        }

        private void dgvVolatilityPrice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var approvalDateNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            // Check if the clicked cell's BackColor is Orange
            if(cbSearch.SelectedIndex == 0)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewRow clickedCell = dataGridView.Rows[e.RowIndex];
                    var code = clickedCell.Cells[0].Value.ToString();
                    if (clickedCell.DefaultCellStyle.BackColor == System.Drawing.Color.Orange || clickedCell.DefaultCellStyle.BackColor == System.Drawing.Color.Lime)
                    {
                        var comment = FindCommentVolatilityChangeBySupplier(approvalDateNow, code, supplierCodeVolatility);
                        if (string.IsNullOrEmpty(comment))
                        {
                            lbComment.Text = "Lý do thay đổi giá: Không có nguyên nhân!";
                        }
                        else
                        {
                            lbComment.Text = "Lý do thay đổi giá: " + comment;
                        }
                    }
                    else
                    {
                        lbComment.Text = "";
                    }
                }
            }
            else
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewRow clickedCell = dataGridView.Rows[e.RowIndex];
                    var code = clickedCell.Cells[0].Value.ToString();
                    if (clickedCell.DefaultCellStyle.BackColor == System.Drawing.Color.Orange || clickedCell.DefaultCellStyle.BackColor == System.Drawing.Color.Lime)
                    {
                        var comment = FindCommentVolatilityChangeBySelectPrice(approvalDateNow, code);
                        if (string.IsNullOrEmpty(comment))
                        {
                            lbComment.Text = "Lý do thay đổi giá: Không có nguyên nhân!";
                        }
                        else
                        {
                            lbComment.Text = "Lý do thay đổi giá: " + comment;
                        }
                    }
                    else
                    {
                        lbComment.Text = "";
                    }
                }
            }
        }

        private string FindCommentVolatilityChangeBySelectPrice(DateTime approvalDateNow, string code)
        {
            using(var ctx = new DBContext())
            {
                return ctx.Tbl_HistoryPrice.Where(w => w.ApprovalDate == approvalDateNow && w.IngredientCode == code && w.PriceMain == 1).Select(s => s.Comment).FirstOrDefault();
            }
        }

        private string FindCommentVolatilityChangeBySupplier(DateTime approvalDateNow, string code, string supplierCode)
        {
            using(var ctx = new DBContext())
            {
                return  ctx.Tbl_HistoryPrice.Where(w => w.ApprovalDate == approvalDateNow && w.IngredientCode == code && w.SupplierCode == supplierCode).Select(s => s.Comment).FirstOrDefault();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Những mặt hàng có biến động giá tăng so với tháng trước");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Những mặt hàng có biến động giá giảm so với tháng trước");
        }

        private void FindMinPrice()
        {
            using (var ctx = new DBContext())
            {
                Common.StartFormLoading();
                var listSupplier = ctx.Tbl_Supplier.ToList();
                for (int indexRow = 0; indexRow < dgvSelectSupplier.RowCount; indexRow++)
                {
                    var inputDate = (DateTime)this.Tag;
                    var code = dgvSelectSupplier.Rows[indexRow].Cells[0].Value.ToString();
                    DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dgvSelectSupplier.Rows[indexRow].Cells[listSupplier.Count() + 4];
                    string supplierNameMinPrice = findSupplierMinPrice(code, listSupplier, inputDate);
                    if (supplierNameMinPrice == null) continue;
                    cbCell.Value = supplierNameMinPrice;
                }
                Common.CloseFormLoading();
            }
        }

        private void btnSortPrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSelectSupplier.Rows.Count < 1) return;
                // Get the rows with an orange background color
                var yellowRows = dgvSelectSupplier.Rows.Cast<DataGridViewRow>()
                    .Where(row => row.DefaultCellStyle.BackColor == Color.Yellow).ToList();

                // Get the rows with an orange background color
                var blueRows = dgvSelectSupplier.Rows.Cast<DataGridViewRow>()
                    .Where(row => row.DefaultCellStyle.BackColor == Color.DeepSkyBlue).ToList();

                var greenRows = dgvSelectSupplier.Rows.Cast<DataGridViewRow>()
                    .Where(row => row.DefaultCellStyle.BackColor == Color.Lime).ToList();

                greenRows.AddRange(yellowRows);
                greenRows.AddRange(blueRows);
                // Sort the DataGridView by moving orange rows to the top
                for (int row = greenRows.Count - 1; row >= 0; row--)
                {
                    dgvSelectSupplier.Rows.Remove(greenRows[row]);
                    dgvSelectSupplier.Rows.Insert(0, greenRows[row]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);
            }
        }

        private void btnSelectPriority_Click(object sender, EventArgs e)
        {
            FormSupplierPriority f = new FormSupplierPriority();
            f.ShowDialog();
        }

        bool checkClick = true;
        private void sắpXếpToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if(dgv!= null)
            {
                if (checkClick)
                {
                    SortByColor(dgv);                    
                }
                else
                {
                    SortByCode(dgv);
                }
                checkClick = !checkClick;
            }            
        }

        private void SortByCode(DataGridView dgv)
        {
            if (dgv.RowCount > 0)
            {
                var rowList = dgv.Rows.Cast<DataGridViewRow>().ToList().OrderBy(o => Convert.ToInt16(o.Cells[0].Value.ToString().Remove(0, 2).Trim()));
                dgv.Rows.Clear();
                dgv.Rows.InsertRange(0, rowList.ToArray());
            }
        }

        private void SortByColor(DataGridView dgv)
        {
            try
            {
                if (dgv == dgvSelectSupplier)
                {
                    if (dgvSelectSupplier.Rows.Count < 1) return;
                    // Get the rows with an orange background color
                    var yellowRows = dgv.Rows.Cast<DataGridViewRow>()
                        .Where(row => row.DefaultCellStyle.BackColor == Color.Yellow).ToList();

                    // Get the rows with an orange background color
                    var blueRows = dgv.Rows.Cast<DataGridViewRow>()
                        .Where(row => row.DefaultCellStyle.BackColor == Color.DeepSkyBlue).ToList();

                    var greenRows = dgv.Rows.Cast<DataGridViewRow>()
                        .Where(row => row.DefaultCellStyle.BackColor == Color.Lime).ToList();

                    greenRows.AddRange(yellowRows);
                    greenRows.AddRange(blueRows);
                    // Sort the DataGridView by moving orange rows to the top
                    for (int row = greenRows.Count - 1; row >= 0; row--)
                    {
                        dgv.Rows.Remove(greenRows[row]);
                        dgv.Rows.Insert(0, greenRows[row]);
                    }
                }

                else if (dgv == dgvVolatilityPrice)
                {
                    if (dgvVolatilityPrice.Rows.Count < 1) return;
                    // Get the rows with an orange background color
                    var orangeRows = dgvVolatilityPrice.Rows.Cast<DataGridViewRow>()
                        .Where(row => row.DefaultCellStyle.BackColor == Color.Orange).ToList();

                    // Get the rows with an orange background color
                    var limeRows = dgvVolatilityPrice.Rows.Cast<DataGridViewRow>()
                        .Where(row => row.DefaultCellStyle.BackColor == Color.Lime).ToList();
                    limeRows.AddRange(orangeRows);
                    // Sort the DataGridView by moving orange rows to the top
                    for (int row = limeRows.Count - 1; row >= 0; row--)
                    {
                        dgvVolatilityPrice.Rows.Remove(limeRows[row]);
                        dgvVolatilityPrice.Rows.Insert(0, limeRows[row]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                FindInfomationPrice();
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            var value = scrollbarVolatility.Value;
            panelVolatility.Left = -value;
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            var value = scrollbarSeach.Value;
            panelSearch.Left = -value;
        }

        private void chọnGiáRẻNhấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv == dgvSelectSupplier)
            {
                if (dgvSelectSupplier.Rows.Count < 1) return;
                FindMinPrice();
            }

            else if (dgv == dgvVolatilityPrice)
            {
                return;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nguyên liệu, thực phẩm được chọn đặt hàng xen kẽ theo ngày, theo nhà cung cấp");
        }
    }
}

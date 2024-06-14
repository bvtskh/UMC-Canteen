using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using NPOI.OpenXmlFormats.Spreadsheet;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.EnumSupplier;

namespace CanTeenManagement
{
    public partial class FormSelectSupplierClon : Form
    {
        SupplierHelper _supplierHelper = new SupplierHelper();
        public FormSelectSupplierClon()
        {
            InitializeComponent();
        }

        private void btnSearchIngredient_Click(object sender, EventArgs e)
        {
            var year = Int16.Parse(txtYear.Text);
            var month = Int16.Parse(txtMonth.Text);
            var listSupplier = _supplierHelper.GetAllSupplier().ToList();
            var data = _supplierHelper.GetCurrentApproveData(year, month);
            if (data.Count <= 0 || data == null)
            {
                UIMessageTip.ShowWarning($"Chưa có thông tin báo giá của tháng: {month}, năm: {year}");
                return;
            }
            dgvSupplierPrice.Rows.Clear();
            //Tạo cột cho bảng
            CreateColumnForDgv(listSupplier);
            //Cập nhật ưu tiển mua theo ngày
            _supplierHelper.UpdatePriorityIngredientByDay(DateTime.Now,UpdateType.Read,year, month);
            //Load dữ liệu ra bảng
            LoadDataToDgv(listSupplier);
        }

        private void LoadDataToDgv(List<Tbl_Supplier> listSupplier)
        {
            var year = Int16.Parse(txtYear.Text);
            var month = Int16.Parse(txtMonth.Text);
  
            string searchStr = txtSearchContent.Text; 
            var ingredientCurrentSelect = _supplierHelper.GetAllIngredientCurrentSelect(year, month).Select(s=>s.IngredientCode).ToList();
            var searchData = _supplierHelper.GetSearchData(ingredientCurrentSelect, searchStr).OrderBy(o=>o.IngredientCode).ToList();
            ViewInfoIngredient(searchData, year, month, listSupplier);
        }

        private void ViewInfoIngredient(List<Tbl_Ingredient> searchData, short year, short month, List<Tbl_Supplier> listSupplier)
        {
            var listPriority = _supplierHelper.GetPriorityIngredientList(); // danh sách ưu tiên mua mặc định theo ngày
            foreach (var item in searchData)
            {
                var indexRow = dgvSupplierPrice.Rows.Add();
                DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dgvSupplierPrice.Rows[indexRow].Cells[listSupplier.Count() + 4];
                List<string> supplierNameList = new List<string>();

                dgvSupplierPrice.Rows[indexRow].Cells[0].Value = item.IngredientCode;
                dgvSupplierPrice.Rows[indexRow].Cells[1].Value = item.IngredientName;
                dgvSupplierPrice.Rows[indexRow].Cells[2].Value = item.Unit;
                dgvSupplierPrice.Rows[indexRow].Cells[3].Value = item.Spec;
                // hiển thị giá tiền của các nhà cung cấp.
                foreach (var supplier in listSupplier) 
                {
                    var cell = dgvSupplierPrice.Rows[indexRow].Cells[supplier.SupplierCode];
                    var price = _supplierHelper.GetPrice(item.IngredientCode, supplier, year, month);
                    cell.Value = Common.ConvertText(price);
                    if (price != null)
                    {
                        supplierNameList.Add(supplier.SupplierName);
                    }
                }
                cbCell.DataSource = supplierNameList;
                // Hiển thị ra nhà đang được chọn
                cbCell.Value = _supplierHelper.GetSelectedSupplier(item.IngredientCode, year, month);
                if (listPriority.Contains(item.IngredientCode))
                {
                    cbCell.ReadOnly = true;
                }
   

                // Tô màu cảnh báo
                // nếu nhà cung cấp đang chọn ko phải rẻ nhất hoặc giá bằng nhau.

                var supplierNameSelected = cbCell.Value.ToString();
                string supplierIdSelectedCode = _supplierHelper.GetSupplierCodeByName(supplierNameSelected);
                if (item.IngredientCode == "CT00183")
                {
                    Console.WriteLine("");
                }
                if (!listPriority.Contains(item.IngredientCode) && !_supplierHelper.IsMinPrice(item.IngredientCode, supplierIdSelectedCode, year, month))
                {
                    dgvSupplierPrice.Rows[indexRow].DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (listPriority.Contains(item.IngredientCode))
                {
                    dgvSupplierPrice.Rows[indexRow].DefaultCellStyle.BackColor = Color.Lime;
                }
                if(item.IngredientName == "Cơm Hộp")
                {
                    dgvSupplierPrice.Rows[indexRow].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                }
            }
        }

        private void CreateColumnForDgv(List<Tbl_Supplier> listSupplier)
        {
            dgvSupplierPrice.ColumnCount = 4 + listSupplier.Count();
            InsertColumn(0, "Code", "IngredientCode", "IngredientCode", false, dgvSupplierPrice, DataGridViewAutoSizeColumnMode.DisplayedCells);
            InsertColumn(1, "Tên nguyên liệu", "IngredientName", "IngredientName", false, dgvSupplierPrice, DataGridViewAutoSizeColumnMode.NotSet);
            InsertColumn(2, "Đơn vị", "Unit", "Unit", false, dgvSupplierPrice, DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader);
            InsertColumn(3, "Thông số", "Spec", "Spec", false, dgvSupplierPrice, DataGridViewAutoSizeColumnMode.NotSet);
            for (int i = 0; i < listSupplier.Count(); i++)
            {
                InsertColumn(i + 4, listSupplier[i].SupplierName, listSupplier[i].SupplierCode, listSupplier[i].SupplierCode, false, dgvSupplierPrice, DataGridViewAutoSizeColumnMode.NotSet);
                dgvSupplierPrice.Columns[i + 4].Width = 100;
                dgvSupplierPrice.Columns[i + 4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgvSupplierPrice.Columns[1].Width = 200;
            DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();
            dgvCmb.HeaderText = "CHỌN NCC";
            dgvCmb.Width = 150;
            dgvCmb.FlatStyle = FlatStyle.Flat;
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            dataGridViewCellStyle.BackColor = Color.AliceBlue;
            dgvCmb.DefaultCellStyle = dataGridViewCellStyle;
            dgvCmb.DisplayMember = "SupplierName";
            dgvSupplierPrice.Columns.Add(dgvCmb);
        }
        private void InsertColumn(int index, string headerText, string name, string dataPropertyName, bool frozen, DataGridView dgv, DataGridViewAutoSizeColumnMode sizeColumn)
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
            new FormUpdatePrice().ShowDialog();
        }

        private void FormSelectSupplierClon_Load(object sender, EventArgs e)
        {
            //using(var db = new DBContext())
            //{
            //    var date = new DateTime(2024, 6, 1);
            //    var data = db.Tbl_HistoryPriceClon.Where(w=>w.ApproveDate < date).ToList();
            //    foreach(var item in data)
            //    {
            //        var temp = db.Tbl_PriceUpdateChange.Where(w=>w.IngredientCode ==  item.IngredientCode && w.ApproveTime.Value.Year == item.mYear &&w.ApproveTime.Value.Month == item.mMonth).ToList();
            //        foreach(var i in temp)
            //        {
            //            i.IsApproved = false;
            //        }
            //        var t = temp.Where(w => w.SupplierCode == item.SupplierCode).FirstOrDefault();
            //        t.IsApproved = true;
            //        db.SaveChanges();
            //    }
            //}
           
            txtYear.Text = DateTime.Now.Year.ToString();
            txtMonth.Text = DateTime.Now.Month.ToString();
            DesignPanel(Int16.Parse(txtYear.Text), Int16.Parse(txtMonth.Text));
        }

        private void DesignPanel(int year, int month)
        {
            this.panelApprove.Controls.Clear();
            var supplierList = _supplierHelper.GetAllSupplier();
            int orignY = 70;
            int originlabelX = 5;
            int origincomboboxX = 105;
            int originbuttonDetailX = 245;
            foreach (var supplier in supplierList)
            {             
                Label lblSupplierName = CreateLabel(supplier, orignY, originlabelX);
                ComboBox cbbApproveDate = CreateCombobox(supplier, orignY, origincomboboxX);
                Button btnDetail = CreateButtonDetail(supplier, orignY, originbuttonDetailX);
                Label lblTitle = CreateLabelTitle();
                orignY += 40;      
                this.panelApprove.Controls.Add(lblSupplierName);
                this.panelApprove.Controls.Add(cbbApproveDate);
                this.panelApprove.Controls.Add(btnDetail);
                this.panelApprove.Controls.Add(lblTitle);
            }

            var comboboxApproveList = this.panelApprove.Controls.OfType<ComboBox>().ToList();
            foreach(var combo in comboboxApproveList)
            {
                var supplierCode = combo.Name.Replace("comboBox", string.Empty);
                var approDateHistory = _supplierHelper.GetApproveDateBySupplier(supplierCode, year , month);
                combo.Items.AddRange(approDateHistory);
            }
        }

        private Label CreateLabelTitle()
        {
            Label labelTitle = new Label();
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelTitle.ForeColor = System.Drawing.Color.Blue;
            labelTitle.Location = new System.Drawing.Point(8, 23);
            labelTitle.Name = "label1";
            labelTitle.Size = new System.Drawing.Size(302, 18);
            labelTitle.TabIndex = 34;
            labelTitle.Text = "Báo giá đang được áp dụng trong tháng";
            return labelTitle;
        }

        private Button CreateButtonDetail(Tbl_Supplier supplier, int orignY, int originbuttonDetailX)
        {
            Button button = new Button();
            button.BackColor = System.Drawing.Color.LimeGreen;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.ForeColor = System.Drawing.Color.White;
            button.Location = new System.Drawing.Point(originbuttonDetailX, orignY);
            button.Name = "buttonDetail"+supplier.SupplierCode;
            button.Size = new System.Drawing.Size(69, 24);
            button.TabIndex = 27;
            button.Text = "Chi tiết";
            button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button.UseVisualStyleBackColor = false;
            button.Click += new System.EventHandler(this.Button_Click);
            return button;
        }  

        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            DateTime dateTime;
            if(button != null)
            {
                string supplierCode = button.Name.Replace("buttonDetail", string.Empty);
                var combobox = GetComboboxOfSupplier(supplierCode);
                if (combobox != null)
                {
                    var date = combobox.Text;
                    if (!DateTime.TryParseExact(date, "dd-MM-yyyy", null, DateTimeStyles.None, out dateTime))
                    {
                        MessageBox.Show("Sai thời gian!");
                        return;
                    }                   
                    if (IsDetailButton(button))
                    {
                        new FormUpdatePrice(1, supplierCode, dateTime).ShowDialog();
                    } 
                }
            }
        }

        private ComboBox GetComboboxOfSupplier(string supplierCode)
        {
            return this.panelApprove.Controls.OfType<ComboBox>().Where(w=>w.Name.Contains(supplierCode)).FirstOrDefault();
        }

        private bool IsDetailButton(Button button)
        {
            return button.Name.Contains("buttonDetail");
        }

        private bool IsApproveButton(Button button)
        {
            return button.Name.Contains("buttonApprove");
        }

        private ComboBox CreateCombobox(Tbl_Supplier supplier, int orignY, int origincomboboxX)
        {
            ComboBox cbbApproveDate = new ComboBox();
            cbbApproveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cbbApproveDate.FormattingEnabled = true;
            cbbApproveDate.Location = new System.Drawing.Point(origincomboboxX, orignY);
            cbbApproveDate.Name = "comboBox"+supplier.SupplierCode;
            cbbApproveDate.Size = new System.Drawing.Size(134, 24);
           
            return cbbApproveDate;
        }

        private Label CreateLabel(Tbl_Supplier supplier, int orignY, int originlabelX)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.Black;
            label.Location = new System.Drawing.Point(originlabelX, orignY);
            label.Name = "label"+ supplier.SupplierCode;
            label.Text = supplier.SupplierName;
            return label;
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            var year = string.IsNullOrEmpty(txtYear.Text) ? 0 : Int16.Parse(txtYear.Text);
            var month = string.IsNullOrEmpty(txtMonth.Text) ? 0 : Int16.Parse(txtMonth.Text);
            DesignPanel(year, month);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvSupplierPrice.RowCount < 1)
            {
                MessageBox.Show("Không có gì để lưu!");
                return;
            }
            try
            {
                var year = string.IsNullOrEmpty(txtYear.Text) ? 0 : Int16.Parse(txtYear.Text);
                var month = string.IsNullOrEmpty(txtMonth.Text) ? 0 : Int16.Parse(txtMonth.Text);
                if(DateTime.Now.Year != year && DateTime.Now.Month != month)
                {
                    MessageBox.Show("Không được thay đổi giá quá khứ!");
                    return;
                }
                _supplierHelper.SaveChangePrice(year, month, dgvSupplierPrice);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            new FormPriority().ShowDialog();
        }
    }
}

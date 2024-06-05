using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using CanTeenManagement.OverTime;
using CanTeenManagement.Utils;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Asn1.Crmf;
using Spire.Xls;
using Spire.Xls.Core;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.EnumSupplier;
using static CanTeenManagement.Bussiness.ENUM.OrderEnum;

namespace CanTeenManagement
{
    public partial class FormOrder : Form
    {
        OrderHelper _orderHelper = new OrderHelper(); // truy cập database

        Tbl_Menu dataDishMainToday;
        Tbl_Menu dataDishSideToday;

        List<IngredientInfo> totalListResultOrder;
        List<Tbl_PreOrder> listItemPreOrder;

        List<string> ingredientListNameOfMenu;
        private List<string> filteredItems;
        private DateTime selectDate;
        private DateTime firstDayOfMonth;
        public FormOrder()
        {
            InitializeComponent();
            SetUpDateTimePicker();
            cbTenThucPham.DropDownHeight = cbTenThucPham.Height * 8;
            panelSystem.Visible = true;
            btnShowSystem.BackgroundImage = Properties.Resources.Arrow;
            dgrListIngredient.AutoGenerateColumns = false;
            cbIngredientList.DropDownHeight = cbIngredientList.ItemHeight * 8;

            dgrListDish.ColumnHeadersDefaultCellStyle.Font = new Font("Arial",10,FontStyle.Bold);
        }
        private void SetUpDateTimePicker()
        {
            DateTime today = DateTime.Today;
            DateTime after2Day = today.AddDays(2);
            DateTime after3Day = today.AddDays(3);
            dateTimePickerOrder.Format = DateTimePickerFormat.Custom;
            dateTimePickerOrder.CustomFormat = "dd-MM-yyyy";
            dateTimePickerOrder.Text = after2Day.Date.ToString();
            lbDatePreOrder.Text = after3Day.Date.ToString("dd-MM-yyyy");

            dateTimePickerHistoryNumberFoodPortion.Format = DateTimePickerFormat.Custom;
            dateTimePickerHistoryNumberFoodPortion.CustomFormat = "dd-MM-yyyy";
            selectDate = dateTimePickerOrder.Value.Date;
            firstDayOfMonth = new DateTime(selectDate.Year, selectDate.Month, 1);
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            LimitedAccess();
            SetFontDefault();
        }
        private void SetFontDefault()
        {
            dgrListDish.AllowUserToAddRows = false;
            dgrListIngredient.AllowUserToAddRows = false;
        }
        private void LimitedAccess()
        {
            if (_orderHelper.GetUserName() == "ReadOnly") Common.DisableAllButtons(this);
        }

        //private void FindIngredientCodeNearlyUsed(DateTime selectDate)
        //{
        //    List<string> samePriceCodeList = new List<string>();
        //    DateTime firstDayOfMonth = new DateTime(selectDate.Year, selectDate.Month, 1);
        //    using (var ctx = new DBContext())
        //    {
        //        var equalPriceList = ctx.Tbl_HistoryPrice.Where(w => w.ApprovalDate == firstDayOfMonth).ToList();

        //        foreach (var price in equalPriceList)
        //        {
        //            if (equalPriceList.Count(s => s.IngredientCode == price.IngredientCode && s.Price == price.Price) > 1)
        //            {
        //                if (!samePriceCodeList.Contains(price.IngredientCode))
        //                    samePriceCodeList.Add(price.IngredientCode);
        //            }
        //        }
        //        // tìm mã đã được mua gần nhất.
        //        var orderNearlyDate = ctx.Tbl_orderHelper.Select(w => w.Date).Max();
        //        var listCodeOrderNearly = ctx.Tbl_orderHelper.Where(w => w.Date == orderNearlyDate).ToList();
        //        // đổi nhà cung cấp cho những mặt hàng vừa tìm được.
        //        foreach(var item in listCodeOrderNearly)
        //        {
        //            if (samePriceCodeList.Contains(item.IngredientCode))
        //            {
        //                var supplierId = item.SupplierId;
        //                var historyExist = ctx.Tbl_HistoryPrice.Where(w => w.ApprovalDate == firstDayOfMonth && w.IngredientCode == item.IngredientCode).ToList();
        //                foreach(var data in historyExist)
        //                {
        //                    if(data.SupplierId == supplierId)
        //                    {
        //                        // priceMain trở về 0
        //                        data.PriceMain = 0;
        //                    }
        //                    else
        //                    {
        //                        // mặt hàng của nhà này sẽ có pricemain là 1
        //                        data.PriceMain = 1;
        //                    }
        //                }
        //                ctx.SaveChanges();
        //            }
        //        }
        //    }
        //}

        private void MessageNotFound(IngredientInfo info)
        {
            MessageBox.Show($"Nguyên liệu: {info.IngredientName} của món: { _orderHelper.GetDishContainIngredient(info.IngredientCode, selectDate)} chưa có báo giá từ nhà cung cấp hoặc chưa được chọn nhà cung cấp trong tháng này, không thể tạo hóa đơn!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show($"Bạn hãy cập nhật báo giá, chọn nhà cung cấp cho: {info.IngredientName}\nHoặc đổi món khác!", "Gợi ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindMenuOrder()
        {
            try
            {
                btnBuyList.Show();
                Common.StartFormLoading();
                dataDishMainToday = _orderHelper.GetDataMenu(selectDate, MenuType.Main);
                dataDishSideToday = _orderHelper.GetDataMenu(selectDate, MenuType.Side);

                if (_orderHelper.IsNullDataMenu(dataDishMainToday, dataDishSideToday, dgrListDish))
                {
                    return;
                }

                if (_orderHelper.Mung1AmLichKoAnVit(dataDishMainToday, dataDishSideToday, selectDate))
                {
                    Common.CloseFormLoading();
                    MessageBox.Show($"Thực đơn ngày: {selectDate.ToString("dd-MM-yyyy")} Là mùng 1 Âm lịch, có món liên quan đến Vịt, Hãy đổi món khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnBuyList.Enabled = false;
                    return;
                }

                btnBuyList.Enabled = true;
                // load main menu
                _orderHelper.LoadDataMenuToDatagridview(dataDishMainToday, dataDishSideToday, dgrListDish);
                btnOrder.Enabled = true;
                _orderHelper.ShowDataAlwayBuy(dgvAlwayBuy);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }

        private void btnUuTien_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNumberPreOrder.Text))
                {
                    MessageBox.Show("Số lượng không đúng!");
                    return;
                }
                _orderHelper.CreatePreOrderItem(cbIngredientList.Text, txtNumberPreOrder.Text, selectDate, dgvPreListOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }

        }

        private void dgrListIngredient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgrListIngredient.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int value = Convert.ToInt32(dgrListIngredient.Rows[e.RowIndex].Cells[4].Value);

                if (value > 0)
                {
                    var ingredientCode = dgrListIngredient.Rows[e.RowIndex].Cells[0].Value.ToString(); // mã nguyên liệu

                    List<Tbl_PreOrder> listPreOrder = _orderHelper.GetIngredientPreOrderByIngredientCode(ingredientCode); // danh sách đã đạt trước đó trùng với mã của nguyên liệu cần đặt
                    // kiểm tra xem danh sách này, hóa đơn đã được thanh toán hay vẫn đang đợi hàng về
                    // nếu hóa đơn đã thanh toán thì loại nó ra
                    // lấy ra danh sách lịch sử đặt hàng đã được thanh toán
                    List<Tbl_OrderHistory> listOrderHistory = _orderHelper.GetOrderHistoryList();
                    ViewDetailPreOrder(_orderHelper.FilterDataPreOrders(listPreOrder, selectDate));
                }
            }
        }
        private void ViewDetailPreOrder(List<Tbl_PreOrder> preOrderList)
        {
            if (preOrderList.Count > 0)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                foreach (var item in preOrderList)
                {
                    var itemExist = _orderHelper.GetIngredientByCode(item.IngredientCode);
                    ToolStripLabel newpreOrder = new ToolStripLabel($"Số lượng : {item.PreOrder} {itemExist.Unit}\nNgày đặt: {item.DateOrder.Value.Date.ToString("dd-MM-yyyy")}\nĐặt trước cho ngày: {item.PreDateOrder.Value.Date.ToString("dd-MM-yyyy")}");
                    newpreOrder.Font = new Font(newpreOrder.Font.FontFamily, newpreOrder.Font.Size + 5, FontStyle.Bold);
                    string contentOrder = newpreOrder.Text;

                    // Add menu options to the context menu
                    menu.Items.Add(contentOrder);
                    //menu.Show(dgrListIngredient, new Point(dgrListIngredient.Width - (dgrListIngredient.Width / 100 * 40), dgrListIngredient.Height - (dgrListIngredient.Height / 100 * 65)));
                    menu.Show(dgrListIngredient, new Point(dgrListIngredient.Width, 0));

                }
            }
        }
        private List<string> special = new List<string>() { "Bún", "Đậu phụ", "Cá " };
        private void dgrListIngredient_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string rowBuy2Times = dgrListIngredient.Rows[e.RowIndex].Cells[1].Value.ToString();
            double rowExistValuePreOrder = Convert.ToDouble(dgrListIngredient.Rows[e.RowIndex].Cells[4].Value);

            foreach (var item in special) // Hàng nguyên liệu chia ra mua 2 lần.
            {
                if (rowBuy2Times.Contains(item))
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
            if (rowExistValuePreOrder > 0) // Hàng có nguyên liệu đặt trước.
            {
                e.CellStyle.BackColor = Color.LightGreen;
            }
        }

        private void txtTenThucPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtTenThucPham.Text))
                {
                    Common.StartFormLoading();

                    string searchText = txtTenThucPham.Text;

                    // Retrieve elements from the database based on the search text
                    List<Tbl_Ingredient> ingredientsList = _orderHelper.GetIngredientListBySearchString(searchText);
                    Thread.Sleep(200);
                    Common.CloseFormLoading();
                    cbTenThucPham.DroppedDown = false;
                    // Clear the ComboBox items
                    cbTenThucPham.Items.Clear();
                    // Add the retrieved elements to the ComboBox
                    cbTenThucPham.Items.AddRange(ingredientsList.ToArray());
                    cbTenThucPham.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                    cbTenThucPham.DisplayMember = "IngredientName";
                }
            }
        }

        private void cbTenThucPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tbl_Ingredient ingred = (Tbl_Ingredient)cbTenThucPham.SelectedItem;
            if (ingred != null)
            {
                txtTenThucPham.Text = ingred.IngredientName.ToString();
                lbunit.Text = ingred.Unit;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var ingredientName = txtTenThucPham.Text;
                double quanlity = txtAlwayBuy.Text == "" ? 0 : double.Parse(txtAlwayBuy.Text);
                if (_orderHelper.IsIngredientNameAvalid(ingredientName, selectDate) != ValidIngredient.OK)
                {
                    if (_orderHelper.IsIngredientNameAvalid(ingredientName, selectDate) == ValidIngredient.InvalidName)
                    {
                        MessageBox.Show("Thực phẩm bạn vừa thêm chưa đúng!");
                    }
                    else if (_orderHelper.IsIngredientNameAvalid(ingredientName, selectDate) == ValidIngredient.NoPrice)
                    {
                        MessageBox.Show("Thực phẩm này chưa được cập nhật giá!");
                        txtTenThucPham.Clear();
                    }
                    return;
                }

                if (string.IsNullOrEmpty(quanlity.ToString()) || quanlity <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ");
                    return;
                }
                _orderHelper.AddtoAlwayBuyDatagridview(ingredientName, quanlity, dgvAlwayBuy, selectDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void picNoteOrderMore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng cho phép chọn và đặt thêm thực phẩm khác khi có nhu cầu!");
        }

        private void picNoteOrderFuture_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Chức năng cho phép đặt hàng trước những mặt hàng cần ưu tiên!\nVí dụ: hôm nay là {dateTimePickerOrder.Value.Date.ToString("dd-MM-yyyy")}\nNgày: {dateTimePickerOrder.Value.Date.AddDays(1).ToString("dd-MM-yyyy")} Cần đặt trước 'Thịt' thì dùng chức năng này.\nĐến {dateTimePickerOrder.Value.Date.AddDays(1).ToString("dd-MM-yyyy")} sẽ tính toán để trừ đi.");
        }

        private void ShowDataPreOrderToComboBox()
        {
            if (cbDishNamePreOrder.Items.Count > 0)
            {
                cbDishNamePreOrder.Items.Clear();
            }
            try
            {
                var timeUutien = selectDate.AddDays(1);
                var timeOrder = selectDate;
                List<Tbl_Menu> menuList = new List<Tbl_Menu>();
                menuList.Add(_orderHelper.GetDataMenu(timeUutien, MenuType.Main));
                menuList.Add(_orderHelper.GetDataMenu(timeUutien, MenuType.Side));
                _orderHelper.GetDishNamePreOrder(_orderHelper.GetDishCodeListPreOrder(),timeUutien).ForEach(f => cbDishNamePreOrder.Items.Add(_orderHelper.GetDishNameByCode(f)));// danh sách món ăn có nguyên liệu cần đặt trước
                if (cbDishNamePreOrder.Items.Count > 0)
                {
                    lbPreOrderAfter1Day.Text = $"Sau 1 ngày :{timeUutien.ToString("dd-MM-yyyy")}\nMón ăn cần đặt trước:";
                }
                else
                {
                    lbPreOrderAfter1Day.Text = $"Sau 1 ngày :{timeUutien.ToString("dd-MM-yyyy")}\nKhông có món cần đặt trước!";
                }
                var ingredientList = _orderHelper.GetIngredientNameByCode(_orderHelper.GetIngredientCodeListOfMenu(menuList).Distinct().ToList());
                cbIngredientList.DataSource = ingredientList;
                ingredientListNameOfMenu = ingredientList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex);
            }
        }

        private void btnShowSystem_Click(object sender, EventArgs e)
        {
            if (panelSystem.Visible == false)
            {
                btnShowSystem.BackgroundImage = Properties.Resources.Arrow;
                panelSystem.Visible = true;
            }
            else
            {
                btnShowSystem.BackgroundImage = Properties.Resources.Arrow1;
                panelSystem.Visible = false;
            }
        }

        private void dateTimePickerOrder_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                selectDate = dateTimePickerOrder.Value.Date;
                firstDayOfMonth = new DateTime(selectDate.Year, selectDate.Month, 1);
                lbDatePreOrder.Text = dateTimePickerOrder.Value.Date.AddDays(1).ToString("dd-MM-yyyy");
                dgvPreListOrder.Rows.Clear();
                dgrListDish.Rows.Clear();
                dgrListIngredient.DataSource = null;
                dgrListIngredient.Refresh();
                // Get the selected date from the DateTimePicker
                DateTime selectedDate = dateTimePickerOrder.Value;
                // Determine the day of the week
                string dayOfWeek = selectedDate.DayOfWeek.ToString();

                // Display the day of the week in the TextBox

                lbDays.Text = dayOfWeek == "Sunday" ? "Chủ nhật" : dayOfWeek == "Monday" ? "Thứ hai" : dayOfWeek == "Tuesday" ? "Thứ ba" : dayOfWeek == "Wednesday" ? "Thứ tư" :
                 dayOfWeek == "Thursday" ? "Thứ năm" : dayOfWeek == "Friday" ? "Thứ sáu" : dayOfWeek == "Saturday" ? "Thứ bảy" : dayOfWeek;
                FindMenuOrder();
                _orderHelper.ShowSafeStock(dgvSafeStock);
                ShowAlarmSafeStock();
                ShowDataPreOrderToComboBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Đã xảy ra lỗi");
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }

        private void ShowAlarmSafeStock()
        {
            if (dgvSafeStock.RowCount > 0)
            {
                lbSafeStock.Text = "Một số nguyên liệu có tồn kho an toàn sắp hết!";
                pictureBox1.Visible = true;
            }
            else
            {
                lbSafeStock.Text = "";
                pictureBox1.Visible = false;
            }
        }

        private void cbIngredientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIngredientList.SelectedIndex != -1)
            {
                lbPreOrderUnit.Text = _orderHelper.GetIngredientByName(cbIngredientList.Text) == null ? null : _orderHelper.GetIngredientByName(cbIngredientList.Text).Unit;
                txtPreorderSearch.Text = cbIngredientList.SelectedItem as string;
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator)
                {
                    e.Handled = true; // Prevent the character from being entered
                }

                // Allow the backspace key
                if (e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = false;
                }

                // Allow only one decimal separator
                if (e.KeyChar == decimalSeparator && ((TextBox)sender).Text.Contains(decimalSeparator))
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xảy ra lỗi khi nhập số lượng");
            }
        }

        private void tabControlOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlOrder.SelectedIndex == 1)
            {
                ShowDataPreOrderToComboBox();
            }
            if (tabControlOrder.SelectedIndex == 4)
            {
                dateTimePickerHistoryNumberFoodPortion_ValueChanged(null, null);
            }
        }

        private void hủyChọnNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectRow = dgvPreListOrder.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                if (selectRow != null)
                {
                    dgvPreListOrder.Rows.Remove(selectRow);
                    dgvPreListOrder.Refresh();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Có lỗi xảy ra " + ex);
            }

        }

        private void xóaKhỏiDanhSáchThườngXuyênMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectRow = dgvAlwayBuy.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                if (selectRow != null)
                {
                    var ingredientName = selectRow.Cells[0].Value.ToString();
                    var ingredientSpec = selectRow.Cells[3].Value == null ? "" : selectRow.Cells[3].Value.ToString();
                    dgvAlwayBuy.Rows.Remove(selectRow);
                    dgvAlwayBuy.Refresh();
                    _orderHelper.UpdateIngredientAlwayBuy(ingredientName, ingredientSpec, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi khi xóa nguyên liệu thường xuyên mua thêm " + ex);
            }
        }

        private void chỉnhSửaĐịnhLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectRow = dgrListDish.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                if (selectRow != null)
                {
                    var dishName = selectRow.Cells[1].Value.ToString();

                    string dishCode = _orderHelper.GetDishCodeByName(dishName);
                    FormAddDish formAddDish = new FormAddDish(dishCode);
                    formAddDish.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex);
            }
        }

        private void contextMenuStripEditQuantative_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cbDishNamePreOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDetailPreOrderDish.Rows.Clear();

            var dishName = cbDishNamePreOrder.SelectedItem as string;
            var dishCode = _orderHelper.GetDishCodeByName(dishName);
            List<Tbl_Quantitative> quantitativeList = _orderHelper.GetQuantitativeByDishCode(dishCode);
            foreach (var item in quantitativeList)
            {
                dgvDetailPreOrderDish.Rows.Add();
                int index = dgvDetailPreOrderDish.RowCount - 1;
                dgvDetailPreOrderDish.Rows[index].Cells[0].Value = _orderHelper.GetIngredientByCode(item.IngredientCode) == null ? null : _orderHelper.GetIngredientByCode(item.IngredientCode).IngredientName; ;
                dgvDetailPreOrderDish.Rows[index].Cells[1].Value = item.Quantitative;
            }

        }

        private void btnEditPreOrderDish_Click(object sender, EventArgs e)
        {
            if (cbDishNamePreOrder.SelectedIndex != -1)
            {
                var dishName = cbDishNamePreOrder.SelectedItem as string;
                var dishCode = _orderHelper.GetDishCodeByName(dishName);
                FormAddDish fd = new FormAddDish(dishCode);
                fd.Show();
            }
        }

        private void dateTimePickerHistoryNumberFoodPortion_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateSelect = dateTimePickerHistoryNumberFoodPortion.Value.Date;
            List<Tbl_FoodPortion> dataFoodPortion = _orderHelper.GetFoodPortionByDate(dateSelect);
            lbInformationNumberFoodPortion.Text = $"Món chính 1: {dataFoodPortion.Sum(s => s.DishMain1Number)} \nMón chính 2: {dataFoodPortion.Sum(s => s.DishMain2Number)} \nMón cải thiện: {dataFoodPortion.Sum(s => s.Improve1Number)} \nBà bầu: {dataFoodPortion.Sum(s => s.GourdFoodNumber)} \nĂn nhẹ 1: {dataFoodPortion.Sum(s => s.SideMeal1Number)} \nĂn nhẹ 2: {dataFoodPortion.Sum(s => s.SideMeal2Number)} \nĂn nhẹ 3: {dataFoodPortion.Sum(s => s.SideMeal3Number)} \nĂn nhẹ 4: {dataFoodPortion.Sum(s => s.SideMeal4Number)}\nĂn nhẹ 5: {dataFoodPortion.Sum(s => s.SideMeal5Number)}\n";
        }
        private void picNoteAutoChangeSupplier_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này giúp bạn tìm ra những nguyên liệu có cùng giá bán giữa các nhà cung cấp, sau đó lọc ra những mặt hàng đã được đặt mua ở đơn hàng gần nhất và chọn nhà cung cấp khác cho nguyên liệu đó");
        }

        private void dgrListIngredient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Handle Ctrl+V for paste
                // Call a method to paste the clipboard data into the selected cell
                PasteDataIntoSelectedCell();
                e.Handled = true; // Prevent default behavior
            }
        }

        private void PasteDataIntoSelectedCell()
        {
            if (dgrListIngredient.SelectedCells.Count == 1)
            {
                DataGridViewCell cell = dgrListIngredient.SelectedCells[0];
                string clipboardText = Clipboard.GetText();

                // Check if the cell is editable (e.g., not a read-only column)
                cell.Value = clipboardText;
            }
        }

        private void txtPreorderSearch_TextChanged(object sender, EventArgs e)
        {
            //string filterText = txtPreorderSearch.Text.ToLower();
            //filteredItems = ingredientListOfMenu
            //    .Where(item => item.ToLower().Contains(filterText))
            //    .ToList();

            //UpdateComboBoxDataSource(filteredItems);
            //cbIngredientList.DroppedDown = true;
            //cbIngredientList.DropDownHeight = cbIngredientList.ItemHeight * 8;
            //Cursor = Cursors.Default;
        }
        private void UpdateComboBoxDataSource(List<string> dataSource)
        {
            //cbIngredientList.DataSource = null; // Clear the existing data source
            //cbIngredientList.DataSource = dataSource;
        }

        private void txtPreorderSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtPreorderSearch.Text))
                {
                    string searchText = txtPreorderSearch.Text;
                    string filterText = txtPreorderSearch.Text.ToLower();
                    filteredItems = ingredientListNameOfMenu
                        .Where(item => item.ToLower().Contains(filterText))
                        .ToList();

                    cbIngredientList.DroppedDown = false;
                    // Clear the ComboBox items
                    cbIngredientList.DataSource = null;
                    cbIngredientList.Items.Clear();
                    // Add the retrieved elements to the ComboBox
                    cbIngredientList.Items.AddRange(filteredItems.ToArray());
                    cbIngredientList.DroppedDown = true;
                    Cursor.Current = Cursors.Default;

                }
                else
                {
                    cbIngredientList.DroppedDown = false;
                    // Clear the ComboBox items
                    cbIngredientList.DataSource = null;
                    cbIngredientList.Items.Clear();
                    cbIngredientList.Items.AddRange(ingredientListNameOfMenu.ToArray());
                    cbIngredientList.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void txtPreorderSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtPreorderSearch.SelectAll();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsErrorDatagridviewIngredientList(dgrListIngredient) != null) return;
                if (_orderHelper.IsExistOrderForThisDay(selectDate))
                {
                    DialogResult log = MessageBox.Show($"Đã tồn tại đơn hàng của ngày {selectDate.Date.ToString("dd-MM-yyyy")}. Bạn vẫn muốn tiếp tục đặt hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (log == DialogResult.No) return;
                }
                string[] supplierArray = _orderHelper.GetSupplierSelectOrder(dgrListIngredient).ToArray();
                Tbl_FoodPortion tbl_FoodPortion = _orderHelper.CreateNumberFoodPortion(Int16.Parse(mainDishNumber1.Value.ToString()), Int16.Parse(mainDishNumber2.Value.ToString()), Int16.Parse(improveDishNumber.Value.ToString()), Int16.Parse(gourdNumber.Value.ToString()), Int16.Parse(sideDishNumber1.Value.ToString()), Int16.Parse(sideDishNumber2.Value.ToString()), Int16.Parse(sideDishNumber3.Value.ToString()), Int16.Parse(sideDishNumber4.Value.ToString()), Int16.Parse(sideDishNumber5.Value.ToString()));
                if (!_orderHelper.ExportOrderListToExcel(supplierArray, selectDate, dgrListIngredient)) return;
                if (_orderHelper.IsSaveSuccessToDataBase(selectDate, totalListResultOrder, dgrListIngredient, firstDayOfMonth, tbl_FoodPortion, listItemPreOrder) != null) return;

                Common.CloseFormLoading();
                MessageBox.Show("Đã Xuất ra File Excel thành công!", "Thông báo!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }

        private ShowMessage IsErrorDatagridviewIngredientList(DataGridView dataGridView)
        {
            //if (IsSunday(selectDate) || IsSunday(DateTime.Now.Date))
            //{
            //    return new ShowMessage($"Chủ nhật không đặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            if (dataGridView.RowCount <= 0)
            {
                return new ShowMessage("Hãy tạo mới danh sách mua hàng trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (selectDate < DateTime.Now.Date)
            {
                return new ShowMessage("Chỉ có thể đặt hàng cho ngày lớn hơn hôm nay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            var getRowToCheckNumberWillOrder = dgrListIngredient.Rows.Cast<DataGridViewRow>().Where(w => w.Cells[2].Value.ToString() != "0").ToList();
            if (getRowToCheckNumberWillOrder.Count <= 0)
            {
                if (!_orderHelper.IsExistOrderForThisDay(selectDate)) // nếu chưa từng đặt hàng cho ngày được chọn thì phải có số lượng suất ăn.
                {
                    return new ShowMessage("Bạn phải điền số lượng suất ăn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            var getRowToCheckNumberActualOrder = dgrListIngredient.Rows.Cast<DataGridViewRow>().Where(w => Convert.ToDouble(w.Cells["SLQuyetDinhMua"].Value) != 0 && w.Cells["SLQuyetDinhMua"].Value != null).ToList();
            if (getRowToCheckNumberActualOrder.Count <= 0)
            {
                return new ShowMessage("Số lượng đặt hàng là 0 ? Bạn không thể tạo đơn hàng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            //Kiểm tra định dạng nhập vào
            if (!IsInputNumber())
            {
                return new ShowMessage("Định dạng số lượng đặt hàng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // kiem tra hoa don dat hang            
            if (_orderHelper.IsPayedBill(selectDate))
            {
                return new ShowMessage($"Đơn hàng ngày: {selectDate.ToString("dd-MM-yyyy")} đã nhập kho. Không thể tạo thêm hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return null;
        }

        private bool IsInputNumber()
        {
            var allRowOrder = dgrListIngredient.Rows.Cast<DataGridViewRow>().ToList();
            foreach (var row in allRowOrder)
            {
                var planOrder = row.Cells[5].Value == null ? "0" : row.Cells[5].Value.ToString();
                double result;
                if (!double.TryParse(planOrder, out result) || result < 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void btnBuyList_Click(object sender, EventArgs e)
        {
            dgrListIngredient.Columns[5].ReadOnly = false;
            try
            {
                Common.StartFormLoading();
                if (IsCreateIngredientListError() != null)
                {
                    Common.CloseFormLoading();

                    return;
                }
                //Common.UpdateSupplierPriority(selectDate); // đổi nhà cung cấp với thực phẩm ưu tiên
                Common.UpdateEqualPrice(selectDate, UpdateType.Update); // đổi nhà cung cấp theo giá bằng nhau.
                #region Tìm những nguyên liệu giá bằng nhau và đã được đặt hàng ở đơn hàng gần nhất để đổi qua nhà cung cấp chưa được đặt.
                // danh sách mã nguyên liệu
                //FindIngredientCodeNearlyUsed(selectDate);
                #endregion

                int totalEatMain = Convert.ToInt16(mainDishNumber1.Value + mainDishNumber2.Value + improveDishNumber.Value);
                int numberEatMain1 = Convert.ToInt16(mainDishNumber1.Value);
                int numberEatMain2 = Convert.ToInt16(mainDishNumber2.Value);
                int numberImprove = Convert.ToInt16(improveDishNumber.Value);
                int numberGourdFood = Convert.ToInt16(gourdNumber.Value);
                #region nguyên liệu thực đơn chính và nhẹ
                List<IngredientInfo> totalList = GetTotalIngredient(totalEatMain, numberEatMain1, numberEatMain2, numberImprove, numberGourdFood);
                #endregion
                var isnullPrice = _orderHelper.IsNullPriceAndSupplier(totalList);
                if (isnullPrice != null)
                {
                    MessageNotFound(isnullPrice);
                    return;
                }
                // Tim kiem nguyen lieu da uu tien mua truoc cho ngày được chọn tạo hóa đơn.
                var afterFilterPreOrder = _orderHelper.GetIngredientPreOrderListFromDate(selectDate);
                // Lấy danh sách nguyên liệu đặt trước từ datagridview
                List<IngredientInfo> ingredientPreOrderList = _orderHelper.GetIngredPreOrderFromDGV(dgvPreListOrder, selectDate, firstDayOfMonth);
                // danh sách nguyên liệu thường xuyên mua ngoài đơn hàng.
                List<IngredientInfo> ingredientAlwayBuy = _orderHelper.GetIngredientAlwayBuyFromDGV(dgvAlwayBuy, selectDate, firstDayOfMonth);
                // Danh sách nguyên liệu tồn kho an toàn.
                List<IngredientInfo> ingredientSafeStock = _orderHelper.GetSafeStockDataFromDGV(dgvSafeStock, selectDate, firstDayOfMonth);
                if (ingredientPreOrderList != null)
                    totalList.AddRange(ingredientPreOrderList);
                if (ingredientAlwayBuy != null)
                    totalList.AddRange(ingredientAlwayBuy);
                if (ingredientSafeStock != null)
                    totalList.AddRange(ingredientSafeStock);
                List<IngredientInfo> uniqueIngredientList = totalList.GroupBy(obj => obj.IngredientCode)
                    .Select(group =>
                    {
                        var item = group.First();
                        item.SLCM = group.Sum(obj => Math.Round((double)obj.SLCM, 3));
                        item.Bill = group.Sum(obj => obj.Bill);
                        item.DateOrderFor = selectDate.ToString("dd-MM-yyyy");
                        return item;
                    }).ToList();
                //sắp xếp lại danh sách nếu có đặt trước.
                if (afterFilterPreOrder.Count > 0)
                {
                    uniqueIngredientList = _orderHelper.SortUniqueIngredientList(afterFilterPreOrder, uniqueIngredientList);
                }

                //nếu không đặt trước thì cũng phải sắp xếp lại
                foreach (var data in uniqueIngredientList)
                {
                    if (data.PreOrder == null) data.PreOrder = 0;
                    data.SLQuyetDinhMua = Math.Round((double)(data.SLCM - (data.PreOrder + data.Stock)), 3); // sl quyết định mua được tính bằng sl ước tính trừ đi đã đặt trước cộng với tồn kho
                    if (data.SLQuyetDinhMua <= 0)
                    {
                        data.SLQuyetDinhMua = 0;
                    }
                }
                dgrListIngredient.DataSource = uniqueIngredientList.OrderBy(o => o.IngredientCode).ToList();
                listItemPreOrder = _orderHelper.GetIngredPreOrder(ingredientPreOrderList); // lấy ra danh sách đặt trước để lưu vào database.
                totalListResultOrder = uniqueIngredientList; // Danh sách lúc đầu khi tạo đơn hàng => sau này dùng để so sánh với số lượng chênh lệch khi sửa trực tiếp
            }
            catch (FormatException)
            {
                MessageBox.Show("Định dạnh vừa nhập không đúng!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }

        private List<IngredientInfo> GetTotalIngredient(int totalEatMain, int numberEatMain1, int numberEatMain2, int numberImprove, int numberGourdFood)
        {
            List<IngredientInfo> totalList = new List<IngredientInfo>();
            if (dataDishMainToday != null)
            {
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishMainToday.MainDishes1, numberEatMain1, firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishMainToday.MainDishes2, numberEatMain2, firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishMainToday.SideDishes, totalEatMain, numberImprove, firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishMainToday.Vegetables, totalEatMain, numberImprove, firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishMainToday.Soup, totalEatMain, firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishMainToday.Pickles, totalEatMain, firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishMainToday.Dessert1, totalEatMain, firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishMainToday.Dessert2, totalEatMain, firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishMainToday.Improve, numberImprove, firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishMainToday.PregnantFood, numberGourdFood, firstDayOfMonth));
            }

            if (dataDishSideToday != null)
            {
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishSideToday.SideMeal1, Convert.ToInt16(sideDishNumber1.Value), firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishSideToday.SideMeal2, Convert.ToInt16(sideDishNumber2.Value), firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishSideToday.SideMeal3, Convert.ToInt16(sideDishNumber3.Value), firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishSideToday.SideMeal4, Convert.ToInt16(sideDishNumber4.Value), firstDayOfMonth));
                totalList.AddRange(_orderHelper.GetDetailInfoIngredient(dataDishSideToday.SideMeal5, Convert.ToInt16(sideDishNumber5.Value), firstDayOfMonth));
            }
            return totalList;
        }

        private ShowMessage IsCreateIngredientListError()
        {
            if (dgrListDish.RowCount < 1)
            {
                return new ShowMessage("Không có dữ liệu, không thể tạo danh sách mua hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!_orderHelper.IsNotUpdatePriceForDate(firstDayOfMonth))
            {
                return new ShowMessage($"Hiện tại chưa có báo giá của tháng {selectDate.Month}. Không thể tạo hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}



using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.OrderEnum;

namespace CanTeenManagement
{
    public partial class FormOutput : Form
    {
        OutputHelper _outputHelper = new OutputHelper();
        DateTime selectDate;
        public FormOutput()
        {
            InitializeComponent();
            dateTimePickerOrder.Format = DateTimePickerFormat.Custom;
            dateTimePickerOrder.Format = DateTimePickerFormat.Custom;
            dateTimePickerOrder.CustomFormat = "dd-MM-yyyy";
            selectDate = dateTimePickerOrder.Value.Date;
        }
        private void FormOutput_Load(object sender, EventArgs e)
        {
            cbCommonlyUse.DropDownHeight = cbCommonlyUse.ItemHeight * 8;
            ShowCommonlyUsedIngredients();
            LimitedAccess();
        }
        private void LimitedAccess()
        {
            //phân quyền
            var LastForm = Common.LastLoginForm();
            if (LastForm.accountTypeName == "ReadOnly")
            {
                Common.DisableAllButtons(this);
            }
        }
        private void ShowCommonlyUsedIngredients()
        {
            try
            {
                dgvAlwayUse.Rows.Clear();
                var ingredientAlwayOutStockList = _outputHelper.GetCommonlyUseIngredient();
                foreach (var item in ingredientAlwayOutStockList)
                {
                    dgvAlwayUse.Rows.Add();
                    dgvAlwayUse.Rows[dgvAlwayUse.RowCount - 1].Cells[0].Value = item.IngredientCode;
                    dgvAlwayUse.Rows[dgvAlwayUse.RowCount - 1].Cells[1].Value = item.IngredientName;
                    dgvAlwayUse.Rows[dgvAlwayUse.RowCount - 1].Cells[2].Value = item.Unit;
                    dgvAlwayUse.Rows[dgvAlwayUse.RowCount - 1].Cells[3].Value = item.Spec;
                    dgvAlwayUse.Rows[dgvAlwayUse.RowCount - 1].Cells[4].Value = _outputHelper.GetIngredientStock(item.IngredientCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }
       
        private void cbSaveStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Tbl_Ingredient dishselect = (Tbl_Ingredient)cbCommonlyUse.SelectedItem;
                if (dishselect == null) return;
                txtCommonlyUse.Text = dishselect.IngredientName.ToString();
                lbDonvi.Text = dishselect.Unit + $"({dishselect.Spec})";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void txtCommonlyUse_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txtCommonlyUse.Text))
                    {
                        Common.StartFormLoading();
                        using (var dbContext = new DBContext())
                        {
                            string searchText = txtCommonlyUse.Text;

                            // Retrieve elements from the database based on the search text
                            var elements = dbContext.Tbl_Ingredient.Where(w => w.IngredientName.Contains(searchText)).ToList();
                            Thread.Sleep(200);
                            Common.CloseFormLoading();
                            cbCommonlyUse.DroppedDown = false;
                            cbCommonlyUse.Items.Clear();
                            cbCommonlyUse.Items.AddRange(elements.ToArray());
                            cbCommonlyUse.DroppedDown = true;
                            Cursor.Current = Cursors.Default;
                            cbCommonlyUse.DisplayMember = "IngredientName";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }            

        private void dgrOutput_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                // Customize the appearance of the cell in the first column
                e.CellStyle.BackColor = Color.Yellow;
            }
        }

        private void txtCommonlyUse_MouseClick(object sender, MouseEventArgs e)
        {
            txtCommonlyUse.SelectAll();
        }
        private void txtInputSL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputIngredientAlwayUse();
                ShowCommonlyUsedIngredients();
            }
        }

        private void InputIngredientAlwayUse()
        {
            try
            {
                if (dgrOutput.RowCount < 1)
                {
                    MessageBox.Show("Bạn phải chọn hóa đơn xuất hàng trước!");
                    return;
                }
                if (cbCommonlyUse.SelectedIndex == -1)
                {
                    MessageBox.Show("Tên thực phẩm không phù hợp!", "Thông báo");
                    return;
                }
                if (string.IsNullOrEmpty(txtCommonlyUseNumber.Text))
                {
                    MessageBox.Show("Số lượng không được để trống!");
                    return;
                }
                double number;
                if (!double.TryParse(txtCommonlyUseNumber.Text, out number))
                {
                    MessageBox.Show("Số lượng không đúng");
                    return;
                }
                DialogResult dialog = MessageBox.Show("bạn có chắc chắn thêm vào danh sách xuất hàng không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    _outputHelper.AddIngredientToDatagridview(dgrOutput, txtCommonlyUseNumber.Text, cbCommonlyUse.SelectedItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void xóaNguyênLiệuDanhSáchXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataGridViewRow> selectRow = dgrOutput.SelectedRows.Cast<DataGridViewRow>().ToList();
                if (selectRow.Count > 0)
                {
                    foreach (var row in selectRow)
                    {
                        dgrOutput.Rows.Remove(row);
                    }
                    dgrOutput.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void xóaKhỏiDanhSáchThườngXuyênXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _outputHelper.DeleteIngredientAlwayUse(dgvAlwayUse);
                ShowCommonlyUsedIngredients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelSystem.Visible = false;
        }

        private void dateTimePickerOrder_ValueChanged(object sender, EventArgs e)
        {
            selectDate = dateTimePickerOrder.Value.Date;
            this.BeginInvoke((Action)(() =>
            {
                FindOutputData(selectDate);
            }));
           
        }

        bool isZoom = false;
        private void pictureBoxZoom_Click(object sender, EventArgs e)
        {
            if (!isZoom)
            {
                panelSystem.Visible = false;
                pictureBoxZoom.BackgroundImage = Properties.Resources.zoom_out;
            }
            else
            {
                panelSystem.Visible = true;
                pictureBoxZoom.BackgroundImage = Properties.Resources.ZoomIn;
            }
            isZoom = !isZoom;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    _outputHelper.ShowIngredientHaveStock(dgvIngredientInStock);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void thêmVàoDanhSáchXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataGridViewRow> selectRow = dgvIngredientInStock.SelectedRows.Cast<DataGridViewRow>().ToList();
                if (selectRow.Count > 0)
                {
                    _outputHelper.InsertIngredientToDgv(selectRow, dgrOutput);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void btnAddOrther_Click(object sender, EventArgs e)
        {
            InputIngredientAlwayUse();
            ShowCommonlyUsedIngredients();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindOutputData(selectDate);
        }

        private void FindOutputData(DateTime selectDate)
        {
            try
            {
                dgrOutput.Rows.Clear();
                //Tìm kiếm ID đơn hàng theo ngày đặt hàng và hóa đơn đó phải là đã nhận.
                int historyOrderPayedID = _outputHelper.GetHistoryOrderidIsInput(selectDate);
                if (historyOrderPayedID <= 0) return;
                ShowCommonlyUsedIngredients();
                // tìm danh sách nguyên liệu đã nhập kho của hóa đơn đã nhận.
                List<string> ingredientCodeListOfOrder = _outputHelper.GetIngredientCodeListOfOrder(historyOrderPayedID);
                List<string> ingredientCodeListOfMenuNotInOrder = _outputHelper.GetIngredientCodeListOfMenuNotInOrder(ingredientCodeListOfOrder, selectDate.Date);
                ShowDataOutput(ingredientCodeListOfOrder, ingredientCodeListOfMenuNotInOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void ShowDataOutput(List<string> ingredientCodeListOfOrder, List<string> ingredientCodeListOfMenuNotInOrder)
        {
            try
            {
                int index = 0;
                foreach (var item in ingredientCodeListOfOrder)
                {
                    double? stock = _outputHelper.GetIngredientStock(item);
                    if (stock == null) stock = 0;
                    dgrOutput.Rows.Add();
                    dgrOutput.Rows[index].Cells[0].Value = item;
                    dgrOutput.Rows[index].Cells[1].Value = _outputHelper.GetIngredientNameByCode(item);
                    dgrOutput.Rows[index].Cells[2].Value = Common.ConvertText(_outputHelper.GetActualOrderValue(item, selectDate));
                    dgrOutput.Rows[index].Cells[4].Value = Common.ConvertText(stock);
                    dgrOutput.Rows[index].Cells[5].Value = _outputHelper.GetIngredientUnit(item);
                    index++;
                }
                foreach (var item in ingredientCodeListOfMenuNotInOrder)
                {
                    var stock = _outputHelper.GetIngredientStock(item);
                    if (stock == null) stock = 0;
                    dgrOutput.Rows.Add();
                    dgrOutput.Rows[index].Cells[0].Value = item;
                    dgrOutput.Rows[index].Cells[1].Value = _outputHelper.GetIngredientNameByCode(item);
                    dgrOutput.Rows[index].Cells[2].Value = "Empty!";
                    dgrOutput.Rows[index].Cells[4].Value = Common.ConvertText(stock);
                    dgrOutput.Rows[index].Cells[5].Value = _outputHelper.GetIngredientUnit(item);
                    index++;
                }
                _outputHelper.AddIngredientAlwayOutStockToDGV(dgrOutput, dgvAlwayUse);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }
     
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgrOutput.RowCount < 1)
                {
                    MessageBox.Show("Hãy chọn ngày xuất đơn hàng!", "Thông báo");
                    return;
                }
                if (_outputHelper.IsEmptyOutStock(dgrOutput))
                {
                    MessageBox.Show("Phải điền số lượng xuất kho cho ít nhất 1 ô!");
                    return;
                }
                //kiểm tra nếu tất cả ô xuất kho rỗng thì dừng lại.
                if (_outputHelper.IsEmptyRowOutStock(dgrOutput) == true)
                {
                    MessageBox.Show("Số lượng Xuất kho phải là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DefaultColorDGV(dgrOutput);
                if (IsRowNotQualify(dgrOutput))
                {
                    MessageBox.Show("Kho không đủ thực phẩm. Hãy kiểm tra lại!", "Thông báo");
                    return;
                }
              

                DialogResult dia = MessageBox.Show("Bạn đã chắc chắn muốn lưu lại?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dia == DialogResult.Yes)
                {
                    // lưu vào kho.
                    if (_outputHelper.IsSaveToStockAndHistoryInOut(dgrOutput,selectDate))
                    {
                        MessageBox.Show("Đã lưu thành công!", "Thông báo!");
                        FindOutputData(selectDate);
                    }
                }
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

        private bool IsRowNotQualify(DataGridView dgrOutput)
        {
            try
            {
                _outputHelper.ArrangeStock();
                List<DataGridViewRow> rowNotQualifyList = _outputHelper.GetRowNotQualifyList(dgrOutput);
                if (rowNotQualifyList.Count > 0)
                {
                    ShowRowNotQualify(rowNotQualifyList);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        private void DefaultColorDGV(DataGridView dgrOutput)
        {
            dgrOutput.Rows.Cast<DataGridViewRow>().ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.White);
        }

        private void ShowRowNotQualify(List<DataGridViewRow> rowNotQualifyList)
        {
            foreach (var row in rowNotQualifyList)
            {
                row.DefaultCellStyle.BackColor = Color.Coral; // tô màu để nhận biết hàng nào ko đủ kho
            }
        }

        private void btnCheckOutStock_Click(object sender, EventArgs e)
        {
            FormCheckHistoryOutStock f = new FormCheckHistoryOutStock(selectDate);
            f.Show();
        }
        bool selectAll = false;
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                var rowCount = dgrOutput.Rows.Cast<DataGridViewRow>().ToList();
                if (!selectAll)
                {
                    btnSelectAll.Text = "Bỏ chọn";
                    foreach (var row in rowCount)
                    {
                        var actualOrder = row.Cells[2].Value == null || row.Cells[2].Value.ToString() == "Empty!" ? "" : row.Cells[2].Value.ToString();
                        row.Cells[3].Value = actualOrder;
                    }

                }
                else
                {
                    btnSelectAll.Text = "Chọn tất cả";
                    foreach (var row in rowCount)
                    {
                        row.Cells[3].Value = "";
                    }
                }
                selectAll = !selectAll;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }
    }
}

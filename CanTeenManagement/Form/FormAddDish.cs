using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Spire.Xls;
using Spire.Xls.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.DishEnum;

namespace CanTeenManagement
{
    public partial class FormAddDish : Form
    {
        DishHelper _dishHelper = new DishHelper();
        private DishStatus Status { get; set; }
        private string dishCode;
        public FormAddDish(string dishCode)
        {
            InitializeComponent();
            cbIngredient.DisplayMember = "IngredientName";

            if (string.IsNullOrEmpty(dishCode))
            {
                txtTitle.Text = "THÊM MÓN ĂN";
                Status = DishStatus.ADD;
            }
            else // update
            {
                if (_dishHelper.IsPreOrderDish(dishCode))
                {
                    cbIsPreOrderDish.CheckState = System.Windows.Forms.CheckState.Checked;
                }
                else
                {
                    cbIsPreOrderDish.CheckState = System.Windows.Forms.CheckState.Unchecked;
                }
                txtTitle.Text = "SỬA NGUYÊN LIỆU";
                Status = DishStatus.UPDATE;
                ShowDetailDish(dishCode);
            }
        }

        private void ShowDetailDish(string dishCode)
        {
            try
            {
                dgvQuantitative.Rows.Clear();
                var selectDish = _dishHelper.GetDishByCode(dishCode);
                this.dishCode = dishCode;
                txtDishName.Text = selectDish.Dish;
                List<Tbl_Quantitative> quantitatives = _dishHelper.GetIngredientQuantitativeList(dishCode);
                foreach (var item in quantitatives)
                {
                    int indexRow = dgvQuantitative.Rows.Add();
                    dgvQuantitative.Rows[indexRow].Cells[0].Value = item.IngredientCode;
                    dgvQuantitative.Rows[indexRow].Cells[1].Value = _dishHelper.GetIngredientByCode(item.IngredientCode).IngredientName;
                    dgvQuantitative.Rows[indexRow].Cells[2].Value = item.Quantitative;
                    dgvQuantitative.Rows[indexRow].Cells[3].Value = _dishHelper.GetIngredientByCode(item.IngredientCode).Unit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void cbIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                Tbl_Ingredient ingredientSelect = (Tbl_Ingredient)cbIngredient.SelectedItem;
                if (_dishHelper.IsNotPrice(ingredientSelect.IngredientCode, date))
                {
                    MessageBox.Show("Thực phẩm này chưa có báo giá từ nhà cung cấp!");
                    return;
                }
                txtUnit.Text = ingredientSelect.Unit;
                lbSpec.Text = "Spec: " + ingredientSelect.Spec;
                txtIngredientName.Text = ingredientSelect.IngredientName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void txtIngredientName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var lstIngredient = _dishHelper.GetIngredientListByContainStr(txtIngredientName.Text);
                    cbIngredient.DroppedDown = false;
                    cbIngredient.Items.Clear();
                    cbIngredient.Items.AddRange(lstIngredient.ToArray());
                    cbIngredient.DroppedDown = true;
                    Cursor.Current = Cursors.Default;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    cbIngredient.Focus();
                    cbIngredient.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            try
            {
                Tbl_Ingredient ingredientSelected = (Tbl_Ingredient)cbIngredient.SelectedItem;
                if (string.IsNullOrEmpty(txtDishName.Text))
                {
                    MessageBox.Show("Chưa nhập tên món ăn", "Thông báo");
                    return;
                }
                if (cbIngredient.SelectedItem == null)
                {
                    MessageBox.Show("Chưa chọn nguyên liệu", "Thông báo");
                    return;
                }
                if (string.IsNullOrEmpty(txtQuantitative.Text))
                {
                    MessageBox.Show("Chưa nhập định lượng", "Thông báo");
                    return;
                }
                string input = txtQuantitative.Text;

                double number;

                if (!double.TryParse(input, out number) || input == "0" || input == "0.")
                {
                    // The input string can be parsed as a double
                    MessageBox.Show("Định lượng nhập không đúng");
                    return;
                }
                if (number == 0)
                {
                    MessageBox.Show("Định lượng nhập không đúng");
                    return;
                }
                var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                var ListOfIngredient = _dishHelper.GetIngredientNameList();
                if (!ListOfIngredient.Contains(txtIngredientName.Text))
                {
                    MessageBox.Show("Nguyên liệu chưa đúng!");
                    txtIngredientName.Clear();
                    return;
                }
                else
                {
                    if (!_dishHelper.IsValidIngredient(ingredientSelected.IngredientCode, date))
                    {
                        MessageBox.Show("Nguyên liệu chưa đúng!");
                        txtIngredientName.Clear();
                        return;
                    }
                }
                //check xem nguyên liệu tồn tại trong datagridview chưa. Nếu chưa thì thêm mới, đã có thì cập nhật
                var rowExist = dgvQuantitative.Rows.Cast<DataGridViewRow>().Where(w => w.Cells[0].Value.ToString() == ingredientSelected.IngredientCode).FirstOrDefault();
                DataGridViewRow row;
                if (rowExist == null)
                {

                    var index = dgvQuantitative.Rows.Add();
                    row = dgvQuantitative.Rows[index];
                }
                else
                {
                    row = rowExist;
                }
                row.Cells[0].Value = ingredientSelected.IngredientCode;
                row.Cells[1].Value = ingredientSelected.IngredientName;
                row.Cells[2].Value = txtQuantitative.Text;
                row.Cells[3].Value = ingredientSelected.Unit;
                txtIngredientName.Text = "";
                txtQuantitative.Text = "0";
                cbIngredient.Items.Clear();
                txtIngredientName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string dishName = Regex.Replace(txtDishName.Text, "\\s+", " ").Trim();
                if (string.IsNullOrEmpty(dishName))
                {
                    MessageBox.Show("Chưa nhập tên món ăn", "Thông báo");
                    return;
                }

                if (Status == DishStatus.ADD)
                {
                    if (dgvQuantitative.RowCount == 0)
                    {
                        MessageBox.Show("Hãy thêm nguyên liệu cho món ăn!");
                        return;
                    }
                    if (_dishHelper.IsExistDish(dishName))
                    {
                        MessageBox.Show(string.Format("Món ăn: {0} \nĐã tồn tại!!!", dishName), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_dishHelper.IsInsertNewDish(dishName, cbIsPreOrderDish.Checked, dgvQuantitative))
                    {
                        MessageBox.Show($"Thêm thành công món: {dishName}", "Thông báo");
                    }
                }
                else if(Status == DishStatus.UPDATE)
                {
                    if (dgvQuantitative.RowCount == 0)
                    {
                        DialogResult dialog = MessageBox.Show("Món này sẽ bị xóa bỏ vì không có nguyên liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialog == DialogResult.Yes)
                        {
                            if (_dishHelper.IsDeleteDish(this.dishCode))
                            MessageBox.Show($"Đã xóa thành công!", "Thông báo");
                            else
                            {
                                MessageBox.Show($"Không tìm thấy dữ liệu!", "Thông báo");
                            }
                            this.Close();
                        }
                        else if (dialog == DialogResult.No)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Xác nhận chỉnh sửa dữ liệu.", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (_dishHelper.IsUpdateDish(this.dishCode, dishName, dgvQuantitative,cbIsPreOrderDish.Checked))
                            {
                                MessageBox.Show("Đã sửa thành công!", "Thông báo");
                            }
                            else
                            {
                                MessageBox.Show($"Không tìm thấy dữ liệu!", "Thông báo");
                            }
                            ShowDetailDish(this.dishCode);
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void xóaNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = (MessageBox.Show("Xác nhận xóa nguyên liệu.", "Thông báo", MessageBoxButtons.YesNo));
                if (dialogResult == DialogResult.Yes)
                {
                    var listRowSelect = dgvQuantitative.SelectedRows.Cast<DataGridViewRow>().ToList();
                    foreach (var item in listRowSelect)
                    {
                        dgvQuantitative.Rows.Remove(item);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void dgvQuantitative_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvQuantitative_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                var rowSelect = dgvQuantitative.Rows[e.RowIndex];
                txtIngredientName.Text = rowSelect.Cells[1].Value.ToString();
                KeyEventArgs keyEventArgs = new KeyEventArgs(Keys.Enter);
                txtIngredientName_KeyDown(null, keyEventArgs);
                txtQuantitative.Text = rowSelect.Cells[2].Value.ToString();
                cbIngredient.SelectedIndex = 0;
                cbIngredient.DroppedDown = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void txtQuantitative_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtQuantitative_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddIngredient_Click(null, null);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    NPOI.SS.UserModel.IWorkbook workbook = new XSSFWorkbook(fileStream);
                    ISheet sheet = workbook.GetSheetAt(0); // Assuming the first sheet

                    // Iterate through each row in the sheet
                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        IRow currentRow = sheet.GetRow(row);

                        // Create a new row in the DataGridView
                        int rowIndex = dgvQuantitative.Rows.Add();

                        // Set the cell values based on the pre-made columns in the DataGridView
                        for (int col = 0; col < currentRow.LastCellNum; col++)
                        {
                            ICell cell = currentRow.GetCell(col);
                            if (cell != null)
                            {
                                dgvQuantitative.Rows[rowIndex].Cells[col].Value = cell.ToString();
                            }
                        }
                    }
                    Common.StartFormLoading();
                    using (var ctx = new DBContext())
                    {

                        List<string> unique = new List<string>();
                        foreach (DataGridViewRow row in dgvQuantitative.Rows)
                        {
                            string name = row.Cells["IngredientCode"].Value.ToString();
                            if (!unique.Contains(name))
                            {
                                unique.Add(name);
                            }
                        }
                        foreach (var name in unique)
                        {
                            int number = 1;
                            Tbl_Dish tbldish = new Tbl_Dish();

                            tbldish.Dish = Regex.Replace(name, "\\s+", " ").Trim();

                            if (ctx.Tbl_Dish.Count() > 0)
                            {
                                number = ctx.Tbl_Dish.Max(m => m.Number.Value) + 1;
                            }
                            tbldish.DishCode = "MA" + number.ToString().PadLeft(3, '0');

                            tbldish.Number = number;
                            ctx.Tbl_Dish.Add(tbldish);
                            ctx.SaveChanges();


                            var filteredRows = dgvQuantitative.Rows.Cast<DataGridViewRow>()
                                               .Where(row => row.Cells["IngredientCode"].Value?.ToString() == name);


                            foreach (var row in filteredRows)
                            {
                                var namee = row.Cells[1].Value.ToString();
                                var code = ctx.Tbl_Ingredient.Where(w => w.IngredientName == namee).Select(s => s.IngredientCode).FirstOrDefault();
                                Tbl_Quantitative tbl_Quantitative = new Tbl_Quantitative();
                                tbl_Quantitative.DishCode = tbldish.DishCode;
                                tbl_Quantitative.IngredientCode = code;
                                tbl_Quantitative.Quantitative = double.Parse(row.Cells[2].Value.ToString());
                                ctx.Tbl_Quantitative.Add(tbl_Quantitative);
                                ctx.SaveChanges();
                            }
                        }
                        Common.CloseFormLoading();
                    }
                }
            }
        }

        private void txtDishName_TextChanged(object sender, EventArgs e)
        {
            // Get the current text in the TextBox
            string text = txtDishName.Text;

            // Split the text into words
            string[] words = text.Split(' ');

            // Capitalize the first letter after each space
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(words[i]))
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                }
            }

            // Join the words back into a single string
            string convertedText = string.Join(" ", words);

            // Preserve the cursor position
            int cursorPosition = txtDishName.SelectionStart;

            // Update the TextBox text
            txtDishName.Text = convertedText;

            // Restore the cursor position
            txtDishName.SelectionStart = cursorPosition;
            txtDishName.SelectionLength = 0;
        }

        private void FormAddDish_Load(object sender, EventArgs e)
        {

        }

        private void txtIngredientName_MouseClick(object sender, MouseEventArgs e)
        {
            txtIngredientName.SelectAll();
        }
    }
}



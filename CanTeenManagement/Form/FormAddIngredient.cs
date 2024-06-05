using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using NPOI.OpenXmlFormats.Spreadsheet;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.DishEnum;

namespace CanTeenManagement
{
    public partial class FormAddIngredient : Form
    {

        IngredientHelper _ingredientHelper = new IngredientHelper();
        private IngredientStatus Status { get; set; }
        private string ingredientCode;

        public FormAddIngredient(string ingredientCode)
        {
            InitializeComponent();
            checkBoxSafeStock.Checked = false;
            txtNumberSafeStock.Enabled = false;
            if (string.IsNullOrEmpty(ingredientCode))
            {
                txtTitle.Text = "THÊM NGUYÊN LIỆU";
                Status = IngredientStatus.ADD;
            }
            else
            {
                txtTitle.Text = "SỬA NGUYÊN LIỆU";
                Status = IngredientStatus.UPDATE;
                this.ingredientCode = ingredientCode;
                ShowIngredientInfo(ingredientCode);
            }           
        }

        private void ShowIngredientInfo(string ingredientCode)
        {
            var ingredientExist = _ingredientHelper.GetIngredient(ingredientCode);
            txtIngredientName.Text = ingredientExist.IngredientName;
            txtIngredientSpec.Text = ingredientExist.Spec;
            txtIngredientUnit.Text = ingredientExist.Unit;
            txtNumberSafeStock.Text = ingredientExist.SafeStock == null ? "" : ingredientExist.SafeStock.ToString();
        }

        private async void btnSaveIngredient_Click(object sender, EventArgs e)
        {
            try
            {
                string ingredientName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Regex.Replace(txtIngredientName.Text, "\\s+", " ").Trim().ToLower());
                string spec = txtIngredientSpec.Text.Trim();
                string unit = txtIngredientUnit.Text.Trim();
                if (string.IsNullOrEmpty(txtIngredientName.Text) || string.IsNullOrEmpty(txtIngredientSpec.Text) || string.IsNullOrEmpty(txtIngredientUnit.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo");
                    return;
                }
                if (Status == IngredientStatus.ADD)
                {
                    if (_ingredientHelper.IsExistIngredient(ingredientName))
                    {
                        MessageBox.Show(string.Format($"Nguyên liệu: {ingredientName} đã tồn tại!"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_ingredientHelper.IsInsertIngredient(ingredientName, spec, unit, txtNumberSafeStock.Text))
                    {
                        MessageBox.Show("Thêm thành công!", "Thông báo");
                    }
                }
                else if(Status == IngredientStatus.UPDATE)
                {
                    var mess = MessageBox.Show(string.Format("Xác nhận cập nhập nguyên liệu\n\nTên nguyên liệu:  {0}\nThông số: {1}\nĐơn vị: {2}", ingredientName, spec, unit), "Xác nhận", MessageBoxButtons.OKCancel);
                    if (mess == DialogResult.OK)
                    {
                        if (_ingredientHelper.IsUpdateIngredient(this.ingredientCode, ingredientName, spec, unit, txtNumberSafeStock.Text))
                        {
                            MessageBox.Show("Sửa thành công!", "Thông báo");
                            ShowIngredientInfo(this.ingredientCode);
                        }
                    }                  
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Nhập sai định dạng số!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }
        bool enabled = true;
        private void txtIngredientPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtIngredientPrice.Text.Length <= 19)
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                    enabled = true;
                }
                else if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                    enabled = true;
                }
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                    enabled = true;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Ký tự quá dài", "Thông báo");
                }
            }

        }
        private void txtIngredientPrice_TextChanged(object sender, EventArgs e)
        {
            if (enabled == true)
            {
                //định dạng giá 
                enabled = false;
                if (txtIngredientPrice.Text.Length > 0)
                {
                    string input = txtIngredientPrice.Text.Replace(",", "").Replace(".", "");
                    string value = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", Int64.Parse(input));
                    txtIngredientPrice.Text = value;
                    txtIngredientPrice.SelectionStart = txtIngredientPrice.Text.Length;
                }

            }
        }
        private void checkBoxSafeStock_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSafeStock.Checked)
            {
                txtNumberSafeStock.Enabled = true;
            }
            else
            {
                txtNumberSafeStock.Enabled = false;
            }
        }

        private void cbIngredientName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //thêm nguyên liệu bằng file excel
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Excel 2010|*.xlsx|Excel|*.xls";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //đọc dữ liệu từ file excel
                    Workbook wbFromMaster = new Workbook();
                    wbFromMaster.LoadFromFile(open.FileName);
                    Worksheet sheet = wbFromMaster.Worksheets[0];

                    using (var ctx = new DBContext())
                    {

                        for (int i = 3; i <= sheet.Rows.Count(); i++)
                        {
                            Tbl_Ingredient newIngredient = new Tbl_Ingredient();

                            newIngredient.IngredientName = sheet.Range[i, 2].DisplayedText == "" ? "" : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Regex.Replace(sheet.Range[i, 2].DisplayedText, "\\s+", " ").Trim().ToLower());

                            var ingredientExist = ctx.Tbl_Ingredient.Where(w => w.IngredientName == newIngredient.IngredientName && w.Spec == newIngredient.Spec).FirstOrDefault();

                            int number = 1;
                            if (ingredientExist == null)
                            {
                                newIngredient.Spec = sheet.Range[i, 3].DisplayedText == "" ? "" : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sheet.Range[i, 3].DisplayedText.Trim());
                                newIngredient.Unit = sheet.Range[i, 4].DisplayedText == "" ? "" : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sheet.Range[i, 4].DisplayedText.Trim());
                                if (ctx.Tbl_Ingredient.Count() <= 0) number = 1;
                                else
                                {
                                    number = ctx.Tbl_Ingredient.Max(m => m.IndexNumber) + 1;
                                }
                                newIngredient.IngredientCode = "CT" + number.ToString().PadLeft(5, '0');
                                newIngredient.IndexNumber = number;

                                ctx.Tbl_Ingredient.Add(newIngredient);
                                ctx.SaveChanges();
                            }
                        }

                        // save to stock
                        var ListNL = ctx.Tbl_Ingredient.ToList();
                        foreach (var item in ListNL)
                        {
                            Tbl_Stock newst = new Tbl_Stock();
                            newst.IngredientCode = item.IngredientCode;
                            newst.Stock = 0;
                            newst.Input = 0;
                            newst.Output = 0;
                            ctx.Tbl_Stock.Add(newst);
                            ctx.SaveChanges();
                        }
                    }
                    MessageBox.Show("Hoàn thành", "Thông báo");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void txtIngredientName_TextChanged(object sender, EventArgs e)
        {
            // Get the current text in the TextBox
            string text = txtIngredientName.Text;

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
            int cursorPosition = txtIngredientName.SelectionStart;

            // Update the TextBox text
            txtIngredientName.Text = convertedText;

            // Restore the cursor position
            txtIngredientName.SelectionStart = cursorPosition;
            txtIngredientName.SelectionLength = 0;
        }

        private void FormAddIngredient_Load(object sender, EventArgs e)
        {
            btnImportExcel.Visible = false;
        }

        private void txtIngredientUnit_TextChanged(object sender, EventArgs e)
        {
            // Get the current text in the TextBox
            string text = txtIngredientUnit.Text;

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
            int cursorPosition = txtIngredientUnit.SelectionStart;

            // Update the TextBox text
            txtIngredientUnit.Text = convertedText;

            // Restore the cursor position
            txtIngredientUnit.SelectionStart = cursorPosition;
            txtIngredientUnit.SelectionLength = 0;
        }

        private void txtNumberSaveStock_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}

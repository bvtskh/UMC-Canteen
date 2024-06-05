using CanTeenManagement.Model;
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

namespace CanTeenManagement
{
    public partial class FormAddIngredientAddSupplier : Form
    {
        private string ingredientCode;
        public FormAddIngredientAddSupplier(string ingredientCode, string ingredientName)
        {
            InitializeComponent();
            this.ingredientCode = ingredientCode;
            txtIngredientName.Text = ingredientName;
            using(var ctx =new DBContext())
            {
                var listSupplier = ctx.Tbl_Supplier.ToList();
                cbIngredientSupplier.DataSource = listSupplier;
                cbIngredientSupplier.DisplayMember = "SupplierName";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using(var ctx=new DBContext())
            {
                if (!string.IsNullOrEmpty(txtIngredientPrice.Text))
                {
                    Tbl_Supplier supplier = (Tbl_Supplier)cbIngredientSupplier.SelectedItem;
                    if (ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingredientCode && w.SupplierCode == supplier.SupplierCode).Count() > 0)
                    {
                        MessageBox.Show(string.Format("NGUYÊN LIỆU: {0}\nNHÀ CUNG CẤP: {1} \nĐÃ TỒN TẠI!!!", txtIngredientName.Text,supplier.SupplierName), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int price= Int32.Parse(txtIngredientPrice.Text.Replace(".", ""));
                    Tbl_HistoryPrice tbl_HistoryPrice = new Tbl_HistoryPrice();
                    tbl_HistoryPrice.IngredientCode = ingredientCode;
                    tbl_HistoryPrice.Price = price;
                    tbl_HistoryPrice.TimeUpdate = DateTime.Now;
                    tbl_HistoryPrice.SupplierCode = supplier.SupplierCode;
                    tbl_HistoryPrice.ApprovalDate = dateIngredientApproval.Value;
                    ctx.Tbl_HistoryPrice.Add(tbl_HistoryPrice);
                    ctx.SaveChanges();
                    MessageBox.Show("Thành công", "Thông báo");
                    this.Close();
                }
            }
        }
        bool enabled = true;
        private void txtIngredientPrice_TextChanged(object sender, EventArgs e)
        {
            if (enabled == true)
            {
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

        private void FormAddIngredientAddSupplier_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FormAddSupplier : Form
    {
        Tbl_Supplier supplier = null;
        public FormAddSupplier()
        {
            InitializeComponent();
        }
        public FormAddSupplier(string supplierCode)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(supplierCode))
            {
                txtTitle.Text = "SỬA NHÀ CUNG CẤP";
                using (var ctx = new DBContext())
                {
                    this.supplier = ctx.Tbl_Supplier.Where(w => w.SupplierCode == supplierCode).FirstOrDefault();
                    txtSupplierCode.Text = supplier.SupplierCode.Trim();
                    txtSupplierName.Text = supplier.SupplierName.Trim();
                }
            }
        }
        private void txtSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSupplierCode.Text) || string.IsNullOrEmpty(txtSupplierName.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo");
                return;
            }
            using (var ctx = new DBContext())
            {
                try
                {                  
                    if (supplier == null)
                    {
                        var checkSupplierCode = ctx.Tbl_Supplier.Where(w => w.SupplierCode == txtSupplierCode.Text).ToList();
                        if (checkSupplierCode.Count > 0)
                        {
                            MessageBox.Show("Mã nhà cung cấp đã tồn tại.", "Thông báo");
                            return;
                        }
                        var checkSupplierName = ctx.Tbl_Supplier.Where(w => w.SupplierName == txtSupplierName.Text).ToList();
                        if (checkSupplierName.Count > 0)
                        {
                            MessageBox.Show("Tên nhà cung cấp đã tồn tại.", "Thông báo");
                            return;
                        }
                        Tbl_Supplier tbl_Supplier = new Tbl_Supplier();
                        tbl_Supplier.SupplierCode = txtSupplierCode.Text;
                        tbl_Supplier.SupplierName = txtSupplierName.Text;
                        ctx.Tbl_Supplier.Add(tbl_Supplier);
                        ctx.SaveChanges();
                        MessageBox.Show("Thành công", "Thông báo");

                    }
                    else
                    {
                        supplier.SupplierCode = txtSupplierCode.Text;
                        supplier.SupplierName = txtSupplierName.Text;
                        ctx.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        MessageBox.Show("Thành công", "Thông báo");

                    }
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Thất bại", "Thông báo");

                }

            }
        }
    }
}

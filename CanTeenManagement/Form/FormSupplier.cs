using CanTeenManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement
{
    public partial class FormSupplier : Form
    {
        public FormSupplier()
        {
            InitializeComponent();
            dgvSupplier.AutoGenerateColumns = false;
        }

        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            using(var ctx=new DBContext())
            {
                var listSupplier = ctx.Tbl_Supplier.Where(w=>w.SupplierName.Contains(txtSearchSupplier.Text)).ToList();
                dgvSupplier.DataSource = listSupplier;
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            FormAddSupplier formAddSupplier = new FormAddSupplier();
            formAddSupplier.ShowDialog();
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            var rowSelect = dgvSupplier.SelectedRows;
            var supplierCode = rowSelect[0].Cells[0].Value.ToString();
            FormAddSupplier formAddSupplier = new FormAddSupplier(supplierCode);
            formAddSupplier.ShowDialog();
        }
    }
}

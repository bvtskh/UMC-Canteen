using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using Sunny.UI;
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
    public partial class FormPriority : Form
    {
        SupplierHelper supplierHelper = new SupplierHelper();
        public FormPriority()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using(var context = new DBContext())
            {
                var supplierCode = (cbSupplier.SelectedItem as Tbl_Supplier).SupplierCode;
                var checklist = this.Controls.OfType<UICheckBox>().Where(w=>w.Checked).ToList();
                foreach (var item in checklist.Select(s => s.Name).ToList())
                {
                    var numberDay = Int16.Parse(item.Replace("cbk", string.Empty));
                    var dataExist = context.Priority.Where(w => w.DAY == numberDay).ToList();
                    foreach(var day in dataExist)
                    {
                        context.Priority.Remove(day);
                    }
                    context.SaveChanges();
                    Tbl_Priority tbl_Priority = new Tbl_Priority();
                    tbl_Priority.DAY = numberDay;
                    tbl_Priority.SupplierCode = supplierCode;
                    context.Priority.Add(tbl_Priority);
                    context.SaveChanges();
                }
            }
        }

        private void FormPriority_Load(object sender, EventArgs e)
        {
            cbSupplier.DataSource = supplierHelper.GetAllSupplier();
            cbSupplier.DisplayMember = "SupplierName";
        }

        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in Controls.OfType<UICheckBox>().ToList())
            {
                item.Checked = false;
            }
            var supplierCodeSelected = (cbSupplier.SelectedItem as Tbl_Supplier).SupplierCode;
            using (var context = new DBContext())
            {
                var checkedList = context.Priority.Where(w=>w.SupplierCode == supplierCodeSelected).ToList();
                foreach (var item in checkedList)
                {
                    var day = "cbk" + item.DAY;
                    this.Controls.OfType<UICheckBox>().Where(w=>w.Name == day).FirstOrDefault().Checked = true;
                }
            }
        }
    }
}

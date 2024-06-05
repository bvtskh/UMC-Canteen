using CanTeenManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.EnumSupplier;

namespace CanTeenManagement
{
    public partial class FormSelectSupplierClon : Form
    {
        public FormSelectSupplierClon()
        {
            InitializeComponent();
        }

        private void btnSearchIngredient_Click(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime(Int16.Parse(cbYear.Text), Int16.Parse(cbMonth.Text), 1);
            UpdateEqualPrice(dateTime, UpdateType.Read);
        }

        private void UpdateEqualPrice(DateTime dateTime, UpdateType read)
        {
            throw new NotImplementedException();
        }

        private void btnImportExcelUpdatePrice_Click(object sender, EventArgs e)
        {

        }
    }
}

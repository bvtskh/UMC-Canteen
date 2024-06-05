using CanTeenManagement.OverTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement
{
    public partial class FormOverTime : Form
    {
        public FormOverTime()
        {
            InitializeComponent();
            dateTimePickerDateOT.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateOT.CustomFormat = "dd-MM-yyyy";
            dgvListOT.ReadOnly = true;
        }

        private void FormOverTime_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var ctx = new DBContextOverTime())
            {
                var date = dateTimePickerDateOT.Value.Date;
                var listHumanRegisted = ctx.Tbl_DailyOverTime.Where(W => W.DateOverTime == date && W.TimeRegisted > 0).ToList();
                lbNumber.Text = $"Tổng số: {listHumanRegisted.Count} người đăng kí tăng ca!"; 
                dgvListOT.DataSource = listHumanRegisted;
                dgvListOT.Columns["Id"].Visible = false;
            }
        }      
    }
}

using CanTeenManagement.Bussiness.SQLHelper;
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
    public partial class FormUpdatePrice : Form
    {
        SupplierHelper _supplierHelper = new SupplierHelper();
        string supplierCode;
        public FormUpdatePrice()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {          
            var dataImport = _supplierHelper.GetDataImport();
            if (dataImport == null) return;
            var approveTime = DateTime.Parse(dataImport.Rows[0].Field<object>(2).ToString());
            dataImport.Rows.RemoveAt(0);
            dataImport.Rows.RemoveAt(0);
            supplierCode = dataImport.Rows[0].Field<string>(4);
            dateTimePicker1.Value = approveTime;
            lblSupplierCode.Text = supplierCode;
            dgvUpdateInfo.DataSource = dataImport;
            dgvUpdateInfo.AutoSizeColumnsMode =  DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormUpdatePrice_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(dgvUpdateInfo.Rows.Count < 0) 
            {
                MessageBox.Show("Không có dữ liệu!"); return;
            }
            if (dateTimePicker1.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Không được cập nhật giá trong quá khứ!"); return;
            }
            if(string.IsNullOrEmpty(supplierCode))
            {
                MessageBox.Show("Mã nhà cung cấp không đúng!"); return;
            }
            if (_supplierHelper.IsExistUpdateTime(dateTimePicker1.Value.Date,supplierCode))
            {
                if(MessageBox.Show($"Đã có giá áp dụng từ ngày: {dateTimePicker1.Value.Date.ToString("MM/dd/yyyy")} của nhà cung cấp {_supplierHelper.GetSupplierName(supplierCode)}, chọn OK để tiếp tục, Cancel để hủy!","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel) return;
            }
            string mess = $"Cập nhật báo giá!\nNgày áp dụng: {dateTimePicker1.Value.Date.ToString("MM/dd/yyyy")}\nNhà cung cấp: {_supplierHelper.GetSupplierName(supplierCode)}";

            if(MessageBox.Show(mess,"Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(_supplierHelper.IsUpdatePrice(dateTimePicker1.Value.Date, supplierCode, dgvUpdateInfo))
                {
                    MessageBox.Show("Đã cập nhật thành công!");
                }
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {

        }
    }
}

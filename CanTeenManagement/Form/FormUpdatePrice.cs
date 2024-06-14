using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using Spire.Xls;
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
    public partial class FormUpdatePrice : Form
    {
        SupplierHelper _supplierHelper = new SupplierHelper();
        string supplierCode;
        int tab;
        DateTime? dateTime;
        public FormUpdatePrice(int tab = 0, string supplierCode ="", DateTime? dateTime = null)
        {
            InitializeComponent();
            dtpApproveTime.Format = DateTimePickerFormat.Custom;
            dtpApproveTime.CustomFormat = "dd-MM-yyyy";
            this.tab = tab;
            this.supplierCode = supplierCode;
            this.dateTime = dateTime;
        }

        [Obsolete]
        private void btnImport_Click(object sender, EventArgs e)
        {          
            var dataImport = _supplierHelper.GetDataImport();
            if (dataImport == null || dataImport.Rows.Count<=0) return;
            var approveTime = DateTime.Parse(dataImport.Rows[0].Field<object>(2).ToString());
            dataImport.Rows.RemoveAt(0);
            dataImport.Rows.RemoveAt(0);
            supplierCode = dataImport.Rows[0].Field<string>(4);
            if (!_supplierHelper.IsValidSupplier(supplierCode))
            {
                MessageBox.Show("Không tồn tại mã nhà cung cấp: " + supplierCode);
                return;
            }
            dtpApproveTime.Value = approveTime;
            lblSupplierCode.Text = supplierCode;
            dgvUpdateInfo.DataSource = dataImport;
            dgvUpdateInfo.AutoSizeColumnsMode =  DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormUpdatePrice_Load(object sender, EventArgs e)
        {
            cbbSupplierTab2.DataSource = _supplierHelper.GetAllSupplier();
            cbbSupplierTab2.DisplayMember = "SupplierName";
            tabControl1.SelectedTab = tabControl1.TabPages[this.tab];
            if (!string.IsNullOrEmpty(this.supplierCode))
            {
                cbbSupplierTab2.Text = _supplierHelper.GetAllSupplier().Where(w => w.SupplierCode == this.supplierCode).Select(s=>s.SupplierName).FirstOrDefault();
                cbbApproveDateTab2.Text = this.dateTime.Value.ToString("dd-MM-yyyy");
            }
            txtMonth.Text = DateTime.Now.Month.ToString();
            txtYear.Text = DateTime.Now.Year.ToString();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(dgvUpdateInfo.Rows.Count <= 0) 
            {
                MessageBox.Show("Không có dữ liệu!"); return;
            }
            if (dtpApproveTime.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Không được cập nhật giá trong quá khứ!"); return;
            }
            if(string.IsNullOrEmpty(supplierCode))
            {
                MessageBox.Show("Mã nhà cung cấp không đúng!"); return;
            }
            if (_supplierHelper.IsExistUpdateTime(dtpApproveTime.Value.Date,supplierCode))
            {
                if(MessageBox.Show($"Đã có giá áp dụng từ ngày: {dtpApproveTime.Value.Date.ToString("dd-MM-yyyy")} của nhà cung cấp {_supplierHelper.GetSupplierName(supplierCode)}, chọn OK để tiếp tục, Cancel để hủy!","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel) return;
            }
            string mess = $"Cập nhật báo giá!\nNgày áp dụng: {dtpApproveTime.Value.Date.ToString("dd-MM-yyyy")}\nNhà cung cấp: {_supplierHelper.GetSupplierName(supplierCode)}";

            if(MessageBox.Show(mess,"Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(_supplierHelper.IsUpdatePrice(dtpApproveTime.Value.Date, supplierCode, dgvUpdateInfo))
                {
                    MessageBox.Show("Đã cập nhật thành công!");
                }
            }
        }

        private void cbbSupplierTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbApproveDateTab2.Items.Clear();
            cbbApproveDateTab2.Text= string.Empty;
            var supplier = cbbSupplierTab2.SelectedItem as Tbl_Supplier;
            cbbApproveDateTab2.Items.AddRange(_supplierHelper.GetApproveDateBySupplier(supplier.SupplierCode));
            cbbApproveDateTab2_SelectedIndexChanged(null, null);
        }

        private void btnSearchTab2_Click(object sender, EventArgs e)
        {
            dgvHistoryPriceTav2.Rows.Clear();
            if (cbbApproveDateTab2.SelectedIndex != -1)
            {
                var supplier = cbbSupplierTab2.SelectedItem as Tbl_Supplier;
                var date = DateTime.ParseExact(cbbApproveDateTab2.SelectedItem as string,"dd-MM-yyyy",null);
                var data = _supplierHelper.GetHistoryPrice(supplier.SupplierCode, date);
               for(int row =0; row < data.Count; row++)
                {
                    dgvHistoryPriceTav2.Rows.Add();
                    dgvHistoryPriceTav2.Rows[row].Cells[0].Value = data[row].IngredientCode;
                    dgvHistoryPriceTav2.Rows[row].Cells[1].Value = _supplierHelper.GetIngredientName(data[row].IngredientCode);
                    dgvHistoryPriceTav2.Rows[row].Cells[2].Value = data[row].OldPrice;
                    dgvHistoryPriceTav2.Rows[row].Cells[3].Value = data[row].NewPrice;
                    dgvHistoryPriceTav2.Rows[row].Cells[6].Value = data[row].UpdateTime.Value.ToString("dd-MM-yyyy HH:mm");
                    dgvHistoryPriceTav2.Rows[row].Cells[7].Value = data[row].ApproveTime.Value.ToString("dd-MM-yyyy");
                }

            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvHistoryPriceTav2.RowCount < 1)
            {
                UIMessageTip.ShowError("Không có nguyên liệu nào được áp dụng!");
                return;
            }
            int year = string.IsNullOrEmpty(txtYear.Text) ? 0 : Int16.Parse(txtYear.Text);
            int month = string.IsNullOrEmpty(txtMonth.Text) ? 0 : Int16.Parse(txtMonth.Text);
            var date = DateTime.ParseExact(cbbApproveDateTab2.Text, "dd-MM-yyyy", null);
            if(date.Year == year && date.Month == month)
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn áp dụng báo giá này không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var supplier = cbbSupplierTab2.SelectedItem as Tbl_Supplier;
                    var supplierCode = supplier.SupplierCode;
                    _supplierHelper.UpdateAprovePrice(supplierCode, date, Int16.Parse(txtYear.Text), Int16.Parse(txtMonth.Text));
                    UIMessageBox.ShowSuccess($"Cập nhật thành công!");
                }
            }
            else
            {
                UIMessageTip.ShowError($"Báo giá tháng: {date.Month} - {date.Year} phải áp dụng đúng tháng được chọn!");
            }
        }

        private void cbbApproveDateTab2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvHistoryPriceTav2.DataSource = null;
            dgvHistoryPriceTav2.Rows.Clear();
            if(cbbApproveDateTab2.SelectedIndex != -1) 
            {
                var date = DateTime.ParseExact(cbbApproveDateTab2.Text, "dd-MM-yyyy", null);
                txtYear.Text =date.Year.ToString();
                txtMonth.Text =date.Month.ToString();
            }
        }
    }
}

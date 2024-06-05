using CanTeenManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement
{
    public partial class FormAccountManagement : Form
    {
        public FormAccountManagement()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            btnDel.Enabled = false;
        }

        private void FormAccountManagement_Load(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void LoadAccount()
        {
            ShowDataAccount();
        }

        private void ShowDataAccount()
        {
            using (var ctx = new DBContext())
            {
                var listAccount = ctx.Tbl_User.ToList();
                foreach (var account in listAccount)
                {
                    dgvAccountMangement.Rows.Add();
                    dgvAccountMangement.Rows[dgvAccountMangement.RowCount - 1].Cells[0].Value = account.Account;
                    dgvAccountMangement.Rows[dgvAccountMangement.RowCount - 1].Cells[1].Value = account.FullName;
                    dgvAccountMangement.Rows[dgvAccountMangement.RowCount - 1].Cells[2].Value = account.PassWord;
                    dgvAccountMangement.Rows[dgvAccountMangement.RowCount - 1].Cells[3].Value = account.Department;
                    dgvAccountMangement.Rows[dgvAccountMangement.RowCount - 1].Cells[4].Value = account.Type == 0 ? "Admin" : "Member";
                }
            }
        }

        private void dgvAccountMangement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtAcc.Enabled = false;
                int row = e.RowIndex;
                string account = dgvAccountMangement.Rows[row].Cells[0].Value.ToString();
                string fullName = dgvAccountMangement.Rows[row].Cells[1].Value == null ? "" : dgvAccountMangement.Rows[row].Cells[1].Value.ToString();
                string password = dgvAccountMangement.Rows[row].Cells[2].Value == null ? "" : dgvAccountMangement.Rows[row].Cells[2].Value.ToString();
                string dept = dgvAccountMangement.Rows[row].Cells[3].Value == null ? "" : dgvAccountMangement.Rows[row].Cells[3].Value.ToString();
                string access = dgvAccountMangement.Rows[row].Cells[4].Value == null ? "" : dgvAccountMangement.Rows[row].Cells[4].Value.ToString();
                txtAcc.Text = account.Trim();
                txtPass.Text = password.Trim();
                txtFullName.Text = fullName.Trim();
                txtDept.Text = dept.Trim();
                txtAccess.Text = access.Trim();
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDel.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string account = txtAcc.Text.Trim();
            string name = txtFullName.Text.Trim();
            string pass = txtPass.Text.Trim();
            string access = txtAccess.Text.Trim();
            if(cbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn bộ phận làm việc!"); return;
            }
            string department = txtDept.Text.Trim();
            if(string.IsNullOrEmpty(account) || string.IsNullOrEmpty(pass)|| string.IsNullOrEmpty(access) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Hãy điền đủ thông tin");
                return;
            }
            else
            {
                CreateAccount(account,name, pass, access, department);
            }
        }
        private void CreateAccount(string account, string name, string pass, string access, string department)
        {
            using(var ctx = new DBContext())
            {
                try
                {
                    if (IsExisted(account))
                    {
                        MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác!");
                        return;
                    }
                    if (!IsPassValid(pass))
                    {
                        MessageBox.Show("Mật khẩu phải từ 4 đến 8 ký tự!");
                        return;
                    }
                    Tbl_User accountNew = new Tbl_User();
                    accountNew.Account = account;
                    accountNew.FullName = name;
                    accountNew.PassWord = pass;
                    accountNew.Department = department;
                    accountNew.Type = access == "Admin" ? 0 : 1;
                    if(accountNew.Type == 0)
                    {
                        accountNew.LimitedAccess = "FULL";
                    }
                    else if(accountNew.Type == 1)
                    {
                        accountNew.LimitedAccess = "Giới hạn nhà cung cấp, thống kê (hóa đơn, báo cáo nhập hàng)";
                    }
                    ctx.Tbl_User.Add(accountNew);
                    ctx.SaveChanges();
                    dgvAccountMangement.Rows.Clear();
                    ShowDataAccount();
                }
                catch ( Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private bool IsPassValid(string pass)
        {
            return pass.Count() >=4  && pass.Count()<=8;
        }

        private bool IsExisted(string account)
        {
            bool result = false;
            using(var ctx = new DBContext())
            {
                var accountExist = ctx.Tbl_User.Where(w => w.Account.Trim() == account.Trim()).FirstOrDefault();
                if (accountExist != null) result = true;
            }
            return result;
        }

        private void cbAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAccess.Text = cbAccess.SelectedItem as string;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtAcc.Enabled = true;
            txtAcc.Clear();
            txtFullName.Clear();
            txtAccess.Clear();
            txtPass.Clear();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDel.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string account = txtAcc.Text.Trim();
            string name  = txtFullName.Text.Trim();
            string pass = txtPass.Text.Trim();
            string access = txtAccess.Text;

            if (string.IsNullOrEmpty(txtDept.Text))
            {
                MessageBox.Show("Bạn chưa chọn bộ phận làm việc!"); return;
            }
            string department = txtDept.Text.Trim();
            if (!IsPassValid(pass))
            {
                MessageBox.Show("Mật khẩu phải từ 4 đến 8 ký tự!");
                return;
            }
            UpdateAccount(account, name, pass,access, department);
            dgvAccountMangement.Rows.Clear();
            ShowDataAccount();
        }

        private void UpdateAccount(string account, string name, string pass,string access, string department)
        {
            using(var ctx = new DBContext())
            {
                var accountExist = ctx.Tbl_User.Where(w => w.Account == account).FirstOrDefault();
                if(accountExist != null)
                {
                    accountExist.PassWord = pass;
                    accountExist.FullName = name;
                    accountExist.Department = department;
                    accountExist.Type = access == "Admin" ? 0 : 1;
                    if (accountExist.Type == 0)
                    {
                        accountExist.LimitedAccess = "FULL";
                    }
                    else if (accountExist.Type == 1)
                    {
                        accountExist.LimitedAccess = "Giới hạn nhà cung cấp, thống kê (hóa đơn, báo cáo nhập hàng)";
                    }
                    ctx.SaveChanges();
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string account = txtAcc.Text.Trim();
            if(account == "admin")
            {
                MessageBox.Show("Không được xóa tài khoản ADMIN!");
                return;
            }
            DialogResult log = MessageBox.Show("Xác nhận xóa tài khoản này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(log == DialogResult.Yes)
            {
                DeleteAccount(account);
                dgvAccountMangement.Rows.Clear();
                ShowDataAccount();
            }
        }

        private void DeleteAccount(string account)
        {
            using(var ctx = new DBContext())
            {
                var accountDel = ctx.Tbl_User.Where(w => w.Account == account).FirstOrDefault();
                if(accountDel != null)
                {
                    ctx.Tbl_User.Remove(accountDel);
                    ctx.SaveChanges();
                }
                else
                {
                    MessageBox.Show("tài khoản không tồn tại!");
                    return;
                }
            }
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDept.Text = cbDepartment.SelectedItem as string;
        }
    }
}

using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using Newtonsoft.Json.Linq;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CanTeenManagement
{
    public partial class FormLogin : UIForm
    {
        LoginHelper _loginHelper = new LoginHelper();
        public string accountTypeName;
        public string Account { get; set; }
        public FormLogin()
        {
            InitializeComponent();
            txtmk.UseSystemPasswordChar = true;
            cbReadOnly.Visible = false;
        }
        private void txttk_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txttk.Text))
            {
                lbtk.Hide();
            }
            else
            {
                lbtk.Show();
            }
        }

        private void lbtk_Click(object sender, EventArgs e)
        {
            txttk.Focus();
        }

        private void lbmk_Click(object sender, EventArgs e)
        {
            txtmk.Focus();
        }

        private void txtmk_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtmk.Text))
            {
                lbmk.Hide();
            }
            else
            {
                lbmk.Show();
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }
        bool isPasswordVisible = false;
        private void showpass_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txtmk.UseSystemPasswordChar = !isPasswordVisible;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {            
            txttk.Focus();
            checktk.Checked = true;
            try
            {
                txttk.Text = CanTeenManagement.Properties.Settings.Default.UserName;
                txtmk.Text = CanTeenManagement.Properties.Settings.Default.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the login data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CheckLogin()
        {
            Common.StartFormLoading();
            if (!_loginHelper.IsValidVersion())
            {
                Common.CloseFormLoading();
                MessageBox.Show($"Đã có phiên bản {_loginHelper.GetNewVersionString()}! Vui lòng vào đường dẫn\n{@"\\vn - file\LCA Department\36.CanTeenManagement\StartUp\.StartUp.exe"}\nđể sử dụng phiên bản mới nhất!");
                System.Environment.Exit(1);
            }           
            if (!cbReadOnly.Checked)
            {
                var account = _loginHelper.GetAccount(txttk.Text, txtmk.Text);
                if (account == null)
                {
                    Common.CloseFormLoading();
                    ShowErrorTip("Thông tin tài khoản hoặc mật khẩu không chính xác!");
                    linklbUser.Visible = true;
                }
                else
                {
                    accountTypeName = _loginHelper.CheckAccount(account);
                    Common.CloseFormLoading();
                    Login(accountTypeName, account.Account.Trim(),account.PassWord.Trim(),account.FullName.Trim());
                }
            }
            else
            {
                accountTypeName = "ReadOnly";
                Common.CloseFormLoading();
                Login("ReadOnly", "ReadOnly", "ReadOnly", "ReadOnly");
            }
        }

        private void Login(string accountTypeName, string account, string passWord, string fullName)
        {
            Form1 f = new Form1();
            f.AccountTypeName = accountTypeName;
            f.Account = account;
            f.FullName = fullName;
            f.PassWord = passWord;
            Account = account;
            if (checktk.Checked)
            {
                CanTeenManagement.Properties.Settings.Default.UserName = account;
                CanTeenManagement.Properties.Settings.Default.Password = passWord;
                CanTeenManagement.Properties.Settings.Default.Save();
            }
            else
            {
                CanTeenManagement.Properties.Settings.Default.UserName = "";
                CanTeenManagement.Properties.Settings.Default.Password = "";
                CanTeenManagement.Properties.Settings.Default.Save();
            }
            f.Show();
            this.Hide();
        }

        private void FormLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the Enter key from producing a beep sound

                // Perform login logic here
                CheckLogin();
            }
        }

        private void txttk_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!string.IsNullOrEmpty(txttk.Text.ToString()) && string.IsNullOrEmpty(txtmk.Text))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    txtmk.Focus();
                    e.Handled = true; // Prevent the Enter key from producing a beep sound
                }
            }
            else if(!string.IsNullOrEmpty(txttk.Text.ToString()) && !string.IsNullOrEmpty(txtmk.Text.ToString()))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    CheckLogin();
                }
            }
            else
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    CheckLogin();
                }
            }           
        }

        private void txtmk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevent the Enter key from producing a beep sound

                // Perform login logic here
                CheckLogin();
            }
        }
        private void FormLogin_Shown(object sender, EventArgs e)
        {
            txttk.Focus();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Get all open forms except the current form
            Form[] openForms = Application.OpenForms.Cast<Form>()
                                    .Where(f => f != this)
                                    .ToArray();

            // Close each open form
            foreach (Form form in openForms)
            {
                form.Close();
            }
        }

        private void linklbUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cbReadOnly.Visible = true;
        }

        private void cbReadOnly_CheckedChanged(object sender, EventArgs e)
        {          
            if(cbReadOnly.CheckState == CheckState.Checked)
            {
                txttk.Text = "ReadOnly";
                txtmk.Text = "ReadOnly";
                txttk.Enabled = false;
                txtmk.Enabled = false;
            }
            else
            {
                txttk.Enabled = true;
                txtmk.Enabled = true;
                txttk.Text = "";
                txtmk.Text = "";
            }
        }
    }
}

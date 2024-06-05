using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement
{
    public partial class FormChangePassword : Form
    {
        string account;
        string password;
        public FormChangePassword(string acc, string pass)
        {
            InitializeComponent();
            account = acc;
            password = pass;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width-(this.Width/10), this.Height);
        }

        private void FormChangePassword_Load(object sender, EventArgs e)
        {

        }
        private void SetupPosition()
        {
            //setup position
            int stX = panelNote.Location.X;
            int endX = stX + panelNote.Width;


            int subX = (stX + endX) / 2;

            int lbX = lbNote.Width / 2;
            int resultX = subX - lbX;
            lbNote.Location = new Point(resultX, 1);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {        
            string mkc = txtOldmk.Text;
            string mkm = txtNewmk.Text;

            if (!IsValidPassword(mkm)) return;
            if (string.IsNullOrEmpty(mkc) || string.IsNullOrEmpty(mkm))
            {
                lbNote.Text = "Vui lòng điền đầy đủ thông tin!";
                SetupPosition();
                Thread.Sleep(200);
                return;
            }
            try
            {
                Common.StartFormLoading();
                using (var ctx = new DBContext())
                {
                    var accountExist = ctx.Tbl_User.Where(w => w.Account == account).FirstOrDefault();
                    if(accountExist != null)
                    {
                        if(accountExist.PassWord.Trim() == mkc)
                        {
                            accountExist.PassWord = mkm.Trim();
                            ctx.SaveChanges();
                            lbNote.Text = "Đã thay đổi mật khẩu!";
                            SetupPosition();                           
                        }
                        else
                        {
                            lbNote.Text = "Mật khẩu sai!";
                            SetupPosition();                                               
                        }
                    }
                    else
                    {
                        lbNote.Text = "Tài khoản này không được phép thay đổi!";
                        SetupPosition();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }

        private bool IsValidPassword(string mkm)
        {
            
            if (mkm.Length < 4)
            {
                lbNote.Text = "Độ dài mật khẩu mới tối thiểu 4 ký tự!";
                SetupPosition();
                return false;
            }
            if (ContainsSpecialCharacters(mkm))
            {
                lbNote.Text = "Mật khẩu không được chứa ký tự đặc biệt!";
                SetupPosition();
                return false;
            }
            return true;
        }
        static bool ContainsSpecialCharacters(string input)
        {
            // Define a regular expression pattern to match any character that is not a letter or a digit
            string pattern = @"[^a-zA-Z0-9]";

            // Use Regex.IsMatch to check if the input string contains any special characters
            return Regex.IsMatch(input, pattern);
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

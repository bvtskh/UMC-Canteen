using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CanTeenManagement.Utils;
using System.Threading;
using CanTeenManagement.Model;
using CanTeenManagement.Bussiness.SQLHelper;

namespace CanTeenManagement
{
    public partial class Form1 : Form
    {
        MainHelper _mainHelper = new MainHelper();
        public string AccountTypeName { get; set; }
        public string Account { get; set; }
        public string FullName { get; set; }
        public string PassWord { get; set; }
        public static Panel panel;
        public bool isSavePriceMain;
        public Form1()
        {
            panel = panelContent;
            InitializeComponent();
            btnMenuOrder.BackColor = Color.Silver;
            btnMenuOrder.FlatStyle = FlatStyle.Flat;
            Common.AddFormToPanel(new FormOrder(), panelContent);

            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void btnMenuOrder_Click(object sender, EventArgs e)
        {
            AlarmSaveSelectSupplier(isSavePriceMain);
            Button btn = sender as Button;
            Common.ClickButtonMenu(btn, panelMenu);
            Common.AddFormToPanel(new FormOrder(), panelContent);
        }

        private void btnMenuInput_Click(object sender, EventArgs e)
        {
            AlarmSaveSelectSupplier(isSavePriceMain);
            Common.StartFormLoading();
            Button btn = sender as Button;
            Common.ClickButtonMenu(btn, panelMenu);
            Common.AddFormToPanel(new FormInput1(), panelContent);
            Common.CloseFormLoading();
        }

        private void btnMenuOutPut_Click(object sender, EventArgs e)
        {
            AlarmSaveSelectSupplier(isSavePriceMain);
            Common.StartFormLoading();
            Button btn = sender as Button;
            Common.ClickButtonMenu(btn, panelMenu);
            Common.AddFormToPanel(new FormOutput(), panelContent);
            Common.CloseFormLoading();
        }

        private void btnMenuStock_Click(object sender, EventArgs e)
        {
            AlarmSaveSelectSupplier(isSavePriceMain);
            Common.StartFormLoading();
            Button btn = sender as Button;
            Common.ClickButtonMenu(btn, panelMenu);
            Common.AddFormToPanel(new FormStock(), panelContent);
            Common.CloseFormLoading();
        }

        private void btnMenuMaster_Click(object sender, EventArgs e)
        {
            AlarmSaveSelectSupplier(isSavePriceMain);
            Common.StartFormLoading();
            // Create an instance of NewForm
            Button btn = sender as Button;

            Common.ClickButtonMenu(btn, panelMenu);
            Common.AddFormToPanel(new FormMaster(), panelContent);
            Common.CloseFormLoading();               
            
        }
        private void btnMenuMenu_Click(object sender, EventArgs e)
        {
            AlarmSaveSelectSupplier(isSavePriceMain);
            Common.StartFormLoading();
            Button btn = sender as Button;
            Common.ClickButtonMenu(btn, panelMenu);
            Common.AddFormToPanel(new FormMenu(), panelContent);
            Common.CloseFormLoading();
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            if (AccountTypeName == "MEMBER")
            {
               // btnMenuSelectSupplier.Hide();
                lbPosition.Text = "[Member]".Trim();
            }
            else if (AccountTypeName == "ADMIN")
            {
                //btnMenuSelectSupplier.Show();
                lbPosition.Text = "[ADMIN]".Trim();
            }
            else if( AccountTypeName == "ReadOnly")
            {
                lbPosition.Text = "[Tài khoản khách]".Trim();
            }
            if(Account.Trim() =="admin" || Account.Trim() == "ReadOnly")
            {
                lbAccount.Text = "Xin chào: " + Account.Trim();
            }
            else
            {
                lbAccount.Text = "Xin chào: " + FullName.Trim() + " - " + Account.Trim();
            }
            
            //setup position lbAcc
            int stX = panel7.Location.X;
            int endX = stX + panel7.Width;
            int subX = (stX + endX) / 2;
            int lbX = lbAccount.Width / 2;
            int resultX = subX - lbX;
            lbAccount.Location = new Point(resultX, 3);

            //setup position lbType Acc
            int stXX = panel8.Location.X;
            int endXX = stXX + panel8.Width;
            int subXX = (stXX + endXX) / 2;
            int lbXX = lbPosition.Width / 2;
            int resultXX = subXX - lbXX;
            lbPosition.Location = new Point(resultXX, 3);
        }     

        private void btnMenuSelectSupplier_Click(object sender, EventArgs e)
        {
            AlarmSaveSelectSupplier(isSavePriceMain);
            Common.StartFormLoading();
            Button btn = sender as Button;
            Common.ClickButtonMenu(btn, panelMenu);
            Common.AddFormToPanel(new FormSelectSupplier(), panelContent);
            Common.CloseFormLoading();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSupplier formSupplier = new FormSupplier();
            formSupplier.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
         
            // Create menu options as labels
            ToolStripMenuItem option1 = new ToolStripMenuItem("Đăng xuất");         
            ToolStripMenuItem option2 = new ToolStripMenuItem("Thoát");
            ToolStripMenuItem option3 = new ToolStripMenuItem("Đổi mật khẩu");
            ToolStripMenuItem option4 = new ToolStripMenuItem("Quản lý tài khoản");
            ToolStripMenuItem option5 = new ToolStripMenuItem("Backup dữ liệu");
            ToolStripMenuItem option6 = new ToolStripMenuItem("Chỉnh sửa đặt hàng");
            option1.Image = Properties.Resources.icons8_login_24;
            option3.Image = Properties.Resources.circle;
            option2.Image = Properties.Resources.x;
            option4.Image = Properties.Resources.view1;
            option5.Image = Properties.Resources.loading;
            if (Account.Trim() != "admin")
            {
                // Add menu options to the context menu
                menu.Items.Add(option1);
                menu.Items.Add(option2);
                menu.Items.Add(option3);
            }
            else
            {
                // Add menu options to the context menu
                menu.Items.Add(option1);
                menu.Items.Add(option2);
                menu.Items.Add(option3);
                menu.Items.Add(option4);
                menu.Items.Add(option5);
                menu.Items.Add(option6);
            }
            
            // Handle option selection
            option1.Click += Option1_Click;
            option2.Click += Option2_Click;
            option3.Click += Option3_Click;
            option4.Click += Option4_Click;
            option5.Click += Option5_Click;
            option6.Click += Option6_Click;
            // Show the context menu
            menu.Show(button1, new Point(0, button1.Height));
        }

        private void Option6_Click(object sender, EventArgs e)
        {
            FormChangeOrder f = new FormChangeOrder();
            f.Show();
        }

        private void Option5_Click(object sender, EventArgs e)
        {
            Common.BackupData();
        }

        private void Option4_Click(object sender, EventArgs e)
        {
            FormAccountManagement facc = new FormAccountManagement();
            facc.ShowDialog();
        }

        private void Option3_Click(object sender, EventArgs e)
        {
            FormChangePassword fchange = new FormChangePassword(Account,PassWord);
            fchange.ShowDialog();
        }

        private void Option1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin newForm = new FormLogin();
            newForm.Show();
            // Get all open forms except the current form
            Form[] openForms = Application.OpenForms.Cast<Form>()
                                    .Where(f => f != this)
                                    .ToArray();
            for(int form = 0; form < openForms.Count(); form++)
            {
                if(openForms[form].Name != "FormLogin")
                openForms[form].Close();
            }                                  
        }
        private void Option2_Click(object sender, EventArgs e)
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btnMenuThucDonNhe_Click(object sender, EventArgs e)
        {
            Common.StartFormLoading();
            Button btn = sender as Button;
            Common.ClickButtonMenu(btn, panelMenu);
            Common.AddFormToPanel(new FormMenuNhe(), panelContent);
            Common.CloseFormLoading();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AlarmSaveSelectSupplier(isSavePriceMain);
        }
        private void AlarmSaveSelectSupplier(bool isSavePriceMain)
        {
            FormSelectSupplier formSupplier = FindFormLast();
            if(formSupplier != null)
            {
                if (!isSavePriceMain && formSupplier.isUpdate) // form supplier phải có thay đổi thì mới được tính là chưa cập nhật.
                {
                    DialogResult log = MessageBox.Show("Chưa lưu thay đổi cập nhật báo giá, bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (log == DialogResult.Yes)
                    {
                        formSupplier.FindInfomationPrice();
                        formSupplier.SaveAndSelectPriceMain();
                        formSupplier.isUpdate = false;
                        isSavePriceMain = false;
                    }
                    else
                    {
                        formSupplier.isUpdate = false;
                        isSavePriceMain = false;
                    }
                }
            }
           
        }
        private FormSelectSupplier FindFormLast()
        {
            List<Form> FormList = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                string formName = form.Name;
                if (formName == "FormSelectSupplier")
                {
                    FormList.Add(form);
                }
            }
            if (FormList.Count > 0)
            {
                var LastForm = (FormSelectSupplier)FormList.Last();
                return LastForm;
            }
            else 
            {
                return null;
            }           
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            Common.StartFormLoading();
            AlarmSaveSelectSupplier(isSavePriceMain);
            Button btn = sender as Button;
            Common.ClickButtonMenu(btn, panelMenu);
            Common.AddFormToPanel(new FormStatistic(), panelContent);
            Common.CloseFormLoading();
        }

        private void btnOverTime_Click(object sender, EventArgs e)
        {
            Common.StartFormLoading();
            AlarmSaveSelectSupplier(isSavePriceMain);
            Button btn = sender as Button;
            Common.ClickButtonMenu(btn, panelMenu);
            Common.AddFormToPanel(new FormOverTime(), panelContent);
            Common.CloseFormLoading();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbRealtime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt");
        }
    }
}

using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.Menu;

namespace CanTeenManagement
{
    public partial class FormMenu : Form
    {
        int currentMonth;
        int currentYear;
        private SelectMenu menuType;
        MenuForm selectMenuForm;

        MenuHelper _menuHelper = new MenuHelper();
        public FormMenu()
        {
            InitializeComponent();
            cbMonth.DataSource = _menuHelper.GetMonth();
            cbYear.DataSource = _menuHelper.GetYear(DateTime.Now);
            cbMonth.Text = DateTime.Now.Month.ToString();
            cbYear.Text = DateTime.Now.Year.ToString();
            cbMonthUse.DataSource = _menuHelper.GetMonth();
            cbYearUse.DataSource = _menuHelper.Get2YearAgo(DateTime.Now);
            cbMonthUse.Text = DateTime.Now.AddMonths(-1).Month.ToString();
            cbYearUse.Text = DateTime.Now.Year.ToString();
            currentMonth = DateTime.Now.Month;
            currentYear = DateTime.Now.Year;
            menuType = SelectMenu.MainMenu;
        }

        private void btnMenuChinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckChangeMenu())
                {
                    return;
                }
                Common.AddFormToPanel(new FormMenuChinh(), panelcontent);
                txtMonth.Text = DateTime.Now.Month + "/" + DateTime.Now.Year;
                btnMenuNhe.BackColor = Color.White;
                btnMenuChinh.BackColor = Color.LemonChiffon;
                btnMenuNhe.FlatAppearance.BorderSize = 0;
                btnMenuChinh.FlatAppearance.BorderSize = 1;
                menuType = SelectMenu.MainMenu;
                selectMenuForm = MenuForm.FormMenuChinh;
                cbMonth.SelectedItem = DateTime.Now.Month.ToString();
                cbYear.SelectedItem = DateTime.Now.Year.ToString();
                _menuHelper.FindAndCloseForm(MenuForm.FormMenuChinh.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex);
            }
        }

        private bool CheckChangeMenu()
        {
            var findMenuChinh = (FormMenuChinh)_menuHelper.FindForm(MenuForm.FormMenuChinh.ToString());
            var findMenuNhe = (FormMenuNhe)_menuHelper.FindForm(MenuForm.FormMenuNhe.ToString());
            if (findMenuChinh != null)
            {
                if (findMenuChinh.isChangeMenu == true)
                {
                    DialogResult log = MessageBox.Show("Bạn đã thay đổi dữ liệu và chưa lưu lại. Tiếp tục chuyển đến mục khác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (log == DialogResult.No)
                    {
                        return false;
                    }
                    else if(log == DialogResult.Yes)
                    {
                        findMenuChinh.isChangeMenu = false;
                        return true;
                    }
                }
            }
            if (findMenuNhe != null)
            {
                if (findMenuNhe.isChangeMenu == true)
                {
                    DialogResult log = MessageBox.Show("Bạn đã thay đổi dữ liệu và chưa lưu lại. Tiếp tục chuyển đến mục khác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (log == DialogResult.No)
                    {
                        return false;
                    }
                    else if (log == DialogResult.Yes)
                    {
                        findMenuNhe.isChangeMenu = false;
                        return true;
                    }
                }
            }
            return true;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            
            txtMonth.Text = DateTime.Now.Month + "/" + DateTime.Now.Year;
            Common.AddFormToPanel(new FormMenuChinh(), panelcontent);
            btnMenuNhe.BackColor = Color.White;
            btnMenuNhe.FlatAppearance.BorderSize = 0;
            LimitedAccess();
        }
        private void LimitedAccess()
        {
            //phân quyền
            var LastForm = Common.LastLoginForm();
            if (LastForm.accountTypeName == "ReadOnly")
            {
                Common.DisableAllButtons(this);
            }
        }

        private void btnGetdataOldMonth_Click(object sender, EventArgs e)
        {
            if (!CheckChangeMenu())
            {
                return;
            }
            if (currentMonth < DateTime.Now.Month && currentYear <= DateTime.Now.Year)
            {
                MessageBox.Show("Không được phép thay đổi dữ liệu của tháng nhỏ hơn tháng hiện tại!");
                return;
            }
            try
            {
                if (!_menuHelper.IsImportDataOldMonth(menuType, cbMonthUse.SelectedItem.ToString(), cbYearUse.SelectedItem.ToString(), selectMenuForm.ToString()))
                {
                    MessageBox.Show("Không tìm thấy dữ liệu!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra : "+ex.Message);
            }
        }

        private void btnMenuNhe_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckChangeMenu())
                {
                    return;
                }
                Common.AddFormToPanel(new FormMenuNhe(), panelcontent);
                txtMonth.Text = DateTime.Now.Month + "/" + DateTime.Now.Year;

                btnMenuChinh.BackColor = Color.White;
                btnMenuNhe.BackColor = Color.LemonChiffon;
                btnMenuChinh.FlatAppearance.BorderSize = 0;
                btnMenuNhe.FlatAppearance.BorderSize = 1;
                menuType = SelectMenu.SideMenu;
                selectMenuForm = MenuForm.FormMenuNhe;
                cbMonth.SelectedItem = DateTime.Now.Month.ToString();
                cbYear.SelectedItem = DateTime.Now.Year.ToString();
                _menuHelper.FindAndCloseForm("FormMenuNhe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex);       
            }
            finally
            {
                Common.CloseFormLoading();
            }
            
        }
        private void btnMenuSearch_Click(object sender, EventArgs e)
        {
            if (!CheckChangeMenu())
            {
                return;
            }
            var month = cbMonth.SelectedValue.ToString();
            var year = cbYear.SelectedValue.ToString();
            currentMonth = int.Parse(month);
            currentYear = int.Parse(year);
            try
            {         
                var ListOfMenu = _menuHelper.getDataOfMenu(month,year,menuType);
                txtMonth.Text = month + "/" + year;
                
                if (menuType == SelectMenu.MainMenu)
                {
                    Common.AddFormToPanel(new FormMenuChinh(int.Parse(month), int.Parse(year), ListOfMenu), panelcontent);
                    btnMenuNhe.BackColor = Color.White;
                    btnMenuChinh.BackColor = Color.LemonChiffon;
                    btnMenuNhe.FlatAppearance.BorderSize = 0;
                    btnMenuChinh.FlatAppearance.BorderSize = 1;
                }
                else if (menuType == SelectMenu.SideMenu)
                {
                    Common.AddFormToPanel(new FormMenuNhe(int.Parse(month), int.Parse(year), ListOfMenu), panelcontent);
                    btnMenuChinh.BackColor = Color.White;
                    btnMenuNhe.BackColor = Color.LemonChiffon;
                    btnMenuChinh.FlatAppearance.BorderSize = 0;
                    btnMenuNhe.FlatAppearance.BorderSize = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }
    }
}

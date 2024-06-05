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
    public partial class FormMenuNhe : Form
    {
        FormMenu formMenu;
        MenuHelper _menuHelper = new MenuHelper();
        public bool isChangeMenu = false;
        public FormMenuNhe()
        {
            InitializeComponent();
            cbDayInMonth.DataSource = _menuHelper.GetDates(DateTime.Now.Year, DateTime.Now.Month);
            int rowIndex = 1;
            foreach (var item in _menuHelper.GetDates(DateTime.Now.Year, DateTime.Now.Month))
            {
                DateTime givenDate = DateTime.ParseExact(item, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DayOfWeek dayOfWeek = givenDate.DayOfWeek;
                dgrMenu.Rows.Add();
                dgrMenu.Rows[rowIndex - 1].Cells[0].Value = item;
                dgrMenu.Rows[rowIndex - 1].Cells[1].Value = _menuHelper.CheckDay(dayOfWeek).ToString();
                rowIndex++;
            }
        }

        private void SetDropdownComboxbox()
        {
            panelSelect.Controls.OfType<ComboBox>().ToList().ForEach(f => f.DropDownHeight = f.ItemHeight * 8);
        }

        public FormMenuNhe(int month, int year, List<Tbl_Menu> menuList)
        {
            InitializeComponent();
            cbDayInMonth.DataSource = _menuHelper.GetDates(year, month);
            if (year > DateTime.Now.Year)
            {
                btnSaveMenu.Enabled = true;
                btnSaveDatabase.Enabled = true;
            }
            else if (year == DateTime.Now.Year)
            {
                if (month >= DateTime.Now.Month)
                {
                    btnSaveMenu.Enabled = true;
                    btnSaveDatabase.Enabled = true;
                }
                else
                {
                    btnSaveMenu.Enabled = false;
                    btnSaveDatabase.Enabled = false;
                }
            }
            else
            {
                btnSaveMenu.Enabled = false;
                btnSaveDatabase.Enabled = false;
            }
            int rowIndex = 1;
            foreach (var item in _menuHelper.GetDates(year, month))
            {
                DateTime givenDate = DateTime.ParseExact(item, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DayOfWeek dayOfWeek = givenDate.DayOfWeek;
                dgrMenu.Rows.Add();
                dgrMenu.Rows[rowIndex - 1].Cells[0].Value = item;
                dgrMenu.Rows[rowIndex - 1].Cells[1].Value = _menuHelper.CheckDay(dayOfWeek).ToString();
                rowIndex++;
            }
            MenuSearchResult(menuList);
            SetDropdownComboxbox();
        }

        private void ClearText()
        {
            panelSelect.Controls.OfType<TextBox>().ToList().ForEach(f => f.Clear());
        }

        private void FormMenuNhe_Load(object sender, EventArgs e)
        {
            var dataList = _menuHelper.getDataOfMenu(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), SelectMenu.SideMenu);
            MenuSearchResult(dataList);
            SetDropdownComboxbox();
            SetTagForTextbox();
            formMenu = _menuHelper.FindLastFormMenu();
            if (formMenu != null)
            {
                formMenu.lbAlarmChangeMenu.Visible = false;
                formMenu.picAlarmChangeMenu.Visible = false;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Common.StartFormLoading();
                    string filePath = saveFileDialog.FileName;
                    _menuHelper.ExportFromDataGridViewToExcel(dgrMenu, filePath);
                    Common.CloseFormLoading();
                    MessageBox.Show("Đã Xuất ra File Excel thành công!", "Thông báo!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }     
        private void dgrMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                DataGridViewRow row = dgrMenu.Rows[e.RowIndex];
                cbDayInMonth.Text = row.Cells[0].Value.ToString();
                SelectValueDgvMenu(row);
            }
        }

        private void cbDayInMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearText();
            var row = dgrMenu.Rows.Cast<DataGridViewRow>().Where(w => w.Cells[0].Value.ToString() == cbDayInMonth.Text).FirstOrDefault();
            if (row != null)
            {
                SelectValueDgvMenu(row);
            }
        }

        private void SelectValueDgvMenu(DataGridViewRow row)
        {
            txtEatDessert1.Text = row.Cells[2].Value?.ToString();
            txtEatDessert2.Text = row.Cells[3].Value?.ToString();
            txtEatDessert3.Text = row.Cells[4].Value?.ToString();
            txtEatDessert4.Text = row.Cells[5].Value?.ToString();
            txtEatDessert5.Text = row.Cells[6].Value?.ToString();
        }

        private void btnSaveMenu_Click(object sender, EventArgs e)
        {
            isChangeMenu = false;
            try
            {
                List<string> dishListOnTextbox = new List<string>();
                panelSelect.Controls.OfType<TextBox>().ToList().ForEach(f => dishListOnTextbox.Add(f.Text));
                if (!_menuHelper.IsValidName(dishListOnTextbox))
                {
                    MessageBox.Show("Thực phẩm bạn vừa thêm chưa đúng. hãy kiểm tra lại!");
                    return;
                }
                var dateSave = cbDayInMonth.SelectedItem.ToString();
                foreach (DataGridViewRow row in dgrMenu.Rows)
                {
                    string date = dgrMenu.Rows[row.Index].Cells[0].Value.ToString();
                    if (date == dateSave)
                    {
                        dgrMenu.Rows[row.Index].Cells[2].Value = txtEatDessert1.Text.ToString();
                        dgrMenu.Rows[row.Index].Cells[3].Value = txtEatDessert2.Text.ToString();
                        dgrMenu.Rows[row.Index].Cells[4].Value = txtEatDessert3.Text.ToString();
                        dgrMenu.Rows[row.Index].Cells[5].Value = txtEatDessert4.Text.ToString();
                        dgrMenu.Rows[row.Index].Cells[6].Value = txtEatDessert5.Text.ToString();
                        if(formMenu != null)
                        {
                            formMenu.lbAlarmChangeMenu.Visible = true;
                            formMenu.picAlarmChangeMenu.Visible = true;
                            formMenu.lbAlarmChangeMenu.Text = "Hãy lưu lại dữ liệu sau khi thay đổi!";
                            formMenu.picAlarmChangeMenu.Image = Properties.Resources.alarm;
                            isChangeMenu = true;
                        }
                    }
                }                    
            }           
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }
        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            if (isChangeMenu != true)
            {
                MessageBox.Show("Có vẻ như bạn chưa thay đổi thực đơn? Lưu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DialogResult dialogResult = MessageBox.Show("Bạn đã chắc chắn lưu lại?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (_menuHelper.SaveChangeMenu(dgrMenu, SelectMenu.SideMenu))
                    {
                        if (formMenu != null)
                        {
                            formMenu.lbAlarmChangeMenu.Visible = true;
                            formMenu.picAlarmChangeMenu.Visible = true;
                            formMenu.lbAlarmChangeMenu.Text = "Dữ liệu Menu đã được thay đổi!";
                            formMenu.picAlarmChangeMenu.Image = Properties.Resources.success;
                        }
                        MessageBox.Show("Đã Lưu thành công!", "Thông báo!");
                        isChangeMenu = false;
                    }                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }  
        }
       
        public void ImportDataOldMonth(List<Tbl_Menu> menu)
        {
            try
            {
                if (menu.Count > 0)
                {
                    foreach (DataGridViewRow row in dgrMenu.Rows)
                    {
                        for (int cell = 2; cell < row.Cells.Count; cell++)
                        {
                            row.Cells[cell].Value = null;
                        }
                    }
                    foreach (var item in menu)
                    {
                        for (int row = 0; row < dgrMenu.RowCount; row++)
                        {
                            var rowDateTime = dgrMenu.Rows[row].Cells[0].Value.ToString();
                            var converDate = DateTime.ParseExact(rowDateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            if (converDate.Day == item.Date.Value.Day)
                            {
                                SetValueToDGV(row, item);
                            }
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetValueToDGV(int row, Tbl_Menu item)
        {
            dgrMenu.Rows[row].Cells[2].Value = _menuHelper.GetDishName(item.SideMeal1);
            dgrMenu.Rows[row].Cells[3].Value = _menuHelper.GetDishName(item.SideMeal2);
            dgrMenu.Rows[row].Cells[4].Value = _menuHelper.GetDishName(item.SideMeal3);
            dgrMenu.Rows[row].Cells[5].Value = _menuHelper.GetDishName(item.SideMeal4);
            dgrMenu.Rows[row].Cells[6].Value = _menuHelper.GetDishName(item.SideMeal5);
        }

        public void MenuSearchResult(List<Tbl_Menu> menuList)
        {
            dgrMenu.AllowUserToAddRows = false;
            dgrMenu.AutoGenerateColumns = false;
            try
            {
                for (int i = 0; i < menuList.Count; i++)
                {
                    var item = menuList[i];
                    for (int j = 0; j < dgrMenu.RowCount; j++)
                    {
                        string dte = item.Date.Value.ToString("dd-MM-yyyy");
                        if (dte == dgrMenu.Rows[j].Cells[0].Value.ToString())
                        {
                            string date = item.Date.Value.ToString("dd-MM-yyyy");
                            DateTime givenDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            DayOfWeek dayOfWeek = givenDate.DayOfWeek;

                            dgrMenu.Rows[j].Cells[0].Value = item.Date.Value.ToString("dd-MM-yyyy");
                            dgrMenu.Rows[j].Cells[1].Value = _menuHelper.CheckDay(dayOfWeek).ToString();
                            SetValueToDGV(j, item);
                        }
                    }
                }               
                cbDayInMonth.Text = DateTime.Now.ToString("dd-MM-yyyy");
                cbDayInMonth.MaxDropDownItems = 8;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }       

        private void xóaThựcĐơnNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectRow = dgrMenu.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            var a = selectRow.Cells[0];
            if (selectRow != null)
            {
                DialogResult log = MessageBox.Show($"Xác nhận xóa thực đơn của ngày {selectRow.Cells[0].Value.ToString()} ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (log == DialogResult.Yes)
                {
                    var convertDate = DateTime.ParseExact(selectRow.Cells[0].Value.ToString(), "dd-MM-yyyy", null);
                    if (convertDate.Year <= DateTime.Now.Year)
                    {
                        if (convertDate.Year < DateTime.Now.Year || (convertDate.Year == DateTime.Now.Year && convertDate.Month < DateTime.Now.Month))
                        {
                            MessageBox.Show("Không được xóa dữ liệu trong quá khứ!");
                            return;
                        }
                    }
                    if (_menuHelper.DeleteThisMenuSelected(convertDate, SelectMenu.SideMenu))
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        for (int index = 2; index < selectRow.Cells.Count; index++)
                        {
                            selectRow.Cells[index].Value = null;
                        }
                    }
                }
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int value = hScrollBar1.Value;
            panelSelect.Left = -value;
        }
        private void SetTagForTextbox()
        {
            txtEatDessert1.Tag = cbEatDessert1;
            txtEatDessert2.Tag = cbEatDessert2;
            txtEatDessert3.Tag = cbEatDessert3;
            txtEatDessert4.Tag = cbEatDessert4;
            txtEatDessert5.Tag = cbEatDessert5;

            cbEatDessert1.Tag = txtEatDessert1;
            cbEatDessert2.Tag = txtEatDessert2;
            cbEatDessert3.Tag = txtEatDessert3;
            cbEatDessert4.Tag = txtEatDessert4;
            cbEatDessert5.Tag = txtEatDessert5;
        }
        private void cbDish_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cbSelect = sender as ComboBox;
                if (cbSelect != null)
                {
                    TextBox associatedTextbox = cbSelect.Tag as TextBox;

                    Tbl_Dish dishselect = (Tbl_Dish)cbSelect.SelectedItem;
                    string dishName = dishselect.Dish.ToString();

                    if (!IsAvalidDish(associatedTextbox, dishName))
                    {
                        MessageBox.Show("Món này đã được chọn. Vui lòng chọn món khác!", "Thông báo!");
                        associatedTextbox.Clear();
                        return;
                    }

                    var ingredientInvalid = _menuHelper.GetIngredientListInvalid(dishselect);
                    if (ingredientInvalid.Count > 0)
                    {
                        string elementsText = string.Join(", ", ingredientInvalid);
                        MessageBox.Show($"Nguyên liệu: {elementsText}.\nNằm trong món: {dishName} không có báo giá trong tháng này!\nHãy xem lại thành phần món ăn hoặc cập nhật lại báo giá từ nhà cung cấp!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    associatedTextbox.Text = dishselect.Dish.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private bool IsAvalidDish(TextBox associatedTextbox, string dishName)
        {
            List<TextBox> textboxList = panelSelect.Controls.OfType<TextBox>().Where(w => w.Name != associatedTextbox.Name).ToList();
            foreach (var box in textboxList)
            {
                if (box.Text == dishName) return false;
            }
            return true;
        }
        private void txtDish_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox keyDowntxt = sender as TextBox;
            if (keyDowntxt != null)
            {
                ComboBox associatedComboBox = keyDowntxt.Tag as ComboBox;
                if (associatedComboBox != null)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (!string.IsNullOrEmpty(keyDowntxt.Text))
                        {
                            string searchText = keyDowntxt.Text;
                            var elements = _menuHelper.GetIngredietListBySearchstr(searchText);
                            associatedComboBox.DroppedDown = false;
                            // Clear the ComboBox items
                            associatedComboBox.Items.Clear();

                            // Add the retrieved elements to the ComboBox
                            associatedComboBox.Items.AddRange(elements.ToArray());
                            associatedComboBox.DroppedDown = true;
                            Cursor.Current = Cursors.Default;
                            associatedComboBox.DisplayMember = "Dish";                                                      
                        }
                    }
                }
            }
        }
        private void txtDish_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox clickedTextBox = sender as TextBox;
            if (clickedTextBox != null)
            {
                clickedTextBox.SelectAll();
            }
        }
    }
}

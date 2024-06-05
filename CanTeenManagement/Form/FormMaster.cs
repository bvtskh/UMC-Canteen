using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement
{
    public partial class FormMaster : Form
    {
        MasterHelper _masterHelper = new MasterHelper();
        public FormMaster()
        {
            InitializeComponent();
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            Common.StartFormLoading();
            FormAddIngredient frm = new FormAddIngredient("");
            Common.CloseFormLoading();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.Cancel)
            {
                btnSearchIngredient_Click(null, null);
            }
        }

        private void btnSearchIngredient_Click(object sender, EventArgs e)
        {
            SearchIngredient(txtSearchIngredient.Text);
        }
        private void SearchIngredient(string text)
        {
            try
            {
                dgvIngredient.AutoGenerateColumns = false;
                dgvIngredient.DataSource = _masterHelper.GetIngredientBySearchStr(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void dgvIngredient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvIngredient.Rows[e.RowIndex];
                btnEditIngredient.Tag = row.Cells["IngredientCode"].Value;
                btnDelete.Tag = row.Cells["IngredientCode"].Value;
            }
        }

        private void btnEditIngredient_Click(object sender, EventArgs e)
        {
            if (btnEditIngredient.Tag != null)
            {
                FormAddIngredient formAddIngredient = new FormAddIngredient(btnEditIngredient.Tag.ToString());
                formAddIngredient.ShowDialog();
                if (formAddIngredient.DialogResult == DialogResult.Cancel)
                {
                    btnSearchIngredient_Click(null, null);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn nguyên liệu.", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnDelete.Tag != null)
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa nguyên liệu?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (_masterHelper.IsDeleteIngredient(btnDelete.Tag.ToString()))
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn nguyên liệu.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void btnSearchDish_Click(object sender, EventArgs e)
        {
            SearchDish(txtSearchDish.Text);
        }

        private void SearchDish(string text)
        {
            try
            {              
                dgvDish.AutoGenerateColumns = false;
                dgvDish.DataSource = _masterHelper.GetDishBySearchStr(text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            FormAddDish formAddDish = new FormAddDish("");
            formAddDish.ShowDialog();
            btnSearchDish_Click(null, null);
        }

        private void dgvDish_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                dgvQuantitative.AutoGenerateColumns = false;
                var dishCode = dgvDish.Rows[e.RowIndex].Cells[0].Value;

                dgvQuantitative.DataSource = _masterHelper.GetQuantitativeOfDish(dishCode);
                if (e.RowIndex >= 0)
                {
                    var row = dgvDish.Rows[e.RowIndex];
                    btnDelDish.Tag = row.Cells["DishCode"].Value;
                    btnEditDish.Tag = row.Cells["DishCode"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }
        private void btnEditDish_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDish.RowCount < 1)
                {
                    MessageBox.Show("Bạn chưa chọn món!");
                    return;
                }
                DataGridViewRow row = dgvDish.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
                string dishCode = row.Cells[0].Value.ToString();
                FormAddDish formAddDish = new FormAddDish(dishCode);
                formAddDish.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }
        private void FormMaster_Load(object sender, EventArgs e)
        {
            dgvDish.AutoGenerateColumns = false;           
            LimitedAccess();
        }
        private void LimitedAccess()
        {
            //phân quyền
            var LastForm = Common.LastLoginForm();
            if (LastForm.accountTypeName == "MEMBER")
            {
                Button btnBaoGia = Controls.Find("btnBaoGia", true).FirstOrDefault() as Button;

                if (btnBaoGia != null)
                {
                    btnBaoGia.Enabled = false;
                }
            }
            else if (LastForm.accountTypeName == "ReadOnly")
            {
                Common.DisableAllButtons(this);
            }
        }
        private void btnDelDish_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnDelDish.Tag != null)
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa món ăn này ???", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (_masterHelper.IsDeleteDish(btnDelDish.Tag.ToString()))
                        {
                            btnSearchDish_Click(null, null);
                            MessageBox.Show("Thành công", "Thông báo");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Chưa chọn món!.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void btnBaoGia_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Common.StartFormLoading();
                    if (_masterHelper.ExportXinBaoGia(saveFileDialog))
                    {                  
                        Common.CloseFormLoading();
                        MessageBox.Show("Tạo file báo giá thành công.", "Thông báo");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred:" + ex.Message);
                }
                finally
                {
                    Common.CloseFormLoading();
                }
            }
        }
     
        private void txtSearchIngredient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchIngredient(txtSearchIngredient.Text);
            }
        }

        private void txtSearchDish_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchDish(txtSearchDish.Text);
            }
        }
    }
}

using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement
{
    public partial class FormSupplierPriority : Form
    {
        string dayOfDN = "Thứ: 2, 4, 6";
        string dayOfHX = "Thứ: 3, 5, 7";
        public FormSupplierPriority()
        {
            InitializeComponent();
            cbIngredient.DropDownHeight = cbIngredient.ItemHeight * 8;
        }

        private void FormSupplierPriority_Load(object sender, EventArgs e)
        {
            ShowInfomation();
            ShowPriorityIngredient();
        }
        string supplier = "";
        private void ShowInfomation()
        {
           
            if (FindSupplier(FindToDay(DateTime.Now)) == dayOfDN)
            {
                supplier = "Đỗ Nguyên";
            }
            else if((FindSupplier(FindToDay(DateTime.Now)) == dayOfHX))
            {
                supplier = "Hữu Xuất";
            }
            else
            {
                supplier = "Chủ nhật không đặt hàng";
            }
            lbDayOfWeek.Text =  ConvertToVNDate(FindToDay(DateTime.Now));
            lbDay.Text = "Ngày: " + DateTime.Now.Date.ToString("dd-MM-yyyy");
            lbSupplierSelected.Text = "Đang chọn nhà cung cấp: " + supplier;
            lbDaysSelect.Text = "Chọn cho: "+FindSupplier(FindToDay(DateTime.Now));
        }

        private string ConvertToVNDate(string day)
        {
            if (day == "Monday")
            {
                return "Thứ hai";
            }
            else if (day == "Tuesday")
            {
                return "Thứ ba";
            }
            else if (day == "Wednesday")
            {
                return "Thứ tư";
            }
            else if (day  == "Thursday")
            {
                return "Thứ năm";
            }
            else if (day == "Friday")
            {
                return "Thứ sáu";
            }
            else if (day ==  "Saturday")
            {
                return "Thứ bảy";
            }
            else if (day == "Sunday")
            {
                return "Chủ nhật";
            }
            return "";
        }

        private void ShowPriorityIngredient()
        {
            using(var ctx = new DBContext())
            {
                var listIngredeient = ctx.Tbl_Ingredient.Where(w => w.SupplierPriorityCode != null).ToList();
                foreach(var item in listIngredeient)
                {
                    dgvIngredient.Rows.Add();
                    int index = dgvIngredient.RowCount - 1;
                    dgvIngredient.Rows[index].Cells[0].Value = item.IngredientCode;
                    dgvIngredient.Rows[index].Cells[1].Value = item.IngredientName;
                    dgvIngredient.Rows[index].Cells[2].Value = item.Unit;
                    dgvIngredient.Rows[index].Cells[3].Value = item.Spec;
                    if(item.SupplierPriorityCode == null)
                    {
                        dgvIngredient.Rows[index].Cells[4].Value = "Chủ nhật không đặt hàng!";
                    }
                    else
                    {
                        dgvIngredient.Rows[index].Cells[4].Value = ctx.Tbl_Supplier.Where(w => w.SupplierCode == item.SupplierPriorityCode).Select(s => s.SupplierName).FirstOrDefault();

                    }
                    string supplierDay = FindSupplier(FindToDay(DateTime.Now));
                    dgvIngredient.Rows[index].Cells[5].Value = supplierDay;
                }                              
            }
        }

        private string FindSupplier(string day)
        {
            if (day == "Monday" ||day == "Wednesday" || day == "Friday")
            {
                return dayOfDN;
            }
            else if (day == "Tuesday" || day == "Thursday" || day == "Saturday")
            {
                return dayOfHX;
            }
            return "Chủ nhật không đặt hàng!";
        }

        private string FindToDay(DateTime now)
        {
            return now.DayOfWeek.ToString();
        }

        private void txtIngredient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtIngredient.Text))
                {
                    Common.StartFormLoading();
                    using (var dbContext = new DBContext())
                    {
                        string searchText = txtIngredient.Text;

                        // Retrieve elements from the database based on the search text
                        var elements = dbContext.Tbl_Ingredient.Where(w => w.IngredientName.Contains(searchText)).ToList();
                        //var element = dbContext.Tbl_Ingredient.Where(w => w.SafeStock != 0).ToList();
                        //var elements = element.Where(w => w.IngredientName.Contains((searchText))).ToList();
                        Thread.Sleep(200);
                        Common.CloseFormLoading();
                        cbIngredient.DroppedDown = false;
                        //  the ComboBox items
                        cbIngredient.Items.Clear();

                        // Add the retrieved elements to the ComboBox
                        cbIngredient.Items.AddRange(elements.ToArray());
                        cbIngredient.DroppedDown = true;
                        Cursor.Current = Cursors.Default;
                        cbIngredient.DisplayMember = "IngredientName";
                    }
                }
            }
        }

        private void cbIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tbl_Ingredient dishselect = (Tbl_Ingredient)cbIngredient.SelectedItem;
            if (dishselect == null) return;
            txtIngredient.Text = dishselect.IngredientName.ToString();
            using (var ctx = new DBContext())
            {
                var getUnit = ctx.Tbl_Ingredient.Where(w => w.IngredientName == txtIngredient.Text.ToString()).Select(s => s.Unit).FirstOrDefault();
                lbUnit.Text = getUnit;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIngredient.Text)) return;
            try
            {
                var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DialogResult dialog = MessageBox.Show("bạn có chắc chắn thêm vào danh sách thực phẩm ưu tiên không?", "Thông báo", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    using (var ctx = new DBContext())
                    {
                        var item = ctx.Tbl_Ingredient.Select(w => w.IngredientName).ToList();

                        if (!item.Contains(txtIngredient.Text.ToString()))
                        {
                            MessageBox.Show("Tên thực phẩm không phù hợp!", "Thông báo");
                            return;
                        }
                        else
                        {
                            var ingredientCode = ctx.Tbl_Ingredient.Where(w => w.IngredientName == txtIngredient.Text).Select(s => s.IngredientCode).FirstOrDefault();
                            var check = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingredientCode && w.ApprovalDate == date && w.PriceMain == 1).FirstOrDefault();
                            if (check == null)
                            {
                                MessageBox.Show("Thực phẩm này chưa được cập nhật giá!");
                                txtIngredient.Clear();
                                return;
                            }
                        }

                        var checkExsitIngredient = dgvIngredient.Rows.Cast<DataGridViewRow>().Where(w => w.Cells[1].Value.ToString() == txtIngredient.Text).FirstOrDefault();
                        if (checkExsitIngredient == null)
                        {
                            dgvIngredient.Rows.Add();
                            var index = dgvIngredient.RowCount - 1;
                            var ingredientCode = ctx.Tbl_Ingredient.Where(w => w.IngredientName == txtIngredient.Text).Select(s => s.IngredientCode).FirstOrDefault();
                            dgvIngredient.Rows[index].Cells[0].Value = ingredientCode;
                            dgvIngredient.Rows[index].Cells[1].Value = txtIngredient.Text;
                            dgvIngredient.Rows[index].Cells[2].Value = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).Select(s => s.Unit).FirstOrDefault();
                            dgvIngredient.Rows[index].Cells[3].Value = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).Select(s => s.Spec).FirstOrDefault();
                            dgvIngredient.Rows[index].Cells[4].Value = supplier;
                            dgvIngredient.Rows[index].Cells[5].Value = FindSupplier(FindToDay(DateTime.Now));
                        }
                        else
                        {
                            MessageBox.Show("Nguyên liệu này đã có trong danh sách rồi!");
                            return;
                        }
                    }
                }
                else if (dialog == DialogResult.No)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void btnNotSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowSelected != null && rowSelected.Index >=0)
                {
                    dgvIngredient.Rows.Remove(rowSelected);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" +ex.Message);
            }
        }
        DataGridViewRow rowSelected = new DataGridViewRow();
        private void dgvIngredient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            int row = e.RowIndex;
            rowSelected = dgvIngredient.Rows[row];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (dgvIngredient.RowCount < 0) return;
            //DialogResult log = MessageBox.Show("bạn xác nhận chọn những nguyên liệu trên là nguyên liệu ưu tiên?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if(log == DialogResult.Yes)
            //{
            //    try
            //    {
            //        var listCodeIngredient = dgvIngredient.Rows.Cast<DataGridViewRow>().Select(w => w.Cells[0].Value.ToString()).ToList();
            //        using (var ctx = new DBContext())
            //        {
            //            var allCodeIngredient = ctx.Tbl_Ingredient.Select(s => s.IngredientCode).ToList();
            //            var exceptList = allCodeIngredient.Except(listCodeIngredient).ToList();
            //            foreach (var item in listCodeIngredient)
            //            {                           
            //                var ingredientExist = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == item).FirstOrDefault();
            //                if (ingredientExist != null)
            //                {
            //                    var supplierExist = ctx.Tbl_Supplier.Where(w => w.SupplierName == supplier).FirstOrDefault();
            //                    int id;
            //                    if (supplierExist == null)
            //                    {
            //                        id = 0;
            //                    }
            //                    else
            //                    {
            //                        id = supplierExist.Id;
            //                    }
            //                    ingredientExist.SupplierPriorityId = id;
            //                }
            //            }
            //            foreach (var item in exceptList) // những nguyên liệu không phải ưu tiên sẽ đặt thành null.
            //            {
            //                var ingredientExist = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == item).FirstOrDefault();
            //                ingredientExist.SupplierPriorityId = null;
            //            }
            //            ctx.SaveChanges();
            //            MessageBox.Show("Đã lưu thành công!");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
            //    }                              
            //}
        }
    }
}

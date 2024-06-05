using CanTeenManagement.Model;
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
    public partial class FormCheckHistoryOutStock : Form
    {
        DateTime currentDate;
        public FormCheckHistoryOutStock(DateTime tag)
        {
            InitializeComponent();
            Tag = tag;
        }

        private void FormCheckHistoryOutStock_Load(object sender, EventArgs e)
        {
            var date = (DateTime)this.Tag;
            currentDate = (DateTime)this.Tag;
            lbtitle.Text = $"Danh sách nguyên liệu xuất kho ngày: {date.ToString("dd-MM-yyyy")}";
            ShowDataOutStock((DateTime)Tag);

        }

        private void ShowDataOutStock(DateTime tag)
        {
            dgvHistoryOutStock.Rows.Clear();
            using (var ctx = new DBContext())
            {
                try
                {
                    var listOutStock = ctx.Tbl_HistoryInOut.Where(w => w.Date == tag && w.Status == "Xuất").ToList();
                    foreach (var item in listOutStock)
                    {
                        var actrualOrder = ctx.Tbl_Order.Where(w => w.IngredientCode == item.IngredientCode && w.Date == tag).Select(s => s.ActualOrder).FirstOrDefault();
                        dgvHistoryOutStock.Rows.Add();
                        int index = dgvHistoryOutStock.RowCount - 1;
                        dgvHistoryOutStock.Rows[index].Cells[0].Value = item.Date?.ToString("dd-MM-yyyy");
                        dgvHistoryOutStock.Rows[index].Cells[1].Value = item.IngredientCode;
                        dgvHistoryOutStock.Rows[index].Cells[2].Value = ctx.Tbl_Ingredient.Where(w=>w.IngredientCode == item.IngredientCode).Select(s=>s.IngredientName).FirstOrDefault();
                        dgvHistoryOutStock.Rows[index].Cells[3].Value = actrualOrder == null ? 0 : actrualOrder;
                        dgvHistoryOutStock.Rows[index].Cells[4].Value = item.Quantity;
                        dgvHistoryOutStock.Rows[index].Cells[5].Value = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == item.IngredientCode).Select(s => s.Unit).FirstOrDefault();
                        dgvHistoryOutStock.Rows[index].Cells[6].Value = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == item.IngredientCode).Select(s => s.Spec).FirstOrDefault();
                        dgvHistoryOutStock.Rows[index].Cells[7].Value = item.UserAction;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: "+ex.Message);
                }                                     
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddDays(-1);
            lbtitle.Text = $"Danh sách nguyên liệu xuất kho ngày: {currentDate.ToString("dd-MM-yyyy")}";
            ShowDataOutStock(currentDate);
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            currentDate =  currentDate.AddDays(1);
            lbtitle.Text = $"Danh sách nguyên liệu xuất kho ngày: {currentDate.ToString("dd-MM-yyyy")}";
            ShowDataOutStock(currentDate);
        }
    }
}

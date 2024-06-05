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
    public partial class FormChangeOrder : Form
    {
        public FormChangeOrder()
        {
            InitializeComponent();
            uiDatePicker1.Value = DateTime.Now;
            dgvChange.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {                
                dgvChange.Rows.Clear();
                using (var ctx = new DBContext())
                {
                    if(cbSuplier.SelectedIndex != -1)
                    {
                        var suplierName = cbSuplier.SelectedItem as string;
                        var suplierCode = ctx.Tbl_Supplier.Where(w => w.SupplierName == suplierName).Select(s => s.SupplierCode).FirstOrDefault();
                        var orderList = ctx.Tbl_Order.Where(w => w.Date == uiDatePicker1.Value && w.SupplierCode == suplierCode).ToList();
                        foreach(var item in orderList)
                        {
                            dgvChange.Rows.Add();
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[0].Value = item.Id;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[1].Value = item.BillCreateDate;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[2].Value = item.Date;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[3].Value = item.IngredientCode;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[4].Value = item.PlanOrder;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[5].Value = item.ActualOrder;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[6].Value = item.HistoryPriceId;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[7].Value = item.CurrentApprovePrice;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[8].Value = item.PriceTotal;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[9].Value = item.OrderHistoryId;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[10].Value = item.SupplierCode;
                            dgvChange.Rows[dgvChange.RowCount - 1].Cells[11].Value = item.ReMark;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FormChangeOrder_Load(object sender, EventArgs e)
        {
            using(var ctx = new DBContext())
            {
                cbSuplier.Items.AddRange(ctx.Tbl_Supplier.Select(s => s.SupplierName).ToArray());
            }
        }

        DataGridViewRow selectRow;
        private void dgvChange_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                selectRow = dgvChange.Rows[e.RowIndex];
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(selectRow != null)
            {
                int id = int.Parse(selectRow.Cells[0].Value.ToString());
                var orderDate = DateTime.Parse(selectRow.Cells[2].Value.ToString());
                var plan = selectRow.Cells[4].Value;
                var actual = selectRow.Cells[5].Value;
                var priceHistoryId = selectRow.Cells[6].Value;
                var price = selectRow.Cells[7].Value;
                var totalPrice = selectRow.Cells[8].Value;
                var historyOrderId = int.Parse(selectRow.Cells[9].Value.ToString());
                var suplier = selectRow.Cells[10].Value;
                var remark = selectRow.Cells[11].Value;
                using (var ctx = new DBContext())
                {
                    using (var transaction = ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            var orderdataExist = ctx.Tbl_Order.Where(w => w.Id == id).FirstOrDefault();
                            if (orderdataExist != null)
                            {
                                orderdataExist.PlanOrder = CheckDouble(plan);
                                orderdataExist.ActualOrder = CheckDouble(actual);
                                orderdataExist.HistoryPriceId = int.Parse(priceHistoryId.ToString());
                                orderdataExist.CurrentApprovePrice = int.Parse(price.ToString());
                                if(actual == null)
                                {
                                    orderdataExist.PriceTotal = null;
                                }
                                else
                                {
                                    orderdataExist.PriceTotal = (int)(int.Parse(price.ToString()) * double.Parse(actual.ToString()));
                                }
                         
                                orderdataExist.SupplierCode = suplier.ToString();
                                orderdataExist.ReMark = remark == null ? "" : remark.ToString();
                                ctx.SaveChanges();
                            }// ls giá
                            var historyOrderExist = ctx.Tbl_OrderHistory.Where(w => w.Id == historyOrderId).FirstOrDefault();
                            if (historyOrderExist != null)
                            {
                                var totalPaymend = ctx.Tbl_Order.Where(w => w.Date == orderDate && w.OrderHistoryId == historyOrderId && w.PriceTotal != null).Sum(s => s.PriceTotal);
                                historyOrderExist.TotalPayment = totalPaymend;
                                ctx.SaveChanges();
                            }
                            // kho
                            string ingredientCode = orderdataExist.IngredientCode;
                            Tbl_Stock tbl_Stock = ctx.Tbl_Stock.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
                            if (tbl_Stock != null)
                            {
                                double act = CheckDouble(actual) ?? 0;
                                double pla = CheckDouble(plan) ?? 0;
                                tbl_Stock.Input += act - pla; 
                            }
                            // lịch sử nhập xuất
                            string historyOrderBillCode = historyOrderExist.HistoryOrderCode;
                            Tbl_HistoryInOut tbl_HistoryInOut = ctx.Tbl_HistoryInOut.Where(w => w.IngredientCode == ingredientCode &&  w.BillCode == historyOrderBillCode).FirstOrDefault();    
                            if (tbl_HistoryInOut != null)
                            {
                                tbl_HistoryInOut.Quantity = CheckDouble(actual) ?? 0;
                                tbl_HistoryInOut.StockAfterInOut += (CheckDouble(actual) ?? 0) - (CheckDouble(plan) ?? 0);
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions and rollback the transaction if something goes wrong
                            Console.WriteLine($"Error: {ex.Message}");
                            transaction.Rollback();
                        }
                    }                  
                }
            }
        }

        private double? CheckDouble(object plan)
        {
            if (plan != null)
            {
                return double.Parse(plan.ToString());
            }
            return null;
        }
    }
}

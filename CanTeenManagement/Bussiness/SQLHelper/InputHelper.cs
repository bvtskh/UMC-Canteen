using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement.Bussiness.SQLHelper
{
    public class InputHelper
    {
        internal List<string> GetSupplierListCodeOrder(DateTime selectDate)
        {
            try
            {
                List<int> supplierListID = new List<int>();
                using (var context = new DBContext())
                {
                    return context.Tbl_Order.Where(w => w.Date == selectDate).ToList().Select(s => s.SupplierCode).Distinct().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal string GetSupplierNameByCode(string supplierCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Supplier.Where(w => w.SupplierCode == supplierCode).Select(s => s.SupplierName).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Tbl_Order> GetOrderDataBySupplierCode(string supplierCode, DateTime selectDate)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var data = context.Tbl_Order.Where(w => w.Date == selectDate && w.SupplierCode == supplierCode).ToList();
                    data.Where(w => w.SupplierCode == supplierCode && w.Date == selectDate).GroupBy(g => g.IngredientCode).Select(s =>
                    {
                        var item = s.First();
                        item.PlanOrder = s.Sum(sum => Math.Round((double)sum.PlanOrder, 3));
                        return item;
                    }).ToList();
                    return data.OrderBy(o => o.IngredientCode).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<string> GetOrderDateNotYetStock()
        {
            try
            {
                using (var context = new DBContext())
                {
                    List<string> dateList = new List<string>();
                    var list = context.Tbl_OrderHistory.Where(w => w.OrderStatus.Trim() == "Chưa nhận").Select(s => s.OrderForDate).ToList();
                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            dateList.Add(item.Value.ToString("dd-MM-yyyy"));
                        }
                    }
                    return dateList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Tbl_Ingredient GetIngredientByCode(string ingredientCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Ingredient.FirstOrDefault(w => w.IngredientCode == ingredientCode);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Tbl_OrderHistory GetOrderHistory(DateTime selectDate)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_OrderHistory.Where(w => w.OrderForDate == selectDate).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsSavedToStock(string supplierCode, DateTime selectDate)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var data = context.Tbl_Order.Where(w => w.Date == selectDate && w.SupplierCode == supplierCode).FirstOrDefault(f => f.ActualOrder != null);
                    if (data != null) return true;
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsFirstSaveToStock(DateTime selectDate)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_OrderHistory.Where(w => w.OrderForDate == selectDate.Date).Select(s => s.OrderStatus == "Chưa nhận").FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal DateTime? GetInputStockTime(string suppliercode, DateTime selectDate)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_HistoryInOut.Where(w => w.Date == selectDate.Date && w.Status.Trim() == "Nhập" && w.SupplierCode == suppliercode).Select(s => s.DateTimeInOut).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsOverDateInput(DateTime selectDate)
        {
            try
            {
                if (DateTime.Now.Date > selectDate.Date)
                {
                    var dayInput = selectDate.Date.DayOfWeek;
                    if (dayInput != DayOfWeek.Saturday && dayInput != DayOfWeek.Sunday) // nếu không phải thứ 7 hoặc chủ nhật thì:
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool InputToStock(List<DataGridView> dataGridViews, DateTime selectDate)
        {
            foreach (var dgv in dataGridViews)
            {
                var supplierCode = dgv.Name.Substring(3);
                if (IsSavedToStock(supplierCode, selectDate)) continue;
                using (var context = new DBContext())
                {
                    try
                    {
                        List<Tbl_HistoryInOut> inOutList = new List<Tbl_HistoryInOut>();
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            string ingredientCode = row.Cells["Mã nguyên liệu"].Value.ToString();
                            if (row.Cells["Số lượng thực nhận"].Value == null || string.IsNullOrEmpty(row.Cells["Số lượng thực nhận"].Value.ToString())) continue;
                            double actualOrder = ConvertActualOrder(row.Cells["Số lượng thực nhận"].Value.ToString());
                            //luu vao order
                            Tbl_Order orderExist = context.Tbl_Order.Where(w => w.Date == selectDate && w.IngredientCode == ingredientCode && w.SupplierCode == supplierCode).FirstOrDefault();
                            orderExist.ActualOrder = Math.Round(double.Parse(actualOrder.ToString()), 3);
                            orderExist.PriceTotal = (int)(orderExist.ActualOrder * orderExist.CurrentApprovePrice);
                            context.SaveChanges();

                            //luu vao kho
                            Tbl_Stock stockExist = context.Tbl_Stock.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
                            if (stockExist.Input == null) stockExist.Input = 0;
                            if (stockExist.Stock == null) stockExist.Stock = 0;
                            stockExist.Input = Math.Round(actualOrder + (double)stockExist.Input, 3);
                            stockExist.Stock = Math.Round(actualOrder + (double)stockExist.Stock, 3);
                            context.SaveChanges();

                            //lưu lịch sử nhập xuất
                            double? currenStock = context.Tbl_Stock.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault().Stock;
                            string status = "Nhập";
                            Tbl_HistoryInOut tblHistoryIn = new Tbl_HistoryInOut();
                            tblHistoryIn.IngredientCode = ingredientCode;
                            tblHistoryIn.Date = selectDate;
                            tblHistoryIn.Quantity = actualOrder;
                            tblHistoryIn.StockBeforInOut = Math.Round((double)currenStock - actualOrder, 3);
                            tblHistoryIn.StockAfterInOut = currenStock;
                            tblHistoryIn.Status = status;
                            tblHistoryIn.DateTimeInOut = DateTime.Now;
                            tblHistoryIn.BillCode = GetHistoryOrderBillCode(selectDate);
                            tblHistoryIn.SupplierName = GetSupplierNameByCode(supplierCode);
                            tblHistoryIn.SupplierCode = supplierCode;
                            tblHistoryIn.UserAction = Common.FindUser();
                            context.Tbl_HistoryInOut.Add(tblHistoryIn);
                            context.SaveChanges();
                        }
                        SaveToHistoryOrder(selectDate);
                    }
                    catch (Exception)
                    {
                        return false;
                        throw;
                    }
                }
            }
            return true;
        }

        private void SaveToHistoryOrder(DateTime selectDate)
        {
            try
            {
                using (var context = new DBContext())
                {
                    // tìm kiếm lịch sử đặt hàng.
                    var orderHistory = context.Tbl_OrderHistory.Where(w => w.OrderForDate == selectDate).FirstOrDefault();
                    var orderHistoryId = orderHistory.Id;
                    var totalPaymend = context.Tbl_Order.Where(w => w.Date == selectDate && w.OrderHistoryId == orderHistoryId && w.ActualOrder != null).Sum(s => s.ActualOrder * s.CurrentApprovePrice);
                    if (orderHistory != null)
                    {
                        orderHistory.OrderStatus = "Đã nhận";
                        orderHistory.TotalPayment = totalPaymend;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi khi nhập hàng! " + ex.Message);
            }
        }

        private string GetHistoryOrderBillCode(DateTime selectDate)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_OrderHistory.Where(w => w.OrderForDate == selectDate).Select(s => s.HistoryOrderCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Tbl_Stock GetIngredientStock(DBContext context, string ingredientCode)
        {
            try
            {
                return context.Tbl_Stock.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Tbl_Order GetIngredientOrder(DBContext context, string ingredientCode, DateTime selectDate, string supplierCode)
        {
            try
            {
                return context.Tbl_Order.Where(w => w.Date == selectDate && w.IngredientCode == ingredientCode && w.SupplierCode == supplierCode).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private double ConvertActualOrder(string value)
        {
            return Math.Round(double.Parse(value.ToString()), 3);
        }

        internal bool IsSavedToStock(List<string> suplierListCodeList,DateTime selectDate)
        {
            try
            {
                foreach (var item in suplierListCodeList)
                {
                    if (!IsSavedToStock(item, selectDate)) return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

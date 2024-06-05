using CanTeenManagement.Bussiness.ENUM;
using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.OrderEnum;

namespace CanTeenManagement.Bussiness.SQLHelper
{
    public class OutputHelper
    {
        internal List<Tbl_Ingredient> GetCommonlyUseIngredient()
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Ingredient.Where(w => w.IsAlwayOutStock == 1).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal double? GetIngredientStock(string ingredientCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Stock.Where(w => w.IngredientCode == ingredientCode).Select(s => s.Stock).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Tbl_Menu GetDataMenu(DateTime selectDate, OrderEnum.MenuType menuType)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Menu.Where(w => w.Date == selectDate && w.MenuType == (int)menuType).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<string> GetIngredientCodeListOfOrder(int historyOrderPayedID)
        {
            try
            {
                using (var context = new DBContext())
                {
                    // nếu đã nhận hàng
                    var ingredientOrderList = context.Tbl_Order.Where(w => w.OrderHistoryId == historyOrderPayedID).ToList();
                    List<string> ingredientCodeOrderList = new List<string>();
                    ingredientOrderList.ForEach(f => ingredientCodeOrderList.Add(f.IngredientCode));
                    return ingredientCodeOrderList.Distinct().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<string> GetIngredientCodeListOfMenuNotInOrder(List<string> ingredientCodeListOfOrder, DateTime selectDate)
        {
            try
            {
                List<Tbl_Menu> menuList = new List<Tbl_Menu>();
                menuList.Add(GetDataMenu(selectDate, OrderEnum.MenuType.Main));
                menuList.Add(GetDataMenu(selectDate, OrderEnum.MenuType.Side));

                List<string> ingredientCodeList = new List<string>();
                List<object> dishCode = new List<object>();
                foreach (var menu in menuList)
                {
                    if(menu!=null)
                    dishCode.AddRange(menu.GetType().GetProperties().Where(w => w.PropertyType == typeof(string) && GetValueProperty(w, menu) != null).Select(s => GetValueProperty(s, menu)).ToList());
                }
                foreach (var item in dishCode)
                {
                    List<Tbl_Quantitative> quantitativesList = GetQuantitativeByDishCode(item.ToString());
                    quantitativesList.ForEach(f => ingredientCodeList.Add(f.IngredientCode));
                }
                return ingredientCodeList.Except(ingredientCodeListOfOrder).ToList();
            }
            catch (Exception)
            {
                throw;
            }          
        }

        private object GetValueProperty(PropertyInfo objectvalue, Tbl_Menu menu)
        {
            try
            {
                return objectvalue.GetValue(menu);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private List<Tbl_Quantitative> GetQuantitativeByDishCode(string dishCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Quantitative.Where(w => w.DishCode == dishCode).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int GetHistoryOrderidIsInput(DateTime selectDate)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_OrderHistory.Where(w => w.OrderForDate == selectDate && w.OrderStatus == "Đã nhận").Select(s => s.Id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal string GetIngredientNameByCode(string ingredientCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).Select(s => s.IngredientName).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal double? GetActualOrderValue(string ingredientCode, DateTime selectDate)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Order.Where(w => w.IngredientCode == ingredientCode && w.Date == selectDate && w.ActualOrder != null).Select(s => s.ActualOrder).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal string GetIngredientUnit(string ingredientCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).Select(s => s.Unit).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void ArrangeStock()
        {
            try
            {
                using (var context = new DBContext())
                {
                    var stock = context.Tbl_Stock.ToList();
                    foreach (var item in stock)
                    {
                        item.Stock = Math.Round((double)item.Stock, 3);
                        item.Input = Math.Round((double)item.Input, 3);
                        item.Output = Math.Round((double)item.Output, 3);
                        if (item.Stock < 0) item.Stock = 0;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        internal List<DataGridViewRow> GetRowNotQualifyList(DataGridView dgrOutput)
        {
            try
            {
                List<DataGridViewRow> rowNotQualifyList = new List<DataGridViewRow>();
                for (int i = 0; i < dgrOutput.RowCount; i++)
                {
                    string numberOutStock = dgrOutput.Rows[i].Cells[3].Value == null ? "0" : dgrOutput.Rows[i].Cells[3].Value.ToString();
                    double resultCheckNumberOutStock;
                    double.TryParse(numberOutStock, out resultCheckNumberOutStock);

                    var stock = dgrOutput.Rows[i].Cells[4].Value; // số lượng trong kho
                    if (stock == null)
                    {
                        rowNotQualifyList.Add(dgrOutput.Rows[i]); // để sau này kiểm tra kho có đủ đáp ứng không.
                    }
                    if (stock != null)
                    {
                        if (resultCheckNumberOutStock > double.Parse(stock.ToString()))
                        {
                            rowNotQualifyList.Add(dgrOutput.Rows[i]);
                        }
                    }
                }
                return rowNotQualifyList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void AddIngredientToDatagridview(DataGridView dgrOutput, string number, object selectItem)
        {
            try
            {                                                           
                Tbl_Ingredient itemAdd = (Tbl_Ingredient)selectItem;
                using (var context = new DBContext())
                {
                    var checkExsitIngredient = dgrOutput.Rows.Cast<DataGridViewRow>().Where(w => w.Cells[0].Value.ToString() == itemAdd.IngredientCode).FirstOrDefault();
                    if (checkExsitIngredient == null)
                    {
                        dgrOutput.Rows.Add();
                        var index = dgrOutput.RowCount - 1;
                        var stock = context.Tbl_Stock.Where(w => w.IngredientCode == itemAdd.IngredientCode).Select(s => s.Stock).FirstOrDefault();
                        if (stock == null) stock = 0;
                        dgrOutput.Rows[index].DefaultCellStyle.BackColor = Color.CornflowerBlue;
                        dgrOutput.Rows[index].Cells[0].Value = itemAdd.IngredientCode;
                        dgrOutput.Rows[index].Cells[1].Value = itemAdd.IngredientName;
                        dgrOutput.Rows[index].Cells[2].Value = "Empty!";
                        dgrOutput.Rows[index].Cells[3].Value = number;
                        dgrOutput.Rows[index].Cells[4].Value = stock;
                        dgrOutput.Rows[index].Cells[5].Value = itemAdd.Unit;
                    }
                    else
                    {
                        checkExsitIngredient.DefaultCellStyle.BackColor = Color.CornflowerBlue;
                        var currentNumber = checkExsitIngredient.Cells[3].Value;
                        if (currentNumber == null) currentNumber = "0";
                        var addNumber = double.Parse(currentNumber.ToString());
                        checkExsitIngredient.Cells[3].Value = addNumber + double.Parse(number);
                    }
                    if (!IsCommonlyUse(itemAdd.IngredientCode))
                    {
                        SaveToAlwaysOutStock(itemAdd.IngredientCode);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void DeleteIngredientAlwayUse(DataGridView dgvAlwayUse)
        {
            try
            {
                using (var context = new DBContext())
                {
                    List<DataGridViewRow> selectRow = dgvAlwayUse.SelectedRows.Cast<DataGridViewRow>().ToList();
                    if (selectRow.Count > 0)
                    {
                        foreach (var row in selectRow)
                        {
                            var ingredientCode = row.Cells[0].Value.ToString();
                            var ingredientExist = context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
                            if (ingredientExist != null)
                            {
                                ingredientExist.IsAlwayOutStock = 0;
                                context.SaveChanges();
                            }
                            dgvAlwayUse.Rows.Remove(row);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }           
        }

        internal void ShowIngredientHaveStock(DataGridView dgvIngredientInStock)
        {
            try
            {
                dgvIngredientInStock.Rows.Clear();
                using (var context = new DBContext())
                {
                    var ingredientHaveStock = context.Tbl_Stock.Where(w => w.Stock != null && w.Stock > 0).ToList();
                    foreach (var item in ingredientHaveStock)
                    {
                        dgvIngredientInStock.Rows.Add();
                        int index = dgvIngredientInStock.RowCount - 1;
                        var row = dgvIngredientInStock.Rows[index];
                        row.Cells[0].Value = item.IngredientCode;
                        row.Cells[1].Value = context.Tbl_Ingredient.Where(w => w.IngredientCode == item.IngredientCode).Select(s => s.IngredientName).FirstOrDefault();
                        row.Cells[2].Value = context.Tbl_Ingredient.Where(w => w.IngredientCode == item.IngredientCode).Select(s => s.Unit).FirstOrDefault();
                        row.Cells[3].Value = context.Tbl_Ingredient.Where(w => w.IngredientCode == item.IngredientCode).Select(s => s.Spec).FirstOrDefault();
                        row.Cells[4].Value = item.Stock;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveToAlwaysOutStock(string ingredientCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    Tbl_Ingredient ingredientExist = context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
                    if (ingredientExist != null)
                    {
                        ingredientExist.IsAlwayOutStock = 1;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool IsCommonlyUse(string ingredientCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    Tbl_Ingredient ingredientExist = context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
                    if (ingredientExist != null) return ingredientExist.IsAlwayOutStock == 1;
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal bool IsSaveToStockAndHistoryInOut(DataGridView dgrOutput, DateTime selectDate)
        {
            DateTime firstDayOfMonth = new DateTime(selectDate.Year, selectDate.Month, 1);
            using (var context = new DBContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgrOutput.Rows)
                        {
                            string ingredientCode = row.Cells[0].Value.ToString();
                            string ingredientName = row.Cells[1].Value.ToString();                  
                            if (row.Cells[3].Value == null || string.IsNullOrEmpty(row.Cells[3].Value.ToString())) continue;
                            double numberOutStock = ConvertOutput(row.Cells[3].Value.ToString());
                            if (numberOutStock <= 0) continue;
                            //Luu vao kho
                            Tbl_Stock tblStockExist = context.Tbl_Stock.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
                            if (tblStockExist.Output == null) tblStockExist.Output = 0;
                            if (tblStockExist.Stock == null) tblStockExist.Stock = 0;
                            tblStockExist.Stock = Math.Round((double)tblStockExist.Stock - numberOutStock, 3);
                            tblStockExist.Output = Math.Round((double)tblStockExist.Output + numberOutStock, 3);
                            context.SaveChanges();
                            // Lưu vào lịch sử nhập xuất
                            double? currenStock = context.Tbl_Stock.Where(w => w.IngredientCode == ingredientCode).Select(s => s.Stock).FirstOrDefault();
                            string status = "Xuất";
                            Tbl_HistoryInOut tblHistoryIn = new Tbl_HistoryInOut();
                            tblHistoryIn.IngredientCode = ingredientCode;
                            tblHistoryIn.Date = selectDate;
                            tblHistoryIn.Quantity = numberOutStock;
                            tblHistoryIn.StockBeforInOut = Math.Round((double)currenStock + numberOutStock, 3);
                            tblHistoryIn.StockAfterInOut = currenStock;
                            tblHistoryIn.Status = status;
                            tblHistoryIn.DateTimeInOut = DateTime.Now;
                            tblHistoryIn.BillCode = GetHistoryOrderBillCode(selectDate);
                            tblHistoryIn.SupplierName = "All";
                            tblHistoryIn.SupplierCode = "All";
                            tblHistoryIn.UserAction = Common.FindUser();
                            context.Tbl_HistoryInOut.Add(tblHistoryIn);
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // If any operation fails, roll back the transaction
                        transaction.Rollback();
                        return false;
                        throw ex;
                    }
                }
            }
            return true;
        }

        internal bool IsEmptyRowOutStock(DataGridView dgrOutput)
        {
            try
            {
                double actualResult;
                foreach (DataGridViewRow item in dgrOutput.Rows)
                {
                    var actualOrder = item.Cells[3].Value == null || item.Cells[3].Value.ToString() == "" ? "0" : item.Cells[3].Value.ToString();
                    if (!double.TryParse(actualOrder, out actualResult))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
                throw;
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

        private double ConvertOutput(string value)
        {
            try
            {
                return Math.Round(double.Parse(value.ToString()), 3);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void AddIngredientAlwayOutStockToDGV(DataGridView dgrOutput, DataGridView dgvAlwayUse)
        {
            var ingredientCommonlyUse = GetCommonlyUseIngredient().Select(s=>s.IngredientCode).ToList();
            var ingredientNotExist = FilterIngredientExistInDGV(ingredientCommonlyUse, dgrOutput);
            AddtoDatagridview(ingredientNotExist,dgrOutput);
        }
        private List<string> FilterIngredientExistInDGV(List<string> ingredientCommonlyUse, DataGridView dgrOutput)
        {
            List<string> ingredientCodeListInDgv = dgrOutput.Rows.Cast<DataGridViewRow>().Select(s => s.Cells[0].Value.ToString()).ToList();
            return ingredientCommonlyUse.Except(ingredientCodeListInDgv).ToList();
        }
        private void AddtoDatagridview(List<string> ingredientNotExist, DataGridView dgrOutput)
        {
            try
            {
                foreach (var item in ingredientNotExist)
                {
                    string ingredientCode = item;
                    string ingredientName = GetIngredientNameByCode(ingredientCode);
                    double? ingredientStock = GetIngredientStock(ingredientCode);
                    string ingredientUnit = GetIngredientUnit(ingredientCode);
                    dgrOutput.Rows.Add();
                    int index = dgrOutput.RowCount - 1;
                    dgrOutput.Rows[index].Cells[0].Value = ingredientCode;
                    dgrOutput.Rows[index].Cells[1].Value = ingredientName;
                    dgrOutput.Rows[index].Cells[2].Value = "Empty!";
                    dgrOutput.Rows[index].Cells[3].Value = null;
                    dgrOutput.Rows[index].Cells[4].Value = ingredientStock;
                    dgrOutput.Rows[index].Cells[5].Value = ingredientUnit;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsEmptyOutStock(DataGridView dgrOutput)
        {
            try
            {
                foreach (DataGridViewRow row in dgrOutput.Rows)
                {
                    if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "" && row.Cells[3].Value.ToString().Trim() != "0")
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void InsertIngredientToDgv(List<DataGridViewRow> selectRow, DataGridView dgrOutput)
        {
            try
            {
                List<string> ingredientList = new List<string>();
                selectRow.ForEach(f => ingredientList.Add(f.Cells[0].Value.ToString()));

                List<string> afterFilterList = FilterIngredientExistInDGV(ingredientList, dgrOutput);
                if (afterFilterList.Count > 0)
                {
                    AddtoDatagridview(afterFilterList, dgrOutput);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

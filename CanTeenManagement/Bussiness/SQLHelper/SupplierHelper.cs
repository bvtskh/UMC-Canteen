using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using MiniExcelLibs;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.Formula.Functions;
using Sunny.UI;
using Sunny.UI.Win32;
using static CanTeenManagement.Bussiness.ENUM.EnumSupplier;

namespace CanTeenManagement.Bussiness.SQLHelper
{
    internal class SupplierHelper
    {
        [Obsolete]
        internal DataTable GetDataImport()
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                // Set the filter to allow only Excel files
                open.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    DataTable data = MiniExcel.QueryAsDataTable(open.FileName, false);
                    return SetColumn(data);
                }
            }
            return new DataTable();
        }

        private DataTable SetColumn(DataTable data)
        {
            var columnList = GetColumn(data.Rows[1]);
            for (int i = 0; i < columnList.Count; i++)
            {
                data.Columns[i].ColumnName = string.IsNullOrEmpty(columnList[i]) ? $"A{i}": columnList[i];
            }
            return data;
        }

        private List<string> GetColumn(DataRow dataRow)
        {
            List<string> list = new List<string>();
            dataRow.ItemArray.ForEach(f => list.Add(f.ToString()));
            return list;
        }

        internal object GetSupplierName(string supplierCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Supplier.Where(w => w.SupplierCode == supplierCode).Select(s => s.SupplierName).FirstOrDefault();
            }
        }

        internal bool IsExistUpdateTime(DateTime date, string supplierCode)
        {
            using (var context = new DBContext())
            {
                var data = context.Tbl_PriceUpdateChange.Where(w => w.ApproveTime == date && w.SupplierCode == supplierCode).FirstOrDefault();
                return data != null;
            }
        }

        internal bool IsUpdatePrice(DateTime date, string supplierCode, DataGridView dgvUpdateInfo)
        {
            using (var context = new DBContext())
            {
                DateTime updateTime = DateTime.Now;
                foreach (DataGridViewRow row in dgvUpdateInfo.Rows)
                {
                    string ingredientCode = CheckCode(row.Cells[0].Value);
                    if (!string.IsNullOrEmpty(ingredientCode))
                    {
                        Tbl_PriceUpdateChange priceUpdateChange = new Tbl_PriceUpdateChange();
                        priceUpdateChange.IngredientCode = ingredientCode;
                        priceUpdateChange.OldPrice = Common.ConvertInt(row.Cells[5].Value);
                        priceUpdateChange.NewPrice = Common.ConvertInt(row.Cells[6].Value);
                        priceUpdateChange.UpdateTime = updateTime;
                        priceUpdateChange.ApproveTime = date;
                        priceUpdateChange.HostName = Environment.MachineName;
                        //priceUpdateChange.UserName = Common.FindUser();
                        priceUpdateChange.SupplierCode = supplierCode.Trim();
                        priceUpdateChange.Reason = row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString();
                        UpdateIngredientPrice(priceUpdateChange);
                    }
                }
                return true;
            }
        }

        private void UpdateIngredientPrice(Tbl_PriceUpdateChange priceUpdateChange)
        {
            using (var context = new DBContext())
            {
                var ingredienCode = priceUpdateChange.IngredientCode;
                var ingredientExist = context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredienCode).FirstOrDefault();
                if (ingredientExist == null) return; // khi không có mã hàng này trong master.

                var dataExist = context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == priceUpdateChange.IngredientCode && w.ApproveTime == priceUpdateChange.ApproveTime && w.SupplierCode == priceUpdateChange.SupplierCode).FirstOrDefault();
                if (dataExist != null)
                {
                    dataExist.OldPrice = priceUpdateChange.OldPrice;
                    dataExist.NewPrice = priceUpdateChange.NewPrice;
                    context.Entry(dataExist).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Tbl_PriceUpdateChange.Add(priceUpdateChange);
                }
                context.SaveChanges();
            }
        }

        private string CheckCode(object value)
        {
            if (value == null) return null;
            if (!IsExistIngredient(value.ToString().Trim())) return null;
            return value.ToString().Trim();
        }

        private bool IsExistIngredient(string ingredientCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault() != null;
            }
        }

        internal bool IsValidSupplier(string supplierCode)
        {
            using (var context = new DBContext())
            {
                var supplier = context.Tbl_Supplier.Where(w => w.SupplierCode == supplierCode).FirstOrDefault();
                return supplier != null;
            }
        }

        internal List<Tbl_Supplier> GetAllSupplier()
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Supplier.ToList();
            }
        }

        internal string[] GetApproveDateBySupplier(string supplierCode)
        {
            using (var context = new DBContext())
            {
                var date = context.Tbl_PriceUpdateChange.Where(w => w.SupplierCode == supplierCode).Select(s => s.ApproveTime).Distinct().OrderByDescending(o => o).ToList();
                var convertToStr = new List<string>();
                date.ForEach(f => convertToStr.Add(f.Value.ToString("dd-MM-yyyy")));
                return convertToStr.ToArray();
            }
        }
        internal string[] GetApproveDateBySupplier(string supplierCode, int year, int month)
        {
            using (var context = new DBContext())
            {
                var date = context.Tbl_HistoryPriceClon.Where(w => w.SupplierCode == supplierCode && w.mYear == year && w.mMonth == month).Select(s => s.ApproveDate).Distinct().OrderByDescending(o => o).ToList();
                var convertToStr = new List<string>();
                date.ForEach(f => convertToStr.Add(f.Value.ToString("dd-MM-yyyy")));
                return convertToStr.ToArray();
            }
        }
        internal List<Tbl_PriceUpdateChange> GetHistoryPrice(string supplierCode, DateTime date)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_PriceUpdateChange.Where(w => w.SupplierCode == supplierCode && w.ApproveTime == date).ToList();
            }
        }

        internal object GetIngredientName(string ingredientCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).Select(s => s.IngredientName).FirstOrDefault();
            }
        }

        internal bool UpdateAprovePrice(string supplierCode, DateTime dateTime, int year, int month)
        {
            try
            {
                using (var context = new DBContext())
                {
                   // var dataSetNull1 = context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == "CT00058" && w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month).ToList();
                    var data = context.Tbl_PriceUpdateChange.Where(w => w.SupplierCode == supplierCode && w.ApproveTime == dateTime).ToList();
                    foreach (var dataNewUpdate in data)
                    {
                        // tại thời điểm trong mỗi tháng chỉ có duy nhất một mã hàng được áp dụng.
                        var ingredientExisted = context.Tbl_HistoryPriceClon.Where(w => w.IngredientCode == dataNewUpdate.IngredientCode && w.mMonth == month && w.mYear == year).FirstOrDefault();
                        if (ingredientExisted == null)
                        {
                            // nếu nó không có giá hoặc nhỏ hơn 0 thì bỏ qua
                            if (dataNewUpdate.NewPrice <= 0 || dataNewUpdate.NewPrice == null) continue;
                            context.Tbl_HistoryPriceClon.Add(new Tbl_PriceHistoryClon // thêm mới
                            {
                                IngredientCode = dataNewUpdate.IngredientCode,
                                Price = dataNewUpdate.NewPrice,
                                SupplierCode = dataNewUpdate.SupplierCode,
                                mYear = year,
                                mMonth = month,
                                ApproveDate = dataNewUpdate.ApproveTime,
                            });
                            dataNewUpdate.IsApproved = true;
                        }
                        else
                        {
                            // cho dữ liệu mới thành không áp dụng.
                            dataNewUpdate.IsApproved = false;
                            // thời gian áp dụng khác tại mã, tại ncc set về null vì ko sử dụng
                            var setNullApproveDate = context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == dataNewUpdate.IngredientCode && w.SupplierCode == dataNewUpdate.SupplierCode && w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month && w.ApproveTime != dataNewUpdate.ApproveTime).ToList();
                            foreach(var change in setNullApproveDate)
                            {
                                change.IsApproved = null;
                            }
                            context.SaveChanges();

                            // so sánh giá lấy giá rẻ.
                            var ingredientList = context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == dataNewUpdate.IngredientCode && w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month && w.IsApproved !=null).ToList();                               
                            // khi áp dụng thì mã hàng tại thời gian này sẽ thay thế cho thời gian áp dụng cũ.
                            if (ingredientList.Count > 0)
                            {                               
                                var minPrice = ingredientList.Where(w => w.NewPrice == ingredientList.Min(m => m.NewPrice)).FirstOrDefault();
                                if(dataNewUpdate.NewPrice <= minPrice.NewPrice)
                                {
                                    minPrice = dataNewUpdate;
                                }
                                if(minPrice.NewPrice == null || minPrice.NewPrice == 0)
                                {
                                    // nếu dữ liệu mới cập nhật là nguyên liệu đang áp dụng
                                    if(dataNewUpdate.SupplierCode == ingredientExisted.SupplierCode && dataNewUpdate.ApproveTime.Value.Year ==  ingredientExisted.mYear && dataNewUpdate.ApproveTime.Value.Month == ingredientExisted.mMonth)
                                    {
                                        context.Tbl_HistoryPriceClon.Remove(ingredientExisted);
                                        dataNewUpdate.IsApproved = null;
                                        context.SaveChanges();

                                        // khi này cần chọn nhà cung cấp khác thay thế.
                                        var dataRemove = ingredientList.Where(w => w.SupplierCode == dataNewUpdate.SupplierCode).FirstOrDefault();
                                        ingredientList.Remove(dataRemove);
                                        minPrice = ingredientList.Where(w => w.NewPrice == ingredientList.Min(m => m.NewPrice)).FirstOrDefault();
                                        if (minPrice.NewPrice == null)
                                        {
                                            minPrice.IsApproved = null;
                                            continue;
                                        }
                                    }
                                    minPrice.IsApproved = null;
                                    continue;
                                }
                                // giá bằng nhau
                                if (ingredientList.Count() > 1 && ingredientList.Where(w => w.NewPrice == ingredientList.Min(m => m.NewPrice)).Count() == ingredientList.Count)
                                {
                                    var today = Common.GetSupplierPriority(DateTime.Now);
                                    var dataSet = context.Tbl_Ingredient.Where(w => w.IngredientCode == dataNewUpdate.IngredientCode).FirstOrDefault();
                                    if (dataSet != null)
                                    {
                                        dataSet.SupplierPriorityCode = today;
                                        context.SaveChanges();
                                    }
                                    minPrice = ingredientList.Where(w => w.SupplierCode == today).FirstOrDefault();
                                    if(minPrice == null)
                                    {
                                        minPrice = ingredientList.Where(w => w.NewPrice == ingredientList.Min(m => m.NewPrice)).FirstOrDefault();
                                    }
                                }

                                // cập nhật lại 
                                ingredientExisted.Price = minPrice.NewPrice;
                                ingredientExisted.SupplierCode = minPrice.SupplierCode;
                                ingredientExisted.ApproveDate = minPrice.ApproveTime;       
                                // thời gian áp dụng tại mã cũ set về false
                                var dataSetNull = context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == minPrice.IngredientCode && w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month && w.IsApproved !=null).ToList();
                                foreach (var item in dataSetNull)
                                {
                                    item.IsApproved = false;
                                }

                                minPrice.IsApproved = true;
                            }
                        }
                        context.SaveChanges();
                    }
                    return true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool IsPriority(string ingredientCode)
        {
            using (var context = new DBContext())
            {
                var data = context.Tbl_Ingredient.Where(w => w.SupplierPriorityCode != null && w.IngredientCode == ingredientCode).FirstOrDefault();
                return data != null;
            }
        }

        internal List<Tbl_PriceHistoryClon> GetCurrentApproveData(short year, short month)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_HistoryPriceClon.Where(w => w.mYear == year && w.mMonth == month).ToList();
            }
        }

        internal List<Tbl_PriceHistoryClon> GetAllIngredientCurrentSelect(short year, short month)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_HistoryPriceClon.Where(w => w.mYear == year && w.mMonth == month).ToList();
            }
        }

        internal List<Tbl_Ingredient> GetSearchData(List<string> ingredientCurrentSelect, string searchStr)
        {
            using (var context = new DBContext())
            {
                var ingredientList = new List<Tbl_Ingredient>();
                foreach (var item in ingredientCurrentSelect)
                {
                    var existData = context.Tbl_Ingredient.Where(w => w.IngredientCode == item).FirstOrDefault();
                    if (existData.IngredientName.ToLower().Contains(searchStr.ToLower()) || existData.IngredientCode.ToLower().Contains(searchStr.ToLower()))
                    {
                        ingredientList.Add(existData);
                    }
                }
                return ingredientList;
            }
        }

        internal List<string> GetPriorityIngredientList()
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.SupplierPriorityCode != null).Select(s => s.IngredientCode).ToList();
            }
        }

        internal double? GetPrice(string ingredientCode, Tbl_Supplier supplier, short year, short month)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == ingredientCode && w.SupplierCode == supplier.SupplierCode && w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month && w.IsApproved != null).Select(s => s.NewPrice).FirstOrDefault();
            }
        }

        internal object GetSelectedSupplier(string ingredientCode, short year, short month)
        {
            using (var context = new DBContext())
            {
                var supplier = context.Tbl_HistoryPriceClon.Where(w => w.IngredientCode == ingredientCode && w.mYear == year && w.mMonth == month).Select(s => s.SupplierCode).FirstOrDefault();
                if (supplier != null)
                {
                    return context.Tbl_Supplier.Where(w => w.SupplierCode == supplier).Select(s => s.SupplierName).FirstOrDefault();
                }
                return null;
            }
        }

        internal string GetSupplierCodeByName(string supplierNameSelected)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Supplier.Where(w => w.SupplierName == supplierNameSelected).Select(s => s.SupplierCode).FirstOrDefault();
            }
        }

        internal bool IsMinPrice(string ingredientCode, string supplierIdSelectedCode, short year, short month)
        {
            using (var context = new DBContext())
            {
                var data = context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == ingredientCode && w.IsApproved != null && w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month).ToList();
                if (data.Count > 0)
                {
                    var minPrice = data.Where(w => w.NewPrice == data.Min(m => m.NewPrice)).FirstOrDefault();
                    if (minPrice.SupplierCode == supplierIdSelectedCode)
                    {
                        return true;
                    }
                    if(minPrice.NewPrice == data.Where(w=>w.SupplierCode == supplierIdSelectedCode).Select(s => s.NewPrice).FirstOrDefault())
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        internal void UpdatePriorityIngredientByDay(DateTime date, UpdateType updateType,short year, short month)
        {
            using(var context = new DBContext())
            {
                var listCode = context.Tbl_PriceUpdateChange.Where(w => w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month && w.IsApproved != null).Select(s => s.IngredientCode).Distinct().ToList();
                List<string> priorityCodeList = new List<string>();
                foreach (var code in listCode)
                {
                    var dataList = context.Tbl_PriceUpdateChange.Where(w => w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month && w.IsApproved != null && w.IngredientCode == code).ToList();
                    if (dataList.Count() > 1 && dataList.Where(w => w.NewPrice == dataList.Min(m => m.NewPrice)).Count() == dataList.Count)
                    {
                        priorityCodeList.Add(code);     
                    }
                }
                string supplier = "";
                if (updateType == UpdateType.Read)
                {
                    supplier = Common.GetSupplierPriority(DateTime.Now);
                }
                else if (updateType == UpdateType.Update)
                {
                    supplier = Common.GetSupplierPriority(date);
                }
                // reset giá ưu tiên bằng nhau
                string sql = $"update [CanteenManagement].[dbo].[Tbl_Ingredient] set [SupplierPriorityCode] = null";
                context.Database.ExecuteSqlCommand(sql, "");
                foreach (var code in priorityCodeList)
                {
                    //cơm hộp
                    if (code == "CT00051") continue;
                    var dataSet = context.Tbl_Ingredient.Where(w => w.IngredientCode == code).FirstOrDefault();
                    if (dataSet != null)
                    {
                        dataSet.SupplierPriorityCode = supplier;
                    }
                    var selectPrice = context.Tbl_PriceUpdateChange.Where(w => w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month && w.IsApproved != null && w.IngredientCode == code && w.SupplierCode == supplier).FirstOrDefault();
                    var ingredientExisted = context.Tbl_HistoryPriceClon.Where(w => w.IngredientCode == code && w.mYear == year && w.mMonth == month).FirstOrDefault();
                    // cập nhật lại 

                    if (selectPrice == null) continue; // đúng ngày chọn nhưng nó lại ko có báo giá
                    ingredientExisted.Price = selectPrice.NewPrice;
                    ingredientExisted.SupplierCode = selectPrice.SupplierCode;
                    ingredientExisted.ApproveDate = selectPrice.ApproveTime;
                    // thời gian áp dụng tại mã cũ set về null
                    var dataSetNull = context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == selectPrice.IngredientCode && w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month && w.IsApproved != null).ToList();
                    foreach (var item in dataSetNull)
                    {
                        item.IsApproved = false;
                    }
                    selectPrice.IsApproved = true;
                    context.SaveChanges();
                }
            }
        }

        internal void SaveChangePrice(int year, int month, DataGridView dgvSupplierPrice)
        {
            int countRow = dgvSupplierPrice.Rows.Count;
            int countColumns = dgvSupplierPrice.Columns.Count - 1;
            for (int i = 0; i < countRow; i++)
            {
                var rowIndex = dgvSupplierPrice.Rows[i];
                string ingredientCode = rowIndex.Cells[0].Value.ToString();
                var supplierSelect = rowIndex.Cells[countColumns].Value;
                if (supplierSelect == null) continue;
 
                using (var context = new DBContext())
                {
                    var supplierChangeCode = GetSupplierCodeByName(supplierSelect.ToString());
                    var priceChange = context.Tbl_HistoryPriceClon.Where(w=>w.IngredientCode == ingredientCode && w.mYear == year && w.mMonth == month).FirstOrDefault();
                    if(priceChange.SupplierCode != supplierChangeCode)
                    {
                        var historyChange = context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == ingredientCode && w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month && w.IsApproved != null && w.SupplierCode == supplierChangeCode).FirstOrDefault();
                        priceChange.Price = historyChange.NewPrice;
                        priceChange.SupplierCode = historyChange.SupplierCode;
                        priceChange.ApproveDate = historyChange.ApproveTime;
                        // thời gian áp dụng tại mã cũ set về null
                        var dataSetNull = context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == ingredientCode && w.ApproveTime.Value.Year == year && w.ApproveTime.Value.Month == month && w.IsApproved != null).ToList();
                        foreach (var item in dataSetNull)
                        {
                            item.IsApproved = false;
                        }
                        historyChange.IsApproved = true;
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}

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
using NPOI.POIFS.Crypt.Dsig;
using Sunny.UI;

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
            return null;
        }

        private DataTable SetColumn(DataTable data)
        {
            var columnList = GetColumn(data.Rows[1]);
            for(int i=0; i<columnList.Count; i++)
            {
                data.Columns[i].ColumnName = columnList[i];
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
            using(var context = new DBContext())
            {
                return context.Tbl_Supplier.Where(w=>w.SupplierCode == supplierCode).Select(s=>s.SupplierName).FirstOrDefault();
            }
        }

        internal bool IsExistUpdateTime(DateTime date, string supplierCode)
        {
            using(var context = new DBContext()) 
            { 
                var data = context.Tbl_PriceUpdateChange.Where(w=>w.ApproveTime == date && w.SupplierCode == supplierCode).FirstOrDefault();
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
                        priceUpdateChange.IngredientCode= ingredientCode;
                        priceUpdateChange.OldPrice = Common.ConvertInt(row.Cells[5].Value);
                        priceUpdateChange.NewPrice = Common.ConvertInt(row.Cells[6].Value);
                        priceUpdateChange.UpdateTime = updateTime;
                        priceUpdateChange.ApproveTime = date;
                        priceUpdateChange.HostName = Environment.MachineName;
                        //priceUpdateChange.UserName = Common.FindUser();
                        priceUpdateChange.SupplierCode = supplierCode;
                        priceUpdateChange.Reason = row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString();
                        UpdateIngredientPrice(priceUpdateChange);
                    }
                }
                return true;
            }
        }

        private void UpdateIngredientPrice(Tbl_PriceUpdateChange priceUpdateChange)
        {
            using(var context = new DBContext())
            {
                var ingredienCode = priceUpdateChange.IngredientCode;
                var dataExist = context.Tbl_PriceUpdateChange.Where(w => w.IngredientCode == priceUpdateChange.IngredientCode && w.ApproveTime == priceUpdateChange.ApproveTime && w.SupplierCode == priceUpdateChange.SupplierCode).FirstOrDefault();
                if(dataExist != null)
                {
                    dataExist.OldPrice = priceUpdateChange.OldPrice;
                    dataExist.NewPrice =priceUpdateChange.NewPrice;
                    context.Entry(dataExist).State= System.Data.Entity.EntityState.Modified;
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
            if (!IsExistIngredient(value.ToString())) return null;
            return value.ToString();
        }

        private bool IsExistIngredient(string ingredientCode)
        {
            using(var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w=>w.IngredientCode == ingredientCode).FirstOrDefault() != null;
            }
        }
    }
}

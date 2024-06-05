using CanTeenManagement.Model;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement.Bussiness.SQLHelper
{
    public class IngredientHelper
    {
        internal Tbl_Ingredient GetIngredient(string ingredientCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
            }
        }

        internal bool IsExistIngredient(string ingredientName)
        {
            using(var context = new DBContext())
            {
                var data = context.Tbl_Ingredient.Where(w=>w.IngredientName == ingredientName).FirstOrDefault();
                return data != null;
            }
        }

        internal bool IsInsertIngredient(string ingredientName, string spec, string unit, string safeStock)
        {
            using(var context = new DBContext())
            {
                Tbl_Ingredient newIngredient = new Tbl_Ingredient();
                newIngredient.IngredientName = ingredientName;
                newIngredient.Spec = spec;
                newIngredient.Unit = unit;
                if (context.Tbl_Ingredient.Count() > 0)
                {
                    newIngredient.IndexNumber = context.Tbl_Ingredient.Max(m => m.IndexNumber) + 1;
                }
                else
                {
                    newIngredient.IndexNumber = 1;
                }
                newIngredient.IngredientCode = "CT" + newIngredient.IndexNumber.ToString().PadLeft(5, '0');
                double? safe = null;
                newIngredient.SafeStock = !string.IsNullOrEmpty(safeStock) ? double.Parse(safeStock) : safe;
                context.Tbl_Ingredient.Add(newIngredient);
                Tbl_Stock tblstock = new Tbl_Stock();
                var tblStockExist = context.Tbl_Stock.Where(w => w.IngredientCode == newIngredient.IngredientCode).FirstOrDefault();
                if (tblStockExist == null)
                {
                    tblstock.IngredientCode = newIngredient.IngredientCode;
                    tblstock.Stock = 0;
                    tblstock.Input = 0;
                    tblstock.Output = 0;
                    context.Tbl_Stock.Add(tblstock);
                    context.SaveChanges();
                }
                context.SaveChanges();
                return true;
            }
        }

        internal bool IsUpdateIngredient(string ingredientCode, string ingredientName, string spec, string unit, string safeStock)
        {
            using(var context = new DBContext())
            {
                var ingredientExist = context.Tbl_Ingredient.Where(w => w.IngredientCode.Equals(ingredientCode)).FirstOrDefault();
                if (ingredientExist == null) return false;
                ingredientExist.IngredientName = ingredientName;
                ingredientExist.Spec = spec;
                ingredientExist.Unit = unit;
                double? safe =null;
                ingredientExist.SafeStock = !string.IsNullOrEmpty(safeStock) ? double.Parse(safeStock) : safe;
                context.Entry(ingredientExist).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}

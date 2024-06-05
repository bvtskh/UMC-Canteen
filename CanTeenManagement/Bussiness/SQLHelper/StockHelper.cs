using CanTeenManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanTeenManagement.Bussiness.SQLHelper
{
    public class StockHelper
    {
        internal List<Tbl_Ingredient> GetIngerdient(string searchStr)
        {
            using(var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IngredientName.Contains(searchStr) || w.IngredientCode.Contains(searchStr)).ToList().GroupBy(g=>g.IngredientCode).Select(s=>s.First()).ToList();
            }
        }

        internal object GetStockValue(string ingredientCode)
        {
            using(var context = new DBContext())
            {
                return context.Tbl_Stock.Where(w => w.IngredientCode == ingredientCode).Select(s => s.Stock).FirstOrDefault();
            }
        }

        internal List<Tbl_HistoryInOut> SearchObjectsByDate(List<Tbl_HistoryInOut> dataFromStock, DateTime startSearch, DateTime endSearch)
        {
            List<Tbl_HistoryInOut> results = new List<Tbl_HistoryInOut>();
            if (dataFromStock != null)
            {
                foreach (var obj in dataFromStock)
                {
                    DateTime objDate = (DateTime)obj.Date;
                    if (objDate >= startSearch && objDate <= endSearch)
                    {
                        results.Add(obj);
                    }
                }
                return results;
            }
            return null;
        }

        internal List<Tbl_HistoryInOut> GetHistoryInOut(string codeSelect, string status)
        {
            using(var context = new DBContext())
            { 
                if(string.IsNullOrEmpty(status)) return context.Tbl_HistoryInOut.Where(w => w.IngredientCode == codeSelect).ToList();
                return context.Tbl_HistoryInOut.Where(w => w.IngredientCode == codeSelect && w.Status == status).ToList();
            }
        }

        internal object GetIngerdientUnit(string ingredientCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).Select(s => s.Unit).FirstOrDefault();
            }
        }

        internal object GetIngerdientName(string ingredientCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).Select(s => s.IngredientName).FirstOrDefault();
            }
        }
    }
}

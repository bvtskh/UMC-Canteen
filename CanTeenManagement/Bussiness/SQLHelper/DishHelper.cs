using CanTeenManagement.Model;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement.Bussiness.SQLHelper
{
    public class DishHelper
    {
        internal Tbl_Dish GetDishByCode(string dishCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Dish.Where(w => w.DishCode == dishCode).FirstOrDefault();
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
                    return context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Tbl_Ingredient> GetIngredientListByContainStr(string text)
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Ingredient.Where(w => w.IngredientName.Contains(text)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<string> GetIngredientNameList()
        {
            try
            {
                using (var context = new DBContext())
                {
                    return context.Tbl_Ingredient.Select(w => w.IngredientName).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Tbl_Quantitative> GetIngredientQuantitativeList(string dishCode)
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

        internal bool IsDeleteDish(string dishCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var dishExist = context.Tbl_Dish.Where(w => w.DishCode == dishCode).FirstOrDefault();
                    if (dishExist == null) return false;
                    var delQuantitative = context.Tbl_Quantitative.Where(w => w.DishCode == dishExist.DishCode);
                    context.Tbl_Quantitative.RemoveRange(delQuantitative);
                    var delDishMenu = context.Tbl_Menu.ToList();

                    PropertyInfo[] properties = typeof(Tbl_Menu).GetProperties();
                    foreach (var item in delDishMenu)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            // Check if the property is of type string
                            if (property.PropertyType == typeof(string))
                            {
                                // Get the value of the property
                                string propertyValue = (string)property.GetValue(item);

                                // Compare the property value with the argument
                                if (propertyValue == dishExist.DishCode)
                                {
                                    property.SetValue(item, null);
                                    context.SaveChanges();
                                }
                            }
                        }
                    }
                    context.Tbl_Dish.Remove(dishExist);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }          
        }

        internal bool IsExistDish(string dishName)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var data = context.Tbl_Dish.Where(w => w.Dish == dishName).FirstOrDefault();
                    return data != null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsInsertNewDish(string dishName, bool ischeck, DataGridView dataGridView)
        {
            try
            {
                using (var context = new DBContext())
                {
                    Tbl_Dish newDish = new Tbl_Dish();
                    newDish.Dish = dishName;
                    if (context.Tbl_Dish.Count() > 0)
                    {
                        newDish.Number = context.Tbl_Dish.Max(m => m.Number.Value) + 1;
                    }
                    else
                    {
                        newDish.Number = 1;
                    }
                    newDish.DishCode = "MA" + newDish.Number.ToString().PadLeft(3, '0');
                    if (ischeck)
                    {
                        newDish.IsPreOrderDish = "OK";
                    }
                    else
                    {
                        newDish.IsPreOrderDish = null;
                    }
                    List<Tbl_Quantitative> quantitatives = new List<Tbl_Quantitative>();
                    for (int row = 0; row < dataGridView.RowCount; row++)
                    {
                        Tbl_Quantitative quantitative = new Tbl_Quantitative();
                        quantitative.DishCode = newDish.DishCode;
                        quantitative.IngredientCode = dataGridView.Rows[row].Cells[0].Value.ToString();
                        quantitative.Quantitative = double.Parse(dataGridView.Rows[row].Cells[2].Value.ToString());
                        quantitatives.Add(quantitative);
                    }
                    context.Tbl_Dish.Add(newDish);
                    context.Tbl_Quantitative.AddRange(quantitatives);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }           
        }

        internal bool IsNotPrice(string ingredientCode, DateTime date)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var data = context.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingredientCode && w.ApprovalDate == date && w.PriceMain == 1).Select(s => s.Price).FirstOrDefault();
                    return data == null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsPreOrderDish(string dishCode)
        {
            try
            {
                using (var ctx = new DBContext())
                {
                    if (ctx.Tbl_Dish.Where(w => w.DishCode == dishCode).Select(s => s.IsPreOrderDish == "OK").FirstOrDefault())
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsUpdateDish(string dishCode, string dishName, DataGridView dataGridView, bool ischeck)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var dishExist = context.Tbl_Dish.Where(w => w.DishCode == dishCode).FirstOrDefault();
                    if (dishExist == null) return false; ;
                    dishExist.Dish = dishName;
                    if (ischeck)
                    {
                        dishExist.IsPreOrderDish = "OK";
                    }
                    else
                    {
                        dishExist.IsPreOrderDish = null;
                    }
                    var ingredientList = context.Tbl_Quantitative.Where(w => w.DishCode == dishCode);
                    context.Tbl_Quantitative.RemoveRange(ingredientList);

                    List<Tbl_Quantitative> quantitatives = new List<Tbl_Quantitative>();
                    for (int rows = 0; rows < dataGridView.RowCount; rows++)
                    {
                        var ingredeintCode = dataGridView.Rows[rows].Cells[0].Value.ToString();
                        Tbl_Quantitative quantitative = new Tbl_Quantitative();
                        quantitative.DishCode = dishCode;
                        quantitative.IngredientCode = ingredeintCode;
                        quantitative.Quantitative = double.Parse(dataGridView.Rows[rows].Cells[2].Value.ToString());
                        quantitatives.Add(quantitative);
                    }
                    context.Tbl_Quantitative.AddRange(quantitatives);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }  
        }

        internal bool IsValidIngredient(string ingredientCode, DateTime date)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var data = context.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingredientCode && w.ApprovalDate == date && w.PriceMain == 1).FirstOrDefault();
                    return data != null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

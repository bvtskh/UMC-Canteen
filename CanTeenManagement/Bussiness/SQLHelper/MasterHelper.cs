using CanTeenManagement.Model;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement.Bussiness.SQLHelper
{
    public class MasterHelper
    {
        internal List<Tbl_Ingredient> GetIngredientBySearchStr(string text)
        {
            using (var context = new DBContext())
            {
                List<Tbl_Ingredient> tbl_Ingredients = new List<Tbl_Ingredient>();
                tbl_Ingredients.AddRange(context.Tbl_Ingredient.Where(w => w.IngredientCode.Contains(text)).ToList());
                tbl_Ingredients.AddRange(context.Tbl_Ingredient.Where(w => w.IngredientName.Contains(text)).ToList());
                return tbl_Ingredients.Distinct().ToList();
            }
        }

        internal bool IsDeleteIngredient(string ingredientCode)
        {

            using (var context = new DBContext())
            {
                using(var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        var historyPrice = context.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingredientCode).ToList();
                        context.Tbl_HistoryPrice.RemoveRange(historyPrice);
                        var ingredient = context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
                        context.Tbl_Ingredient.Remove(ingredient);
                        context.SaveChanges();
                        trans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        return false;
                        throw;
                    }
                }
            }             
        }

        internal List<Tbl_Dish> GetDishBySearchStr(string text)
        {
            using (var context = new DBContext())
            {
                List<Tbl_Dish> tbl_Dishes = new List<Tbl_Dish>();
                tbl_Dishes.AddRange(context.Tbl_Dish.Where(w => w.Dish.Contains(text)).ToList());
                tbl_Dishes.AddRange(context.Tbl_Dish.Where(w => w.DishCode.Contains(text)).ToList());
                return tbl_Dishes.Distinct().ToList();               
            }
        }

        internal object GetQuantitativeOfDish(object dishCode)
        {
            using(var context = new DBContext())
            {
                return context.Tbl_Quantitative.Where(w => w.DishCode == dishCode.ToString()).Select(s => new
                {
                    QuantitativeIngredientCode = s.Tbl_Ingredient.IngredientCode,
                    QuantitativeIngredientName = s.Tbl_Ingredient.IngredientName,
                    QuantitativeIngredient = s.Quantitative,
                    QuantitativeUnit = s.Tbl_Ingredient.Unit
                }).ToList();
            }
        }
        internal bool IsDeleteDish(string dishCode)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var dish = context.Tbl_Dish.Where(w => w.DishCode == dishCode).FirstOrDefault();
                    var delQuanti = context.Tbl_Quantitative.Where(w => w.DishCode == dish.DishCode);
                    context.Tbl_Quantitative.RemoveRange(delQuanti);
                    var delFromMenu = context.Tbl_Menu.ToList();
                    PropertyInfo[] properties = typeof(Tbl_Menu).GetProperties();
                    foreach (var item in delFromMenu)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            // Check if the property is of type string
                            if (property.PropertyType == typeof(string))
                            {
                                // Get the value of the property
                                string propertyValue = (string)property.GetValue(item);

                                // Compare the property value with the argument
                                if (propertyValue == dish.DishCode)
                                {
                                    property.SetValue(item, null);
                                    context.SaveChanges();
                                }
                            }
                        }
                    }
                    context.Tbl_Dish.Remove(dish);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }            
        }

        internal bool ExportXinBaoGia(SaveFileDialog saveFileDialog)
        {
            try
            {
                using (var context = new DBContext())
                {
                    Workbook workbook = new Workbook();
                    var listSupplier = context.Tbl_Supplier.ToList();

                    foreach (var item in listSupplier)
                    {
                        workbook.LoadFromFile(@"\\vn-file\\DX Center\\36. CanTeenManagement\\Master\\FormMaster.xlsx");

                        Worksheet sheet = workbook.Worksheets[0];

                        sheet.Range["C1"].Value = DateTime.Now.AddMonths(1).Month + "/1/" + DateTime.Now.AddMonths(1).Year;
                        //var listIngerdientCode = dgvIngredient.Rows.OfType<DataGridViewRow>().Select(s => s.Cells[0].Value.ToString()).ToList();
                        var listIngerdientCode = context.Tbl_Ingredient.Select(w => w.IngredientCode).ToList();
                        int rowIndex = 0;
                        sheet.Name = item.SupplierName;
                        for (int i = 0; i < listIngerdientCode.Count(); i++)
                        {

                            var ingCode = listIngerdientCode[i];
                            var ingredient = context.Tbl_Ingredient.Where(w => w.IngredientCode == ingCode).FirstOrDefault();
                            var historyPrice = context.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingCode && w.SupplierCode == item.SupplierCode).ToList();
                            var priceNow = historyPrice.Where(w => w.ApprovalDate == historyPrice.Max(m => m.ApprovalDate).Value).OrderByDescending(o => o.Id).FirstOrDefault();
                            //if (priceNow == null) continue;
                            if (priceNow != null)
                            {
                                sheet.Range[rowIndex + 3, 1].Text = priceNow.Tbl_Ingredient.IngredientCode.Trim();
                                sheet.Range[rowIndex + 3, 2].Text = priceNow.Tbl_Ingredient.IngredientName;
                                sheet.Range[rowIndex + 3, 3].Text = priceNow.Tbl_Ingredient.Spec;
                                sheet.Range[rowIndex + 3, 4].Text = priceNow.Tbl_Ingredient.Unit;
                                sheet.Range[rowIndex + 3, 5].Text = priceNow.SupplierCode;
                                sheet.Range[rowIndex + 3, 6].Text = priceNow.Price.ToString();
                            }
                            else
                            {
                                sheet.Range[rowIndex + 3, 1].Text = ingredient.IngredientCode.Trim();
                                sheet.Range[rowIndex + 3, 2].Text = ingredient.IngredientName;
                                sheet.Range[rowIndex + 3, 3].Text = ingredient.Spec;
                                sheet.Range[rowIndex + 3, 4].Text = ingredient.Unit;
                                sheet.Range[rowIndex + 3, 5].Text = item.SupplierCode;
                            }
                            rowIndex++;
                        }
                        workbook.SaveToFile(saveFileDialog.FileName + @"\Báo Giá NCC " + item.SupplierName + " T" + (DateTime.Now.Month + 1).ToString() + ".xlsx");
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}

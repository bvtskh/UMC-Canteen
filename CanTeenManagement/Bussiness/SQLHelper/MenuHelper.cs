using CanTeenManagement.Model;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.Menu;

namespace CanTeenManagement.Bussiness.SQLHelper
{
    public class MenuHelper
    {
        internal Form FindForm(string formname)
        {
            List<Form> FormList = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                string formName = form.Name;
                if (formName == formname)
                {
                    FormList.Add(form);
                }
            }
            if (FormList.Count > 0)
            {
                if (FormList[0].GetType() == typeof(FormMenuChinh)) return (FormMenuChinh)FormList.Last();
                else return (FormMenuNhe)FormList.Last();
            }
            return null;
        }
     
        internal void FindAndCloseForm(string formname)
        {
            List<Form> FormList = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                string formName = form.Name;
                if (formName == formname)
                {
                    FormList.Add(form);
                }
            }
            if (FormList.Count > 0)
            {
                Form form = new Form();
                if (FormList[0].GetType() == typeof(FormMenuChinh)) form=(FormMenuChinh)FormList.Last();
                else form = (FormMenuNhe)FormList.Last();

                FormList.Where(w => w != form).ToList().ForEach(f => f.Close());
            }
        }

        internal object CheckDay(DayOfWeek dayOfWeek)
        {
            if (dayOfWeek == DayOfWeek.Monday)
            {
                return "Thứ hai";
            }
            else if (dayOfWeek == DayOfWeek.Tuesday)
            {
                return "Thứ ba";
            }
            else if (dayOfWeek == DayOfWeek.Wednesday)
            {
                return "Thứ tư";
            }
            else if (dayOfWeek == DayOfWeek.Thursday)
            {
                return "Thứ năm";
            }
            else if (dayOfWeek == DayOfWeek.Friday)
            {
                return "Thứ sáu";
            }
            else if (dayOfWeek == DayOfWeek.Saturday)
            {
                return "Thứ bảy";
            }
            else if (dayOfWeek == DayOfWeek.Sunday)
            {
                return "Chủ nhật";
            }
            return null;
        }

        public List<string> GetDates(int year, int month)
        {

            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                             .Select(day => (new DateTime(year, month, day)).ToString("dd-MM-yyyy"))
                             .ToList();
        }

        internal List<string> GetMonth()
        {
            List<string> monthList = new List<string>();
            for (int month = 1; month < 13; month++)
            {
                monthList.Add(month.ToString());
            }
            return monthList;
        }
        internal List<string> GetYear(DateTime date)
        {
            List<string> yearList = new List<string>();
            int before = date.AddYears(-1).Year;
            int after = date.AddYears(1).Year;
            for (int year = before; year <= after; year++)
            {
                yearList.Add(year.ToString());
            }
            return yearList;
        }
        internal List<string> Get2YearAgo(DateTime date)
        {
            List<string> yearList = new List<string>();
            int before2 = date.AddYears(-2).Year;
            int before1 = date.AddYears(-1).Year;
            yearList.Add(before2.ToString());
            yearList.Add(before1.ToString());
            yearList.Add(date.Year.ToString());

            return yearList;
        }

        internal List<Tbl_Dish> GetIngredietListBySearchstr(string searchText)
        {
            using(var context = new DBContext())
            {
                return context.Tbl_Dish.Where(w => w.Dish.Contains(searchText)).ToList();
            }
        }

        internal bool IsImportDataOldMonth(ENUM.Menu.SelectMenu menuType, string month, string year, string formName)
        {
            using(var context = new DBContext())
            {
                var ListOfMenu = context.Tbl_Menu.Where(w => w.Date.Value.Month.ToString() == month && w.Date.Value.Year.ToString() == year && w.MenuType == (int)menuType).ToList();
                if (ListOfMenu.Count > 0)
                {
                    if (formName == MenuForm.FormMenuChinh.ToString())
                    {
                        FormMenuChinh form = (FormMenuChinh)FindForm(formName);
                        form.ImportDataOldMonth(ListOfMenu);
                        return true;
                    }
                    else
                    {
                        FormMenuNhe form = (FormMenuNhe)FindForm(formName);
                        form.ImportDataOldMonth(ListOfMenu);
                        return true;
                    }                   
                }
                return false;
            }           
        }

        internal List<Tbl_Menu> getDataOfMenu(string month, string year, SelectMenu menuType)
        {
            using(var context = new DBContext())
            {
                return context.Tbl_Menu.Where(w => w.Date.Value.Month.ToString() == month && w.Date.Value.Year.ToString() == year && w.MenuType == (int)menuType).ToList();
            }           
        }

        internal FormMenu FindLastFormMenu()
        {
            List<Form> FormList = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                string formName = form.Name;
                if (formName == "FormMenu")
                {
                    FormList.Add(form);
                }
            }
            return (FormMenu)FormList.Last();
        }

        internal List<string> GetIngredientListInvalid(Tbl_Dish dishselect)
        {
            List<string> ingredientInvalid = new List<string>();
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            using (var ctx = new DBContext())
            {
                var dishExist = ctx.Tbl_Quantitative.Where(w => w.DishCode == dishselect.DishCode).Select(s => s.IngredientCode).ToList();
                var historyPrice = ctx.Tbl_HistoryPrice.Where(w => w.ApprovalDate == date && w.PriceMain == 1).Select(s => s.IngredientCode).ToList();
                foreach (var item in dishExist)
                {
                    if (!historyPrice.Contains(item))
                    {
                        ingredientInvalid.Add(item);
                    }
                }
            }
            return ingredientInvalid;
        }

        internal bool IsValidName(List<string> dishListOnTextbox)
        {
            using (var context = new DBContext())
            {
                List<string> dishNameList = context.Tbl_Dish.Select(s => s.Dish).ToList();
                List<string> filteredList = dishListOnTextbox.Where(element => !string.IsNullOrEmpty(element)).ToList();
                return filteredList.All(dishNameList.Contains);
            }          
        }

        internal void ExportFromDataGridViewToExcel(DataGridView dgrMenu, string filePath)
        {
            try
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet worksheet = workbook.CreateSheet("Sheet1");

                // Write data from the DataGridView to the worksheet

                IRow headerRow = worksheet.CreateRow(0);
                string name = $"THỰC ĐƠN MÓN ĂN THÁNG:" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                var headerCell = headerRow.CreateCell(0);
                headerCell.SetCellValue(name);

                //// Set font style for the text at the top
                var headerCellStyle = workbook.CreateCellStyle();
                var headerFont = workbook.CreateFont();
                headerFont.FontName = "Arial";
                headerFont.FontHeightInPoints = 22;
                headerFont.Color = IndexedColors.Red.Index;
                headerCellStyle.SetFont(headerFont);
                headerCell.CellStyle = headerCellStyle;

                IRow nextRow = worksheet.CreateRow(2);


                for (int colIndex = 0; colIndex < dgrMenu.Columns.Count; colIndex++)
                {
                    var title = nextRow.CreateCell(colIndex);
                    title.SetCellValue(dgrMenu.Columns[colIndex].HeaderText);
                    // Set font style for the column headers
                    var headerCellStyleExcel = workbook.CreateCellStyle();
                    var headerFontExcel = workbook.CreateFont();
                    headerFontExcel.FontName = "Arial";
                    headerFontExcel.FontHeightInPoints = 15;
                    headerFontExcel.Color = IndexedColors.Blue.Index;
                    headerFontExcel.IsBold = true;
                    headerCellStyleExcel.SetFont(headerFontExcel);
                    title.CellStyle = headerCellStyleExcel;

                }

                for (int i = 0; i < dgrMenu.Rows.Count; i++)
                {
                    IRow row = worksheet.CreateRow(i + 3);

                    for (int j = 0; j < dgrMenu.Columns.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.SetCellValue(dgrMenu.Rows[i].Cells[j].Value?.ToString());
                    }
                }

                // Save the workbook
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fileStream);
                }

                // Close the workbook
                workbook.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        internal bool SaveChangeMenu(DataGridView dgrMenu,SelectMenu selectMenu)
        {
            try
            {
                using (var conetxt = new DBContext())
                {
                    if (selectMenu == SelectMenu.MainMenu)
                    {
                        for (int row = 0; row < dgrMenu.Rows.Count; row++)
                        {
                            string tempMainDishes1 = dgrMenu.Rows[row].Cells[2].Value?.ToString();
                            string tempMainDishes2 = dgrMenu.Rows[row].Cells[3].Value?.ToString();
                            if (string.IsNullOrEmpty(tempMainDishes1) && string.IsNullOrEmpty(tempMainDishes2)) continue;
                            var dateInput = DateTime.ParseExact(dgrMenu.Rows[row].Cells[0].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            Tbl_Menu tblMenuExist = conetxt.Tbl_Menu.Where(w => w.Date == dateInput && w.MenuType == (int)selectMenu).FirstOrDefault();
                            Tbl_Menu tblMenu = new Tbl_Menu();
                            if (tblMenuExist != null) tblMenu = tblMenuExist;
                            tblMenu.MenuType = (int)selectMenu;
                            tblMenu.MainDishes1 = GetDishCode(dgrMenu.Rows[row].Cells[2].Value?.ToString());
                            tblMenu.MainDishes2 = GetDishCode(dgrMenu.Rows[row].Cells[3].Value?.ToString());
                            tblMenu.SideDishes = GetDishCode(dgrMenu.Rows[row].Cells[4].Value?.ToString());
                            tblMenu.Vegetables = GetDishCode(dgrMenu.Rows[row].Cells[5].Value?.ToString());
                            tblMenu.Soup = GetDishCode(dgrMenu.Rows[row].Cells[6].Value?.ToString());
                            tblMenu.Pickles = GetDishCode(dgrMenu.Rows[row].Cells[7].Value?.ToString());
                            tblMenu.Dessert1 = GetDishCode(dgrMenu.Rows[row].Cells[8].Value?.ToString());
                            tblMenu.Dessert2 = GetDishCode(dgrMenu.Rows[row].Cells[9].Value?.ToString());
                            tblMenu.Improve = GetDishCode(dgrMenu.Rows[row].Cells[10].Value?.ToString());
                            tblMenu.PregnantFood = GetDishCode(dgrMenu.Rows[row].Cells[11].Value?.ToString());
                            tblMenu.Date = dateInput;
                            if (tblMenuExist == null)
                            {
                                conetxt.Tbl_Menu.Add(tblMenu);
                            }
                            else
                            {
                                conetxt.Entry(tblMenu).State = System.Data.Entity.EntityState.Modified;
                            }
                            conetxt.SaveChanges();
                        }
                        return true;
                    }
                    else if (selectMenu == SelectMenu.SideMenu)
                    {
                        for (int row = 0; row < dgrMenu.Rows.Count; row++)
                        {
                            string tempEatDessert1 = dgrMenu.Rows[row].Cells[2].Value?.ToString();
                            string tempEatDessert2 = dgrMenu.Rows[row].Cells[3].Value?.ToString();
                            string tempEatDessert3 = dgrMenu.Rows[row].Cells[4].Value?.ToString();
                            string tempEatDessert4 = dgrMenu.Rows[row].Cells[5].Value?.ToString();
                            string tempEatDessert5 = dgrMenu.Rows[row].Cells[6].Value?.ToString();
                            if (string.IsNullOrEmpty(tempEatDessert1) && string.IsNullOrEmpty(tempEatDessert2) && string.IsNullOrEmpty(tempEatDessert3) && string.IsNullOrEmpty(tempEatDessert4) && string.IsNullOrEmpty(tempEatDessert5)) continue;
                            var dateInput = DateTime.ParseExact(dgrMenu.Rows[row].Cells[0].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            Tbl_Menu tblMenuExist = conetxt.Tbl_Menu.Where(w => w.Date == dateInput && w.MenuType == (int)selectMenu).FirstOrDefault();
                            Tbl_Menu tblMenu = new Tbl_Menu();
                            if (tblMenuExist != null) tblMenu = tblMenuExist;
                            tblMenu.MenuType = (int)selectMenu;
                            tblMenu.SideMeal1 = GetDishCode(tempEatDessert1);
                            tblMenu.SideMeal2 = GetDishCode(tempEatDessert2);
                            tblMenu.SideMeal3 = GetDishCode(tempEatDessert3);
                            tblMenu.SideMeal4 = GetDishCode(tempEatDessert4);
                            tblMenu.SideMeal5 = GetDishCode(tempEatDessert5);

                            tblMenu.Date = dateInput;
                            if (tblMenuExist == null)
                            {
                                conetxt.Tbl_Menu.Add(tblMenu);
                            }
                            else
                            {
                                conetxt.Entry(tblMenu).State = System.Data.Entity.EntityState.Modified;
                            }
                            conetxt.SaveChanges();
                        }
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }          
        }
        private string GetDishCode(string dishName)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Dish.Where(w => w.Dish == dishName).Select(s => s.DishCode).FirstOrDefault();
            }
        }

        internal bool DeleteThisMenuSelected(DateTime dateTime,SelectMenu selectMenu)
        {
            using (var context = new DBContext())
            {
                var menuExist = context.Tbl_Menu.Where(w => w.Date == dateTime && w.MenuType == (int)selectMenu).FirstOrDefault();
                if (menuExist != null)
                {
                    context.Tbl_Menu.Remove(menuExist);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        internal string GetDishName(string dishCode)
        {
            using(var context = new DBContext())
            {
                return context.Tbl_Dish.Where(w => w.DishCode == dishCode).Select(s => s.Dish).FirstOrDefault();
            }
        }
    }
}

using CanTeenManagement.Model;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Crmf;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.EnumSupplier;

namespace CanTeenManagement.Utils
{
    public static class Common
    {

        public static void ClickButtonMenu(Button btn, Panel panle)
        {
            foreach (var item in panle.Controls.OfType<Button>())
            {
                item.BackColor = System.Drawing.Color.Transparent;
                item.FlatStyle = FlatStyle.Popup;
            }
            btn.BackColor = System.Drawing.Color.Silver;
            btn.FlatStyle = FlatStyle.Flat;
        }
        public static void AddFormToPanel(Form form, Panel panel)
        {
            panel.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.Show();
        }
        public static void StartFormLoading()
        {
            FormLoading formLoading = new FormLoading();
            var formList = Application.OpenForms.Cast<Form>();
            var formActive = formList.Where(w => w.Name == "FormLoading").ToList();
            if (formActive.Count() == 0)
            {
                Thread thread = new Thread(() =>
                {
                    formLoading.ShowDialog();
                });
                thread.Start();
            }

        }
        public static void CloseFormLoading()
        {
            var formList = Application.OpenForms.Cast<Form>();
            var formLoad = formList.Where(w => w.Name == "FormLoading").ToList();
            if (formLoad.Count>0)
            {
                foreach(var form in formLoad)
                {
                    form.Invoke(new MethodInvoker(delegate ()
                    {
                        form.Close();
                    }));
                }               
            }
        }

        public static void ExportExcel(DataGridView dgv)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel|xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StartFormLoading();
                    Workbook wookbook = new Workbook();
                    wookbook.LoadFromFile((@"\\vn-file\DX Center\36. CanTeenManagement\Master\FormMaster.xlsx"));

                    Worksheet sheetNew = wookbook.Worksheets.Create();
                    int countColumns = dgv.ColumnCount;
                    //spire dòng file excel bắt đầu từ 1

                    //tạo tiêu đề cho cột excel

                    for (int i = 1; i <= countColumns; i++)
                    {
                        sheetNew.Range[1, i].Value = dgv.Columns[i - 1].HeaderText.ToString();
                        sheetNew.Range[1, i].Style.Color = Color.FromArgb(189, 215, 238);
                        sheetNew.Range[1, i].Style.Font.IsBold = true;
                        sheetNew.Range[1, i].AutoFitColumns();
                    }
                    int countRows = dgv.RowCount;

                    // ghi dữ liệu
                    for (int row = 0; row < countRows; row++)
                    {
                        for (int cell = 0; cell < countColumns; cell++)
                        {
                            sheetNew.Range[row + 2, cell + 1].Value = dgv.Rows[row].Cells[cell].Value == null ? "" : dgv.Rows[row].Cells[cell].Value.ToString().Trim();
                        }
                    }
                    wookbook.Worksheets.Remove(0);
                    wookbook.SaveToFile(saveFileDialog.FileName + ".xlsx");
                    CloseFormLoading();
                    MessageBox.Show("Thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                CloseFormLoading();
                MessageBox.Show("Thất bại", "Thông báo");
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                CloseFormLoading();
            }
        }
        public static List<IngredientInfo> GetInfoIngredientFromShared(string dishName, int totalEatMain, DateTime date)
        {
            using (var ctx = new DBContext())
            {
                var infoDish = ctx.Tbl_Quantitative.Where(w => w.DishCode == dishName).Select(s => new IngredientInfo
                {
                    IngredientCode = s.IngredientCode,
                    IngredientName = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.IngredientName).FirstOrDefault(),
                    Price = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == s.IngredientCode && w.ApprovalDate == date && w.PriceMain == 1).Select(ss => ss.Price).FirstOrDefault().ToString(),
                    SupplierName = ctx.Tbl_Supplier.Find(ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == s.IngredientCode && w.ApprovalDate == date && w.PriceMain == 1).FirstOrDefault().SupplierCode).SupplierName,
                    Unit = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.Unit).FirstOrDefault(),
                    SLCM = (double)s.Quantitative * totalEatMain, // Ăn cải thiện vẫn múc canh bình thường.
                    Stock = (float)ctx.Tbl_Stock.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.Stock).FirstOrDefault(),
                }).ToList();
                return infoDish;
            }
        }
        public static List<IngredientInfo> GetIngredientFromVegetable(string vegetables, int totalEatMain, int nmrSlCaiThien, DateTime date)
        {
            using (var ctx = new DBContext())
            {
                var infoVegetable = ctx.Tbl_Quantitative.Where(w => w.DishCode == vegetables).Select(s => new IngredientInfo
                {
                    IngredientCode = s.IngredientCode,
                    IngredientName = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.IngredientName).FirstOrDefault(),
                    Price = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == s.IngredientCode && w.ApprovalDate == date && w.PriceMain == 1).Select(ss => ss.Price).FirstOrDefault().ToString(),
                    SupplierName = ctx.Tbl_Supplier.Find(ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == s.IngredientCode && w.ApprovalDate == date && w.PriceMain == 1).FirstOrDefault().SupplierCode).SupplierName,
                    Unit = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.Unit).FirstOrDefault(),
                    SLCM = (double)s.Quantitative * (totalEatMain - nmrSlCaiThien), // Ăn cải thiện thì không có rau.
                    Stock = (float)ctx.Tbl_Stock.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.Stock).FirstOrDefault(),
                }).ToList();
                return infoVegetable;
            }
        }
        public static List<IngredientInfo> GetIngredientFromSideDish(string sideDishes, int totalEatMain, int improve, DateTime date)
        {
            using (var ctx = new DBContext())
            {
                var infoSideDishe = ctx.Tbl_Quantitative.Where(w => w.DishCode == sideDishes).Select(s => new IngredientInfo
                {
                    IngredientCode = s.IngredientCode,
                    IngredientName = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.IngredientName).FirstOrDefault(),
                    Price = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == s.IngredientCode && w.ApprovalDate == date && w.PriceMain == 1).Select(ss => ss.Price).FirstOrDefault().ToString(),
                    SupplierName = ctx.Tbl_Supplier.Find(ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == s.IngredientCode && w.ApprovalDate == date && w.PriceMain == 1).FirstOrDefault().SupplierCode).SupplierName,
                    Unit = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.Unit).FirstOrDefault(),
                    SLCM = (double)s.Quantitative * (totalEatMain - improve),// Ăn cải thiện thì không có món phụ
                    Stock = (float)ctx.Tbl_Stock.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.Stock).FirstOrDefault(),
                }).ToList();
                return infoSideDishe;
            }
        }
        public static void DisableAllButtons(Form form)
        {
            // Recursively disable buttons in the form and its child controls
            foreach (Control control in form.Controls)
            {
                // Disable the button
                control.Enabled = false;
            }
        }
        public static FormLogin LastLoginForm()
        {
            List<Form> FormList = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                string formName = form.Name;
                if (formName == "FormLogin")
                {
                    FormList.Add(form);
                }
            }
            return (FormLogin)FormList.Last();
        }
        public static void UpdateEqualPrice(DateTime date,UpdateType updateType)
        {
            List<string> samePriceCodeList = new List<string>();
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            using (var ctx = new DBContext())
            {
                var equalPriceList = ctx.Tbl_HistoryPrice.Where(w => w.ApprovalDate == firstDayOfMonth).ToList();
                foreach (var price in equalPriceList)
                {
                    if (equalPriceList.Count(s => s.IngredientCode == price.IngredientCode && s.Price == price.Price) > 1)
                    {
                        if (!samePriceCodeList.Contains(price.IngredientCode))
                            samePriceCodeList.Add(price.IngredientCode);
                    }
                }
                // sau khi có được danh sách thực phẩm giá bằng nhau thì tiến hành đặt ưu tiên.
                List<Tbl_Ingredient> listIngredient = new List<Tbl_Ingredient>();
                foreach(var code in samePriceCodeList)
                {
                    var ingredientExist = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == code).FirstOrDefault();
                    listIngredient.Add(ingredientExist);
                }
                // sau khi co danh sach nguyen lieu thi cap nhat pricemain
                Tbl_Ingredient comHop = ctx.Tbl_Ingredient.Where(f => f.IngredientName.Trim() == "cơm hộp").FirstOrDefault();
                listIngredient.Remove(comHop);
                string today="";
                if(updateType == UpdateType.Read)
                {
                    today = DateTime.Now.Date.DayOfWeek.ToString();
                }
                else if(updateType == UpdateType.Update)
                {
                    today = date.DayOfWeek.ToString();
                }
                if (today == "Monday" || today == "Wednesday" || today == "Friday")
                {
                    UpdatePriceMain(listIngredient, "DN", firstDayOfMonth);
                }
                else
                {
                    UpdatePriceMain(listIngredient, "HX", firstDayOfMonth);
                }
            }

        }
        #region Chức năng chọn thực phẩm ưu tiên
        public static void UpdateSupplierPriority(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            // Cập nhật lại báo giá của nhà cung cấp theo ngày cho những nguyên liệu ưu tiên

            // Tìm ra hôm nay là thứ mấy để biết sẽ chọn nhà nào ĐN(246) HX(357)
            //chủ nhật không cho đặt hàng, ID = 0;
            // Khi biết là thứ mấy và biết sẽ chọn nhà cung cấp nào thì tiến hành cập nhật và lưu lại
            // 15/9/23
            using (var ctx = new DBContext())
            {
                var ingredientPriority = ctx.Tbl_Ingredient.Where(w => w.SupplierPriorityCode != null).ToList();
                string today = date.DayOfWeek.ToString();
                if (today == "Monday" || today == "Wednesday" || today == "Friday")
                {
                    UpdatePriceMain(ingredientPriority, "DN",firstDayOfMonth);
                }
                else
                {
                    UpdatePriceMain(ingredientPriority, "HX",firstDayOfMonth);
                }
            }
        }
        #endregion
        public static void UpdatePriceMain(List<Tbl_Ingredient> ingredientPriority, string supplierCode, DateTime firstDay)
        {
            try
            {
                using (var ctx = new DBContext())
                {
                    var allIngredientCode = ctx.Tbl_Ingredient.Select(s => s.IngredientCode).ToList();
                    var equalPriceCode = ingredientPriority.Select(s => s.IngredientCode).ToList();
                    var ingredientExcept = allIngredientCode.Except(equalPriceCode).ToList();
                    foreach(var item in ingredientExcept)
                    {
                        var itemExistNotChange = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == item).FirstOrDefault();
                        itemExistNotChange.SupplierPriorityCode = null;
                    }
                    foreach (var item in ingredientPriority)
                    {
                        var changeToMain = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == item.IngredientCode && w.SupplierCode == supplierCode && w.ApprovalDate == firstDay).ToList();
                        var changeNotMain = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == item.IngredientCode && w.SupplierCode != supplierCode && w.ApprovalDate == firstDay).ToList();
                        var ingredientExist = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == item.IngredientCode).FirstOrDefault();
                        ingredientExist.SupplierPriorityCode = supplierCode;
                        foreach (var price in changeToMain)
                        {
                            price.PriceMain = 1;
                        }
                        foreach (var price in changeNotMain)
                        {
                            price.PriceMain = 0;
                        }
                    }
                    var comHop = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == "CT00051" && w.ApprovalDate == firstDay).ToList();
                    if (comHop.Where(w => w.SupplierCode == "DN") != null)
                    {
                        comHop.Where(w => w.SupplierCode == "DN").FirstOrDefault().PriceMain = 1;
                        comHop.Where(w => w.SupplierCode != "DN").FirstOrDefault().PriceMain = 0;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi khi cập nhật nhà cung cấp! " + ex);
            }
        }
 
        public static string ConvertText(double? currentApprovePrice)
        {
            if (currentApprovePrice != null)
            {
                double number = (double)currentApprovePrice;
                string formattedNumber;
                if (number % 2 == 0 || number % 2 == 1)
                {
                    formattedNumber = ((int)number).ToString("#,##0");
                    return formattedNumber;
                }
                else
                {
                    formattedNumber = number.ToString("#,##0.###");
                    return formattedNumber;
                }
            }
            return null;
        }
        public static void BackupData()
        {
            List<string> tableName = new List<string> {
                "Tbl_Quantitative" ,
                "Tbl_Dish" ,
                "Tbl_Menu" ,
                "Tbl_Ingredient",
                "Tbl_ChangeOrder",
                "Tbl_FoodPortion",
                "Tbl_HistoryInOut",
                "Tbl_HistoryPrice",
                "Tbl_Order",
                "Tbl_OrderHistory",
                "Tbl_PreOrder",
                "Tbl_Stock",
                "Tbl_Supplier",
                "Tbl_User",
                "Tbl_Version",
            };
            try
            {
                using (var ctx = new DBContext())
                {
                    int pathNumber = 1;
                    string originalPath = "C:\\Users\\U42107\\Desktop\\ThanhDX\\Thanh_Project\\Thanh_Project\\Cantin\\BackUp\\BackUpdataBase";
                    string dailyPath = $"BackUp_{DateTime.Now.Date.Day}_{DateTime.Now.Date.Month}_{DateTime.Now.Date.Year}";
                    string combine = Path.Combine(originalPath, dailyPath);
                    string savePath = combine;
                    int ordinal = 1;
                    while (Directory.Exists(savePath))
                    {
                        savePath = $"{combine} ({ordinal})";
                        ordinal++;
                    }
                    Directory.CreateDirectory(savePath);

                    foreach (var table in tableName)
                    {
                        if (pathNumber == 1)
                        {
                            var query = ctx.Set<Tbl_Quantitative>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,DishCode,IngredientCode,Quantitative) VALUES";
                            foreach (var entity in query)
                            {
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},'{entity.DishCode}','{entity.IngredientCode}',{entity.Quantitative}),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";
                            File.WriteAllText(Path.Combine(savePath, "QuantitativeBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 2)
                        {
                            var query = ctx.Set<Tbl_Dish>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,DishCode,Dish,Number,IsPreOrderDish) VALUES";
                            foreach (var entity in query)
                            {
                                string isPreOrderDish = CheckNull(entity.IsPreOrderDish);
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},'{entity.DishCode}',N'{entity.Dish}', {entity.Number},{isPreOrderDish}),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "DishBackup.sql"), sqlScript);

                        }
                        else if (pathNumber == 3)
                        {
                            var query = ctx.Set<Tbl_Menu>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,MainDishes1,MainDishes2,SideDishes,Vegetables,Soup,Pickles,Dessert1,Dessert2,Improve,GourdFood,SideMeal1,SideMeal2,SideMeal3,SideMeal4,SideMeal5,Date,MenuType) VALUES";
                            foreach (var entity in query)
                            {
                                string mainDish1 = CheckNull(entity.MainDishes1);
                                string mainDish2 = CheckNull(entity.MainDishes2);
                                string sideDish = CheckNull(entity.SideDishes);
                                string vegetables = CheckNull(entity.Vegetables);
                                string soup = CheckNull(entity.Soup);
                                string pickless = CheckNull(entity.Pickles);
                                string dessert1 = CheckNull(entity.Dessert1);
                                string dessert2 = CheckNull(entity.Dessert2);
                                string improve = CheckNull(entity.Improve);
                                string gourdFood = CheckNull(entity.PregnantFood);
                                string sideMeal1 = CheckNull(entity.SideMeal1);
                                string sideMeal2 = CheckNull(entity.SideMeal2);
                                string sideMeal3 = CheckNull(entity.SideMeal3);
                                string sideMeal4 = CheckNull(entity.SideMeal4);
                                string sideMeal5 = CheckNull(entity.SideMeal5);
                                string date = CheckNull(entity.Date.ToString());
                                string menuType = CheckNull(entity.MenuType.ToString());
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},{mainDish1},{mainDish2},{sideDish},{vegetables},{soup},{pickless},{ dessert1},{dessert2},{improve},{gourdFood},{sideMeal1},{sideMeal2},{sideMeal3},{sideMeal4},{sideMeal5},'{date}',{menuType}),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "MenuBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 4)
                        {
                            var query = ctx.Set<Tbl_Ingredient>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (id,IngredientCode,IngredientName,Spec,Unit,SafeStock,IndexNumber,IsAlwayOutStock,SupplierPriorityId,IsAlwayBuy) VALUES";
                            foreach (var entity in query)
                            {
                                string isAlwayOutStock = CheckNull(entity.IsAlwayOutStock.ToString());
                                string isSafeStock = CheckNull(entity.SafeStock.ToString());
                                string supplierPriorityCode = CheckNull(entity.SupplierPriorityCode.ToString());
                                var isAlwayBuy = CheckNull(entity.IsAlwayBuy.ToString());
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},{entity.IngredientCode}, N'{entity.IngredientName}',N'{entity.Spec}',N'{entity.Unit}',{isSafeStock},{entity.IndexNumber},{isAlwayOutStock},{supplierPriorityCode},{isAlwayBuy}),";
                            }
                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "IngredientBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 5)
                        {
                            var query = ctx.Set<Tbl_ChangeOrder>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,OrderDate,IngredientCode,OriginalOrder,ActualOrder,OrderHistoryId,SupplierId) VALUES";
                            foreach (var entity in query)
                            {
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},'{entity.OrderDate}', {entity.IngredientCode}, {entity.OriginalOrder},{entity.ActualOrder},{entity.OrderHistoryId},{entity.SupplierCode}),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "ChangeOrderBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 6)
                        {
                            var query = ctx.Set<Tbl_FoodPortion>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,DateOrder,DishMain1Number,DishMain2Number,DishSideNumber,VegetableNumber,SoupNumber,PicklesNumber,Dessert1Number,Dessert2Number,Improve1Number,GourdFoodNumber,SideMeal1Number,SideMeal2Number,SideMeal3Number,SideMeal4Number,SideMeal5Number,OrderHistoryId) VALUES";
                            foreach (var entity in query)
                            {
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},'{entity.DateOrder}', {entity.DishMain1Number}, {entity.DishMain2Number},{entity.DishSideNumber},{entity.VegetableNumber},{entity.SoupNumber},{entity.PicklesNumber},{entity.Dessert1Number},{entity.Dessert2Number},{entity.Improve1Number},{entity.GourdFoodNumber},{entity.SideMeal1Number},{entity.SideMeal2Number},{entity.SideMeal3Number},{entity.SideMeal4Number},{entity.SideMeal5Number},{entity.OrderHistoryId}),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "FoodPortionBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 7)
                        {
                            var query = ctx.Set<Tbl_HistoryInOut>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,Date,IngredientCode,Quantity,HistoryPriceId,PriceTotal,StockBeforInOut,StockAfterInOut,Status,DateTimeInOut,UserAction,BillCode,SupplierName) VALUES";
                            foreach (var entity in query)
                            {
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},'{entity.Date}',{entity.IngredientCode},{entity.Quantity},{entity.HistoryPriceId},{entity.PriceTotal},{entity.StockBeforInOut},{entity.StockAfterInOut},N'{entity.Status}','{entity.DateTimeInOut}',{entity.UserAction},{entity.BillCode},N'{entity.SupplierName}'),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "HistoryInOutBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 8)
                        {
                            var query = ctx.Set<Tbl_HistoryPrice>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,IngredientCode,Price,TimeUpdate,SupplierId,ApprovalDate,Comment,PriceMain) VALUES";
                            foreach (var entity in query)
                            {
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},{entity.IngredientCode}, {entity.Price}, '{entity.TimeUpdate}',{entity.SupplierCode},'{entity.ApprovalDate}',N'{entity.Comment}',{entity.PriceMain}),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "HistoryPriceBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 9)
                        {
                            var query = ctx.Set<Tbl_Order>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,BillCreateDate,Date,IngredientCode,ActualOrder,PlanOrder,HistoryPriceId,CurrentApprovePrice,expectedPriceTotal,PriceTotal,OrderHistoryId,SupplierId) VALUES";
                            foreach (var entity in query)
                            {
                                string actualOrder = CheckNull(entity.ActualOrder.ToString());
                                string toTalPrice = CheckNull(entity.PriceTotal.ToString());
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},'{entity.BillCreateDate}', '{entity.Date}', {entity.IngredientCode},{actualOrder},{entity.PlanOrder},{entity.HistoryPriceId},{entity.CurrentApprovePrice},{toTalPrice},{entity.OrderHistoryId},{entity.SupplierCode}),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "OrderBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 10)
                        {
                            var query = ctx.Set<Tbl_OrderHistory>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,OrderDate,OrderForDate,OrderStatus,AccountOrder,TotalPayment,HistoryOrderCode) VALUES";
                            foreach (var entity in query)
                            {
                                string totalPayment = CheckNull(entity.TotalPayment.ToString());
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},'{entity.OrderDate}', '{entity.OrderForDate}', N'{entity.OrderStatus}',{entity.AccountOrder},{totalPayment},{entity.HistoryOrderCode}),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "OrderHistoryBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 11)
                        {
                            var query = ctx.Set<Tbl_PreOrder>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,IngredientCode,PreOrder,PreDateOrder,DateOrder,OrderHistoryId) VALUES";
                            foreach (var entity in query)
                            {
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},'{entity.IngredientCode}', {entity.PreOrder}, '{entity.PreDateOrder}','{entity.DateOrder}',{entity.OrderHistoryId}),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "PreOrderBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 12)
                        {
                            var query = ctx.Set<Tbl_Stock>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,IngredientCode,Stock,Input,Output) VALUES";
                            foreach (var entity in query)
                            {
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},{entity.IngredientCode}, {entity.Stock}, {entity.Input},{entity.Output}),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "StockBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 13)
                        {
                            var query = ctx.Set<Tbl_Supplier>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,SupplierCode,SupplierName) VALUES";
                            foreach (var entity in query)
                            {
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id},{entity.SupplierCode}, N'{entity.SupplierName}'),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "SupplierBackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 14)
                        {
                            var query = ctx.Set<Model.Tbl_User>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,Account,PassWord,Type,FullName,Department,LimitedAccess) VALUES";
                            foreach (var entity in query)
                            {
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id}, N'{entity.Account}', '{entity.PassWord}',{entity.Type}, N'{entity.FullName}', N'{entity.Department}', N'{entity.LimitedAccess}'),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "Userbackup.sql"), sqlScript);
                        }
                        else if (pathNumber == 15)
                        {
                            var query = ctx.Set<Tbl_Version>();
                            string sqlScript = $"SET IDENTITY_INSERT {table} ON\nGO\nINSERT INTO {table} (Id,Version,CreateDate) VALUES";
                            foreach (var entity in query)
                            {
                                // Modify this part according to your entity class properties
                                sqlScript += $"\n({entity.Id}, {entity.Version}, '{entity.CreateDate}'),";
                            }

                            // Remove the trailing comma and add a semicolon
                            sqlScript = sqlScript.TrimEnd(',') + ";";

                            // Write the SQL script to the backup file
                            File.WriteAllText(Path.Combine(savePath, "VersionBackup.sql"), sqlScript);
                        }
                        pathNumber++;
                    }
                    MessageBox.Show("Backup completed successfully.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string CheckNull(string entity)
        {
            if (string.IsNullOrEmpty(entity)) return "NULL";
            return entity;
        }
        public static string FindUser()
        {
            List<Form> FormList = new List<Form>();
            foreach (Form form in Application.OpenForms)
            {
                string formName = form.Name;
                if (formName == "FormLogin")
                {
                    FormList.Add(form);
                }
            }
            var LastForm = (FormLogin)FormList.Last();
            return LastForm.Account;
        }

        internal static int? ConvertInt(object value)
        {
            int result;
            if(value!=null)
            {
                if (int.TryParse(value.ToString(), out result)) return result;
            }
            return null;
        }
        private static readonly HttpClient client = new HttpClient();

        public static async Task<double> GetExchangeRateFromVNDAsync(string key)
        {
            string url = $"https://v6.exchangerate-api.com/v6/cd493f7ab38bdf9c9bc61757/latest/VND";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Phân tích dữ liệu JSON trả về
                var jsonData = JObject.Parse(responseBody);
                var conversionRates = jsonData["conversion_rates"];
                var usdToVndRate = conversionRates[key].ToObject<double>();

                return usdToVndRate;
            }
            catch (HttpRequestException e)
            {
                return 0;
            }
        }
    }
}

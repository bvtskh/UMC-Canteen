using CanTeenManagement.Bussiness.ENUM;
using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CanTeenManagement.Bussiness.ENUM.OrderEnum;

namespace CanTeenManagement.Bussiness.SQLHelper
{
    public class OrderHelper
    {
        internal List<string> GetAllDayInMonth(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                            .Select(day => (new DateTime(year, month, day)).ToString("dd-MM-yyyy"))
                            .ToList();
        }
        internal string GetUserName()
        {
            return Common.FindUser();
        }

        internal string GetIngredientCodeByName(string ingredientName)
        {
            using (var context = new DBContext())
            {
                var data = context.Tbl_Ingredient.Where(w => w.IngredientName == ingredientName).FirstOrDefault();
                if (data != null) return data.IngredientCode;
                return null;
            }
        }

        internal Tbl_HistoryPrice GetHistoryPriceIsPriceMain(string ingredientCode, DateTime firstDayOfMonth)
        {
            using (var context = new DBContext())
            {
                var data = context.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingredientCode && w.ApprovalDate == firstDayOfMonth && w.PriceMain == 1).FirstOrDefault();
                return data;
            }
        }

        internal double? GetStockByIngredientCode(string ingredientCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Stock.Where(w => w.IngredientCode == ingredientCode).Select(s => s.Stock).FirstOrDefault();
            }
        }
        public object GetDishContainIngredient(string ingredCode, DateTime date)
        {
            using (var context = new DBContext())
            {
                List<string> nameDishList = new List<string>();
                var listDishInDay = context.Tbl_Menu.Where(w => w.Date == date).ToList();
                foreach (var item in listDishInDay)
                {
                    nameDishList.Add(item.MainDishes1);
                    nameDishList.Add(item.MainDishes2);
                    nameDishList.Add(item.SideDishes);
                    nameDishList.Add(item.Vegetables);
                    nameDishList.Add(item.Soup);
                    nameDishList.Add(item.Pickles);
                    nameDishList.Add(item.Improve);
                    nameDishList.Add(item.Dessert1);
                    nameDishList.Add(item.Dessert2);
                    nameDishList.Add(item.PregnantFood);
                    nameDishList.Add(item.SideMeal1);
                    nameDishList.Add(item.SideMeal2);
                    nameDishList.Add(item.SideMeal3);
                    nameDishList.Add(item.SideMeal4);
                    nameDishList.Add(item.SideMeal5);
                }
                var quantityExist = context.Tbl_Quantitative.Where(W => W.IngredientCode == ingredCode).Select(s => s.DishCode).ToList();
                foreach (var dish in quantityExist)
                {
                    if (nameDishList.Contains(dish))
                    {
                        return context.Tbl_Dish.Where(w => w.DishCode == dish).Select(s => s.Dish).FirstOrDefault();
                    }
                }
                return null;
            }
        }

        internal Tbl_Menu GetDataMenu(DateTime selectDate, OrderEnum.MenuType menuType)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Menu.Where(w => w.Date == selectDate && w.MenuType == (int)menuType).FirstOrDefault();
            }
        }

        internal bool Mung1AmLichKoAnVit(Tbl_Menu dataDishMainToday, Tbl_Menu dataDishSideToday,DateTime selectDate)
        {
            if (!IsMung1AmLich(selectDate)) return false;
            List<string> dishNameContainVit = new List<string>();
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.MainDishes1));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.MainDishes2));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.SideDishes));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.Vegetables));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.Soup));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.Pickles));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.Dessert1));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.Dessert2));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.Improve));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.PregnantFood));

            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.SideMeal1));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.SideMeal2));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.SideMeal3));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.SideMeal4));
            dishNameContainVit.Add(GetDishNameByCode(dataDishMainToday.SideMeal5));

            foreach (var dish in dishNameContainVit)
            {
                if (dish != null)
                {
                    if (dish.Contains("Vịt"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public string GetDishNameByCode(string dishCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Dish.Where(w => w.DishCode == dishCode).Select(s => s.Dish).FirstOrDefault();
            }
        }

        internal List<Tbl_Ingredient> GetIngredientAlwayBuy()
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IsAlwayBuy == 1).ToList();
            }
        }

        internal bool IsNullDataMenu(Tbl_Menu menuMain, Tbl_Menu menuSide,DataGridView dataGridView)
        {
            if (menuMain == null)
            {
                dataGridView.Rows.Clear();
            }
            if (menuSide == null)
            {
                dataGridView.Rows.Clear();
            }
            if (menuMain == null && menuSide == null)
            {
                dataGridView.Rows.Clear();
                dataGridView.Rows.Clear();
                return true;
            }
            return false;
        }

        internal int GetNextIdHistoryOrder()
        {
            using (var context = new DBContext())
            {
                if (context.Tbl_PreOrder.ToList().Count() > 1)
                {
                    return context.Tbl_OrderHistory.Select(s => s.Id).Max() + 1;
                }
                return 1;
            }
        }

        internal void ShowDataAlwayBuy(DataGridView dataGridView)
        {
            try
            {
                if (dataGridView.RowCount > 0)
                {
                    dataGridView.Rows.Clear();
                }
                List<Tbl_Ingredient> ingredientAlwayBuyList = GetIngredientAlwayBuy();
                if (ingredientAlwayBuyList.Count > 0)
                {
                    foreach (var item in ingredientAlwayBuyList)
                    {
                        dataGridView.Rows.Add();
                        int index = dataGridView.RowCount - 1;
                        dataGridView.Rows[index].Cells[0].Value = item.IngredientName;
                        dataGridView.Rows[index].Cells[2].Value = item.Unit;
                        dataGridView.Rows[index].Cells[3].Value = item.Spec;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        internal void CreatePreOrderItem(string ingredientName, string number, DateTime selectDate, DataGridView dgvPreListOrder)
        {
            Tbl_PreOrder preOrderSave = new Tbl_PreOrder();
            //Để lưu vào bảng đặt trước
            preOrderSave.IngredientCode = GetIngredientCodeByName(ingredientName);
            preOrderSave.PreDateOrder = selectDate.AddDays(1);
            preOrderSave.PreOrder = double.Parse(number);
            preOrderSave.DateOrder = selectDate;
            int idCurrent = GetNextIdHistoryOrder();
            preOrderSave.OrderHistoryId = idCurrent;
            // đẩy dữ liệu  vào datagridview
            FillPreOrederToDataGridview( ingredientName,preOrderSave,dgvPreListOrder,selectDate);
        }

        private void FillPreOrederToDataGridview(string ingredientName,Tbl_PreOrder preOrderSave,DataGridView dataGridView,DateTime selectDate)
        {
            if (IsIngredientNameAvalid(ingredientName, selectDate) != ValidIngredient.OK)
            {
                return;
            }
            if (string.IsNullOrEmpty(preOrderSave.PreOrder.ToString()))
            {              
                return;
            }
            var rowExist = dataGridView.Rows.Cast<DataGridViewRow>().Where(w => w.Cells[1].Value.ToString() == ingredientName).FirstOrDefault();
            if (rowExist == null)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[dataGridView.RowCount - 1].Cells[0].Value = preOrderSave.PreDateOrder.Value.ToString("dd-MM-yyyy");
                dataGridView.Rows[dataGridView.RowCount - 1].Cells[1].Value = ingredientName;
                dataGridView.Rows[dataGridView.RowCount - 1].Cells[2].Value = preOrderSave.PreOrder;
                dataGridView.Rows[dataGridView.RowCount - 1].Cells[3].Value = GetIngredientByCode(preOrderSave.IngredientCode) == null ? null : GetIngredientByCode(preOrderSave.IngredientCode).Unit;
            }
            else
            {
                var currentNumber = double.Parse(rowExist.Cells[2].Value.ToString());
                rowExist.Cells[2].Value = currentNumber + preOrderSave.PreOrder;
            }
        }

        private bool IsMung1AmLich(DateTime selectDate)
        {
            // Tạo một instance của ChineseLunisolarCalendar
            ChineseLunisolarCalendar lunarCalendar = new ChineseLunisolarCalendar();

            // Lấy thông tin ngày âm lịch
            int lunarDay = lunarCalendar.GetDayOfMonth(selectDate);

            return lunarDay == 1;
        }

        internal void LoadDataMenuToDatagridview(Tbl_Menu dataDishMainToday, Tbl_Menu dataDishSideToday, DataGridView dgrListDish)
        {
            try
            {
                dgrListDish.Rows.Add(15); // tao ra 15 hang du lieu
                if (dataDishMainToday != null)
                {
                    dgrListDish.Rows[0].Cells["DishTypeMain"].Value = "Món chính 1";
                    dgrListDish.Rows[0].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishMainToday.MainDishes1);

                    dgrListDish.Rows[1].Cells["DishTypeMain"].Value = "Món chính 2";
                    dgrListDish.Rows[1].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishMainToday.MainDishes2);

                    dgrListDish.Rows[2].Cells["DishTypeMain"].Value = "Món phụ";
                    dgrListDish.Rows[2].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishMainToday.SideDishes);

                    dgrListDish.Rows[3].Cells["DishTypeMain"].Value = "Rau";
                    dgrListDish.Rows[3].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishMainToday.Vegetables);

                    dgrListDish.Rows[4].Cells["DishTypeMain"].Value = "Canh";
                    dgrListDish.Rows[4].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishMainToday.Soup);

                    dgrListDish.Rows[5].Cells["DishTypeMain"].Value = "Dưa góp";
                    dgrListDish.Rows[5].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishMainToday.Pickles);

                    dgrListDish.Rows[6].Cells["DishTypeMain"].Value = "Tráng miệng 1";
                    dgrListDish.Rows[6].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishMainToday.Dessert1);

                    dgrListDish.Rows[7].Cells["DishTypeMain"].Value = "Tráng miệng 2";
                    dgrListDish.Rows[7].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishMainToday.Dessert2);

                    dgrListDish.Rows[8].Cells["DishTypeMain"].Value = "Cải thiện";
                    dgrListDish.Rows[8].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishMainToday.Improve);

                    dgrListDish.Rows[9].Cells["DishTypeMain"].Value = "Bà bầu";
                    dgrListDish.Rows[9].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishMainToday.PregnantFood);
                }

                if (dataDishSideToday != null)
                {
                    dgrListDish.Rows[10].Cells["DishTypeMain"].Value = "Ăn nhẹ 1";
                    dgrListDish.Rows[10].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishSideToday.SideMeal1);

                    dgrListDish.Rows[11].Cells["DishTypeMain"].Value = "Ăn nhẹ 2";
                    dgrListDish.Rows[11].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishSideToday.SideMeal2);

                    dgrListDish.Rows[12].Cells["DishTypeMain"].Value = "Ăn nhẹ 3";
                    dgrListDish.Rows[12].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishSideToday.SideMeal3);

                    dgrListDish.Rows[13].Cells["DishTypeMain"].Value = "Ăn nhẹ 4";
                    dgrListDish.Rows[13].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishSideToday.SideMeal4);

                    dgrListDish.Rows[14].Cells["DishTypeMain"].Value = "Ăn nhẹ 5";
                    dgrListDish.Rows[14].Cells["DishNameMain"].Value = GetDishNameByCode(dataDishSideToday.SideMeal5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        internal void AddtoAlwayBuyDatagridview(string ingredientName, double quanlity,DataGridView dataGridView,DateTime dateTime)
        {
            try
            {
                var ingredientInfo = GetIngredientByName(ingredientName);
                if (ingredientInfo != null)
                {
                    string ingredientCode = ingredientInfo.IngredientCode;
                    var unit = ingredientInfo.Unit;
                    IngredientInfo newIngredient = new IngredientInfo
                    {
                        IngredientCode = ingredientCode,
                        IngredientName = ingredientName,
                        SLCM = quanlity,
                        Unit = unit,
                        DateOrder = dateTime.Date,
                        DateOrderFor = dateTime.Date.ToString("dd-MM-yyyy"),
                    };
                    dataGridView.Rows.Add();
                    int index = dataGridView.RowCount - 1;
                    dataGridView.Rows[index].Cells[0].Value = newIngredient.IngredientName;
                    dataGridView.Rows[index].Cells[1].Value = newIngredient.SLCM;
                    dataGridView.Rows[index].Cells[2].Value = newIngredient.Unit;
                    dataGridView.Rows[index].Cells[3].Value = GetIngredientByCode(ingredientCode) == null ? null : GetIngredientByCode(ingredientCode).Spec;//spec
                    // Công nhận nguyên liệu này là thường xuyên mua
                    UpdateIngredientAlwayBuy(ingredientCode, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<string> GetIngredientNameByCode(List<string> codeList)
        {
            List<string> nameList = new List<string>();
            codeList.ForEach(f => nameList.Add(GetIngredientNameByCode(f)));
            return nameList;
        }

        private string GetIngredientNameByCode(string ingredientCode)
        {
            using(var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).Select(s => s.IngredientName).FirstOrDefault();
            }
        }

        internal List<string> GetDishNamePreOrder(List<string> dishCodeListPreOrder, DateTime timeUutien)
        {
            List<Tbl_Menu> menuList = new List<Tbl_Menu>();
            menuList.Add(GetDataMenu(timeUutien, OrderEnum.MenuType.Main));
            menuList.Add(GetDataMenu(timeUutien, OrderEnum.MenuType.Side));
            List<string> listDishNameOfMenu = new List<string>();
            foreach(var menu in menuList)
            {
                if(menu !=null)
                listDishNameOfMenu.AddRange(menu.GetType().GetProperties().Where(w => w.PropertyType == typeof(string)).Select(s => s.GetValue(menu) as string).ToList());
            }
            listDishNameOfMenu.RemoveAll(string.IsNullOrEmpty);
            return dishCodeListPreOrder.Intersect(listDishNameOfMenu).Distinct().ToList();
        }

        internal ValidIngredient IsIngredientNameAvalid(string ingredientName, DateTime date)
        {
            using (var context = new DBContext())
            {
                var listName = context.Tbl_Ingredient.Select(s => s.IngredientName).ToList();
                bool existsInList = listName.Contains(ingredientName);
                if (!existsInList)
                {
                    return ValidIngredient.InvalidName; //sai ten
                }
                else
                {
                    var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                    var ingredientCode = context.Tbl_Ingredient.Where(w => w.IngredientName == ingredientName).Select(s => s.IngredientCode).FirstOrDefault();
                    var check = context.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingredientCode && w.ApprovalDate == firstDayOfMonth && w.PriceMain == 1).FirstOrDefault();
                    if (check == null)
                    {
                        return ValidIngredient.NoPrice; // chua co bao gia
                    }
                }
                return ValidIngredient.OK;    //true        
            }
        }
        internal Tbl_Ingredient GetIngredientByName(string ingredientName)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IngredientName == ingredientName).FirstOrDefault();
            }
        }
        internal Tbl_Ingredient GetIngredientByCode(string ingredientCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
            }
        }

        internal List<Tbl_PreOrder> GetIngredientPreOrderByIngredientCode(string ingredientCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_PreOrder.Where(w => w.IngredientCode == ingredientCode).ToList();
            }
        }

        internal List<Tbl_OrderHistory> GetOrderHistoryList()
        {
            using (var context = new DBContext())
            {
                return context.Tbl_OrderHistory.ToList();
            }
        }

        internal List<Tbl_Ingredient> GetIngredientListBySearchString(string searchText)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(w => w.IngredientName.Contains(searchText)).ToList();
            }
        }

        internal void UpdateIngredientAlwayBuy(string ingredientCode, bool statusAlwayBuy)
        {
            using (var context = new DBContext())
            {
                var ingredientExist = context.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).FirstOrDefault();
                ingredientExist.IsAlwayBuy = statusAlwayBuy ? 1 : 0;
                context.SaveChanges();
            }
        }

        internal List<Tbl_Ingredient> GetIngredientSafeStock()
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Ingredient.Where(s => s.SafeStock != null && s.SafeStock != 0).ToList();
            }
        }

        internal List<string> GetDishCodeListPreOrder()
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Dish.Where(w => w.IsPreOrderDish == "OK").Select(s => s.DishCode).ToList();
            }
        }

        internal IEnumerable<string> GetIngredientCodeListOfMenu(List<Tbl_Menu> menuList)
        {
            List<string> ingredientCodeList = new List<string>();
            List<object> dishCode = new List<object>();
            foreach(var menu in menuList)
            {
                if(menu != null)
                dishCode.AddRange(menu.GetType().GetProperties().Where(w => w.PropertyType == typeof(string) && GetValueProperty(w, menu) != null).Select(s => GetValueProperty(s, menu)).ToList());
            }
            foreach (var item in dishCode)
            {
                List<Tbl_Quantitative> quantitativesList = GetQuantitativeByDishCode(item.ToString());
                quantitativesList.ForEach(f => ingredientCodeList.Add(f.IngredientCode));
            }            
            return ingredientCodeList;
        }

        internal void ShowSafeStock(DataGridView dgvSafeStock)
        {
            dgvSafeStock.Rows.Clear();
            try
            {
                var ingredientListSafeStock = GetIngredientSafeStock();
                if (ingredientListSafeStock.Count > 0)
                {
                    foreach (var item in ingredientListSafeStock)
                    {
                        double? stock = GetStockByIngredientCode(item.IngredientCode);
                        if (stock <= item.SafeStock)
                        {
                            dgvSafeStock.Rows.Add();
                            int index = dgvSafeStock.RowCount - 1;
                            dgvSafeStock.Rows[index].Cells[0].Value = item.IngredientName;
                            dgvSafeStock.Rows[index].Cells[1].Value = stock;
                            dgvSafeStock.Rows[index].Cells[3].Value = item.Unit;
                            dgvSafeStock.Rows[index].Cells[4].Value = item.SafeStock;
                        }
                    }                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex);
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
        public List<Tbl_Quantitative> GetQuantitativeByDishCode(string dishCode)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Quantitative.Where(w => w.DishCode == dishCode).ToList();
            }
        }

        internal void UpdateIngredientAlwayBuy(string ingredientName, string ingredientSpec, bool statusAlwayBuy)
        {
            using (var context = new DBContext())
            {
                var ingredientExist = context.Tbl_Ingredient.Where(w => w.IngredientName == ingredientName && w.Spec == ingredientSpec).FirstOrDefault();
                if (ingredientExist != null)
                {
                    ingredientExist.IsAlwayBuy = statusAlwayBuy ? 1 : 0;
                }
                context.SaveChanges();
            }
        }

        internal string GetDishCodeByName(string dishName)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Dish.Where(w => w.Dish == dishName).Select(s => s.DishCode).FirstOrDefault();
            }
        }

        internal List<Tbl_FoodPortion> GetFoodPortionByDate(DateTime dateSelect)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_FoodPortion.Where(w => w.DateOrder == dateSelect).ToList();
            }
        }

        internal bool IsExistOrderForThisDay(DateTime selectDate)
        {
            using (var context = new DBContext())
            {
                var value = context.Tbl_Order.Where(w => w.Date == selectDate).FirstOrDefault();
                if (value != null) return true;
                return false;
            }
        }

        internal ShowMessage IsSaveSuccessToDataBase(DateTime selectDate, List<IngredientInfo> totalListResultOrder, DataGridView dgrListIngredient, DateTime firstDayOfMonth, Tbl_FoodPortion numberFoodPortion, List<Tbl_PreOrder> listItemPreOrder)
        {
            using (var context = new DBContext())
            {
                try
                {
                    var dateCode = selectDate.ToString("ddMMyy");
                    var historyId = 1;
                    if (context.Tbl_OrderHistory.Count() > 0)
                    {
                        historyId = context.Tbl_OrderHistory.Max(m => m.Id) + 1;
                    }
                    // thêm vào lịch sử nhập hàng. Tbl_OrderHistory.
                    // nếu ngày được chọn chưa có hóa đơn nào thì tạo mới
                    var historyOrderExist = context.Tbl_OrderHistory.Where(w => w.OrderForDate == selectDate).FirstOrDefault();
                    if (historyOrderExist == null)
                    {
                        Tbl_OrderHistory orderNewHistory = new Tbl_OrderHistory();
                        orderNewHistory.OrderDate = DateTime.Now;
                        orderNewHistory.OrderForDate = selectDate;
                        orderNewHistory.OrderStatus = "Chưa nhận";
                        orderNewHistory.HistoryOrderCode = $"HD{dateCode}_{historyId}";
                        orderNewHistory.AccountOrder = Common.FindUser();
                        context.Tbl_OrderHistory.Add(orderNewHistory);
                        context.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    return new ShowMessage("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {              
                        #region Thêm vào bảng Order.
                        List<Tbl_Order> ingredientOrderList = new List<Tbl_Order>();
                        List<Tbl_ChangeOrder> changeOrderList = new List<Tbl_ChangeOrder>();
                        try
                        {
                            foreach (var item in totalListResultOrder)
                            {

                                // vẫn là Id của lịch sử mua của ngày đc chọn, chỉ tăng thêm số lần mua trong ngày. để phân biệt
                                // là đã đặt hàng hoặc chưa nhưng vẫn đảm bảo chúng ở cùng 1 hóa đơn.      
                                string ingerdientName = item.IngredientName;
                                string ingredientCode = item.IngredientCode;
                                string numberOrderPlan = dgrListIngredient.Rows.Cast<DataGridViewRow>().Where(w => w.Cells[0].Value.ToString() == item.IngredientCode).Select(s => s.Cells[5].Value == null ? "0" : s.Cells[5].Value.ToString()).FirstOrDefault();
                                if (numberOrderPlan != "0")
                                {
                                    double orderPlanOriginal = Math.Round((double)item.SLQuyetDinhMua, 3);
                                    double orderPlan = Math.Round(double.Parse(numberOrderPlan), 3);
                                    if (orderPlan <= 0) continue;
                                    // lấy giá của tháng trùng với thời gian đặt hàng.

                                    var historyPrice = context.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingredientCode && w.ApprovalDate == firstDayOfMonth && w.PriceMain == 1).FirstOrDefault();
                                    if (historyPrice == null)
                                    {
                                        return new ShowMessage($"Nguyên liệu, thực phẩm: {ingerdientName} chưa có báo giá của tháng {selectDate.Month}. Tạo hóa đơn thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    var price = GetPriceFormHistoryPriceId(historyPrice.Id);

                                    //Mỗi lần thêm là một bản ghi mới => kiểm soát được số lần nhập hàng trong ngày
                                    Tbl_Order tblOrder = new Tbl_Order();
                                    tblOrder.Date = selectDate;
                                    tblOrder.BillCreateDate = DateTime.Now;
                                    tblOrder.IngredientCode = ingredientCode;
                                    tblOrder.PlanOrder = orderPlan;
                                    tblOrder.HistoryPriceId = historyPrice.Id;
                                    tblOrder.CurrentApprovePrice = price;
                                    tblOrder.OrderHistoryId = GetHistoryOrderByDate(selectDate).Id;
                                    tblOrder.SupplierCode = GetSupplierByName(item.SupplierName).SupplierCode;
                                    // remark mua thêm trên cùng một mặt hàng
                                    if (IsIngredientOrderAgainSameInvoice(tblOrder.OrderHistoryId, ingredientCode))
                                    {
                                        tblOrder.ReMark = $"Mua thêm mặt hàng: {ingredientCode} trên cùng hóa đơn ngày: {selectDate}";
                                    }
                                    ingredientOrderList.Add(tblOrder);
                                    #region ghi lại sự thay đổi của người tạo đơn hàng khi họ trực tiếp sửa trên datagridview
                                    if (orderPlanOriginal != orderPlan)
                                    {
                                        Tbl_ChangeOrder newChangeOrder = new Tbl_ChangeOrder();
                                        newChangeOrder.OrderDate = selectDate;
                                        newChangeOrder.IngredientCode = ingredientCode;
                                        newChangeOrder.OriginalOrder = orderPlanOriginal;
                                        newChangeOrder.ActualOrder = orderPlan;
                                        newChangeOrder.OrderHistoryId = tblOrder.OrderHistoryId;
                                        newChangeOrder.SupplierCode = tblOrder.SupplierCode;
                                        changeOrderList.Add(newChangeOrder);
                                    }
                                    #endregion
                                }
                            }
                            context.Tbl_Order.AddRange(ingredientOrderList);
                            context.Tbl_ChangeOrder.AddRange(changeOrderList);
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return new ShowMessage("Xảy ra lỗi trong lúc đặt hàng, Đặt hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion
                        #region thêm số lượng suất ăn vào bảng.
                        try
                        {
                            // nếu ngày chọn đã đặt hàng rồi thì cộng dồn thêm số lượng suất ăn.
                            numberFoodPortion.DateOrder = selectDate;
                            numberFoodPortion.OrderHistoryId = GetHistoryOrderByDate(selectDate).Id;
                            context.Tbl_FoodPortion.Add(numberFoodPortion);
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return new ShowMessage("Xảy ra lỗi trong lúc lưu lại số lượng suất ăn, Đặt hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion
                        try
                        {
                            // thêm vào bảng đặt trước.
                            if (listItemPreOrder.Count > 0)
                            {
                                foreach (var item in listItemPreOrder)
                                {
                                    var stock = GetStockByIngredientCode(item.IngredientCode);
                                    if (stock == null) stock = 0;
                                    item.OrderHistoryId = GetHistoryOrderByDate(selectDate).Id;
                                }
                                context.Tbl_PreOrder.AddRange(listItemPreOrder);
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return new ShowMessage("Xảy ra lỗi trong lúc lưu lại số lượng đặt trước, Đặt hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        context.SaveChanges();
                        // If all operations succeed, commit the transaction
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return new ShowMessage("Xảy ra lỗi trong lúc lưu lại số lượng đặt trước, Đặt hàng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return null;
        }
        public int? GetPriceFormHistoryPriceId(int id)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_HistoryPrice.Where(w => w.Id == id).Select(s => s.Price).FirstOrDefault();
            }
        }
        public Tbl_OrderHistory GetHistoryOrderByDate(DateTime selectDate)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_OrderHistory.Where(w => w.OrderForDate == selectDate).FirstOrDefault();
            }
        }
        public Tbl_Supplier GetSupplierByName(string supplierName)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Supplier.Where(w => w.SupplierName == supplierName).FirstOrDefault();
            }
        }
        public bool IsIngredientOrderAgainSameInvoice(int? orderHistoryId, string ingredientCode)
        {
            using (var context = new DBContext())
            {
                var existData = context.Tbl_Order.Where(w => w.OrderHistoryId == orderHistoryId && w.IngredientCode == ingredientCode).FirstOrDefault();
                if (existData != null) return true;
                return false;
            }
        }

        internal bool IsPayedBill(DateTime selectDate)
        {
            using (var context = new DBContext())
            {
                if (context.Tbl_OrderHistory.Where(w => w.OrderForDate == selectDate && w.OrderStatus == "Đã nhận").FirstOrDefault() != null) return true;
                return false;
            }
        }

        internal List<Tbl_PreOrder> GetIngredientPreOrderListFromDate(DateTime selectDate)
        {
            using (var context = new DBContext())
            {
                return context.Tbl_PreOrder.Where(w => w.PreDateOrder == selectDate).ToList();
            }
        }

        internal List<Tbl_PreOrder> FilterDataPreOrders(List<Tbl_PreOrder> listPreOrder, DateTime selectDate)
        {
            List<Tbl_PreOrder> resultList = new List<Tbl_PreOrder>();
            foreach (var item in listPreOrder)
            {
                if (item.DateOrder == selectDate.AddDays(-1))
                {
                    resultList.Add(item);
                }
            }
            return resultList;
        }

        internal IEnumerable<IngredientInfo> GetDetailInfoIngredient(string dishCode, int totalEatMain, DateTime approvalDate)
        {          
            using (var context = new DBContext())
            {
                var infoDish = context.Tbl_Quantitative.Where(w => w.DishCode == dishCode).Select(s => new IngredientInfo
                {
                    IngredientCode = s.IngredientCode,
                    IngredientName = context.Tbl_Ingredient.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.IngredientName).FirstOrDefault(),
                    Price = context.Tbl_HistoryPrice.Where(w => w.IngredientCode == s.IngredientCode && w.ApprovalDate == approvalDate && w.PriceMain == 1).FirstOrDefault().Price.ToString(),
                    SupplierName = context.Tbl_Supplier.Where(w1 => w1.SupplierCode == context.Tbl_HistoryPrice.Where(w => w.IngredientCode == s.IngredientCode && w.ApprovalDate == approvalDate && w.PriceMain == 1).FirstOrDefault().SupplierCode).FirstOrDefault().SupplierName,
                    Unit = context.Tbl_Ingredient.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.Unit).FirstOrDefault(),
                    SLCM = (double)s.Quantitative * totalEatMain, // Ăn cải thiện vẫn múc canh bình thường.
                    Stock = (float)context.Tbl_Stock.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.Stock).FirstOrDefault(),
                }).ToList();
                return infoDish;
            }
        }

        private string GetSupplierNameByCode(string supplierCode)
        {
            using(var context = new DBContext())
            {
                var item = context.Tbl_Supplier.Where(w => w.SupplierCode == supplierCode).FirstOrDefault();
                if (item != null) return item.SupplierName;
                return null;
            }
        }

        internal IEnumerable<IngredientInfo> GetDetailInfoIngredient(string dishCode, int totalEatMain, int ortherNumberDish, DateTime approvalDate)
        {
            using (var context = new DBContext())
            {
                var infoDish = context.Tbl_Quantitative.Where(w => w.DishCode == dishCode).Select(s => new IngredientInfo
                {
                    IngredientCode = s.IngredientCode,
                    IngredientName = context.Tbl_Ingredient.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.IngredientName).FirstOrDefault(),
                    Price = context.Tbl_HistoryPrice.Where(w => w.IngredientCode == s.IngredientCode && w.ApprovalDate == approvalDate && w.PriceMain == 1).FirstOrDefault().Price.ToString(),
                    SupplierName = context.Tbl_Supplier.Where(w1 => w1.SupplierCode == context.Tbl_HistoryPrice.Where(w => w.IngredientCode == s.IngredientCode && w.ApprovalDate == approvalDate && w.PriceMain == 1).FirstOrDefault().SupplierCode).FirstOrDefault().SupplierName,
                    Unit = context.Tbl_Ingredient.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.Unit).FirstOrDefault(),
                    SLCM = (double)s.Quantitative * (totalEatMain - ortherNumberDish), // Ăn cải thiện thì không có rau.
                    Stock = (float)context.Tbl_Stock.Where(w => w.IngredientCode == s.IngredientCode).Select(ss => ss.Stock).FirstOrDefault(),
                }).ToList();
                return infoDish;
            }
        }

        internal bool IsNotUpdatePriceForDate(DateTime firstDayOfMonth)
        {
            using (var context = new DBContext())
            {
                var data = context.Tbl_HistoryPrice.Where(w => w.ApprovalDate == firstDayOfMonth && w.PriceMain == 1).FirstOrDefault();
                if (data == null) return false;
                return true;
            }
        }

        internal List<Tbl_PreOrder> GetIngredPreOrder(List<IngredientInfo> ingredientPreOrderList)
        {
            List<Tbl_PreOrder> listItemPreOrder = new List<Tbl_PreOrder>();
            foreach (var item in ingredientPreOrderList)
            {
                Tbl_PreOrder tblPreOrder = new Tbl_PreOrder();
                tblPreOrder.DateOrder = item.DateOrder;
                tblPreOrder.IngredientCode = item.IngredientCode;
                tblPreOrder.OrderHistoryId = null;
                tblPreOrder.PreDateOrder = item.PreDateOrder;
                tblPreOrder.PreOrder = item.SLCM - item.Stock;
                if (tblPreOrder.PreOrder <= 0) continue;
                listItemPreOrder.Add(tblPreOrder);
            }
            return listItemPreOrder;
        }

        internal List<IngredientInfo> GetSafeStockDataFromDGV(DataGridView dgvSafeStock,DateTime selectDate, DateTime firstDayOfMonth)
        {
            List<IngredientInfo> ingredientSafeStockList = new List<IngredientInfo>();
            foreach (DataGridViewRow row in dgvSafeStock.Rows)
            {
                var ingredientName = row.Cells[0].Value.ToString();
                var ingredientCode = GetIngredientCodeByName(ingredientName);
                var numberOrder = row.Cells[2].Value == null ? "0" : row.Cells[2].Value.ToString();
                if (numberOrder == "0") continue;
                var unit = row.Cells[3].Value ==null?"": row.Cells[3].Value.ToString();
                Tbl_HistoryPrice historyPriceExist = GetHistoryPriceIsPriceMain(ingredientCode, firstDayOfMonth);
                if (historyPriceExist == null)
                {                   
                    return null;
                }
                string Price = ConvertToFormattedString((int)historyPriceExist.Price);
                double bill = double.Parse(numberOrder.ToString()) * (Convert.ToDouble(historyPriceExist.Price));
                var stock = GetStockByIngredientCode(ingredientCode);
                var supplierName = GetsupplierNameById(GetHistoryPriceIsPriceMain(ingredientCode, firstDayOfMonth).SupplierCode);
                IngredientInfo safeSTNewItem = new IngredientInfo
                {
                    IngredientCode = ingredientCode,
                    Stock = (float)stock,
                    IngredientName = ingredientName,
                    Price = Price,
                    SLCM = double.Parse(numberOrder.ToString()),
                    Bill = bill,
                    SupplierName = supplierName,
                    DateOrder = selectDate,
                    PreDateOrder = selectDate.AddDays(1),
                    Unit = unit
                };
                ingredientSafeStockList.Add(safeSTNewItem);
            }
            return ingredientSafeStockList;
        }
        public string ConvertToFormattedString(double value)
        {

            int integerValue = (int)value; // Extract the integer part
            string numberString = integerValue.ToString(); // Convert the integer value to string
            string formattedString = "";

            // Add comma separators every 3 characters from right to left
            for (int i = numberString.Length - 1, count = 0; i >= 0; i--, count++)
            {
                formattedString = numberString[i] + formattedString;
                if (count % 3 == 2 && i > 0)
                {
                    formattedString = "," + formattedString;
                }
            }

            return formattedString;
        }

        internal List<IngredientInfo> GetIngredientAlwayBuyFromDGV(DataGridView dgvAlwayBuy,DateTime selectDate,DateTime firstDayOfMonth)
        {
            List<IngredientInfo> ingredientAlwayBuyList = new List<IngredientInfo>();
            foreach (DataGridViewRow row in dgvAlwayBuy.Rows)
            {
                var ingredientName = row.Cells[0].Value.ToString();
                var ingredientCode = GetIngredientCodeByName(ingredientName);
                var numberOrder = row.Cells[1].Value == null ? "0" : row.Cells[1].Value.ToString();
                string unit  = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
                if (numberOrder == "0") continue;
                var historyPriceExist = GetHistoryPriceIsPriceMain(ingredientCode, firstDayOfMonth);
                if (historyPriceExist == null)
                {
                    MessageBox.Show($"Chưa cập nhật giá tháng {selectDate.Month} cho {ingredientName}");
                    return null;
                }
                string Price = ConvertToFormattedString((int)historyPriceExist.Price);
                double bill = double.Parse(numberOrder.ToString()) * (Convert.ToDouble(historyPriceExist.Price));
                var stock = GetStockByIngredientCode(ingredientCode);
                var supplierName = GetsupplierNameById(GetHistoryPriceIsPriceMain(ingredientCode, firstDayOfMonth).SupplierCode);
                IngredientInfo preOrderNewItem = new IngredientInfo
                {
                    IngredientCode = ingredientCode,
                    Stock = (float)stock,
                    IngredientName = ingredientName,
                    Price = Price,
                    SLCM = double.Parse(numberOrder.ToString()),
                    Bill = bill,
                    SupplierName = supplierName,
                    DateOrder = selectDate,
                    PreDateOrder = selectDate.AddDays(1),
                    Unit =unit
                };
                ingredientAlwayBuyList.Add(preOrderNewItem);
            }
            return ingredientAlwayBuyList;
        }

        internal List<string> GetSupplierSelectOrder(DataGridView dgrListIngredient)
        {
            List<string> supplierSelectOrder = new List<string>();
            foreach (DataGridViewRow row in dgrListIngredient.Rows)
            {
                string supplier = row.Cells["ncc"].Value.ToString();
                if (!supplierSelectOrder.Contains(supplier) && Convert.ToDouble(row.Cells["SLQuyetDinhMua"].Value) != 0 && row.Cells["SLQuyetDinhMua"].Value != null)
                {
                    supplierSelectOrder.Add(supplier);
                }
            }
            return supplierSelectOrder;
        }

        internal bool ExportOrderListToExcel(string[] supplierArray,DateTime selectDate,DataGridView dataGridView)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    DialogResult result = folderBrowserDialog.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                    {
                        Common.StartFormLoading();
                        string selectedPath = folderBrowserDialog.SelectedPath;
                        string baseFolderPath = Path.Combine(selectedPath, $"Đơn hàng " + selectDate.Day.ToString() + "_" + selectDate.Month.ToString() + "_" + selectDate.Year.ToString());
                        string finalFolderPath = baseFolderPath;

                        int ordinal = 1;
                        while (Directory.Exists(finalFolderPath))
                        {
                            finalFolderPath = $"{baseFolderPath} ({ordinal})";
                            ordinal++;
                        }

                        // Create the folder if it doesn't exist
                        Directory.CreateDirectory(finalFolderPath);
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        for (int i = 0; i < supplierArray.Length; i++)
                        {
                            string ncc = supplierArray[i];
                            string filePath = Path.Combine(finalFolderPath, $"Đơn hàng {ncc} ngày " + selectDate.Day.ToString() + "_" + selectDate.Month.ToString() + "_" + selectDate.Year.ToString() + ".xlsx");
                            if (!OpenAndEditExcelFile(@"\\vn-file\\DX Center\\36. CanTeenManagement\\Master\\FileMau.xlsx", dataGridView, ncc, filePath, selectDate)) return false;
                        }
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal List<IngredientInfo> GetIngredPreOrderFromDGV(DataGridView dgvPreListOrder, DateTime selectDate, DateTime firstDayOfMonth)
        {
            List<IngredientInfo> ingredientPreOrderList = new List<IngredientInfo>();

            foreach (DataGridViewRow row in dgvPreListOrder.Rows)
            {
                var ingredientName = row.Cells[1].Value.ToString();
                var ingredientCode = GetIngredientCodeByName(ingredientName);
                var numberPreOrder = row.Cells[2].Value == null ? 0 : double.Parse(row.Cells[2].Value.ToString());
                string unit = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();
                var historyPriceExist = GetHistoryPriceIsPriceMain(ingredientCode, firstDayOfMonth);
                if (historyPriceExist == null)
                {
                    MessageBox.Show($"Chưa cập nhật giá tháng {selectDate.Month} cho {ingredientName}");
                    return null;
                }
                string Price = ConvertToFormattedString((int)historyPriceExist.Price);

                var stock = GetStockByIngredientCode(ingredientCode);
                string supplierName = GetsupplierNameById(GetHistoryPriceIsPriceMain(ingredientCode, firstDayOfMonth).SupplierCode);
                IngredientInfo preOrderNewItem = new IngredientInfo
                {
                    IngredientCode = ingredientCode,
                    Stock = (float)stock,
                    IngredientName = ingredientName,
                    Price = Price,
                    SLCM = numberPreOrder,
                    SupplierName = supplierName,
                    DateOrder = selectDate,
                    PreDateOrder = selectDate.AddDays(1),
                    Unit = unit
                };
                ingredientPreOrderList.Add(preOrderNewItem);
            }
            return ingredientPreOrderList;
        }

        private string GetsupplierNameById(string supplierCode)
        {
            using(var context = new DBContext())
            {
                if (supplierCode != null) return context.Tbl_Supplier.Find(supplierCode).SupplierName;
                return null;
            }
        }

        internal bool OpenAndEditExcelFile(string filePathBase, DataGridView dataGridView, string ncc, string filePathSave,DateTime selectDate)
        {
            try
            {
                // Load the Excel file into a workbook
                using (FileStream fileStream = new FileStream(filePathBase, FileMode.Open, FileAccess.Read))
                {
                    NPOI.SS.UserModel.IWorkbook workbook = new XSSFWorkbook(fileStream);

                    // Access the first sheet in the workbook
                    ISheet sheet = workbook.GetSheetAt(0);

                    // Filter the data based on ncc
                    var filteredRows = dataGridView.Rows.Cast<DataGridViewRow>()
                        .Where(row => row.Cells["NCC"].Value.ToString().Equals(ncc, StringComparison.OrdinalIgnoreCase) && row.Cells["SLQuyetDinhMua"].Value.ToString() != "0");
                    // tên nhà cung cấp

                    IRow row0 = sheet.GetRow(0);
                    row0.Cells[6].SetCellValue(ncc);
                    // thời gian đặt hàng.
                    IRow row2 = sheet.GetRow(2);
                    var dateTimeOrder = $"Ngày {selectDate.Day}  tháng {selectDate.Month}  năm {selectDate.Year}";
                    row2.Cells[1].SetCellValue(dateTimeOrder);
                    // bắt đầu ghi từ hàng thứ 4.
                    int rowIndex = 4;
                    sheet.ShiftRows(rowIndex, sheet.LastRowNum, filteredRows.Count(), true, false); // tạo hàng theo số lượng thực phẩm
                    int stt = 0;
                    foreach (var row in filteredRows)
                    {
                        string slcanmua = row.Cells[5].Value.ToString(); // số lượng đặt hàng lấy từ datagridview.
                        if (slcanmua == "0") continue;
                        //Custom hàng, ô theo mẫu.
                        IRow dataRow = sheet.CreateRow(rowIndex++);
                        for (int cel = 0; cel < 10; cel++)
                        {
                            NPOI.SS.UserModel.IFont font = workbook.CreateFont();
                            font.FontName = "Times New Roman";
                            // Create a cell style with thick border
                            ICellStyle cellStyle = workbook.CreateCellStyle();
                            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                            cellStyle.SetFont(font);
                            cellStyle.WrapText = false;
                            dataRow.CreateCell(cel);
                            dataRow.Cells[cel].CellStyle = cellStyle;
                        }
                        dataRow.Cells[0].SetCellValue(++stt); // số thứ tự.
                        dataRow.Cells[1].SetCellValue(row.Cells[0].Value.ToString().Trim()); // lấy mã thực phẩm.
                        dataRow.Cells[2].SetCellValue(row.Cells[1].Value.ToString());//Lấy tên nl từ datagridview

                        double result;
                        if (double.TryParse(slcanmua, out result))
                        {
                            double convert;
                            if (result > 1)
                            {
                                convert = Math.Round(result, 2);
                            }
                            else
                            {
                                convert = Math.Round(result, 3);
                            }

                            dataRow.Cells[3].SetCellValue(convert);// Lấy sl cần đặt hàng.
                        }
                        dataRow.Cells[5].SetCellValue(row.Cells[6].Value.ToString()); // don vi tinh                          
                    }
                    // Autosize columns
                    for (int colIndex = 0; colIndex < 7; colIndex++)
                    {
                        sheet.AutoSizeColumn(colIndex);

                    }
                    // Save the workbook to the specified file path
                    using (FileStream fileStreamm = new FileStream(filePathSave, FileMode.Create, FileAccess.Write))
                    {
                        workbook.Write(fileStreamm);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        internal List<IngredientInfo> SortUniqueIngredientList(List<Tbl_PreOrder> afterFilterPreOrder, List<IngredientInfo> uniqueIngredientList)
        {
            foreach (var item in afterFilterPreOrder)
            {
                foreach (var data in uniqueIngredientList)
                {
                    if (data.IngredientCode == item.IngredientCode)
                    {
                        if (data.PreOrder == null) data.PreOrder = 0;
                        data.PreOrder += (float)item.PreOrder; // cong don so luong da dat hang truoc do cua moi loai nguyen lieu
                        data.SLQuyetDinhMua = Math.Round((double)(data.SLCM - (data.PreOrder + data.Stock)), 3); // sl quyết định mua được tính bằng sl ước tính trừ đi đã đặt trước cộng với tồn kho
                        if (data.SLQuyetDinhMua <= 0)
                        {
                            data.SLQuyetDinhMua = 0;
                        }
                    }
                }
            }
            return uniqueIngredientList;
        }

        internal IngredientInfo IsNullPriceAndSupplier(List<IngredientInfo> totalList)
        {
            foreach (var item in totalList)
            {
                if (item.Price == null || item.SupplierName == null)
                {
                    return item;
                }
            }
            return null;
        }

        internal Tbl_FoodPortion CreateNumberFoodPortion(int mainDishNumber1, int mainDishNumber2, int improveDishNumber, int gourdNumber, int side1, int side2, int side3, int side4, int side5)
        {
            Tbl_FoodPortion tbl_FoodPortion = new Tbl_FoodPortion();
            tbl_FoodPortion.DishMain1Number = mainDishNumber1;
            tbl_FoodPortion.DishMain2Number = mainDishNumber2;
            tbl_FoodPortion.DishSideNumber = mainDishNumber1 + mainDishNumber2;
            tbl_FoodPortion.VegetableNumber = mainDishNumber1 + mainDishNumber2;
            tbl_FoodPortion.SoupNumber =mainDishNumber1 + mainDishNumber2 + improveDishNumber;
            tbl_FoodPortion.PicklesNumber = mainDishNumber1 + mainDishNumber2 + improveDishNumber;
            tbl_FoodPortion.Dessert1Number = mainDishNumber1 + mainDishNumber2 + improveDishNumber;
            tbl_FoodPortion.Dessert2Number =mainDishNumber1 + mainDishNumber2 + improveDishNumber;
            tbl_FoodPortion.Improve1Number = improveDishNumber;
            tbl_FoodPortion.GourdFoodNumber = gourdNumber;
            tbl_FoodPortion.SideMeal1Number = side1;
            tbl_FoodPortion.SideMeal2Number = side2;
            tbl_FoodPortion.SideMeal3Number = side3;
            tbl_FoodPortion.SideMeal4Number = side4;
            tbl_FoodPortion.SideMeal5Number = side5;
            return tbl_FoodPortion;
        }
    }
}

using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement
{
    public partial class FormUuTienDatHang : Form
    {
        public List<IngredientInfo> AddPreOrderList { get; set; }
        public List<Tbl_PreOrder> PreOrderList { get; set; }
        Tbl_Menu listMainMenu;
        Tbl_Menu listSideMenu;
        DateTime timeUutien;
        DateTime timeOrder;
        public FormUuTienDatHang()
        {
            InitializeComponent();
        }

        public FormUuTienDatHang(Tbl_Menu listMainMenu, Tbl_Menu listSideMenu , DateTime timeUutien, DateTime timeOrder)
        {
            InitializeComponent();
            this.listMainMenu = listMainMenu;
            this.listSideMenu = listSideMenu;
            this.timeUutien = timeUutien;
            this.timeOrder = timeOrder;
            lbOrder.Text = timeOrder.ToString("dd-MM-yyyy");
            lbPreOrder.Text = timeUutien.ToString("dd-MM-yyyy");

        }

        private void FormUuTienDatHang_Load(object sender, EventArgs e)
        {
            List<string> listName = GetListName(listMainMenu, listSideMenu);
            cbIngredientList.DataSource = listName;
            cbIngredientList.SelectedItem = -1;
        }

        private List<string> GetListName(Tbl_Menu listMainMenu, Tbl_Menu listSideMenu)
        {
            List<string> listIngredientName = new List<string>();
            using(var ctx = new DBContext())
            {
                List<Tbl_Quantitative> dishMain1Ingredients = ctx.Tbl_Quantitative.Where(w=>w.DishCode == listMainMenu.MainDishes1).ToList();
                List<Tbl_Quantitative> dishMain2Ingredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listMainMenu.MainDishes2).ToList();
                List<Tbl_Quantitative> vegetableIngredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listMainMenu.Vegetables).ToList();
                List<Tbl_Quantitative> soupIngredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listMainMenu.Soup).ToList();
                List<Tbl_Quantitative> picklesIngredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listMainMenu.Pickles).ToList();
                List<Tbl_Quantitative> improveIngredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listMainMenu.Improve).ToList();
                List<Tbl_Quantitative> GourdFoodIngredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listMainMenu.PregnantFood).ToList();
                List<Tbl_Quantitative> sideDishIngredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listMainMenu.SideDishes).ToList();
                List<Tbl_Quantitative> Dessert1Ingredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listMainMenu.Dessert1).ToList();
                List<Tbl_Quantitative> dessert2Ingredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listMainMenu.Dessert2).ToList();
                // menu nhe
                List<Tbl_Quantitative> sideMeal1Ingredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listSideMenu.SideMeal1).ToList();
                List<Tbl_Quantitative> sideMeal2Ingredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listSideMenu.SideMeal2).ToList();
                List<Tbl_Quantitative> sideMeal3Ingredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listSideMenu.SideMeal3).ToList();
                List<Tbl_Quantitative> sideMeal4Ingredients = ctx.Tbl_Quantitative.Where(w => w.DishCode == listSideMenu.SideMeal4).ToList();
                // lay ten nl
                foreach(var ingredient in dishMain1Ingredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in dishMain2Ingredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in sideDishIngredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in vegetableIngredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in soupIngredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in picklesIngredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in improveIngredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in GourdFoodIngredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in Dessert1Ingredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in Dessert1Ingredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in sideMeal1Ingredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in sideMeal2Ingredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in sideMeal3Ingredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
                foreach (var ingredient in sideMeal4Ingredients)
                {
                    listIngredientName.Add(ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredient.IngredientCode).Select(s => s.IngredientName).FirstOrDefault());
                }
            }
            return listIngredientName;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
           
            using (var ctx = new DBContext())
            {
                var name = cbIngredientList.SelectedItem as string;
                if (!CheckIngredientNameAvalid(name))
                {
                    return;
                }
                var code = ctx.Tbl_Ingredient.Where(w => w.IngredientName == name).Select(s => s.IngredientCode).FirstOrDefault();
                if (string.IsNullOrEmpty(txtNumber.Text))
                {
                    MessageBox.Show("Số lượng nhập không đúng!");
                    return;
                }
                var rowExist = dgvPreListOrder.Rows.Cast<DataGridViewRow>().Where(w => w.Cells[2].Value.ToString() == name).FirstOrDefault();
                if (rowExist == null)
                {
                    dgvPreListOrder.Rows.Add();
                    dgvPreListOrder.Rows[dgvPreListOrder.RowCount - 1].Cells[0].Value = timeUutien.ToString("dd-MM-yyyy");
                    dgvPreListOrder.Rows[dgvPreListOrder.RowCount - 1].Cells[1].Value = code;
                    dgvPreListOrder.Rows[dgvPreListOrder.RowCount - 1].Cells[2].Value = name;
                    dgvPreListOrder.Rows[dgvPreListOrder.RowCount - 1].Cells[3].Value = txtNumber.Text;
                    dgvPreListOrder.Rows[dgvPreListOrder.RowCount - 1].Cells[4].Value = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == code).Select(s => s.Unit).FirstOrDefault();
                }
                else
                {
                    var currentNumber = double.Parse(rowExist.Cells[3].Value.ToString());
                    rowExist.Cells[3].Value = currentNumber + double.Parse(txtNumber.Text);
                }
            }                       
        }
        bool checkValid;
        private bool CheckIngredientNameAvalid(string ingredientName)
        {
            using (var ctx = new DBContext())
            {
                var listName = ctx.Tbl_Ingredient.Select(s => s.IngredientName).ToList();
                bool existsInList = listName.Contains(ingredientName);
                if (!existsInList)
                {
                    MessageBox.Show("Thực phẩm bạn vừa thêm chưa đúng!");
                    checkValid = false;
                }
                else
                {
                    var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    var ingredientCode = ctx.Tbl_Ingredient.Where(w => w.IngredientName == ingredientName).Select(s => s.IngredientCode).FirstOrDefault();
                    var check = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == ingredientCode && w.ApprovalDate == firstDayOfMonth && w.PriceMain == 1).FirstOrDefault();
                    if (check == null)
                    {
                        MessageBox.Show("Thực phẩm này chưa được cập nhật giá!");
                        checkValid = false;
                    }
                    else
                    {
                        checkValid = true;
                    }
                }
            }
            return checkValid;
        }
        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            using(var ctx = new DBContext())
            {
                PreOrderList = new List<Tbl_PreOrder>();
                foreach (DataGridViewRow row in dgvPreListOrder.Rows)
                {                  
                    Tbl_PreOrder dataNew = new Tbl_PreOrder();
                    dataNew.IngredientCode = row.Cells[1].Value.ToString();
                    dataNew.PreDateOrder = DateTime.ParseExact(row.Cells[0].Value.ToString(), "dd-MM-yyyy", null);
                    dataNew.PreOrder = double.Parse(row.Cells[3].Value.ToString());
                    PreOrderList.Add(dataNew);
                    GetDetailData();
                }
            }           
            this.Close();
        }

        private void GetDetailData()
        {
            AddPreOrderList = new List<IngredientInfo>();
            if (AddPreOrderList.Count > 0 || AddPreOrderList != null) AddPreOrderList.Clear();
            using (var ctx = new DBContext())
            {
                foreach(DataGridViewRow row in dgvPreListOrder.Rows)
                {
                    
                    var code = row.Cells[1].Value.ToString();
                    var name = row.Cells[2].Value.ToString();
                    var sl = double.Parse(row.Cells[3].Value.ToString());
                    var unit = row.Cells[4].Value.ToString();
                    var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    var price = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == code && w.ApprovalDate == date && w.PriceMain == 1).Select(ss => ss.Price).FirstOrDefault();
                    string Price = ConvertToFormattedString((int)price);
                    double bill = sl * (Convert.ToDouble(price));
                    string Bill = ConvertToFormattedString(bill);
                    var stock = ctx.Tbl_Stock.Where(w => w.IngredientCode == code).Select(s => s.Stock).FirstOrDefault();
                    var Quanti = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == code).Select(ss => ss.Unit).FirstOrDefault();
                    var NCC = ctx.Tbl_HistoryPrice.Where(w => w.IngredientCode == code && w.ApprovalDate == date && w.PriceMain == 1).FirstOrDefault().SupplierCode;
                    var newobj = new IngredientInfo { IngredientCode = code, Stock = (float)stock, IngredientName = name, Price = Price, SLCM = sl, Bill = bill, SupplierName = NCC, Unit = Quanti ,DateOrder = DateTime.ParseExact(lbOrder.Text, "dd-MM-yyyy", null), PreDateOrder= DateTime.ParseExact(lbPreOrder.Text,"dd-MM-yyyy",null)};

                    AddPreOrderList.Add(newobj);
                }              
            }
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

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator)
            {
                e.Handled = true; // Prevent the character from being entered
            }

            // Allow the backspace key
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }

            // Allow only one decimal separator
            if (e.KeyChar == decimalSeparator && ((TextBox)sender).Text.Contains(decimalSeparator))
            {
                e.Handled = true;
            }
        }
        bool checkClick = false;
        private void dgvPreListOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int row = e.RowIndex;
                if (dgvPreListOrder.Rows[row] == null)
                {
                    checkClick = false;
                    btnDel.Visible = false;
                    return;
                }
                else
                {
                    rowIndex = dgvPreListOrder.Rows[row];
                    checkClick = true;
                    btnDel.Visible = true;
                    return;
                }
            }
        }
        DataGridViewRow rowIndex = new DataGridViewRow();
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkClick == true && rowIndex != null)
                {
                    dgvPreListOrder.Rows.Remove(rowIndex);
                    btnDel.Visible = false;
                }
                else
                {
                    btnDel.Visible = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void cbIngredientList_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                var getUnit = ctx.Tbl_Ingredient.Where(w => w.IngredientName == cbIngredientList.Text.ToString()).Select(s => s.Unit).FirstOrDefault();
                lbUnit.Text = getUnit;
            }
        }
    }
}

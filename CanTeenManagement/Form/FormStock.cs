using CanTeenManagement.Bussiness.SQLHelper;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement
{
    public partial class FormStock : Form
    {
        List<Tbl_HistoryInOut> dataFromStockAll;
        List<Tbl_HistoryInOut> dataFromStockIn;
        List<Tbl_HistoryInOut> dataFromStockOut;

        StockHelper _stockHelper = new StockHelper();
        public FormStock()
        {
            InitializeComponent();
            DateTime currentDate = DateTime.Now.AddDays(2);
            DateTime previousMonthDate = currentDate.AddMonths(-1);

            datefrom.Value = previousMonthDate;
            dateTo.Value= DateTime.Now.AddDays(2);
            datefrom.Format = DateTimePickerFormat.Custom;
            dateTo.Format = DateTimePickerFormat.Custom;
            datefrom.CustomFormat = "dd-MM-yyyy";
            dateTo.CustomFormat = "dd-MM-yyyy";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchIngredient();
        }
        
        private void SearchIngredient()
        {
            try
            {
                Common.StartFormLoading();
                dgrStock.Rows.Clear();
                string searchStr = txtSearch.Text;
                List<Tbl_Ingredient> resultList = _stockHelper.GetIngerdient(searchStr);
                for (int item = 0; item < resultList.Count(); item++)
                {
                    var data = resultList[item];
                    var stock = _stockHelper.GetStockValue(data.IngredientCode);
                    if (stock == null) stock = 0;
                    dgrStock.Rows.Add();
                    dgrStock.Rows[item].Cells[0].Value = data.IngredientCode;
                    dgrStock.Rows[item].Cells[1].Value = data.IngredientName;
                    dgrStock.Rows[item].Cells[2].Value = Common.ConvertText(Math.Round((double)stock, 3));
                    dgrStock.Rows[item].Cells[3].Value = data.Unit;
                    dgrStock.Rows[item].Cells[4].Value = data.Spec;
                    dgrStock.Rows[item].Cells[5].Value = data.SafeStock;
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }
      
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgrHistory.DataSource = null;
                dgrHistory.Rows.Clear();
                dgrHistory.AutoGenerateColumns = false;
                var startSearch = datefrom.Value.Date;
                var endSearch = dateTo.Value.Date;
                List<object> listIO = new List<object>();
                if (cbStatus.SelectedIndex == 0) //chon tat ca
                {
                    List<Tbl_HistoryInOut> searchResults = _stockHelper.SearchObjectsByDate(dataFromStockAll, startSearch, endSearch);
                    ViewDataOnHistoryInOut(searchResults);
                }
                if (cbStatus.SelectedIndex == 1)
                {
                    List<Tbl_HistoryInOut> searchResults = _stockHelper.SearchObjectsByDate(dataFromStockIn, startSearch, endSearch);
                    ViewDataOnHistoryInOut(searchResults);
                }
                if (cbStatus.SelectedIndex == 2)
                {
                    List<Tbl_HistoryInOut> searchResults =  _stockHelper.SearchObjectsByDate(dataFromStockOut, startSearch, endSearch);
                    ViewDataOnHistoryInOut(searchResults);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }           
        }
      
        private void dgrStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgrHistory.AutoGenerateColumns = false;
                var startSearch = datefrom.Value;
                var endSearch = dateTo.Value;                 
                if (e.RowIndex >= 0) // Check if a row was clicked (not header or empty area)
                {
                    Common.StartFormLoading();
                    DataGridViewRow selectedRow = dgrStock.Rows[e.RowIndex];

                    var codeSelect = selectedRow.Cells[0].Value.ToString();
                    dataFromStockAll = _stockHelper.GetHistoryInOut(codeSelect, "");
                    dataFromStockIn = _stockHelper.GetHistoryInOut(codeSelect, "Nhập").ToList();
                    dataFromStockOut = _stockHelper.GetHistoryInOut(codeSelect,"Xuất").ToList();
                    if (cbStatus.SelectedIndex == 0)
                    {
                        List<Tbl_HistoryInOut> searchResults = _stockHelper.SearchObjectsByDate(dataFromStockAll, startSearch, endSearch);
                        ViewDataOnHistoryInOut(searchResults);
                    }
                    else if(cbStatus.SelectedIndex == 1)
                    {
                        List<Tbl_HistoryInOut> searchResults = _stockHelper.SearchObjectsByDate(dataFromStockIn, startSearch, endSearch);
                        ViewDataOnHistoryInOut(searchResults);
                    }
                    else if(cbStatus.SelectedIndex == 2)
                    {
                        List<Tbl_HistoryInOut> searchResults = _stockHelper.SearchObjectsByDate(dataFromStockOut, startSearch, endSearch);
                        ViewDataOnHistoryInOut(searchResults);
                    }
                }
                Common.CloseFormLoading();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }        
        }

        private void ViewDataOnHistoryInOut(List<Tbl_HistoryInOut> searchResults)
        {
            try
            {
                if (searchResults != null)
                {
                    List<object> listIO = new List<object>();
                    if (searchResults.Count <= 0)
                    {
                        dgrHistory.DataSource = null;
                        dgrHistory.Rows.Clear();
                        return;
                    }
                    foreach (var result in searchResults)
                    {
                        var unit = _stockHelper.GetIngerdientUnit(result.IngredientCode);
                        var name = _stockHelper.GetIngerdientName(result.IngredientCode);
                        if (result.StockAfterInOut == null || result.StockBeforInOut == null) continue;
                        object newobj = new { SupplierName = result.SupplierName, DateTimeInOut = result.DateTimeInOut.Value.ToString("dd-MM-yyy hh:mm:ss tt"), UserAction = result.UserAction, BillName = result.BillCode, Unit = unit, DateOrder = result.Date.Value.ToString("dd-MM-yyyy"), IngredientName = name, Quantity = result.Quantity, StockAfterInOut = Math.Round((double)result.StockAfterInOut, 3), StockBeforInOut = Math.Round((double)result.StockBeforInOut, 3), Status = result.Status };
                        listIO.Add(newobj);
                    }
                    dgrHistory.DataSource = listIO;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message);
            }
        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
            LimitedAccess();
        }
        private void LimitedAccess()
        {
            //phân quyền
            var LastForm = Common.LastLoginForm();
            if (LastForm.accountTypeName == "ReadOnly")
            {
                Common.DisableAllButtons(this);
            }
        }

        private void datefrom_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SearchIngredient();
            }
        }

        bool isclickZoom = false;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!isclickZoom)
            {
                tableLayoutPanel2.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 30);
                tableLayoutPanel2.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 70);
                pictureBox1.BackgroundImage = Properties.Resources.Arrow1;
            }
            else
            {
                tableLayoutPanel2.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 50);
                tableLayoutPanel2.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 50);
                pictureBox1.BackgroundImage = Properties.Resources.Arrow;
            }
            isclickZoom = !isclickZoom;
        }
    }
}

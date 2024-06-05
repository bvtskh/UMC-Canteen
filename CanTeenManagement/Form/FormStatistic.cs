using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace CanTeenManagement
{

    public partial class FormStatistic : Form
    {
        ZedGraphControl zedgraphNew;
        ZedGraphControl zedgraphNew2;
        public FormStatistic()
        {
            InitializeComponent();
            var montList = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            var yearList = new List<string>();
            var menuList = new List<string> { "Thực đơn chính", "Thực đơn nhẹ" };
            var currentYear = DateTime.Now.Year;
            yearList.Add((currentYear - 2).ToString());
            yearList.Add((currentYear - 1).ToString());
            yearList.Add(currentYear.ToString());
            yearList.Add((currentYear+1).ToString());
            cbMonth.Items.AddRange(montList.ToArray());
            cbYear.Items.AddRange(yearList.ToArray());
            cbMonth.Text = DateTime.Now.Month.ToString();
            cbYear.Text = DateTime.Now.Year.ToString();
            cbSelectMenu.DataSource = menuList;
            cbFrom.SelectedIndex = 0;
            cbTo.SelectedIndex = cbTo.Items.Count - 1;

            cbChooseBill.SelectedIndex = 0;
            dateFromBill.Format = DateTimePickerFormat.Custom;
            dateToBill.Format = DateTimePickerFormat.Custom;
            dateFromBill.CustomFormat = "dd-MM-yyyy";
            dateToBill.CustomFormat = "dd-MM-yyyy";

            dateFromBill.Value = dateFromBill.Value.AddDays(-15);
            dateToBill.Value = dateToBill.Value.AddDays(1);

            dateTimePickerReportDataFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerReportDataFrom.CustomFormat = "dd-MM-yyyy";
            dateTimePickerReportDataFrom.Value = dateTimePickerReportDataFrom.Value.AddDays(-3);

            dateTimePickerReportDataTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerReportDataTo.CustomFormat = "dd-MM-yyyy";
            dateTimePickerReportDataTo.Value = dateTimePickerReportDataTo.Value.AddDays(2);
            dateTimePickerReportData_ValueChanged(null, null);

        }

        private void btnSearchDataMenu_Click(object sender, EventArgs e)
        {
            Common.StartFormLoading();
            try
            {
                if (cbSelectMenu.SelectedIndex != -1)
                {
                    if (cbSelectMenu.SelectedIndex == 0)
                    {
                        if (cbFrom.SelectedItem as string != "" && cbTo.SelectedItem as string != "")
                        {
                            DateTime dateFrom = DateTime.ParseExact(cbFrom.Text, "dd-MM-yyyy", null);
                            DateTime dateTo = DateTime.ParseExact(cbTo.Text, "dd-MM-yyyy", null);
                            int month = int.Parse(cbMonth.Text);
                            int year = int.Parse(cbYear.Text);
                            // tìm kiếm thực đơn chính của tháng và số lượng cụ thể của chúng.
                            List<string> menuListOfMonth = FindDishMainOfMonth(month, year, 1, dateFrom, dateTo);
                            DrawChart(GetDishNameList(menuListOfMonth));
                        }
                    }

                    if (cbSelectMenu.SelectedIndex == 1)
                    {
                        if (cbFrom.SelectedIndex != -1 && cbTo.SelectedIndex != -1)
                        {
                            DateTime dateFrom = DateTime.ParseExact(cbFrom.Text, "dd-MM-yyyy", null);
                            DateTime dateTo = DateTime.ParseExact(cbTo.Text, "dd-MM-yyyy", null);
                            int month = int.Parse(cbMonth.Text);
                            int year = int.Parse(cbYear.Text);
                            // tìm kiếm thực đơn nhẹ của tháng và số lượng cụ thể của chúng.
                            List<string> menuListOfMonth = FindSideMenuOfMonth(month, year, 2, dateFrom, dateTo);
                            DrawChartForSideMenu(GetDishNameList(menuListOfMonth));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }

        private void DrawChartForSideMenu(List<string> list)
        {
            List<string> uniqueDishName = list.Distinct().ToList();
            if (zedgraphNew != null)
            {
                panel1.Controls.Remove(zedgraphNew);

                // Dispose of the ZedGraphControl to release resources
                zedgraphNew.Dispose();
            }
            List<SideMenu> sideMenuList = new List<SideMenu>();
            foreach (var dishName in uniqueDishName)
            {
                SideMenu dish = new SideMenu { Name = dishName, Number = list.Count(c => c == dishName) };
                sideMenuList.Add(dish);
            }
            ClearBackGround();
            zedgraphNew = new ZedGraphControl();
            panelCircle.Controls.Add(zedgraphNew);
            zedgraphNew.Dock = DockStyle.Fill;

            GraphPane pane = zedgraphNew.GraphPane;
            pane.CurveList.Clear();
            pane.Title.Text = "Món ăn nhẹ";
            pane.Title.FontSpec.Size = 20;
            pane.Legend.Position = LegendPos.Right;

            // Create a pie chart item
            List<Color> pieItemListColor = new List<Color> { Color.Blue, Color.Pink, Color.Yellow, Color.Orange, Color.Green, Color.Red, Color.Purple, Color.Gray };
            int indexColor = 0;
            foreach (var item in sideMenuList)
            {
                PieItem pieItem = pane.AddPieSlice(item.Number, pieItemListColor[indexColor], 0.2, item.Name);
                pieItem.LabelType = PieLabelType.Percent;
                indexColor++;
            }

            pane.Legend.IsVisible = true;
            pane.Legend.FontSpec.Size = 14;
            //pane.Rect = new RectangleF(0.1f, 0.1f, panelCircle.Width, panelCircle.Height);
            zedgraphNew.AxisChange();
            zedgraphNew.Invalidate();
        }

        private List<string> FindSideMenuOfMonth(int month, int year, int type, DateTime dateFrom, DateTime dateTo)
        {
            List<string> menuListMainDish = new List<string>();
            using (var ctx = new DBContext())
            {
                List<string> menuSide1OfMonth = ctx.Tbl_Menu.Where(w => w.Date.Value.Month == month && w.Date.Value.Year == year && w.Date >= dateFrom && w.Date <= dateTo && w.MenuType == type && w.SideMeal1 != null).Select(s => s.SideMeal1).ToList();
                List<string> menuSide2OfMonth = ctx.Tbl_Menu.Where(w => w.Date.Value.Month == month && w.Date.Value.Year == year && w.Date >= dateFrom && w.Date <= dateTo && w.MenuType == type && w.SideMeal2 != null).Select(s => s.SideMeal2).ToList();
                List<string> menuSide3OfMonth = ctx.Tbl_Menu.Where(w => w.Date.Value.Month == month && w.Date.Value.Year == year && w.Date >= dateFrom && w.Date <= dateTo && w.MenuType == type && w.SideMeal3 != null).Select(s => s.SideMeal3).ToList();
                List<string> menuSide4OfMonth = ctx.Tbl_Menu.Where(w => w.Date.Value.Month == month && w.Date.Value.Year == year && w.Date >= dateFrom && w.Date <= dateTo && w.MenuType == type && w.SideMeal4 != null).Select(s => s.SideMeal4).ToList();
                List<string> menuSide5OfMonth = ctx.Tbl_Menu.Where(w => w.Date.Value.Month == month && w.Date.Value.Year == year && w.Date >= dateFrom && w.Date <= dateTo && w.MenuType == type && w.SideMeal5 != null).Select(s => s.SideMeal5).ToList();

                menuListMainDish.AddRange(menuSide1OfMonth);
                menuListMainDish.AddRange(menuSide2OfMonth);
                menuListMainDish.AddRange(menuSide3OfMonth);
                menuListMainDish.AddRange(menuSide4OfMonth);
                menuListMainDish.AddRange(menuSide5OfMonth);
            }
            return menuListMainDish;
        }

        private void DrawChart(List<string> list)
        {
            ClearBackGround();

            List<string> numberThit = new List<string>();
            List<string> numberGa = new List<string>();
            List<string> numberBo = new List<string>();
            List<string> numberVit = new List<string>();
            List<string> numberCa = new List<string>();
            List<string> numberOrther = new List<string>();
            foreach (var dish in list)
            {
                if (dish != null)
                {
                    if (dish.Contains("thịt") || dish.Contains("Thịt")) numberThit.Add(dish);
                    else if (dish.Contains("gà") || dish.Contains("Gà")) numberGa.Add(dish);
                    else if (dish.Contains("bò") || dish.Contains("Bò")) numberBo.Add(dish);
                    else if (dish.Contains("vịt") || dish.Contains("Vịt")) numberVit.Add(dish);
                    else if (dish.Contains("cá") || dish.Contains("Cá")) numberCa.Add(dish);
                    else numberOrther.Add(dish);
                }
            }
            zedgraphNew = new ZedGraphControl();
            panelCircle.Controls.Add(zedgraphNew);
            zedgraphNew.Dock = DockStyle.Fill;

            GraphPane pane = zedgraphNew.GraphPane;
            pane.CurveList.Clear();
            pane.Title.Text = "Món ăn chính";
            pane.Title.FontSpec.Size = 20;
            pane.Legend.Position = LegendPos.Right;

            // Create a pie chart item
            PieItem pieThit = pane.AddPieSlice(numberThit.Count, System.Drawing.Color.Blue, 0.2, "Món thịt");
            PieItem pieGa = pane.AddPieSlice(numberGa.Count, System.Drawing.Color.Red, 0.2, "Món gà");
            PieItem pieCa = pane.AddPieSlice(numberCa.Count, System.Drawing.Color.Green, 0.2, "Món cá");
            PieItem pieBo = pane.AddPieSlice(numberBo.Count, System.Drawing.Color.Orange, 0.2, "Món bò");
            PieItem pieVit = pane.AddPieSlice(numberVit.Count, System.Drawing.Color.Yellow, 0.2, "Món vịt");
            PieItem pieOrther = pane.AddPieSlice(numberOrther.Count, System.Drawing.Color.Pink, 0.2, "Món khác");

            // Show percentages on each pie slice
            pieThit.LabelType = PieLabelType.Percent;
            pieGa.LabelType = PieLabelType.Percent;
            pieCa.LabelType = PieLabelType.Percent;
            pieBo.LabelType = PieLabelType.Percent;
            pieVit.LabelType = PieLabelType.Percent;
            pieOrther.LabelType = PieLabelType.Percent;
            // Set pie chart labels and format

            pane.Legend.IsVisible = true;
            pane.Legend.FontSpec.Size = 14;
            //pane.Rect = new RectangleF(0.1f, 0.1f, panelCircle.Width, panelCircle.Height);
            zedgraphNew.AxisChange();
            zedgraphNew.Invalidate();
            CreateDgvDetail(numberThit, numberGa, numberBo, numberVit, numberCa, numberOrther);
        }

        private void CreateDgvDetail(List<string> numberThit, List<string> numberGa, List<string> numberBo, List<string> numberVit, List<string> numberCa, List<string> numberOrther)
        {
            dgvDetailDishMain.Rows.Clear();
            dgvDetailDishMain.ColumnCount = 2;
            dgvDetailDishMain.Columns[0].HeaderText = "Loại món ăn";
            dgvDetailDishMain.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvDetailDishMain.Columns[0].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold); // Change the font size here
            dgvDetailDishMain.Columns[1].HeaderText = "Tổng Số lượng";
            dgvDetailDishMain.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvDetailDishMain.Columns[1].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold); // Change the font size here
            DataGridViewComboBoxColumn cbcell = new DataGridViewComboBoxColumn();
            cbcell.HeaderText = "Chi tiết món";

            dgvDetailDishMain.Columns.Add(cbcell);
            dgvDetailDishMain.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDetailDishMain.Columns[2].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold); // Change the font size here

            dgvDetailDishMain.EnableHeadersVisualStyles = false;
            dgvDetailDishMain.ColumnHeadersDefaultCellStyle.BackColor = Color.Khaki; // Change the color here

            dgvDetailDishMain.DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Regular); // Change the font size here
            dgvDetailDishMain.AllowUserToAddRows = false;
            dgvDetailDishMain.RowHeadersVisible = false;

            for (int row = 0; row < 6; row++)
            {
                dgvDetailDishMain.Rows.Add();
            }
            AddDataToDgvMainDish(numberThit, "Món thịt", 0);
            AddDataToDgvMainDish(numberGa, "Món gà", 1);
            AddDataToDgvMainDish(numberCa, "Món cá", 2);
            AddDataToDgvMainDish(numberBo, "Món bò", 3);
            AddDataToDgvMainDish(numberVit, "Món vịt", 4);
            AddDataToDgvMainDish(numberOrther, "Món khác", 5);
        }

        private void AddDataToDgvMainDish(List<string> typeMenuList, string name, int row)
        {
            foreach (var item in typeMenuList)
            {
                dgvDetailDishMain.Rows[row].Cells[0].Value = name;
                dgvDetailDishMain.Rows[row].Cells[1].Value = typeMenuList.Count();
            }
            DataGridViewComboBoxCell cbCell = (DataGridViewComboBoxCell)dgvDetailDishMain.Rows[row].Cells[2];

            cbCell.DataSource = typeMenuList.Distinct().ToList();
            if (typeMenuList.Count > 0)
            {
                cbCell.Value = typeMenuList[0];
            }
        }

        private void ClearBackGround()
        {
            panelCircle.BackgroundImage = null;
            panelChartCircleBill.BackgroundImage = null;
            panelChart.BackgroundImage = null;
            if (zedgraphNew != null)
            {
                zedgraphNew.Dispose();
            }
            if (zedgraphNew2 != null)
            {
                zedgraphNew2.Dispose();
            }

        }

        private List<string> GetDishNameList(List<string> menuListOfMonth)
        {
            // List<string> uniqueElements = menuListOfMonth.Distinct().ToList();
            List<string> dishNameList = new List<string>();
            using (var ctx = new DBContext())
            {
                foreach (var dishCode in menuListOfMonth)
                {
                    var dishName = ctx.Tbl_Dish.Where(w => w.DishCode == dishCode).Select(s => s.Dish).FirstOrDefault();
                    dishNameList.Add(dishName);
                }
            }
            return dishNameList;
        }

        private List<string> FindDishMainOfMonth(int month, int year, int type, DateTime timeFrom, DateTime timeTo)
        {
            List<string> menuListMainDish = new List<string>();
            using (var ctx = new DBContext())
            {
                List<string> menuMainDish1ListOfMonth = ctx.Tbl_Menu.Where(w => w.Date.Value.Month == month && w.Date.Value.Year == year && w.Date >= timeFrom && w.Date <= timeTo && w.MenuType == type && w.MainDishes1 != null).Select(s => s.MainDishes1).ToList();
                List<string> menuMainDish2ListOfMonth = ctx.Tbl_Menu.Where(w => w.Date.Value.Month == month && w.Date.Value.Year == year && w.Date >= timeFrom && w.Date <= timeTo && w.MenuType == type && w.MainDishes2 != null).Select(s => s.MainDishes2).ToList();
                menuListMainDish.AddRange(menuMainDish1ListOfMonth);
                menuListMainDish.AddRange(menuMainDish2ListOfMonth);
            }
            return menuListMainDish;
        }

        private void FormStatistic_Load(object sender, EventArgs e)
        {
            //phân quyền
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
            if (LastForm.accountTypeName != "ADMIN")
            {
                if (LastForm.accountTypeName == "MEMBER")
                {
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage3);
                }
                else
                {
                    Common.DisableAllButtons(this);
                }
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFrom.Items.Clear();
            cbTo.Items.Clear();
            if (cbMonth.SelectedIndex != -1)
            {
                int month = int.Parse(cbMonth.Text);
                int year = int.Parse(cbYear.Text);

                int daysInMonth = DateTime.DaysInMonth(year, month);

                // Loop through all days in September 2023
                for (int day = 1; day <= daysInMonth; day++)
                {
                    DateTime date = new DateTime(year, month, day);
                    cbFrom.Items.Add(date.ToString("dd-MM-yyyy"));
                    cbTo.Items.Add(date.ToString("dd-MM-yyyy"));
                }
                cbFrom.SelectedIndex = 0;
                cbTo.SelectedIndex = cbTo.Items.Count - 1;
            }
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFrom.Items.Clear();
            cbTo.Items.Clear();
            if (cbYear.SelectedIndex != -1)
            {
                int month = int.Parse(cbMonth.Text);
                int year = int.Parse(cbYear.Text);

                int daysInMonth = DateTime.DaysInMonth(year, month);

                // Loop through all days in September 2023
                for (int day = 1; day <= daysInMonth; day++)
                {
                    DateTime date = new DateTime(year, month, day);
                    cbFrom.Items.Add(date.ToString("dd-MM-yyyy"));
                    cbTo.Items.Add(date.ToString("dd-MM-yyyy"));
                }
                cbFrom.SelectedIndex = 0;
                cbTo.SelectedIndex = cbTo.Items.Count - 1;
            }
        }

        private async void btnSearchtabBill_Click(object sender, EventArgs e)
        {
            Common.StartFormLoading();
            var dateFromOfBill = dateFromBill.Value.Date;
            var dateToOfBill = dateToBill.Value.Date;
            try
            {
                if (cbChooseBill.SelectedIndex != -1)
                {
                    if (cbChooseBill.SelectedIndex == 0)
                    {
                        var echangeRate = await Common.GetExchangeRateFromVNDAsync("USD");
                        DrawChartSupplier(FindTotalBillOfSupplier(dateFromOfBill, dateToOfBill), echangeRate);
                        DrawChartCircleBill(FindTotalBillOfSupplier(dateFromOfBill, dateToOfBill), echangeRate);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }

        }
        
        private void DrawChartCircleBill(List<SupplierInfomation> list, double echangeRate)
        {
            zedgraphNew2 = new ZedGraphControl();
            panelChartCircleBill.Controls.Add(zedgraphNew2);
            zedgraphNew2.Dock = DockStyle.Fill;

            GraphPane pane = zedgraphNew2.GraphPane;
            pane.CurveList.Clear();
            pane.Title.Text = "Tổng số tiền($)";
            pane.Title.FontSpec.Size = 20;
            pane.Legend.Position = LegendPos.TopFlushLeft;
          
            if (echangeRate == 0)
            {
                echangeRate = 0.00004;
            }
            // Create a pie chart item
            PieItem pieDN = pane.AddPieSlice(list.Where(w => w.SupplierName.Trim() == "Đỗ Nguyên").Sum(s => s.TotalPrice * echangeRate), System.Drawing.Color.Blue, 0.1, "Đỗ Nguyên");
            PieItem pieHX = pane.AddPieSlice(list.Where(w => w.SupplierName.Trim() == "Hữu Xuất").Sum(s => s.TotalPrice * echangeRate), System.Drawing.Color.Red, 0.1, "Hữu Xuất");

            // Show percentages on each pie slice
            pieDN.LabelType = PieLabelType.Name_Value_Percent;
            pieHX.LabelType = PieLabelType.Name_Value_Percent;

            // Set pie chart labels and format
            pane.Legend.IsVisible = false;
            pane.Legend.FontSpec.Size = 12;

            //pane.Rect = new RectangleF(0.1f, 0.1f, panelCircle.Width, panelCircle.Height);
            zedgraphNew2.AxisChange();
            zedgraphNew2.Invalidate();
        }

        private void DrawChartSupplier(List<SupplierInfomation> findTotalBillOfSupplier, double echangeRate)
        {
            ClearBackGround();
            zedgraphNew = new ZedGraphControl();
            panelChart.Controls.Add(zedgraphNew);
            zedgraphNew.Dock = DockStyle.Fill;

            // Create a GraphPane
            GraphPane graphPane = zedgraphNew.GraphPane;

            // Set the title and labels
            graphPane.Title.Text = "Thống kê số tiền mua theo nhà cung cấp";
            graphPane.XAxis.Title.Text = "Thời gian";
            graphPane.YAxis.Title.Text = "Số tiền USD";

            var listDataDN = findTotalBillOfSupplier.Where(w => w.SupplierName.Trim() == "Đỗ Nguyên").ToList();
            var listDataHx = findTotalBillOfSupplier.Where(w => w.SupplierName.Trim() == "Hữu Xuất").ToList();
            // Create a list of points for the chart
            PointPairList pointDNList = new PointPairList();
            PointPairList pointHXList = new PointPairList();

            // Create a list to hold the data points
            PointPairList flowData = new PointPairList();


            if (echangeRate == 0)
            {
                echangeRate = 0.00004;
            }
            

            var dateListDN = listDataDN.Select(w => w.Date).ToList();
            var dateListHX = listDataHx.Select(s => s.Date).ToList();

            var dateListExceptDN = dateListDN.Except(dateListHX).ToList();
            var dateListExceptHX = dateListHX.Except(dateListDN).ToList();

            if (dateListExceptDN.Count > 0)
            {
                foreach(var item in dateListExceptDN)
                {
                    SupplierInfomation supplierAdd = new SupplierInfomation();
                    supplierAdd.Date = item.Date;
                    supplierAdd.SupplierName = "Hữu Xuất";
                    supplierAdd.TotalPrice = 0;
                    listDataHx.Add(supplierAdd);
                }
                listDataHx = listDataHx.OrderBy(o => o.Date).ToList();
            }
            if (dateListExceptHX.Count > 0)
            {
                foreach (var item in dateListExceptHX)
                {
                    SupplierInfomation supplierAdd = new SupplierInfomation();
                    supplierAdd.Date = item.Date;
                    supplierAdd.SupplierName = "Đỗ Nguyên";
                    supplierAdd.TotalPrice = 0;
                    listDataDN.Add(supplierAdd);
                }
                listDataDN = listDataDN.OrderBy(o => o.Date).ToList();
            }
            int countTotal = listDataDN.Count >= listDataHx.Count ? listDataDN.Count : listDataHx.Count;
            for (int i = 0; i < countTotal; i++)
            {
                pointDNList.Add(i, Math.Round(listDataDN[i].TotalPrice * echangeRate, 2));
                pointHXList.Add(i, Math.Round(listDataHx[i].TotalPrice * echangeRate, 2));
                flowData.Add(i, (pointDNList[i].Y + pointHXList[i].Y));
            }

            // Create the line graph
            LineItem lines = graphPane.AddCurve("Tổng tiền", flowData, Color.DarkOrange, SymbolType.None);
            lines.Line.Width = 2;
            lines.Symbol.Fill = new Fill(Color.White);

            // Create a bar chart
            BarItem barDN = graphPane.AddBar("Đỗ Nguyên", pointDNList, Color.Blue);
            BarItem barHX = graphPane.AddBar("Hữu Xuất", pointHXList, Color.Red);

            // Adjust the scale range for the Y and Y2 axes
            //graphPane.YAxis.Scale.Max = findTotalBillOfSupplier.Max(m => m.TotalPrice);
            //List<DateTime> numberDate = findTotalBillOfSupplier.Select(s => s.Date).Distinct().ToList();
            List<DateTime> numberDate = listDataDN.Select(s => s.Date).Distinct().ToList();
            string[] labels = new string[numberDate.Count()];
            for (int point = 0; point < numberDate.Count(); point++)
            {
                labels[point] = numberDate[point].ToString("dd-MM");
            }

            // Customize appearance
            graphPane.BarSettings.ClusterScaleWidth = 0.8;
            graphPane.BarSettings.Type = BarType.Stack;

            graphPane.XAxis.Scale.MinorStep = 0;
            // graphPane.XAxis.Scale.MajorStep = 2;
            graphPane.XAxis.Scale.TextLabels = labels;
            graphPane.XAxis.Type = ZedGraph.AxisType.Text;
            graphPane.XAxis.Scale.FontSpec.Size = 8;
            // Customize the chart appearance
            barDN.Bar.Fill = new Fill(Color.Blue);
            barDN.Bar.Fill.Type = FillType.Solid;
            barDN.Bar.Fill.RangeMin = 0;
            barDN.Bar.Fill.RangeMax = 5;
            // Customize the chart appearance
            barHX.Bar.Fill = new Fill(Color.Red);
            barHX.Bar.Fill.Type = FillType.Solid;
            barHX.Bar.Fill.RangeMin = 0;
            barHX.Bar.Fill.RangeMax = 5;

            // Adjust the space between the clusters of bars
            //graphPane.BarSettings.ClusterScaleWidth = 0.8;
            // Add labels for values above each column
            for (int i = 0; i < numberDate.Count; i++)
            {
                TextObj textDN = new TextObj("$" + Common.ConvertText(pointDNList[i].Y).ToString(), i + 1, pointDNList[i].Y / 2);
                TextObj textHX = new TextObj("$" + Common.ConvertText(pointHXList[i].Y).ToString(), i + 1, (pointHXList[i].Y + pointDNList[i].Y) - (pointHXList[i].Y / 2));
                TextObj text = new TextObj("$" + Common.ConvertText(flowData[i].Y).ToString(), i + 1, flowData[i].Y + flowData[i].Y * 0.12f);

                textDN.Location.AlignH = AlignH.Center;
                textDN.Location.AlignV = AlignV.Top;
                textDN.FontSpec.Size = 8;
                textDN.FontSpec.FontColor = Color.Black;
                textDN.FontSpec.Border.IsVisible = false;

                //
                textHX.Location.AlignH = AlignH.Center;
                textHX.Location.AlignV = AlignV.Top;
                textHX.FontSpec.Size = 8;
                textHX.FontSpec.FontColor = Color.Black;
                textHX.FontSpec.Border.IsVisible = false;
                //
                text.Location.AlignH = AlignH.Center;
                text.Location.AlignV = AlignV.Top;
                text.FontSpec.Size = 8;
                text.FontSpec.FontColor = Color.Black;
                text.FontSpec.Border.IsVisible = false;
                graphPane.GraphObjList.Add(textDN);
                graphPane.GraphObjList.Add(textHX);
                graphPane.GraphObjList.Add(text);
            }
            // Format the Y-axis labels to include the "$" symbol
            graphPane.YAxis.Scale.Format = "$#.##";
            graphPane.YAxis.Scale.FontSpec.Size = 8;
            // Refresh the chart
            zedgraphNew.AxisChange();
            zedgraphNew.Invalidate();
        }

        private List<SupplierInfomation> FindTotalBillOfSupplier(DateTime dateFromOfBill, DateTime dateToOfBill)
        {
            DateTime selectDate = dateFromOfBill;
            using (var ctx = new DBContext())
            {
                var supplierList = ctx.Tbl_Supplier.ToList();
                List<SupplierInfomation> listSupplierInfomation = new List<SupplierInfomation>();
                foreach (var supplier in supplierList)
                {
                    dateFromOfBill = selectDate;
                    while (dateFromOfBill <= dateToOfBill)
                    {
                        //Tìm hóa đơn đã thanh toán.
                        Tbl_OrderHistory orderHistoryExist = ctx.Tbl_OrderHistory.Where(w => w.OrderForDate == dateFromOfBill && w.OrderStatus.Trim() == "Đã nhận").FirstOrDefault();
                        if (orderHistoryExist != null)
                        {
                            var historyOrderId = orderHistoryExist.Id;
                            // tìm đên danh sách đặt hàng của ngày này.
                            var ingredienOrderList = ctx.Tbl_Order.Where(w => w.OrderHistoryId == historyOrderId && w.SupplierCode == supplier.SupplierCode).ToList();
                            if (ingredienOrderList.Count > 0)
                            {
                                SupplierInfomation newData = new SupplierInfomation();
                                newData.TotalPrice = (int)ingredienOrderList.Where(w => w.PriceTotal != null).Sum(s => s.PriceTotal);
                                newData.Date = dateFromOfBill;
                                newData.SupplierName = supplier.SupplierName;
                                listSupplierInfomation.Add(newData);
                                dateFromOfBill = dateFromOfBill.AddDays(1);
                            }
                            else
                            {
                                dateFromOfBill = dateFromOfBill.AddDays(1);
                            }
                        }

                        else
                        {
                            dateFromOfBill = dateFromOfBill.AddDays(1);
                        }
                    }
                }
                return listSupplierInfomation;
            }
        }

        private void dgvDetailDishMain_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvDetailDishMain.CurrentCell is DataGridViewComboBoxCell)
            {
                // Cast the editing control to a ComboBox
                ComboBox comboBox = e.Control as ComboBox;

                if (comboBox != null)
                {
                    // Subscribe to the SelectedIndexChanged event of the ComboBox
                    comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the currently selected value in the ComboBox
            ComboBox comboBox = sender as ComboBox;

            if (comboBox != null)
            {
                var selectedValue = comboBox.SelectedItem;
                if (selectedValue != null)
                {
                    lbDishName.Text = $"Tên món: {selectedValue}";
                    DateTime dateFrom = DateTime.ParseExact(cbFrom.Text, "dd-MM-yyyy", null);
                    DateTime dateTo = DateTime.ParseExact(cbTo.Text, "dd-MM-yyyy", null);
                    int month = int.Parse(cbMonth.Text);
                    int year = int.Parse(cbYear.Text);
                    // tìm kiếm thực đơn chính của tháng và số lượng cụ thể của chúng.
                    List<string> menuListOfMonth = FindDishMainOfMonth(month, year, 1, dateFrom, dateTo);
                    var dishNameList = GetDishNameList(menuListOfMonth);
                    int count = dishNameList.Count(c => c == selectedValue.ToString());
                    lbNumberAppear.Text = $"Số lần xuất hiện món này: {count} lần";
                }
            }
        }
        private void FindDataOrder()
        {
            DateTime selectDateFrom = dateTimePickerReportDataFrom.Value.Date;
            DateTime selectDateTo = dateTimePickerReportDataTo.Value.Date;
            string codeDN = "DN";
            string codeHX = "HX";
            dgvReportDN.Rows.Clear();
            dgvReportHX.Rows.Clear();
            try
            {
                Common.StartFormLoading();
                using (var ctx = new DBContext())
                {
                    var dataInputDN = ctx.Tbl_Order.Where(w => w.Date >= selectDateFrom && w.Date <= selectDateTo && w.SupplierCode == codeDN).ToList();
                    var dataInputHX = ctx.Tbl_Order.Where(w => w.Date >= selectDateFrom && w.Date <= selectDateTo && w.SupplierCode == codeHX).ToList();
                    if (dataInputDN.Count <= 0 && dataInputHX.Count <= 0)
                    {
                        lbReportStatus.Text = "Không tìm thấy đơn hàng nào";
                        picReportStatus.BackgroundImage = Properties.Resources.x;
                    }
                    if (dataInputDN.Count > 0)
                    {
                        dataInputDN = dataInputDN.OrderBy(o => o.Date).ToList();
                        for (int row = 0; row < dataInputDN.Count; row++)
                        {
                            var item = dataInputDN[row];
                            var ingredientCode = item.IngredientCode;
                            var ingredientName = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).Select(s => s.IngredientName).FirstOrDefault();
                            dgvReportDN.Rows.Add();
                            dgvReportDN.Rows[row].Cells[0].Value = item.Date.Value.ToString("dd.MM.yyyy");
                            dgvReportDN.Rows[row].Cells[1].Value = ingredientCode;
                            dgvReportDN.Rows[row].Cells[2].Value = ingredientName;
                            dgvReportDN.Rows[row].Cells[3].Value = Common.ConvertText(item.PlanOrder);
                            dgvReportDN.Rows[row].Cells[4].Value = Common.ConvertText(item.ActualOrder);
                            dgvReportDN.Rows[row].Cells[5].Value = Common.ConvertText(item.CurrentApprovePrice);
                            dgvReportDN.Rows[row].Cells[6].Value = Common.ConvertText(item.PriceTotal);
                        }
                        var totalPrice = dataInputDN.Where(w => w.PriceTotal != null).Sum(s => s.PriceTotal);
                        lbTotalPriceDN.Text = $"Tổng tiền: {Common.ConvertText(totalPrice)} VND";
                        if (totalPrice > 0)
                        {
                            lbReportStatus.Text = "Đơn hàng đã được thanh toán!";
                            picReportStatus.BackgroundImage = Properties.Resources.ok;
                        }
                        else
                        {
                            lbReportStatus.Text = "Đơn hàng chưa được thanh toán!";
                            picReportStatus.BackgroundImage = Properties.Resources.qs;
                        }
                    }
                    else
                    {
                        lbTotalPriceHX.Text = $"Tổng tiền: 0 VND";
                    }
                    if (dataInputHX.Count > 0)
                    {
                        dataInputHX = dataInputHX.OrderBy(o => o.Date).ToList();
                        for (int row = 0; row < dataInputHX.Count; row++)
                        {
                            var item = dataInputHX[row];
                            var ingredientCode = item.IngredientCode;
                            var ingredientName = ctx.Tbl_Ingredient.Where(w => w.IngredientCode == ingredientCode).Select(s => s.IngredientName).FirstOrDefault();
                            dgvReportHX.Rows.Add();
                            dgvReportHX.Rows[row].Cells[0].Value = item.Date.Value.ToString("dd.MM.yyyy");
                            dgvReportHX.Rows[row].Cells[1].Value = ingredientCode;
                            dgvReportHX.Rows[row].Cells[2].Value = ingredientName;
                            dgvReportHX.Rows[row].Cells[3].Value = Common.ConvertText(item.PlanOrder);
                            dgvReportHX.Rows[row].Cells[4].Value = Common.ConvertText(item.ActualOrder);
                            dgvReportHX.Rows[row].Cells[5].Value = Common.ConvertText(item.CurrentApprovePrice);
                            dgvReportHX.Rows[row].Cells[6].Value = Common.ConvertText(item.PriceTotal);
                        }
                        var totalPrice = dataInputHX.Where(w => w.PriceTotal != null).Sum(s => s.PriceTotal);
                        lbTotalPriceHX.Text = $"Tổng tiền: {Common.ConvertText(totalPrice)} VND";
                    }
                    else
                    {
                        lbTotalPriceHX.Text = $"Tổng tiền: 0 VND";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                Common.CloseFormLoading();
            }
        }
        private void dateTimePickerReportData_ValueChanged(object sender, EventArgs e)
        {
            FindDataOrder();
        }

        DataGridView dgv = new DataGridView();
        private void xuấtFileThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv != null)
            {
                if (dgv == dgvReportDN || dgv == dgvReportHX)
                {
                    if (dgv.RowCount > 0)
                    {
                        Common.ExportExcel(dgv);
                    }
                }
            }
        }

        private void contextMenuStripReportData_Opened(object sender, EventArgs e)
        {
            DataGridView dataGridView = (sender as ContextMenuStrip).SourceControl as DataGridView;
            dgv = dataGridView;
        }

        private void dateTimePickerReportDataTo_ValueChanged(object sender, EventArgs e)
        {
            FindDataOrder();
        }
        bool isScale = false;
        private void pictureBoxScaleChart_Click(object sender, EventArgs e)
        {
            if (!isScale)
            {
                panelDrawCircle.Width = 250;
                pictureBoxScaleChart.BackgroundImage = Properties.Resources.zoom_out;
                lbZoom.Text = "Thu nhỏ";
            }
            else
            {
                panelDrawCircle.Width = 686;
                pictureBoxScaleChart.BackgroundImage = Properties.Resources.ZoomIn;

                lbZoom.Text = "Phóng to";
            }
            isScale = !isScale;
        }
    }
}

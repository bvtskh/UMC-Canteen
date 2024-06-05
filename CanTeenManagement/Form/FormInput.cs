using CanTeenManagement.Bussiness.SQLHelper;
using CanTeenManagement.Model;
using CanTeenManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanTeenManagement
{
    public partial class FormInput : Form
    {
        DateTime selectDate;
        InputHelper _inputHelper = new InputHelper();
        TableLayoutPanel tablePanel;
        DataGridView dataGridView;
        CheckBox CheckBox;
        Label labelsupplierName;
        Label labelOrderTime;
        Panel panelStatus;
        PictureBox picStatus;

        List<string> suplierListCodeList;
        public FormInput()
        {
            InitializeComponent();
            selectDate = datetimepicker.Value.Date;
            datetimepicker.ValueChanged += Datetimepicker_ValueChanged;
            datetimepicker.Format = DateTimePickerFormat.Custom;
            datetimepicker.Format = DateTimePickerFormat.Custom;
            datetimepicker.CustomFormat = "dd-MM-yyyy";
        }

        private void Datetimepicker_ValueChanged(object sender, EventArgs e)
        {
            selectDate = datetimepicker.Value.Date;
            FindDataInput(selectDate);
        }

        private void FormInputClon_Load(object sender, EventArgs e)
        {
            try
            {
                cbOrderNotYetStock.Items.AddRange(_inputHelper.GetOrderDateNotYetStock().ToArray());
                lbFindOrderResult.Text = $"Tìm thấy: {cbOrderNotYetStock.Items.Count} đơn hàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindDataInput(selectDate);
        }
        private void FindDataInput(DateTime dateTime)
        {
            try
            {
                if (tablePanel != null) panelLayout.Controls.Remove(tablePanel);
                if (panelContainCheckBox != null) panelContainCheckBox.Controls.Remove(panelCheckbox);
                if (panelStatus != null) panelContainStatus.Controls.Remove(panelStatus);
                suplierListCodeList = _inputHelper.GetSupplierListCodeOrder(dateTime.Date).OrderBy(o => o).ToList();
                CreateTableLayoutPanel(suplierListCodeList);
                CreateCheckBoxSelectSupplier(suplierListCodeList);
                OrderStatus(dateTime.Date, suplierListCodeList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }
        private void OrderStatus(DateTime selectDate, List<string> supplierCodeList)
        {
            try
            {
                Tbl_OrderHistory orderHistory = _inputHelper.GetOrderHistory(selectDate);
                if (orderHistory == null)
                {
                    lbNotification.Text = "Chưa có đơn hàng nào cho ngày này!";
                    picNoteOrder.BackgroundImage = Properties.Resources.x;
                    picNoteOrder.BackgroundImageLayout = ImageLayout.Stretch;
                    lbOrderTime.Text = "";
                    lbUserOrder.Text = "";
                    lbHistoryOrderCode.Text = "";
                }
                else
                {
                    if (_inputHelper.IsFirstSaveToStock(selectDate))
                    {
                        lbNotification.Text = "Đơn hàng này đang chờ xử lý!";
                        picNoteOrder.BackgroundImage = Properties.Resources.question1;
                        picNoteOrder.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        lbNotification.Text = "Đơn hàng này đã nhập vào kho!";
                        picNoteOrder.BackgroundImage = Properties.Resources.ok;
                        picNoteOrder.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                    lbOrderTime.Text = orderHistory.OrderDate.Value.ToString("dd-MM-yyyy hh:mm:ss tt");
                    lbUserOrder.Text = orderHistory.AccountOrder;
                    lbHistoryOrderCode.Text = orderHistory.HistoryOrderCode;


                    Point pointSupplierName = new Point(5, 10);
                    Point pointOrderTime = new Point(5, 40);
                    Point pointPicStatus = new Point(280, 5);

                    panelStatus = new Panel();
                    panelStatus.Dock = DockStyle.Fill;
                    panelContainStatus.Controls.Add(panelStatus);

                    for (int i = 0; i < supplierCodeList.Count; i++)
                    {
                        labelsupplierName = CreatedLabelSupplierName(new Label(), supplierCodeList[i], pointSupplierName);
                        labelOrderTime = CreatedLabelOrderTime(new Label(), supplierCodeList[i], pointOrderTime);
                        picStatus = CreatePictureBoxStatus(new PictureBox(), supplierCodeList[i], pointPicStatus);



                        panelStatus.Controls.Add(labelsupplierName);
                        panelStatus.Controls.Add(labelOrderTime);
                        panelStatus.Controls.Add(picStatus);

                        pointSupplierName = new Point(5, pointSupplierName.Y + 60);
                        pointOrderTime = new Point(5, pointOrderTime.Y + 60);
                        pointPicStatus = new Point(280, pointPicStatus.Y + 60);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private PictureBox CreatePictureBoxStatus(PictureBox pictureBox, string suppliercode, Point pointPicStatus)
        {
            try
            {
                pictureBox.Location = pointPicStatus;
                pictureBox.Name = "picSTT" + suppliercode;
                pictureBox.Size = new System.Drawing.Size(30, 30);
                pictureBox.TabIndex = 23;
                pictureBox.TabStop = false;
                pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                if (_inputHelper.IsSavedToStock(suppliercode, selectDate.Date))
                {
                    pictureBox.BackgroundImage = Properties.Resources.ok;
                }
                else
                {
                    pictureBox.BackgroundImage = Properties.Resources.x;
                }
                return pictureBox;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
            return null;
        }

        private Label CreatedLabelOrderTime(Label labelOrderTime, string suppliercode, Point pointOrderTime)
        {
            try
            {
                labelOrderTime.AutoSize = true;
                labelOrderTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelOrderTime.Location = pointOrderTime;
                labelOrderTime.Name = "lbTime" + suppliercode;
                labelOrderTime.Size = new System.Drawing.Size(67, 16);
                labelOrderTime.TabIndex = 31;
                var dateInOut = _inputHelper.GetInputStockTime(suppliercode, selectDate);
                labelOrderTime.Text = "Thời gian: " + (dateInOut == null ? "" : dateInOut.Value.ToString("dd-MM-yyyy hh:mm:ss tt"));
                return labelOrderTime;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
            return null;
        }

        private Label CreatedLabelSupplierName(Label labelsupplierName, string suppliercode, Point point)
        {
            try
            {
                labelsupplierName.AutoSize = true;
                labelsupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelsupplierName.ForeColor = System.Drawing.Color.Black;
                labelsupplierName.Location = point;
                labelsupplierName.Name = "lbSup" + suppliercode;
                labelsupplierName.Size = new System.Drawing.Size(88, 16);
                labelsupplierName.TabIndex = 21;
                if (_inputHelper.IsSavedToStock(suppliercode, selectDate.Date))
                {
                    labelsupplierName.Text = _inputHelper.GetSupplierNameByCode(suppliercode) + ": Đã nhập vào kho!";
                }
                else
                {
                    labelsupplierName.Text = _inputHelper.GetSupplierNameByCode(suppliercode) + ": Chưa nhập vào kho!";
                }
                return labelsupplierName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
            return null;
        }

        private void CreateCheckBoxSelectSupplier(List<string> suplierListCode)
        {
            try
            {
                panelCheckbox = new Panel();
                foreach (var item in suplierListCode)
                {
                    CheckBox = new CheckBox();
                    CheckBox.Text = $"Nhận hàng {_inputHelper.GetSupplierNameByCode(item)}";
                    CheckBox.AutoSize = true;
                    CheckBox.Name = "cb" + item;
                    CheckBox.Font = new Font("Arial", 12);
                    CheckBox.Dock = DockStyle.Right;
                    CheckBox.Checked = true;
                    CheckBox.CheckedChanged += CheckBox_CheckedChanged;
                    CheckBox_CheckedChanged(CheckBox, new EventArgs());
                    panelCheckbox.Controls.Add(CheckBox);
                }
                panelCheckbox.Dock = DockStyle.Fill;
                panelContainCheckBox.Controls.Add(panelCheckbox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var checkbox = sender as CheckBox;
                string supplierCode = checkbox.Name.Substring(2);
                if (!checkbox.Checked)
                {
                    checkbox.BackColor = Color.White;
                    ReadOnlyDgv(supplierCode);
                }
                else if (checkbox.Checked && !_inputHelper.IsSavedToStock(supplierCode, selectDate.Date))
                {
                    checkbox.BackColor = Color.LimeGreen;
                    UnReadOnlyDgv(supplierCode);
                }
                else if (checkbox.Checked && _inputHelper.IsSavedToStock(supplierCode, selectDate.Date))
                {
                    checkbox.BackColor = Color.LimeGreen;
                    ReadOnlyDgv(supplierCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void ReadOnlyDgv(string supplierCode)
        {
            DataGridView dataGridView = tablePanel.Controls.OfType<DataGridView>().Where(w => w.Name == "dgv" + supplierCode).FirstOrDefault();
            if (dataGridView != null) dataGridView.ReadOnly = true;
        }

        private void UnReadOnlyDgv(string supplierCode)
        {
            DataGridView dataGridView = tablePanel.Controls.OfType<DataGridView>().Where(w => w.Name == "dgv" + supplierCode).FirstOrDefault();
            if (dataGridView != null)
            {
                dataGridView.ReadOnly = false;
                dataGridView.Columns.Cast<DataGridViewColumn>().Where(w => w.Name != "Số lượng thực nhận").ToList().ForEach(f => f.ReadOnly = true);
            }
        }
        public void CreateTableLayoutPanel(List<string> suplierListCode)
        {
            try
            {
                tablePanel = new TableLayoutPanel();
                tablePanel.ColumnCount = suplierListCode.Count();

                // Set column styles to divide the space equally
                for (int i = 0; i < suplierListCode.Count; i++)
                {
                    tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / suplierListCode.Count));
                    Label label = new Label();
                    label.Text = _inputHelper.GetSupplierNameByCode(suplierListCode[i]);
                    label.Font = new Font("Arial", 12, FontStyle.Bold);
                    tablePanel.Controls.Add(label, i, 0);
                    dataGridView = new DataGridView() { Name = "dgv" + suplierListCode[i] };
                    dataGridView.Dock = DockStyle.Fill;

                    var orderDataList = _inputHelper.GetOrderDataBySupplierCode(suplierListCode[i], selectDate.Date);
                    ViewDataToDGV(dataGridView, orderDataList);
                    tablePanel.Controls.Add(dataGridView, i, 1);
                }
                tablePanel.Dock = DockStyle.Fill;
                panelLayout.Controls.Add(tablePanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void ViewDataToDGV(DataGridView dgv, List<Tbl_Order> orderDataList)
        {
            try
            {
                CustomDatagridview(dgv);
                foreach (var item in orderDataList)
                {
                    dgv.Rows.Add();
                    int index = dgv.RowCount - 1;
                    dgv.Rows[index].Cells["Mã nguyên liệu"].Value = item.IngredientCode;
                    dgv.Rows[index].Cells["Tên nguyên liệu"].Value = _inputHelper.GetIngredientByCode(item.IngredientCode).IngredientName;
                    dgv.Rows[index].Cells["Số lượng đặt hàng"].Value = Common.ConvertText(item.PlanOrder);
                    dgv.Rows[index].Cells["Số lượng thực nhận"].Value = Common.ConvertText(item.ActualOrder == null ? null : item.ActualOrder);
                    dgv.Rows[index].Cells["Đơn vị"].Value = _inputHelper.GetIngredientByCode(item.IngredientCode).Unit;
                    dgv.Rows[index].Cells["Định lượng"].Value = _inputHelper.GetIngredientByCode(item.IngredientCode).Spec;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private void CustomDatagridview(DataGridView dgv)
        {
            dgv.Columns.Add("Mã nguyên liệu", "Mã nguyên liệu");
            dgv.Columns.Add("Tên nguyên liệu", "Tên nguyên liệu");
            dgv.Columns.Add("Số lượng đặt hàng", "Số lượng đặt hàng");
            dgv.Columns.Add("Số lượng thực nhận", "Số lượng thực nhận");
            dgv.Columns.Add("Đơn vị", "Đơn vị");
            dgv.Columns.Add("Định lượng", "Định lượng");
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Khaki;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Arial", 11);
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.Columns["Số lượng thực nhận"].DefaultCellStyle.BackColor = Color.Yellow;
            dgv.BackgroundColor = Color.White;
        }
        bool isZoom = false;
        private void pictureBoxZoom_Click(object sender, EventArgs e)
        {
            if (!isZoom)
            {
                panelSystem.Visible = false;
                pictureBoxZoom.BackgroundImage = Properties.Resources.zoom_out;
            }
            else
            {
                panelSystem.Visible = true;
                pictureBoxZoom.BackgroundImage = Properties.Resources.ZoomIn;
            }
            isZoom = !isZoom;
        }
        bool select = false;
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (!select)
            {
                selectAll();
            }
            else
            {
                UnSelectAll();
            }
            select = !select;
        }

        private void UnSelectAll()
        {
            var datagridviewList = tablePanel.Controls.OfType<DataGridView>().ToList();
            if (datagridviewList.Count > 0)
            {
                foreach (var dgv in datagridviewList)
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        var plan = row.Cells["Số lượng đặt hàng"].Value;
                        row.Cells["Số lượng thực nhận"].Value = null;
                        btnSelectAll.Text = "Chọn tất cả";
                    }
                }
            }
            panelCheckbox.Controls.OfType<CheckBox>().ToList().ForEach(a => a.Checked = false);
        }

        private void selectAll()
        {
            var datagridviewList = tablePanel.Controls.OfType<DataGridView>().ToList();
            if (datagridviewList.Count > 0)
            {
                foreach(var dgv in datagridviewList)
                {
                    foreach(DataGridViewRow row in dgv.Rows)
                    {
                        var plan = row.Cells["Số lượng đặt hàng"].Value;
                        row.Cells["Số lượng thực nhận"].Value = plan;
                        btnSelectAll.Text = "Bỏ chọn";
                    }
                }
            }
            panelCheckbox.Controls.OfType<CheckBox>().ToList().ForEach(a => a.Checked =true);
        }

        private void cbOrderNotYetStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            var orderDate = cbOrderNotYetStock.SelectedItem as string;
            selectDate = DateTime.ParseExact(orderDate, "dd-MM-yyyy", null);
            datetimepicker.Value = selectDate;
            FindDataInput(selectDate);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsNotNullData())
                {
                    MessageBox.Show("Không có dữ liệu!");
                    return;
                }
                if (Common.FindUser() != "admin")
                {
                    if (_inputHelper.IsOverDateInput(selectDate))
                    {
                        MessageBox.Show("Đã quá thời gian nhận hàng, không thể thao tác!");
                        return;
                    }
                }
                if (!IsSelectDgv())
                {
                    MessageBox.Show("Hãy tích chọn nhà cung cấp nhận hàng!");
                    return;
                }
                if (_inputHelper.IsSavedToStock(suplierListCodeList, selectDate.Date))
                {
                    MessageBox.Show("Những đơn hàng này đã nhập kho rồi!");
                    return;
                }
                if (!IsValidValueDgv())
                {
                    MessageBox.Show("Phải điền số lượng, số lượng phải là số và lớn hơn 0!");
                    return;
                }
                if(MessageBox.Show("Bạn có chắc lưu lại không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_inputHelper.InputToStock(GetDgvIsChecked(), selectDate.Date))
                    {
                        MessageBox.Show("Lưu thành công!");
                        FindDataInput(selectDate);
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.Message);
            }
        }

        private bool IsValidValueDgv()
        {
           var dgvListChecked = GetDgvIsChecked();
            foreach (var dgv in dgvListChecked)
            {
                if (!IsNotEmptyActual(dgv) || !IsNumberFormatValue(dgv)) return false;
            }          
            return true;
        }

        private List<DataGridView> GetDgvIsChecked()
        {
            List<string> supplierchecked = new List<string>();
            GetCheckBoxList().Where(w => w.Checked).ToList().ForEach(f => supplierchecked.Add(f.Name.Substring(2)));
            List<DataGridView> dataGridViews = new List<DataGridView>();
            foreach (var item in supplierchecked)
            {
                dataGridViews.Add(GetDatagridviewList().Where(w => w.Name == "dgv" + item).FirstOrDefault());
            }
            return dataGridViews;
        }

        private bool IsNumberFormatValue(DataGridView dgv)
        {
            var valueList = dgv.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["Số lượng thực nhận"].Value != null).Select(s=>s.Cells["Số lượng thực nhận"].Value).ToList();
            double result;
            foreach(var item in valueList)
            {
                if(double.TryParse(item.ToString(), out result))
                {
                    if (result <= 0) return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsNotEmptyActual(DataGridView dgv)
        {
            var data = dgv.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["Số lượng thực nhận"].Value != null).Select(s => s.Cells["Số lượng thực nhận"].Value).ToList();
            if (data.Count <= 0) return false;
            return true;
        }
        private bool IsSelectDgv()
        {
            List<CheckBox> checkBoxes = GetCheckBoxList();
            return checkBoxes.Any(s => s.Checked);
        }

        private List<CheckBox> GetCheckBoxList()
        {
            if (panelCheckbox != null)
            {
                return panelCheckbox.Controls.OfType<CheckBox>().ToList();
            }
            return null;
        }

        private bool IsNotNullData()
        {
            List<DataGridView> dgvList = GetDatagridviewList();
            return dgvList.Select(w => w.Rows.Count > 0).FirstOrDefault();
        }

        private List<DataGridView> GetDatagridviewList()
        {
            if(tablePanel != null)
            {
                return tablePanel.Controls.OfType<DataGridView>().ToList();
            }
            return null;
        }
    }
}

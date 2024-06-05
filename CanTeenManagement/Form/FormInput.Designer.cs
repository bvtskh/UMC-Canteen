
namespace CanTeenManagement
{
    partial class FormInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.label1 = new System.Windows.Forms.Label();
            this.datetimepicker = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxZoom = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.panelSystem = new System.Windows.Forms.Panel();
            this.panelContainStatus = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lbFindOrderResult = new System.Windows.Forms.Label();
            this.cbOrderNotYetStock = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbHistoryOrderCode = new System.Windows.Forms.Label();
            this.lbOrderTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUserOrder = new System.Windows.Forms.Label();
            this.picNoteOrder = new System.Windows.Forms.PictureBox();
            this.lbNotification = new System.Windows.Forms.Label();
            this.panelSelectSupplier = new System.Windows.Forms.Panel();
            this.panelContainCheckBox = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSelectAll = new Sunny.UI.UISymbolButton();
            this.panelLayout = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZoom)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelSystem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoteOrder)).BeginInit();
            this.panelSelectSupplier.SuspendLayout();
            this.panelContainCheckBox.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1783, 41);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(699, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(352, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Danh sách nguyên liệu đặt hàng";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnSearch);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.datetimepicker);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(375, 39);
            this.panel7.TabIndex = 27;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = global::CanTeenManagement.Properties.Resources.search2;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(248, 7);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnSearch.Radius = 15;
            this.btnSearch.Size = new System.Drawing.Size(106, 27);
            this.btnSearch.Style = Sunny.UI.UIStyle.Custom;
            this.btnSearch.StyleCustomMode = true;
            this.btnSearch.Symbol = 61530;
            this.btnSearch.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnSearch.TabIndex = 114;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày : ";
            // 
            // datetimepicker
            // 
            this.datetimepicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimepicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimepicker.Location = new System.Drawing.Point(84, 8);
            this.datetimepicker.Name = "datetimepicker";
            this.datetimepicker.Size = new System.Drawing.Size(137, 26);
            this.datetimepicker.TabIndex = 1;
            // 
            // pictureBoxZoom
            // 
            this.pictureBoxZoom.BackgroundImage = global::CanTeenManagement.Properties.Resources.ZoomIn;
            this.pictureBoxZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxZoom.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxZoom.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxZoom.Name = "pictureBoxZoom";
            this.pictureBoxZoom.Size = new System.Drawing.Size(37, 37);
            this.pictureBoxZoom.TabIndex = 18;
            this.pictureBoxZoom.TabStop = false;
            this.pictureBoxZoom.Click += new System.EventHandler(this.pictureBoxZoom_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 625);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1783, 48);
            this.panel2.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::CanTeenManagement.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(1680, 8);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnSave.Radius = 15;
            this.btnSave.Size = new System.Drawing.Size(92, 35);
            this.btnSave.Style = Sunny.UI.UIStyle.Custom;
            this.btnSave.StyleCustomMode = true;
            this.btnSave.Symbol = 61530;
            this.btnSave.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnSave.TabIndex = 115;
            this.btnSave.Text = "Lưu";
            this.btnSave.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelSystem
            // 
            this.panelSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSystem.Controls.Add(this.panelContainStatus);
            this.panelSystem.Controls.Add(this.label9);
            this.panelSystem.Controls.Add(this.lbFindOrderResult);
            this.panelSystem.Controls.Add(this.cbOrderNotYetStock);
            this.panelSystem.Controls.Add(this.label11);
            this.panelSystem.Controls.Add(this.label6);
            this.panelSystem.Controls.Add(this.label7);
            this.panelSystem.Controls.Add(this.lbHistoryOrderCode);
            this.panelSystem.Controls.Add(this.lbOrderTime);
            this.panelSystem.Controls.Add(this.label2);
            this.panelSystem.Controls.Add(this.lbUserOrder);
            this.panelSystem.Controls.Add(this.picNoteOrder);
            this.panelSystem.Controls.Add(this.lbNotification);
            this.panelSystem.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSystem.Location = new System.Drawing.Point(0, 41);
            this.panelSystem.Name = "panelSystem";
            this.panelSystem.Size = new System.Drawing.Size(376, 584);
            this.panelSystem.TabIndex = 2;
            // 
            // panelContainStatus
            // 
            this.panelContainStatus.Location = new System.Drawing.Point(11, 209);
            this.panelContainStatus.Name = "panelContainStatus";
            this.panelContainStatus.Size = new System.Drawing.Size(343, 227);
            this.panelContainStatus.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(87, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 24);
            this.label9.TabIndex = 23;
            this.label9.Text = "Thông tin đơn hàng";
            // 
            // lbFindOrderResult
            // 
            this.lbFindOrderResult.AutoSize = true;
            this.lbFindOrderResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFindOrderResult.Location = new System.Drawing.Point(14, 470);
            this.lbFindOrderResult.Name = "lbFindOrderResult";
            this.lbFindOrderResult.Size = new System.Drawing.Size(61, 16);
            this.lbFindOrderResult.TabIndex = 30;
            this.lbFindOrderResult.Text = "Tìm thấy:";
            // 
            // cbOrderNotYetStock
            // 
            this.cbOrderNotYetStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOrderNotYetStock.FormattingEnabled = true;
            this.cbOrderNotYetStock.Location = new System.Drawing.Point(182, 462);
            this.cbOrderNotYetStock.Name = "cbOrderNotYetStock";
            this.cbOrderNotYetStock.Size = new System.Drawing.Size(152, 28);
            this.cbOrderNotYetStock.TabIndex = 29;
            this.cbOrderNotYetStock.SelectedIndexChanged += new System.EventHandler(this.cbOrderNotYetStock_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(13, 439);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(331, 20);
            this.label11.TabIndex = 28;
            this.label11.Text = "Danh sách đơn hàng chưa nhập vào kho";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Thời gian đặt hàng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Người đặt hàng:";
            // 
            // lbHistoryOrderCode
            // 
            this.lbHistoryOrderCode.AutoSize = true;
            this.lbHistoryOrderCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHistoryOrderCode.Location = new System.Drawing.Point(116, 185);
            this.lbHistoryOrderCode.Name = "lbHistoryOrderCode";
            this.lbHistoryOrderCode.Size = new System.Drawing.Size(0, 15);
            this.lbHistoryOrderCode.TabIndex = 20;
            // 
            // lbOrderTime
            // 
            this.lbOrderTime.AutoSize = true;
            this.lbOrderTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrderTime.Location = new System.Drawing.Point(151, 131);
            this.lbOrderTime.Name = "lbOrderTime";
            this.lbOrderTime.Size = new System.Drawing.Size(0, 15);
            this.lbOrderTime.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Mã hóa đơn: ";
            // 
            // lbUserOrder
            // 
            this.lbUserOrder.AutoSize = true;
            this.lbUserOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserOrder.Location = new System.Drawing.Point(137, 158);
            this.lbUserOrder.Name = "lbUserOrder";
            this.lbUserOrder.Size = new System.Drawing.Size(0, 15);
            this.lbUserOrder.TabIndex = 14;
            // 
            // picNoteOrder
            // 
            this.picNoteOrder.Location = new System.Drawing.Point(290, 70);
            this.picNoteOrder.Name = "picNoteOrder";
            this.picNoteOrder.Size = new System.Drawing.Size(31, 30);
            this.picNoteOrder.TabIndex = 17;
            this.picNoteOrder.TabStop = false;
            // 
            // lbNotification
            // 
            this.lbNotification.AutoSize = true;
            this.lbNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotification.ForeColor = System.Drawing.Color.Blue;
            this.lbNotification.Location = new System.Drawing.Point(16, 72);
            this.lbNotification.Name = "lbNotification";
            this.lbNotification.Size = new System.Drawing.Size(0, 18);
            this.lbNotification.TabIndex = 12;
            // 
            // panelSelectSupplier
            // 
            this.panelSelectSupplier.Controls.Add(this.panelContainCheckBox);
            this.panelSelectSupplier.Controls.Add(this.panel3);
            this.panelSelectSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelectSupplier.Location = new System.Drawing.Point(376, 41);
            this.panelSelectSupplier.Name = "panelSelectSupplier";
            this.panelSelectSupplier.Size = new System.Drawing.Size(1407, 37);
            this.panelSelectSupplier.TabIndex = 3;
            // 
            // panelContainCheckBox
            // 
            this.panelContainCheckBox.Controls.Add(this.pictureBoxZoom);
            this.panelContainCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainCheckBox.Location = new System.Drawing.Point(0, 0);
            this.panelContainCheckBox.Name = "panelContainCheckBox";
            this.panelContainCheckBox.Size = new System.Drawing.Size(1235, 37);
            this.panelContainCheckBox.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSelectAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1235, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 37);
            this.panel3.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectAll.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btnSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Image = global::CanTeenManagement.Properties.Resources.office_material;
            this.btnSelectAll.Location = new System.Drawing.Point(0, 0);
            this.btnSelectAll.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Padding = new System.Windows.Forms.Padding(5, 0, 10, 0);
            this.btnSelectAll.Radius = 15;
            this.btnSelectAll.Size = new System.Drawing.Size(172, 37);
            this.btnSelectAll.Style = Sunny.UI.UIStyle.Custom;
            this.btnSelectAll.StyleCustomMode = true;
            this.btnSelectAll.Symbol = 61530;
            this.btnSelectAll.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.btnSelectAll.TabIndex = 120;
            this.btnSelectAll.Text = "Chọn tất cả";
            this.btnSelectAll.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // panelLayout
            // 
            this.panelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLayout.Location = new System.Drawing.Point(376, 78);
            this.panelLayout.Name = "panelLayout";
            this.panelLayout.Size = new System.Drawing.Size(1407, 547);
            this.panelLayout.TabIndex = 4;
            // 
            // FormInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1783, 673);
            this.Controls.Add(this.panelLayout);
            this.Controls.Add(this.panelSelectSupplier);
            this.Controls.Add(this.panelSystem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInput";
            this.Text = "FormInput";
            this.Load += new System.EventHandler(this.FormInputClon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZoom)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelSystem.ResumeLayout(false);
            this.panelSystem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNoteOrder)).EndInit();
            this.panelSelectSupplier.ResumeLayout(false);
            this.panelContainCheckBox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelSystem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker datetimepicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbHistoryOrderCode;
        private System.Windows.Forms.Label lbOrderTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUserOrder;
        private System.Windows.Forms.PictureBox picNoteOrder;
        private System.Windows.Forms.Label lbNotification;
        private System.Windows.Forms.ComboBox cbOrderNotYetStock;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbFindOrderResult;
        private System.Windows.Forms.PictureBox pictureBoxZoom;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton btnSave;
        private System.Windows.Forms.Panel panelSelectSupplier;
        private System.Windows.Forms.Panel panelLayout;
        private System.Windows.Forms.Panel panelCheckbox;
        private System.Windows.Forms.Panel panel3;
        private Sunny.UI.UISymbolButton btnSelectAll;
        private System.Windows.Forms.Panel panelContainCheckBox;
        private System.Windows.Forms.Panel panelContainStatus;
    }
}
﻿namespace CanTeenManagement
{
    partial class FormUpdatePrice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvUpdateInfo = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpApproveTime = new System.Windows.Forms.DateTimePicker();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvHistoryPriceTav2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtYear = new Sunny.UI.UITextBox();
            this.txtMonth = new Sunny.UI.UITextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnSearchTab2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbApproveDateTab2 = new System.Windows.Forms.ComboBox();
            this.cbbSupplierTab2 = new System.Windows.Forms.ComboBox();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.btnImport = new Sunny.UI.UISymbolButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateInfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryPriceTav2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 649);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvUpdateInfo);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1000, 618);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cập nhật giá";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvUpdateInfo
            // 
            this.dgvUpdateInfo.AllowUserToAddRows = false;
            this.dgvUpdateInfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUpdateInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUpdateInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpdateInfo.EnableHeadersVisualStyles = false;
            this.dgvUpdateInfo.Location = new System.Drawing.Point(3, 57);
            this.dgvUpdateInfo.Name = "dgvUpdateInfo";
            this.dgvUpdateInfo.Size = new System.Drawing.Size(994, 513);
            this.dgvUpdateInfo.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 570);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(994, 45);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpApproveTime);
            this.panel1.Controls.Add(this.lblSupplierCode);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 54);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã nhà cung cấp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thời gian áp dụng:";
            // 
            // dtpApproveTime
            // 
            this.dtpApproveTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpApproveTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpApproveTime.Location = new System.Drawing.Point(275, 15);
            this.dtpApproveTime.Name = "dtpApproveTime";
            this.dtpApproveTime.Size = new System.Drawing.Size(130, 26);
            this.dtpApproveTime.TabIndex = 2;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierCode.Location = new System.Drawing.Point(549, 22);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(0, 16);
            this.lblSupplierCode.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 618);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lịch sử cập nhật";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvHistoryPriceTav2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 75);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(994, 540);
            this.panel4.TabIndex = 1;
            // 
            // dgvHistoryPriceTav2
            // 
            this.dgvHistoryPriceTav2.AllowUserToAddRows = false;
            this.dgvHistoryPriceTav2.AllowUserToDeleteRows = false;
            this.dgvHistoryPriceTav2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistoryPriceTav2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistoryPriceTav2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryPriceTav2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvHistoryPriceTav2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistoryPriceTav2.EnableHeadersVisualStyles = false;
            this.dgvHistoryPriceTav2.Location = new System.Drawing.Point(0, 0);
            this.dgvHistoryPriceTav2.Name = "dgvHistoryPriceTav2";
            this.dgvHistoryPriceTav2.Size = new System.Drawing.Size(994, 540);
            this.dgvHistoryPriceTav2.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã nguyên liệu";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên nguyên liệu";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Giá cũ";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Giá mới";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Thông số";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Định lượng";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Thời gian cập nhật";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Thời gian áp dụng";
            this.Column8.Name = "Column8";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtYear);
            this.panel3.Controls.Add(this.txtMonth);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btnApprove);
            this.panel3.Controls.Add(this.btnSearchTab2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cbbApproveDateTab2);
            this.panel3.Controls.Add(this.cbbSupplierTab2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 72);
            this.panel3.TabIndex = 0;
            // 
            // txtYear
            // 
            this.txtYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtYear.Location = new System.Drawing.Point(422, 29);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtYear.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtYear.Name = "txtYear";
            this.txtYear.Padding = new System.Windows.Forms.Padding(5);
            this.txtYear.RectColor = System.Drawing.Color.Silver;
            this.txtYear.ShowText = false;
            this.txtYear.Size = new System.Drawing.Size(81, 25);
            this.txtYear.TabIndex = 43;
            this.txtYear.Text = "0";
            this.txtYear.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtYear.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtYear.Watermark = "";
            // 
            // txtMonth
            // 
            this.txtMonth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMonth.Location = new System.Drawing.Point(558, 29);
            this.txtMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMonth.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Padding = new System.Windows.Forms.Padding(5);
            this.txtMonth.RectColor = System.Drawing.Color.Silver;
            this.txtMonth.ShowText = false;
            this.txtMonth.Size = new System.Drawing.Size(61, 25);
            this.txtMonth.TabIndex = 44;
            this.txtMonth.Text = "0";
            this.txtMonth.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMonth.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtMonth.Watermark = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(419, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 40;
            this.label5.Text = "Áp dụng cho tháng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "Năm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(502, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 42;
            this.label7.Text = "Tháng";
            // 
            // btnApprove
            // 
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Location = new System.Drawing.Point(626, 26);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(84, 30);
            this.btnApprove.TabIndex = 2;
            this.btnApprove.Text = "Áp dụng";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnSearchTab2
            // 
            this.btnSearchTab2.BackColor = System.Drawing.Color.White;
            this.btnSearchTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchTab2.Location = new System.Drawing.Point(277, 30);
            this.btnSearchTab2.Name = "btnSearchTab2";
            this.btnSearchTab2.Size = new System.Drawing.Size(84, 26);
            this.btnSearchTab2.TabIndex = 2;
            this.btnSearchTab2.Text = "Tìm kiếm";
            this.btnSearchTab2.UseVisualStyleBackColor = false;
            this.btnSearchTab2.Click += new System.EventHandler(this.btnSearchTab2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Lịch sử áp dụng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nhà cung cấp";
            // 
            // cbbApproveDateTab2
            // 
            this.cbbApproveDateTab2.FormattingEnabled = true;
            this.cbbApproveDateTab2.Location = new System.Drawing.Point(150, 30);
            this.cbbApproveDateTab2.Name = "cbbApproveDateTab2";
            this.cbbApproveDateTab2.Size = new System.Drawing.Size(121, 26);
            this.cbbApproveDateTab2.TabIndex = 0;
            this.cbbApproveDateTab2.SelectedIndexChanged += new System.EventHandler(this.cbbApproveDateTab2_SelectedIndexChanged);
            // 
            // cbbSupplierTab2
            // 
            this.cbbSupplierTab2.FormattingEnabled = true;
            this.cbbSupplierTab2.Location = new System.Drawing.Point(17, 30);
            this.cbbSupplierTab2.Name = "cbbSupplierTab2";
            this.cbbSupplierTab2.Size = new System.Drawing.Size(121, 26);
            this.cbbSupplierTab2.TabIndex = 0;
            this.cbbSupplierTab2.SelectedIndexChanged += new System.EventHandler(this.cbbSupplierTab2_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(70)))), ((int)(((byte)(55)))));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Image = global::CanTeenManagement.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(879, 5);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.RectColor = System.Drawing.Color.Transparent;
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImport
            // 
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnImport.Image = global::CanTeenManagement.Properties.Resources.excel;
            this.btnImport.Location = new System.Drawing.Point(21, 10);
            this.btnImport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnImport.Name = "btnImport";
            this.btnImport.RectColor = System.Drawing.Color.Transparent;
            this.btnImport.Size = new System.Drawing.Size(100, 35);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FormUpdatePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 649);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormUpdatePrice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUpdatePrice";
            this.Load += new System.EventHandler(this.FormUpdatePrice_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateInfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryPriceTav2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvUpdateInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpApproveTime;
        private System.Windows.Forms.Label lblSupplierCode;
        private Sunny.UI.UISymbolButton btnImport;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UISymbolButton btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSearchTab2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbApproveDateTab2;
        private System.Windows.Forms.ComboBox cbbSupplierTab2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvHistoryPriceTav2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button btnApprove;
        private Sunny.UI.UITextBox txtYear;
        private Sunny.UI.UITextBox txtMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
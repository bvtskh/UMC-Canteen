namespace CanTeenManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvUpdateInfo = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.btnImport = new Sunny.UI.UISymbolButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateInfo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(225)))), ((int)(((byte)(214)))));
            this.dgvUpdateInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUpdateInfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUpdateInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiSymbolButton2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lblSupplierCode);
            this.panel1.Controls.Add(this.uiSymbolButton1);
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
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(724, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 26);
            this.textBox1.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(275, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 26);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierCode.Location = new System.Drawing.Point(556, 22);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(0, 16);
            this.lblSupplierCode.TabIndex = 1;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.White;
            this.uiSymbolButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiSymbolButton1.Image = global::CanTeenManagement.Properties.Resources.search2;
            this.uiSymbolButton1.Location = new System.Drawing.Point(954, 16);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(25, 26);
            this.uiSymbolButton1.TabIndex = 0;
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // btnImport
            // 
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(70)))), ((int)(((byte)(155)))));
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnImport.Image = global::CanTeenManagement.Properties.Resources.excel;
            this.btnImport.Location = new System.Drawing.Point(21, 10);
            this.btnImport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 35);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import";
            this.btnImport.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1000, 618);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lịch sử cập nhật";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(70)))), ((int)(((byte)(155)))));
            this.uiSymbolButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiSymbolButton2.Image = global::CanTeenManagement.Properties.Resources.excel;
            this.uiSymbolButton2.Location = new System.Drawing.Point(580, 10);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton2.TabIndex = 5;
            this.uiSymbolButton2.Text = "Import";
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.uiSymbolButton2.Click += new System.EventHandler(this.uiSymbolButton2_Click);
            // 
            // FormUpdatePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 649);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormUpdatePrice";
            this.Text = "FormUpdatePrice";
            this.Load += new System.EventHandler(this.FormUpdatePrice_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateInfo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvUpdateInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblSupplierCode;
        private Sunny.UI.UISymbolButton btnImport;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UISymbolButton btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
    }
}
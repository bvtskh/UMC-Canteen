namespace CanTeenManagement
{
    partial class FormUuTienDatHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lbOrder = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPreOrder = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPreListOrder = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbUnit = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIngredientList = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAddToOrder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreListOrder)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày đặt hàng:";
            // 
            // lbOrder
            // 
            this.lbOrder.AutoSize = true;
            this.lbOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrder.Location = new System.Drawing.Point(121, 44);
            this.lbOrder.Name = "lbOrder";
            this.lbOrder.Size = new System.Drawing.Size(51, 16);
            this.lbOrder.TabIndex = 1;
            this.lbOrder.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đặt trước cho ngày:";
            // 
            // lbPreOrder
            // 
            this.lbPreOrder.AutoSize = true;
            this.lbPreOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPreOrder.Location = new System.Drawing.Point(155, 86);
            this.lbPreOrder.Name = "lbPreOrder";
            this.lbPreOrder.Size = new System.Drawing.Size(51, 16);
            this.lbPreOrder.TabIndex = 3;
            this.lbPreOrder.Text = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvPreListOrder);
            this.groupBox1.Controls.Add(this.lbOrder);
            this.groupBox1.Controls.Add(this.lbPreOrder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 155);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thời gian";
            // 
            // dgvPreListOrder
            // 
            this.dgvPreListOrder.AllowUserToAddRows = false;
            this.dgvPreListOrder.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreListOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPreListOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreListOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvPreListOrder.EnableHeadersVisualStyles = false;
            this.dgvPreListOrder.Location = new System.Drawing.Point(227, 25);
            this.dgvPreListOrder.Name = "dgvPreListOrder";
            this.dgvPreListOrder.RowHeadersVisible = false;
            this.dgvPreListOrder.Size = new System.Drawing.Size(67, 378);
            this.dgvPreListOrder.TabIndex = 1;
            this.dgvPreListOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreListOrder_CellClick);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Thời gian";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã nguyên liệu";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Tên nguyên liệu";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Số lượng";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Đơn vị";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lbUnit);
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtNumber);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cbIngredientList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 328);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đặt hàng ";
            // 
            // lbUnit
            // 
            this.lbUnit.AutoSize = true;
            this.lbUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUnit.Location = new System.Drawing.Point(186, 59);
            this.lbUnit.Name = "lbUnit";
            this.lbUnit.Size = new System.Drawing.Size(0, 16);
            this.lbUnit.TabIndex = 6;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.Blue;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(268, 114);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(89, 34);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "Chọn";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(279, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số lượng";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(268, 56);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(89, 26);
            this.txtNumber.TabIndex = 3;
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Danh sách thực phẩm";
            // 
            // cbIngredientList
            // 
            this.cbIngredientList.FormattingEnabled = true;
            this.cbIngredientList.Location = new System.Drawing.Point(12, 54);
            this.cbIngredientList.Name = "cbIngredientList";
            this.cbIngredientList.Size = new System.Drawing.Size(168, 28);
            this.cbIngredientList.TabIndex = 0;
            this.cbIngredientList.SelectedIndexChanged += new System.EventHandler(this.cbIngredientList_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 483);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.webBrowser1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(363, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 483);
            this.panel2.TabIndex = 7;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 10);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(848, 418);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.Url = new System.Uri("http://youtube.com", System.UriKind.Absolute);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(848, 10);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnDel);
            this.panel3.Controls.Add(this.btnAddToOrder);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 428);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(848, 55);
            this.panel3.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.Blue;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(482, 10);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(89, 34);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "Xóa";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAddToOrder
            // 
            this.btnAddToOrder.BackColor = System.Drawing.Color.SpringGreen;
            this.btnAddToOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToOrder.ForeColor = System.Drawing.Color.Black;
            this.btnAddToOrder.Location = new System.Drawing.Point(579, 9);
            this.btnAddToOrder.Name = "btnAddToOrder";
            this.btnAddToOrder.Size = new System.Drawing.Size(266, 34);
            this.btnAddToOrder.TabIndex = 6;
            this.btnAddToOrder.Text = "Thêm vào danh sách đặt hàng";
            this.btnAddToOrder.UseVisualStyleBackColor = false;
            this.btnAddToOrder.Click += new System.EventHandler(this.btnAddToOrder_Click);
            // 
            // FormUuTienDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 483);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormUuTienDatHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt hàng trước theo yêu cầu";
            this.Load += new System.EventHandler(this.FormUuTienDatHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreListOrder)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPreOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbIngredientList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddToOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridView dgvPreListOrder;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbUnit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
namespace CanTeenManagement
{
    partial class FormCheckHistoryOutStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnnext = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.lbtitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvHistoryOutStock = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryOutStock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lbtitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 48);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnnext);
            this.panel3.Controls.Add(this.btnback);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(971, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 48);
            this.panel3.TabIndex = 1;
            // 
            // btnnext
            // 
            this.btnnext.BackColor = System.Drawing.Color.White;
            this.btnnext.BackgroundImage = global::CanTeenManagement.Properties.Resources.Arrow1;
            this.btnnext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnext.Location = new System.Drawing.Point(51, 3);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(42, 39);
            this.btnnext.TabIndex = 1;
            this.btnnext.UseVisualStyleBackColor = false;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.White;
            this.btnback.BackgroundImage = global::CanTeenManagement.Properties.Resources.Arrow;
            this.btnback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Location = new System.Drawing.Point(3, 3);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(42, 39);
            this.btnback.TabIndex = 0;
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // lbtitle
            // 
            this.lbtitle.AutoSize = true;
            this.lbtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitle.ForeColor = System.Drawing.Color.White;
            this.lbtitle.Location = new System.Drawing.Point(12, 9);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(250, 25);
            this.lbtitle.TabIndex = 0;
            this.lbtitle.Text = "Lịch sử xuất kho ngày:";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 448);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1221, 10);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvHistoryOutStock);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 48);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1221, 400);
            this.panel4.TabIndex = 3;
            // 
            // dgvHistoryOutStock
            // 
            this.dgvHistoryOutStock.AllowUserToAddRows = false;
            this.dgvHistoryOutStock.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistoryOutStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistoryOutStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryOutStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column4,
            this.Column2,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistoryOutStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistoryOutStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistoryOutStock.EnableHeadersVisualStyles = false;
            this.dgvHistoryOutStock.Location = new System.Drawing.Point(0, 0);
            this.dgvHistoryOutStock.Name = "dgvHistoryOutStock";
            this.dgvHistoryOutStock.RowHeadersVisible = false;
            this.dgvHistoryOutStock.Size = new System.Drawing.Size(1221, 400);
            this.dgvHistoryOutStock.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Đơn hàng ngày";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Mã nguyên liệu";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tên nguyên liệu";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 250;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Số lượng thực nhận";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column6.HeaderText = "Số lượng đã xuất kho";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Đơn vị";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Thông số";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Người thực hiện";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // FormCheckHistoryOutStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 458);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormCheckHistoryOutStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCheckHistoryOutStock";
            this.Load += new System.EventHandler(this.FormCheckHistoryOutStock_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryOutStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvHistoryOutStock;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}

namespace CanTeenManagement
{
    partial class FormChangeOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiDatePicker1 = new Sunny.UI.UIDatePicker();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.cbSuplier = new Sunny.UI.UIComboBox();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.dgvChange = new System.Windows.Forms.DataGridView();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChange)).BeginInit();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiDatePicker1
            // 
            this.uiDatePicker1.FillColor = System.Drawing.Color.White;
            this.uiDatePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiDatePicker1.Location = new System.Drawing.Point(2, 6);
            this.uiDatePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDatePicker1.MaxLength = 10;
            this.uiDatePicker1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiDatePicker1.Name = "uiDatePicker1";
            this.uiDatePicker1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiDatePicker1.Size = new System.Drawing.Size(150, 29);
            this.uiDatePicker1.SymbolDropDown = 61555;
            this.uiDatePicker1.SymbolNormal = 61555;
            this.uiDatePicker1.TabIndex = 0;
            this.uiDatePicker1.Text = "2024-01-03";
            this.uiDatePicker1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiDatePicker1.Value = new System.DateTime(2024, 1, 3, 16, 41, 51, 374);
            this.uiDatePicker1.Watermark = "";
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.cbSuplier);
            this.uiPanel1.Controls.Add(this.btnSearch);
            this.uiPanel1.Controls.Add(this.uiDatePicker1);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1619, 40);
            this.uiPanel1.TabIndex = 1;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSuplier
            // 
            this.cbSuplier.DataSource = null;
            this.cbSuplier.FillColor = System.Drawing.Color.White;
            this.cbSuplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbSuplier.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.cbSuplier.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.cbSuplier.Location = new System.Drawing.Point(155, 6);
            this.cbSuplier.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbSuplier.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbSuplier.Name = "cbSuplier";
            this.cbSuplier.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbSuplier.Size = new System.Drawing.Size(150, 29);
            this.cbSuplier.TabIndex = 2;
            this.cbSuplier.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbSuplier.Watermark = "";
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearch.Image = global::CanTeenManagement.Properties.Resources.search2;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(308, 6);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TipsFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvChange
            // 
            this.dgvChange.AllowUserToAddRows = false;
            this.dgvChange.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChange.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChange.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.dgvChange.ContextMenuStrip = this.uiContextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChange.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChange.EnableHeadersVisualStyles = false;
            this.dgvChange.Location = new System.Drawing.Point(0, 40);
            this.dgvChange.Name = "dgvChange";
            this.dgvChange.RowHeadersVisible = false;
            this.dgvChange.Size = new System.Drawing.Size(1619, 571);
            this.dgvChange.TabIndex = 2;
            this.dgvChange.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChange_CellClick);
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(132, 28);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // Column12
            // 
            this.Column12.HeaderText = "ID";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Ngày tạo hóa đơn";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Hóa đơn ngày";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mã nguyên liệu";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Kế hoạch";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Thực nhận";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Mã lịch sử giá";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Giá";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Tổng tiền";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Mã hóa đơn";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Nhà cung cấp";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Ghi chú";
            this.Column11.Name = "Column11";
            // 
            // FormChangeOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1619, 611);
            this.Controls.Add(this.dgvChange);
            this.Controls.Add(this.uiPanel1);
            this.Name = "FormChangeOrder";
            this.Text = "FormChangeOrder";
            this.Load += new System.EventHandler(this.FormChangeOrder_Load);
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChange)).EndInit();
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDatePicker uiDatePicker1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolButton btnSearch;
        private System.Windows.Forms.DataGridView dgvChange;
        private Sunny.UI.UIComboBox cbSuplier;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}
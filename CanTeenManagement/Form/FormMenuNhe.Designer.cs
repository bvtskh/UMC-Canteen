
namespace CanTeenManagement
{
    partial class FormMenuNhe
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaThựcĐơnNàyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnSaveMenu = new System.Windows.Forms.Button();
            this.btnSaveDatabase = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.txtEatDessert5 = new System.Windows.Forms.TextBox();
            this.cbEatDessert5 = new System.Windows.Forms.ComboBox();
            this.txtEatDessert2 = new System.Windows.Forms.TextBox();
            this.cbEatDessert2 = new System.Windows.Forms.ComboBox();
            this.txtEatDessert1 = new System.Windows.Forms.TextBox();
            this.cbEatDessert1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEatDessert4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDayInMonth = new System.Windows.Forms.ComboBox();
            this.cbEatDessert4 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEatDessert3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbEatDessert3 = new System.Windows.Forms.ComboBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dgrMenu = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SideMeal4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrMenu)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaThựcĐơnNàyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 26);
            // 
            // xóaThựcĐơnNàyToolStripMenuItem
            // 
            this.xóaThựcĐơnNàyToolStripMenuItem.Name = "xóaThựcĐơnNàyToolStripMenuItem";
            this.xóaThựcĐơnNàyToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.xóaThựcĐơnNàyToolStripMenuItem.Text = "Xóa thực đơn này";
            this.xóaThựcĐơnNàyToolStripMenuItem.Click += new System.EventHandler(this.xóaThựcĐơnNàyToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnExportExcel);
            this.panel2.Controls.Add(this.btnSaveMenu);
            this.panel2.Controls.Add(this.btnSaveDatabase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 499);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1220, 51);
            this.panel2.TabIndex = 35;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.BackColor = System.Drawing.Color.Green;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Image = global::CanTeenManagement.Properties.Resources.excel;
            this.btnExportExcel.Location = new System.Drawing.Point(1035, 9);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(172, 38);
            this.btnExportExcel.TabIndex = 29;
            this.btnExportExcel.Text = "Xuất File Excel";
            this.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnSaveMenu
            // 
            this.btnSaveMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMenu.BackColor = System.Drawing.Color.MediumBlue;
            this.btnSaveMenu.FlatAppearance.BorderSize = 0;
            this.btnSaveMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveMenu.ForeColor = System.Drawing.Color.White;
            this.btnSaveMenu.Image = global::CanTeenManagement.Properties.Resources.sign;
            this.btnSaveMenu.Location = new System.Drawing.Point(846, 9);
            this.btnSaveMenu.Name = "btnSaveMenu";
            this.btnSaveMenu.Size = new System.Drawing.Size(102, 38);
            this.btnSaveMenu.TabIndex = 28;
            this.btnSaveMenu.Text = "Thêm";
            this.btnSaveMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveMenu.UseVisualStyleBackColor = false;
            this.btnSaveMenu.Click += new System.EventHandler(this.btnSaveMenu_Click);
            // 
            // btnSaveDatabase
            // 
            this.btnSaveDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDatabase.BackColor = System.Drawing.Color.Crimson;
            this.btnSaveDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDatabase.ForeColor = System.Drawing.Color.White;
            this.btnSaveDatabase.Image = global::CanTeenManagement.Properties.Resources.database;
            this.btnSaveDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveDatabase.Location = new System.Drawing.Point(954, 9);
            this.btnSaveDatabase.Name = "btnSaveDatabase";
            this.btnSaveDatabase.Size = new System.Drawing.Size(75, 38);
            this.btnSaveDatabase.TabIndex = 33;
            this.btnSaveDatabase.Text = "Lưu";
            this.btnSaveDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveDatabase.UseVisualStyleBackColor = false;
            this.btnSaveDatabase.Click += new System.EventHandler(this.btnSaveDatabase_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 373);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1220, 126);
            this.panel3.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelSelect);
            this.groupBox1.Controls.Add(this.hScrollBar1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1220, 126);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn thực đơn ";
            // 
            // panelSelect
            // 
            this.panelSelect.Controls.Add(this.txtEatDessert5);
            this.panelSelect.Controls.Add(this.cbEatDessert5);
            this.panelSelect.Controls.Add(this.txtEatDessert2);
            this.panelSelect.Controls.Add(this.cbEatDessert2);
            this.panelSelect.Controls.Add(this.txtEatDessert1);
            this.panelSelect.Controls.Add(this.cbEatDessert1);
            this.panelSelect.Controls.Add(this.label3);
            this.panelSelect.Controls.Add(this.txtEatDessert4);
            this.panelSelect.Controls.Add(this.label2);
            this.panelSelect.Controls.Add(this.cbDayInMonth);
            this.panelSelect.Controls.Add(this.cbEatDessert4);
            this.panelSelect.Controls.Add(this.label11);
            this.panelSelect.Controls.Add(this.label1);
            this.panelSelect.Controls.Add(this.txtEatDessert3);
            this.panelSelect.Controls.Add(this.label10);
            this.panelSelect.Controls.Add(this.label9);
            this.panelSelect.Controls.Add(this.cbEatDessert3);
            this.panelSelect.Location = new System.Drawing.Point(3, 23);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(1220, 80);
            this.panelSelect.TabIndex = 34;
            // 
            // txtEatDessert5
            // 
            this.txtEatDessert5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEatDessert5.Location = new System.Drawing.Point(900, 33);
            this.txtEatDessert5.Name = "txtEatDessert5";
            this.txtEatDessert5.Size = new System.Drawing.Size(144, 24);
            this.txtEatDessert5.TabIndex = 35;
            this.txtEatDessert5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDish_MouseClick);
            this.txtEatDessert5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDish_KeyDown);
            // 
            // cbEatDessert5
            // 
            this.cbEatDessert5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEatDessert5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEatDessert5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEatDessert5.FormattingEnabled = true;
            this.cbEatDessert5.Location = new System.Drawing.Point(900, 33);
            this.cbEatDessert5.Name = "cbEatDessert5";
            this.cbEatDessert5.Size = new System.Drawing.Size(159, 24);
            this.cbEatDessert5.TabIndex = 34;
            this.cbEatDessert5.SelectedValueChanged += new System.EventHandler(this.cbDish_SelectedIndexChanged);
            // 
            // txtEatDessert2
            // 
            this.txtEatDessert2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEatDessert2.Location = new System.Drawing.Point(363, 33);
            this.txtEatDessert2.Name = "txtEatDessert2";
            this.txtEatDessert2.Size = new System.Drawing.Size(144, 24);
            this.txtEatDessert2.TabIndex = 28;
            this.txtEatDessert2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDish_MouseClick);
            this.txtEatDessert2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDish_KeyDown);
            // 
            // cbEatDessert2
            // 
            this.cbEatDessert2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEatDessert2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEatDessert2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEatDessert2.FormattingEnabled = true;
            this.cbEatDessert2.Location = new System.Drawing.Point(363, 33);
            this.cbEatDessert2.Name = "cbEatDessert2";
            this.cbEatDessert2.Size = new System.Drawing.Size(159, 24);
            this.cbEatDessert2.TabIndex = 25;
            this.cbEatDessert2.SelectedValueChanged += new System.EventHandler(this.cbDish_SelectedIndexChanged);
            // 
            // txtEatDessert1
            // 
            this.txtEatDessert1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEatDessert1.Location = new System.Drawing.Point(184, 34);
            this.txtEatDessert1.Name = "txtEatDessert1";
            this.txtEatDessert1.Size = new System.Drawing.Size(144, 24);
            this.txtEatDessert1.TabIndex = 28;
            this.txtEatDessert1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDish_MouseClick);
            this.txtEatDessert1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDish_KeyDown);
            // 
            // cbEatDessert1
            // 
            this.cbEatDessert1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEatDessert1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEatDessert1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEatDessert1.FormattingEnabled = true;
            this.cbEatDessert1.Location = new System.Drawing.Point(184, 34);
            this.cbEatDessert1.Name = "cbEatDessert1";
            this.cbEatDessert1.Size = new System.Drawing.Size(159, 24);
            this.cbEatDessert1.TabIndex = 23;
            this.cbEatDessert1.SelectedValueChanged += new System.EventHandler(this.cbDish_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(926, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 33;
            this.label3.Text = "Ăn nhẹ 5";
            // 
            // txtEatDessert4
            // 
            this.txtEatDessert4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEatDessert4.Location = new System.Drawing.Point(721, 33);
            this.txtEatDessert4.Name = "txtEatDessert4";
            this.txtEatDessert4.Size = new System.Drawing.Size(144, 24);
            this.txtEatDessert4.TabIndex = 31;
            this.txtEatDessert4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDish_MouseClick);
            this.txtEatDessert4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDish_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày";
            // 
            // cbDayInMonth
            // 
            this.cbDayInMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbDayInMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbDayInMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDayInMonth.FormattingEnabled = true;
            this.cbDayInMonth.IntegralHeight = false;
            this.cbDayInMonth.Location = new System.Drawing.Point(6, 33);
            this.cbDayInMonth.Name = "cbDayInMonth";
            this.cbDayInMonth.Size = new System.Drawing.Size(159, 26);
            this.cbDayInMonth.TabIndex = 1;
            this.cbDayInMonth.SelectedIndexChanged += new System.EventHandler(this.cbDayInMonth_SelectedIndexChanged);
            // 
            // cbEatDessert4
            // 
            this.cbEatDessert4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEatDessert4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEatDessert4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEatDessert4.FormattingEnabled = true;
            this.cbEatDessert4.Location = new System.Drawing.Point(721, 33);
            this.cbEatDessert4.Name = "cbEatDessert4";
            this.cbEatDessert4.Size = new System.Drawing.Size(159, 24);
            this.cbEatDessert4.TabIndex = 30;
            this.cbEatDessert4.SelectedValueChanged += new System.EventHandler(this.cbDish_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(214, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 18);
            this.label11.TabIndex = 22;
            this.label11.Text = "Ăn nhẹ 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(749, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "Ăn nhẹ 4";
            // 
            // txtEatDessert3
            // 
            this.txtEatDessert3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEatDessert3.Location = new System.Drawing.Point(541, 33);
            this.txtEatDessert3.Name = "txtEatDessert3";
            this.txtEatDessert3.Size = new System.Drawing.Size(144, 24);
            this.txtEatDessert3.TabIndex = 28;
            this.txtEatDessert3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDish_MouseClick);
            this.txtEatDessert3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDish_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(392, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 18);
            this.label10.TabIndex = 24;
            this.label10.Text = "Ăn nhẹ 2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(571, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 18);
            this.label9.TabIndex = 26;
            this.label9.Text = "Ăn nhẹ 3";
            // 
            // cbEatDessert3
            // 
            this.cbEatDessert3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbEatDessert3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEatDessert3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEatDessert3.FormattingEnabled = true;
            this.cbEatDessert3.Location = new System.Drawing.Point(541, 33);
            this.cbEatDessert3.Name = "cbEatDessert3";
            this.cbEatDessert3.Size = new System.Drawing.Size(159, 24);
            this.cbEatDessert3.TabIndex = 27;
            this.cbEatDessert3.SelectedValueChanged += new System.EventHandler(this.cbDish_SelectedIndexChanged);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.LargeChange = 50;
            this.hScrollBar1.Location = new System.Drawing.Point(3, 106);
            this.hScrollBar1.Maximum = 1200;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1214, 17);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // dgrMenu
            // 
            this.dgrMenu.AllowUserToAddRows = false;
            this.dgrMenu.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgrMenu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column13,
            this.Column14,
            this.Column15,
            this.SideMeal4,
            this.Column3});
            this.dgrMenu.ContextMenuStrip = this.contextMenuStrip1;
            this.dgrMenu.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgrMenu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgrMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrMenu.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgrMenu.EnableHeadersVisualStyles = false;
            this.dgrMenu.Location = new System.Drawing.Point(0, 0);
            this.dgrMenu.Name = "dgrMenu";
            this.dgrMenu.ReadOnly = true;
            this.dgrMenu.RowHeadersVisible = false;
            this.dgrMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrMenu.Size = new System.Drawing.Size(1220, 373);
            this.dgrMenu.TabIndex = 2;
            this.dgrMenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrMenu_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Date";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Ngày";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Thứ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 190;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "SideMeal1";
            this.Column13.HeaderText = "Ăn nhẹ 1";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column13.Width = 160;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "SideMeal2";
            this.Column14.HeaderText = "Ăn nhẹ 2";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column14.Width = 160;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "SideMeal3";
            this.Column15.HeaderText = "Ăn nhẹ 3";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column15.Width = 160;
            // 
            // SideMeal4
            // 
            this.SideMeal4.DataPropertyName = "SideMeal4";
            this.SideMeal4.HeaderText = "Ăn nhẹ 4";
            this.SideMeal4.Name = "SideMeal4";
            this.SideMeal4.ReadOnly = true;
            this.SideMeal4.Width = 160;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Ăn nhẹ 5";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgrMenu);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 550);
            this.panel1.TabIndex = 34;
            // 
            // FormMenuNhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1220, 550);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenuNhe";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenuNhe_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelSelect.ResumeLayout(false);
            this.panelSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrMenu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaThựcĐơnNàyToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnSaveMenu;
        private System.Windows.Forms.Button btnSaveDatabase;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.TextBox txtEatDessert5;
        private System.Windows.Forms.ComboBox cbEatDessert5;
        private System.Windows.Forms.TextBox txtEatDessert2;
        private System.Windows.Forms.ComboBox cbEatDessert2;
        private System.Windows.Forms.TextBox txtEatDessert1;
        private System.Windows.Forms.ComboBox cbEatDessert1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEatDessert4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbDayInMonth;
        private System.Windows.Forms.ComboBox cbEatDessert4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEatDessert3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbEatDessert3;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.DataGridView dgrMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn SideMeal4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
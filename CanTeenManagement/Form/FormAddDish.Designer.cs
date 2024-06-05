
namespace CanTeenManagement
{
    partial class FormAddDish
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbSpec = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuantitative = new System.Windows.Forms.TextBox();
            this.txtIngredientName = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.Label();
            this.cbIngredient = new System.Windows.Forms.ComboBox();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbIsPreOrderDish = new System.Windows.Forms.CheckBox();
            this.txtDishName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvQuantitative = new System.Windows.Forms.DataGridView();
            this.IngredientCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IngredientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantitative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaNguyênLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuantitative)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 49);
            this.panel1.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.DarkGreen;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(969, 49);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "THÊM MÓN ĂN";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 609F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(969, 358);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 352);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbSpec);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtQuantitative);
            this.groupBox1.Controls.Add(this.txtIngredientName);
            this.groupBox1.Controls.Add(this.txtUnit);
            this.groupBox1.Controls.Add(this.cbIngredient);
            this.groupBox1.Controls.Add(this.btnAddIngredient);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 236);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm thông nguyên liệu";
            // 
            // lbSpec
            // 
            this.lbSpec.AutoSize = true;
            this.lbSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpec.ForeColor = System.Drawing.Color.Black;
            this.lbSpec.Location = new System.Drawing.Point(12, 116);
            this.lbSpec.Name = "lbSpec";
            this.lbSpec.Size = new System.Drawing.Size(55, 20);
            this.lbSpec.TabIndex = 44;
            this.lbSpec.Text = "Spec:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(114, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 25);
            this.label6.TabIndex = 43;
            this.label6.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(108, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 25);
            this.label1.TabIndex = 42;
            this.label1.Text = "*";
            // 
            // txtQuantitative
            // 
            this.txtQuantitative.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantitative.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantitative.Location = new System.Drawing.Point(16, 195);
            this.txtQuantitative.Name = "txtQuantitative";
            this.txtQuantitative.Size = new System.Drawing.Size(135, 26);
            this.txtQuantitative.TabIndex = 16;
            this.txtQuantitative.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantitative_KeyDown);
            this.txtQuantitative.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantitative_KeyPress);
            // 
            // txtIngredientName
            // 
            this.txtIngredientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIngredientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngredientName.Location = new System.Drawing.Point(16, 69);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(332, 26);
            this.txtIngredientName.TabIndex = 14;
            this.txtIngredientName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtIngredientName_MouseClick);
            this.txtIngredientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIngredientName_KeyDown);
            // 
            // txtUnit
            // 
            this.txtUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnit.AutoSize = true;
            this.txtUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.ForeColor = System.Drawing.Color.Black;
            this.txtUnit.Location = new System.Drawing.Point(179, 198);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(59, 20);
            this.txtUnit.TabIndex = 13;
            this.txtUnit.Text = "Đơn vị";
            // 
            // cbIngredient
            // 
            this.cbIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIngredient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIngredient.FormattingEnabled = true;
            this.cbIngredient.IntegralHeight = false;
            this.cbIngredient.Location = new System.Drawing.Point(16, 69);
            this.cbIngredient.Name = "cbIngredient";
            this.cbIngredient.Size = new System.Drawing.Size(348, 26);
            this.cbIngredient.TabIndex = 15;
            this.cbIngredient.SelectedIndexChanged += new System.EventHandler(this.cbIngredient_SelectedIndexChanged);
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddIngredient.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddIngredient.FlatAppearance.BorderSize = 0;
            this.btnAddIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIngredient.ForeColor = System.Drawing.Color.White;
            this.btnAddIngredient.Image = global::CanTeenManagement.Properties.Resources.sign;
            this.btnAddIngredient.Location = new System.Drawing.Point(267, 192);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(97, 33);
            this.btnAddIngredient.TabIndex = 11;
            this.btnAddIngredient.Text = "   Thêm";
            this.btnAddIngredient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddIngredient.UseVisualStyleBackColor = false;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Định lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nguyên liệu";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.cbIsPreOrderDish);
            this.panel7.Controls.Add(this.txtDishName);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(381, 116);
            this.panel7.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên món ăn";
            // 
            // cbIsPreOrderDish
            // 
            this.cbIsPreOrderDish.AutoSize = true;
            this.cbIsPreOrderDish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsPreOrderDish.ForeColor = System.Drawing.Color.Red;
            this.cbIsPreOrderDish.Location = new System.Drawing.Point(19, 80);
            this.cbIsPreOrderDish.Name = "cbIsPreOrderDish";
            this.cbIsPreOrderDish.Size = new System.Drawing.Size(213, 20);
            this.cbIsPreOrderDish.TabIndex = 44;
            this.cbIsPreOrderDish.Text = "Là món có nguyên liệu đặt trước";
            this.cbIsPreOrderDish.UseVisualStyleBackColor = true;
            // 
            // txtDishName
            // 
            this.txtDishName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDishName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDishName.Location = new System.Drawing.Point(19, 42);
            this.txtDishName.Name = "txtDishName";
            this.txtDishName.Size = new System.Drawing.Size(345, 26);
            this.txtDishName.TabIndex = 2;
            this.txtDishName.TextChanged += new System.EventHandler(this.txtDishName_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(117, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 25);
            this.label7.TabIndex = 41;
            this.label7.Text = "*";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(390, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(576, 352);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(576, 301);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvQuantitative);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(576, 301);
            this.panel6.TabIndex = 0;
            // 
            // dgvQuantitative
            // 
            this.dgvQuantitative.AllowUserToAddRows = false;
            this.dgvQuantitative.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvQuantitative.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuantitative.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvQuantitative.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuantitative.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IngredientCode,
            this.IngredientName,
            this.Quantitative,
            this.Unit});
            this.dgvQuantitative.ContextMenuStrip = this.contextMenuStrip;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuantitative.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvQuantitative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuantitative.EnableHeadersVisualStyles = false;
            this.dgvQuantitative.Location = new System.Drawing.Point(0, 0);
            this.dgvQuantitative.Name = "dgvQuantitative";
            this.dgvQuantitative.ReadOnly = true;
            this.dgvQuantitative.RowHeadersVisible = false;
            this.dgvQuantitative.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuantitative.Size = new System.Drawing.Size(576, 301);
            this.dgvQuantitative.TabIndex = 0;
            this.dgvQuantitative.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuantitative_CellClick);
            this.dgvQuantitative.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuantitative_CellDoubleClick);
            // 
            // IngredientCode
            // 
            this.IngredientCode.HeaderText = "Mã Nguyên Liệu";
            this.IngredientCode.Name = "IngredientCode";
            this.IngredientCode.ReadOnly = true;
            // 
            // IngredientName
            // 
            this.IngredientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IngredientName.HeaderText = "Tên Nguyên Liệu";
            this.IngredientName.Name = "IngredientName";
            this.IngredientName.ReadOnly = true;
            // 
            // Quantitative
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Quantitative.DefaultCellStyle = dataGridViewCellStyle5;
            this.Quantitative.HeaderText = "Định Lượng";
            this.Quantitative.Name = "Quantitative";
            this.Quantitative.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Đơn Vị";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaNguyênLiệuToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(160, 26);
            // 
            // xóaNguyênLiệuToolStripMenuItem
            // 
            this.xóaNguyênLiệuToolStripMenuItem.Name = "xóaNguyênLiệuToolStripMenuItem";
            this.xóaNguyênLiệuToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.xóaNguyênLiệuToolStripMenuItem.Text = "Xóa nguyên liệu";
            this.xóaNguyênLiệuToolStripMenuItem.Click += new System.EventHandler(this.xóaNguyênLiệuToolStripMenuItem_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnImportExcel);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 301);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(576, 51);
            this.panel4.TabIndex = 0;
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportExcel.BackColor = System.Drawing.Color.DarkGreen;
            this.btnImportExcel.FlatAppearance.BorderSize = 0;
            this.btnImportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportExcel.Image = global::CanTeenManagement.Properties.Resources.excel;
            this.btnImportExcel.Location = new System.Drawing.Point(48, 7);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(185, 35);
            this.btnImportExcel.TabIndex = 27;
            this.btnImportExcel.Text = "   Nhập file excel";
            this.btnImportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportExcel.UseVisualStyleBackColor = false;
            this.btnImportExcel.Visible = false;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::CanTeenManagement.Properties.Resources.diskette;
            this.btnSave.Location = new System.Drawing.Point(455, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 35);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "   Lưu";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormAddDish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(969, 407);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "FormAddDish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MÓN ĂN";
            this.Load += new System.EventHandler(this.FormAddDish_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuantitative)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDishName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtUnit;
        private System.Windows.Forms.ComboBox cbIngredient;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvQuantitative;
        private System.Windows.Forms.TextBox txtIngredientName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem xóaNguyênLiệuToolStripMenuItem;
        private System.Windows.Forms.TextBox txtQuantitative;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbIsPreOrderDish;
        private System.Windows.Forms.Label lbSpec;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn IngredientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantitative;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.Panel panel7;
    }
}
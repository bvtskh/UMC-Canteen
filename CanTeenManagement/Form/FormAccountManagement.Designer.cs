namespace CanTeenManagement
{
    partial class FormAccountManagement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvAccountMangement = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtAccess = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAccess = new System.Windows.Forms.ComboBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountMangement)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 45);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(351, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Quản lý tài khoản";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1070, 10);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvAccountMangement);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 45);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1070, 282);
            this.panel4.TabIndex = 4;
            // 
            // dgvAccountMangement
            // 
            this.dgvAccountMangement.AllowUserToAddRows = false;
            this.dgvAccountMangement.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SandyBrown;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccountMangement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAccountMangement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountMangement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column5,
            this.Column3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccountMangement.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAccountMangement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccountMangement.EnableHeadersVisualStyles = false;
            this.dgvAccountMangement.Location = new System.Drawing.Point(10, 0);
            this.dgvAccountMangement.Name = "dgvAccountMangement";
            this.dgvAccountMangement.RowHeadersVisible = false;
            this.dgvAccountMangement.Size = new System.Drawing.Size(704, 282);
            this.dgvAccountMangement.TabIndex = 1;
            this.dgvAccountMangement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccountMangement_CellClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtDept);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.cbDepartment);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtFullName);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.txtAccess);
            this.panel3.Controls.Add(this.btnDel);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbAccess);
            this.panel3.Controls.Add(this.txtPass);
            this.panel3.Controls.Add(this.txtAcc);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(714, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 282);
            this.panel3.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = global::CanTeenManagement.Properties.Resources.plus;
            this.btnRefresh.Location = new System.Drawing.Point(314, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(37, 36);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtAccess
            // 
            this.txtAccess.Enabled = false;
            this.txtAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccess.Location = new System.Drawing.Point(119, 154);
            this.txtAccess.Name = "txtAccess";
            this.txtAccess.Size = new System.Drawing.Size(196, 24);
            this.txtAccess.TabIndex = 8;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Image = global::CanTeenManagement.Properties.Resources.icons8_cancel_24;
            this.btnDel.Location = new System.Drawing.Point(250, 239);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(81, 36);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "Xóa";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.Gold;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Image = global::CanTeenManagement.Properties.Resources.updated;
            this.btnUpdate.Location = new System.Drawing.Point(142, 239);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 36);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Quyền truy cập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tài khoản";
            // 
            // cbAccess
            // 
            this.cbAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccess.FormattingEnabled = true;
            this.cbAccess.Items.AddRange(new object[] {
            "Admin",
            "Member"});
            this.cbAccess.Location = new System.Drawing.Point(119, 154);
            this.cbAccess.Name = "cbAccess";
            this.cbAccess.Size = new System.Drawing.Size(212, 24);
            this.cbAccess.TabIndex = 4;
            this.cbAccess.SelectedIndexChanged += new System.EventHandler(this.cbAccess_SelectedIndexChanged);
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(119, 117);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(212, 22);
            this.txtPass.TabIndex = 3;
            // 
            // txtAcc
            // 
            this.txtAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc.Location = new System.Drawing.Point(119, 44);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(212, 22);
            this.txtAcc.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::CanTeenManagement.Properties.Resources.sign;
            this.btnAdd.Location = new System.Drawing.Point(11, 239);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 36);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Tạo mới";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 282);
            this.panel5.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Họ và tên";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(119, 81);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(212, 22);
            this.txtFullName.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Account";
            this.Column1.HeaderText = "Tài khoản";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Họ và tên";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PassWord";
            this.Column2.HeaderText = "Mật khẩu";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Bộ phận";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Type";
            this.Column3.HeaderText = "Quyền truy cập";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bộ phận";
            // 
            // cbDepartment
            // 
            this.cbDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Items.AddRange(new object[] {
            "GA",
            "PUR - LOG",
            "PI - IT",
            "PI - LCA"});
            this.cbDepartment.Location = new System.Drawing.Point(119, 193);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(212, 24);
            this.cbDepartment.TabIndex = 12;
            this.cbDepartment.SelectedIndexChanged += new System.EventHandler(this.cbDepartment_SelectedIndexChanged);
            // 
            // txtDept
            // 
            this.txtDept.Enabled = false;
            this.txtDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDept.Location = new System.Drawing.Point(119, 193);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(196, 24);
            this.txtDept.TabIndex = 14;
            // 
            // FormAccountManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 337);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormAccountManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAccountManagement";
            this.Load += new System.EventHandler(this.FormAccountManagement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountMangement)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvAccountMangement;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAccess;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtAccess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.TextBox txtDept;
    }
}
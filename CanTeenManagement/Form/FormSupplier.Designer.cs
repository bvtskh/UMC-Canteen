
namespace CanTeenManagement
{
    partial class FormSupplier
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
            this.btnAddSupplier = new System.Windows.Forms.Button();
            this.btnSearchSupplier = new System.Windows.Forms.Button();
            this.txtSearchSupplier = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.SupplierCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEditSupplier = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddSupplier);
            this.panel1.Controls.Add(this.btnSearchSupplier);
            this.panel1.Controls.Add(this.txtSearchSupplier);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 71);
            this.panel1.TabIndex = 2;
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSupplier.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddSupplier.FlatAppearance.BorderSize = 0;
            this.btnAddSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSupplier.ForeColor = System.Drawing.Color.White;
            this.btnAddSupplier.Image = global::CanTeenManagement.Properties.Resources.sign;
            this.btnAddSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSupplier.Location = new System.Drawing.Point(479, 23);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(137, 28);
            this.btnAddSupplier.TabIndex = 9;
            this.btnAddSupplier.Text = "   Thêm";
            this.btnAddSupplier.UseVisualStyleBackColor = false;
            this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
            // 
            // btnSearchSupplier
            // 
            this.btnSearchSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchSupplier.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearchSupplier.FlatAppearance.BorderSize = 0;
            this.btnSearchSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSearchSupplier.Image = global::CanTeenManagement.Properties.Resources.search;
            this.btnSearchSupplier.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearchSupplier.Location = new System.Drawing.Point(360, 22);
            this.btnSearchSupplier.Name = "btnSearchSupplier";
            this.btnSearchSupplier.Size = new System.Drawing.Size(114, 28);
            this.btnSearchSupplier.TabIndex = 8;
            this.btnSearchSupplier.Text = " Tìm kiếm";
            this.btnSearchSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchSupplier.UseVisualStyleBackColor = false;
            this.btnSearchSupplier.Click += new System.EventHandler(this.btnSearchSupplier_Click);
            // 
            // txtSearchSupplier
            // 
            this.txtSearchSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchSupplier.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchSupplier.Location = new System.Drawing.Point(151, 22);
            this.txtSearchSupplier.Name = "txtSearchSupplier";
            this.txtSearchSupplier.Size = new System.Drawing.Size(203, 26);
            this.txtSearchSupplier.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "NHÀ CUNG CẤP";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(628, 351);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvSupplier);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(628, 218);
            this.panel4.TabIndex = 5;
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.AllowUserToAddRows = false;
            this.dgvSupplier.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplier.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupplierCode,
            this.SupplierName});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSupplier.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplier.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSupplier.EnableHeadersVisualStyles = false;
            this.dgvSupplier.Location = new System.Drawing.Point(0, 0);
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.ReadOnly = true;
            this.dgvSupplier.RowHeadersVisible = false;
            this.dgvSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplier.Size = new System.Drawing.Size(628, 218);
            this.dgvSupplier.TabIndex = 5;
            // 
            // SupplierCode
            // 
            this.SupplierCode.DataPropertyName = "SupplierCode";
            this.SupplierCode.HeaderText = "Mã NCC";
            this.SupplierCode.Name = "SupplierCode";
            this.SupplierCode.ReadOnly = true;
            this.SupplierCode.Width = 200;
            // 
            // SupplierName
            // 
            this.SupplierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SupplierName.DataPropertyName = "SupplierName";
            this.SupplierName.HeaderText = "Tên NCC";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnEditSupplier);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 289);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(628, 62);
            this.panel3.TabIndex = 4;
            // 
            // btnEditSupplier
            // 
            this.btnEditSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEditSupplier.FlatAppearance.BorderSize = 0;
            this.btnEditSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditSupplier.ForeColor = System.Drawing.Color.White;
            this.btnEditSupplier.Image = global::CanTeenManagement.Properties.Resources.office_material;
            this.btnEditSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditSupplier.Location = new System.Drawing.Point(508, 15);
            this.btnEditSupplier.Name = "btnEditSupplier";
            this.btnEditSupplier.Size = new System.Drawing.Size(108, 35);
            this.btnEditSupplier.TabIndex = 22;
            this.btnEditSupplier.Text = "  Sửa";
            this.btnEditSupplier.UseVisualStyleBackColor = false;
            this.btnEditSupplier.Click += new System.EventHandler(this.btnEditSupplier_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::CanTeenManagement.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(360, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "   Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // FormSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(628, 351);
            this.Controls.Add(this.panel2);
            this.Name = "FormSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHÀ CUNG CẤP";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearchSupplier;
        private System.Windows.Forms.TextBox txtSearchSupplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddSupplier;
        private System.Windows.Forms.Button btnEditSupplier;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
    }
}
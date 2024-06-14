namespace CanTeenManagement
{
    partial class FormSelectSupplierClon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStripExportExcel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xuấtExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sắpXếpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chọnGiáRẻNhấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPriority = new System.Windows.Forms.Button();
            this.btnImportExcelUpdatePrice = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchContent = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelApprove = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtYear = new Sunny.UI.UITextBox();
            this.txtMonth = new Sunny.UI.UITextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvSupplierPrice = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.contextMenuStripExportExcel.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelApprove.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierPrice)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripExportExcel
            // 
            this.contextMenuStripExportExcel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xuấtExcelToolStripMenuItem,
            this.sắpXếpToolStripMenuItem,
            this.chọnGiáRẻNhấtToolStripMenuItem});
            this.contextMenuStripExportExcel.Name = "contextMenuStripExportExcel";
            this.contextMenuStripExportExcel.Size = new System.Drawing.Size(163, 70);
            // 
            // xuấtExcelToolStripMenuItem
            // 
            this.xuấtExcelToolStripMenuItem.Image = global::CanTeenManagement.Properties.Resources.excel;
            this.xuấtExcelToolStripMenuItem.Name = "xuấtExcelToolStripMenuItem";
            this.xuấtExcelToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.xuấtExcelToolStripMenuItem.Text = "Xuất excel";
            // 
            // sắpXếpToolStripMenuItem
            // 
            this.sắpXếpToolStripMenuItem.Image = global::CanTeenManagement.Properties.Resources.refresh;
            this.sắpXếpToolStripMenuItem.Name = "sắpXếpToolStripMenuItem";
            this.sắpXếpToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.sắpXếpToolStripMenuItem.Text = "Sắp xếp";
            // 
            // chọnGiáRẻNhấtToolStripMenuItem
            // 
            this.chọnGiáRẻNhấtToolStripMenuItem.Image = global::CanTeenManagement.Properties.Resources.doanh_thu;
            this.chọnGiáRẻNhấtToolStripMenuItem.Name = "chọnGiáRẻNhấtToolStripMenuItem";
            this.chọnGiáRẻNhấtToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.chọnGiáRẻNhấtToolStripMenuItem.Text = "Chọn giá rẻ nhất";
            // 
            // panelSearch
            // 
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.label3);
            this.panelSearch.Controls.Add(this.btnPriority);
            this.panelSearch.Controls.Add(this.btnImportExcelUpdatePrice);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtSearchContent);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 51);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(399, 192);
            this.panelSearch.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(126, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Nội dung tìm kiếm";
            // 
            // btnPriority
            // 
            this.btnPriority.BackColor = System.Drawing.Color.Maroon;
            this.btnPriority.FlatAppearance.BorderSize = 0;
            this.btnPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPriority.ForeColor = System.Drawing.Color.White;
            this.btnPriority.Image = global::CanTeenManagement.Properties.Resources.order2;
            this.btnPriority.Location = new System.Drawing.Point(111, 139);
            this.btnPriority.Name = "btnPriority";
            this.btnPriority.Size = new System.Drawing.Size(154, 31);
            this.btnPriority.TabIndex = 27;
            this.btnPriority.Text = "Ngày ưu tiên";
            this.btnPriority.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPriority.UseVisualStyleBackColor = false;
            this.btnPriority.Click += new System.EventHandler(this.btnPriority_Click);
            // 
            // btnImportExcelUpdatePrice
            // 
            this.btnImportExcelUpdatePrice.BackColor = System.Drawing.Color.LimeGreen;
            this.btnImportExcelUpdatePrice.FlatAppearance.BorderSize = 0;
            this.btnImportExcelUpdatePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExcelUpdatePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportExcelUpdatePrice.ForeColor = System.Drawing.Color.White;
            this.btnImportExcelUpdatePrice.Image = global::CanTeenManagement.Properties.Resources.refresh;
            this.btnImportExcelUpdatePrice.Location = new System.Drawing.Point(111, 102);
            this.btnImportExcelUpdatePrice.Name = "btnImportExcelUpdatePrice";
            this.btnImportExcelUpdatePrice.Size = new System.Drawing.Size(154, 31);
            this.btnImportExcelUpdatePrice.TabIndex = 27;
            this.btnImportExcelUpdatePrice.Text = "  Cập nhật giá";
            this.btnImportExcelUpdatePrice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportExcelUpdatePrice.UseVisualStyleBackColor = false;
            this.btnImportExcelUpdatePrice.Click += new System.EventHandler(this.btnImportExcelUpdatePrice_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::CanTeenManagement.Properties.Resources.search1;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(111, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(154, 32);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Thông tin báo giá";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearchIngredient_Click);
            // 
            // txtSearchContent
            // 
            this.txtSearchContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchContent.Location = new System.Drawing.Point(11, 36);
            this.txtSearchContent.Name = "txtSearchContent";
            this.txtSearchContent.Size = new System.Drawing.Size(375, 22);
            this.txtSearchContent.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panelApprove);
            this.panel1.Controls.Add(this.panelSearch);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 668);
            this.panel1.TabIndex = 36;
            // 
            // panelApprove
            // 
            this.panelApprove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelApprove.Controls.Add(this.label1);
            this.panelApprove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelApprove.Location = new System.Drawing.Point(0, 243);
            this.panelApprove.Name = "panelApprove";
            this.panelApprove.Size = new System.Drawing.Size(399, 425);
            this.panelApprove.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtYear);
            this.panel2.Controls.Add(this.txtMonth);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 51);
            this.panel2.TabIndex = 40;
            // 
            // txtYear
            // 
            this.txtYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtYear.Location = new System.Drawing.Point(191, 13);
            this.txtYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtYear.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtYear.Name = "txtYear";
            this.txtYear.Padding = new System.Windows.Forms.Padding(5);
            this.txtYear.RectColor = System.Drawing.Color.Silver;
            this.txtYear.ShowText = false;
            this.txtYear.Size = new System.Drawing.Size(81, 25);
            this.txtYear.TabIndex = 38;
            this.txtYear.Text = "0";
            this.txtYear.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtYear.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtYear.Watermark = "";
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            // 
            // txtMonth
            // 
            this.txtMonth.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMonth.Location = new System.Drawing.Point(327, 13);
            this.txtMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMonth.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Padding = new System.Windows.Forms.Padding(5);
            this.txtMonth.RectColor = System.Drawing.Color.Silver;
            this.txtMonth.ShowText = false;
            this.txtMonth.Size = new System.Drawing.Size(59, 25);
            this.txtMonth.TabIndex = 39;
            this.txtMonth.Text = "0";
            this.txtMonth.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtMonth.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtMonth.Watermark = "";
            this.txtMonth.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "Thời gian áp dụng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(145, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Năm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(271, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 37;
            this.label6.Text = "Tháng";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvSupplierPrice);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(404, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(958, 668);
            this.panel3.TabIndex = 37;
            // 
            // dgvSupplierPrice
            // 
            this.dgvSupplierPrice.AllowUserToAddRows = false;
            this.dgvSupplierPrice.AllowUserToDeleteRows = false;
            this.dgvSupplierPrice.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplierPrice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSupplierPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSupplierPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSupplierPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupplierPrice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSupplierPrice.EnableHeadersVisualStyles = false;
            this.dgvSupplierPrice.Location = new System.Drawing.Point(0, 0);
            this.dgvSupplierPrice.Name = "dgvSupplierPrice";
            this.dgvSupplierPrice.Size = new System.Drawing.Size(958, 618);
            this.dgvSupplierPrice.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 618);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(958, 50);
            this.panel4.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::CanTeenManagement.Properties.Resources.diskette;
            this.btnSave.Location = new System.Drawing.Point(840, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 34);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "   Lưu";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormSelectSupplierClon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 678);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FormSelectSupplierClon";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "FormSelectSupplierClon";
            this.Load += new System.EventHandler(this.FormSelectSupplierClon_Load);
            this.contextMenuStripExportExcel.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelApprove.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierPrice)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripExportExcel;
        private System.Windows.Forms.ToolStripMenuItem xuấtExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sắpXếpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chọnGiáRẻNhấtToolStripMenuItem;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImportExcelUpdatePrice;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelApprove;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UITextBox txtYear;
        private Sunny.UI.UITextBox txtMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvSupplierPrice;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPriority;
    }
}
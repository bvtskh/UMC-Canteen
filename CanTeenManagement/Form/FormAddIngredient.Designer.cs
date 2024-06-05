
namespace CanTeenManagement
{
    partial class FormAddIngredient
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.Label();
            this.panelIngredient = new System.Windows.Forms.Panel();
            this.txtNumberSafeStock = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIngredientName = new System.Windows.Forms.TextBox();
            this.checkBoxSafeStock = new System.Windows.Forms.CheckBox();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnSaveIngredient = new System.Windows.Forms.Button();
            this.txtIngredientUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIngredientSpec = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPrice = new System.Windows.Forms.Panel();
            this.txtIngredientPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateIngredientApproval = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panelIngredient.SuspendLayout();
            this.panelPrice.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 37);
            this.panel1.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.ForestGreen;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(647, 37);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "THÊM NGUYÊN LIỆU";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelIngredient
            // 
            this.panelIngredient.Controls.Add(this.txtNumberSafeStock);
            this.panelIngredient.Controls.Add(this.label11);
            this.panelIngredient.Controls.Add(this.label10);
            this.panelIngredient.Controls.Add(this.label9);
            this.panelIngredient.Controls.Add(this.label5);
            this.panelIngredient.Controls.Add(this.txtIngredientName);
            this.panelIngredient.Controls.Add(this.checkBoxSafeStock);
            this.panelIngredient.Controls.Add(this.btnImportExcel);
            this.panelIngredient.Controls.Add(this.btnSaveIngredient);
            this.panelIngredient.Controls.Add(this.txtIngredientUnit);
            this.panelIngredient.Controls.Add(this.label3);
            this.panelIngredient.Controls.Add(this.txtIngredientSpec);
            this.panelIngredient.Controls.Add(this.label2);
            this.panelIngredient.Controls.Add(this.label1);
            this.panelIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIngredient.Location = new System.Drawing.Point(0, 37);
            this.panelIngredient.Name = "panelIngredient";
            this.panelIngredient.Size = new System.Drawing.Size(647, 216);
            this.panelIngredient.TabIndex = 2;
            // 
            // txtNumberSafeStock
            // 
            this.txtNumberSafeStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumberSafeStock.Location = new System.Drawing.Point(190, 168);
            this.txtNumberSafeStock.Name = "txtNumberSafeStock";
            this.txtNumberSafeStock.Size = new System.Drawing.Size(223, 26);
            this.txtNumberSafeStock.TabIndex = 40;
            this.txtNumberSafeStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumberSaveStock_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(150, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 25);
            this.label11.TabIndex = 37;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(73, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 25);
            this.label10.TabIndex = 36;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(426, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 16);
            this.label9.TabIndex = 35;
            this.label9.Text = "VD: (Kg, Chai, Hộp v.v...)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(419, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "VD: (4-6 miếng, chai 500 gam v.v...)";
            // 
            // txtIngredientName
            // 
            this.txtIngredientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngredientName.Location = new System.Drawing.Point(190, 19);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(441, 26);
            this.txtIngredientName.TabIndex = 18;
            this.txtIngredientName.TextChanged += new System.EventHandler(this.txtIngredientName_TextChanged);
            // 
            // checkBoxSafeStock
            // 
            this.checkBoxSafeStock.AutoSize = true;
            this.checkBoxSafeStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSafeStock.Location = new System.Drawing.Point(19, 174);
            this.checkBoxSafeStock.Name = "checkBoxSafeStock";
            this.checkBoxSafeStock.Size = new System.Drawing.Size(158, 24);
            this.checkBoxSafeStock.TabIndex = 32;
            this.checkBoxSafeStock.Text = "Tồn kho an toàn";
            this.checkBoxSafeStock.UseVisualStyleBackColor = true;
            this.checkBoxSafeStock.CheckedChanged += new System.EventHandler(this.checkBoxSafeStock_CheckedChanged);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.BackColor = System.Drawing.Color.DarkGreen;
            this.btnImportExcel.FlatAppearance.BorderSize = 0;
            this.btnImportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportExcel.Image = global::CanTeenManagement.Properties.Resources.excel;
            this.btnImportExcel.Location = new System.Drawing.Point(417, 229);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(185, 35);
            this.btnImportExcel.TabIndex = 25;
            this.btnImportExcel.Text = "   Nhập file excel";
            this.btnImportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportExcel.UseVisualStyleBackColor = false;
            this.btnImportExcel.Visible = false;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnSaveIngredient
            // 
            this.btnSaveIngredient.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSaveIngredient.FlatAppearance.BorderSize = 0;
            this.btnSaveIngredient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveIngredient.ForeColor = System.Drawing.Color.White;
            this.btnSaveIngredient.Image = global::CanTeenManagement.Properties.Resources.diskette;
            this.btnSaveIngredient.Location = new System.Drawing.Point(456, 164);
            this.btnSaveIngredient.Name = "btnSaveIngredient";
            this.btnSaveIngredient.Size = new System.Drawing.Size(118, 35);
            this.btnSaveIngredient.TabIndex = 24;
            this.btnSaveIngredient.Text = "   Lưu";
            this.btnSaveIngredient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveIngredient.UseVisualStyleBackColor = false;
            this.btnSaveIngredient.Click += new System.EventHandler(this.btnSaveIngredient_Click);
            // 
            // txtIngredientUnit
            // 
            this.txtIngredientUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngredientUnit.Location = new System.Drawing.Point(190, 120);
            this.txtIngredientUnit.Name = "txtIngredientUnit";
            this.txtIngredientUnit.Size = new System.Drawing.Size(223, 26);
            this.txtIngredientUnit.TabIndex = 21;
            this.txtIngredientUnit.TextChanged += new System.EventHandler(this.txtIngredientUnit_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Đơn vị";
            // 
            // txtIngredientSpec
            // 
            this.txtIngredientSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngredientSpec.Location = new System.Drawing.Point(190, 71);
            this.txtIngredientSpec.Name = "txtIngredientSpec";
            this.txtIngredientSpec.Size = new System.Drawing.Size(223, 26);
            this.txtIngredientSpec.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Thông số";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tên nguyên liệu";
            // 
            // panelPrice
            // 
            this.panelPrice.Controls.Add(this.txtIngredientPrice);
            this.panelPrice.Controls.Add(this.label6);
            this.panelPrice.Controls.Add(this.label7);
            this.panelPrice.Controls.Add(this.label4);
            this.panelPrice.Controls.Add(this.label8);
            this.panelPrice.Controls.Add(this.dateIngredientApproval);
            this.panelPrice.Location = new System.Drawing.Point(19, 213);
            this.panelPrice.Name = "panelPrice";
            this.panelPrice.Size = new System.Drawing.Size(532, 164);
            this.panelPrice.TabIndex = 35;
            // 
            // txtIngredientPrice
            // 
            this.txtIngredientPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngredientPrice.Location = new System.Drawing.Point(188, 17);
            this.txtIngredientPrice.Name = "txtIngredientPrice";
            this.txtIngredientPrice.Size = new System.Drawing.Size(286, 26);
            this.txtIngredientPrice.TabIndex = 27;
            this.txtIngredientPrice.TextChanged += new System.EventHandler(this.txtIngredientPrice_TextChanged);
            this.txtIngredientPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIngredientPrice_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Giá";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(480, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "VND";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nhà cung cấp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "Ngày áp dụng";
            // 
            // dateIngredientApproval
            // 
            this.dateIngredientApproval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateIngredientApproval.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateIngredientApproval.Location = new System.Drawing.Point(188, 120);
            this.dateIngredientApproval.Name = "dateIngredientApproval";
            this.dateIngredientApproval.Size = new System.Drawing.Size(338, 26);
            this.dateIngredientApproval.TabIndex = 29;
            // 
            // FormAddIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(647, 253);
            this.Controls.Add(this.panelIngredient);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddIngredient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nguyên liệu";
            this.Load += new System.EventHandler(this.FormAddIngredient_Load);
            this.panel1.ResumeLayout(false);
            this.panelIngredient.ResumeLayout(false);
            this.panelIngredient.PerformLayout();
            this.panelPrice.ResumeLayout(false);
            this.panelPrice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Panel panelIngredient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateIngredientApproval;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnSaveIngredient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIngredientUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIngredientSpec;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxSafeStock;
        private System.Windows.Forms.TextBox txtIngredientName;
        private System.Windows.Forms.Panel panelPrice;
        private System.Windows.Forms.TextBox txtIngredientPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumberSafeStock;
    }
}
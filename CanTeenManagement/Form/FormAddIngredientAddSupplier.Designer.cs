
namespace CanTeenManagement
{
    partial class FormAddIngredientAddSupplier
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIngredientName = new System.Windows.Forms.Label();
            this.cbIngredientSupplier = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIngredientPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dateIngredientApproval = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 37);
            this.panel1.TabIndex = 2;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Blue;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(0, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(491, 37);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "THÊM NHÀ CUNG CẤP";
            this.txtTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tên nguyên liệu:";
            // 
            // txtIngredientName
            // 
            this.txtIngredientName.AutoSize = true;
            this.txtIngredientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngredientName.Location = new System.Drawing.Point(188, 57);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(135, 20);
            this.txtIngredientName.TabIndex = 18;
            this.txtIngredientName.Text = "Tên nguyên liệu";
            // 
            // cbIngredientSupplier
            // 
            this.cbIngredientSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIngredientSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIngredientSupplier.FormattingEnabled = true;
            this.cbIngredientSupplier.Location = new System.Drawing.Point(192, 108);
            this.cbIngredientSupplier.Name = "cbIngredientSupplier";
            this.cbIngredientSupplier.Size = new System.Drawing.Size(275, 28);
            this.cbIngredientSupplier.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Nhà cung cấp:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(421, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "VND";
            // 
            // txtIngredientPrice
            // 
            this.txtIngredientPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngredientPrice.Location = new System.Drawing.Point(192, 159);
            this.txtIngredientPrice.Name = "txtIngredientPrice";
            this.txtIngredientPrice.Size = new System.Drawing.Size(221, 26);
            this.txtIngredientPrice.TabIndex = 35;
            this.txtIngredientPrice.TextChanged += new System.EventHandler(this.txtIngredientPrice_TextChanged);
            this.txtIngredientPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIngredientPrice_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(140, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Giá:";
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
            this.btnSave.Location = new System.Drawing.Point(192, 261);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 35);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "   Lưu";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(58, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 39;
            this.label8.Text = "Ngày áp dụng:";
            // 
            // dateIngredientApproval
            // 
            this.dateIngredientApproval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateIngredientApproval.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateIngredientApproval.Location = new System.Drawing.Point(193, 210);
            this.dateIngredientApproval.Name = "dateIngredientApproval";
            this.dateIngredientApproval.Size = new System.Drawing.Size(275, 26);
            this.dateIngredientApproval.TabIndex = 38;
            // 
            // FormAddIngredientAddSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(491, 308);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateIngredientApproval);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIngredientPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbIngredientSupplier);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIngredientName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddIngredientAddSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm nhà cung cấp";
            this.Load += new System.EventHandler(this.FormAddIngredientAddSupplier_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtIngredientName;
        private System.Windows.Forms.ComboBox cbIngredientSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIngredientPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateIngredientApproval;
    }
}
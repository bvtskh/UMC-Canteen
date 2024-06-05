namespace CanTeenManagement
{
    partial class FormChangePassword
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
            this.txtOldmk = new System.Windows.Forms.TextBox();
            this.txtNewmk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbNote = new System.Windows.Forms.Label();
            this.panelNote = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOldmk
            // 
            this.txtOldmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldmk.Location = new System.Drawing.Point(111, 56);
            this.txtOldmk.Name = "txtOldmk";
            this.txtOldmk.Size = new System.Drawing.Size(174, 26);
            this.txtOldmk.TabIndex = 0;
            // 
            // txtNewmk
            // 
            this.txtNewmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewmk.Location = new System.Drawing.Point(111, 94);
            this.txtNewmk.Name = "txtNewmk";
            this.txtNewmk.Size = new System.Drawing.Size(174, 26);
            this.txtNewmk.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu mới";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(111, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Location = new System.Drawing.Point(210, 138);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 30);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(133, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Đổi mật khẩu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 42);
            this.panel1.TabIndex = 6;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(36, 1);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(0, 16);
            this.lbNote.TabIndex = 7;
            // 
            // panelNote
            // 
            this.panelNote.Controls.Add(this.lbNote);
            this.panelNote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNote.Location = new System.Drawing.Point(0, 185);
            this.panelNote.Name = "panelNote";
            this.panelNote.Size = new System.Drawing.Size(377, 26);
            this.panelNote.TabIndex = 8;
            // 
            // FormChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(377, 211);
            this.Controls.Add(this.panelNote);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNewmk);
            this.Controls.Add(this.txtOldmk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.FormChangePassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelNote.ResumeLayout(false);
            this.panelNote.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldmk;
        private System.Windows.Forms.TextBox txtNewmk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Panel panelNote;
    }
}
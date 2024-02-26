namespace QLTTB_TDH
{
    partial class fLogin
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
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_Dang_nhap = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txb_Mat_khau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txb_Ten_dang_nhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoat.Location = new System.Drawing.Point(513, 213);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(127, 50);
            this.btn_Thoat.TabIndex = 16;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_Dang_nhap
            // 
            this.btn_Dang_nhap.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Dang_nhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dang_nhap.Location = new System.Drawing.Point(363, 213);
            this.btn_Dang_nhap.Name = "btn_Dang_nhap";
            this.btn_Dang_nhap.Size = new System.Drawing.Size(127, 50);
            this.btn_Dang_nhap.TabIndex = 15;
            this.btn_Dang_nhap.Text = "Đăng nhập";
            this.btn_Dang_nhap.UseVisualStyleBackColor = true;
            this.btn_Dang_nhap.Click += new System.EventHandler(this.btn_Dang_nhap_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txb_Mat_khau);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(11, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 72);
            this.panel2.TabIndex = 14;
            // 
            // txb_Mat_khau
            // 
            this.txb_Mat_khau.Location = new System.Drawing.Point(264, 29);
            this.txb_Mat_khau.Name = "txb_Mat_khau";
            this.txb_Mat_khau.Size = new System.Drawing.Size(354, 22);
            this.txb_Mat_khau.TabIndex = 1;
            this.txb_Mat_khau.Text = "3623";
            this.txb_Mat_khau.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txb_Ten_dang_nhap);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 72);
            this.panel1.TabIndex = 13;
            // 
            // txb_Ten_dang_nhap
            // 
            this.txb_Ten_dang_nhap.Location = new System.Drawing.Point(264, 29);
            this.txb_Ten_dang_nhap.Name = "txb_Ten_dang_nhap";
            this.txb_Ten_dang_nhap.Size = new System.Drawing.Size(354, 22);
            this.txb_Ten_dang_nhap.TabIndex = 1;
            this.txb_Ten_dang_nhap.Text = "admin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // fLogin
            // 
            this.AcceptButton = this.btn_Dang_nhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Thoat;
            this.ClientSize = new System.Drawing.Size(664, 278);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Dang_nhap);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_Dang_nhap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txb_Mat_khau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txb_Ten_dang_nhap;
        private System.Windows.Forms.Label label1;
    }
}
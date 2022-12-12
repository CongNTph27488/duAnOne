namespace _3.pl
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbLoaiSp = new System.Windows.Forms.Label();
            this.lbChucVu = new System.Windows.Forms.Label();
            this.lbNhanVien = new System.Windows.Forms.Label();
            this.lbBanHang = new System.Windows.Forms.Label();
            this.qlSp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbLoaiSp
            // 
            this.lbLoaiSp.AutoSize = true;
            this.lbLoaiSp.Location = new System.Drawing.Point(23, 36);
            this.lbLoaiSp.Name = "lbLoaiSp";
            this.lbLoaiSp.Size = new System.Drawing.Size(67, 20);
            this.lbLoaiSp.TabIndex = 0;
            this.lbLoaiSp.Text = "qlLoaiSp";
            this.lbLoaiSp.Click += new System.EventHandler(this.lbLoaiSp_Click);
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.Location = new System.Drawing.Point(20, 114);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(71, 20);
            this.lbChucVu.TabIndex = 1;
            this.lbChucVu.Text = "qlChucVu";
            this.lbChucVu.Click += new System.EventHandler(this.lbChucVu_Click);
            // 
            // lbNhanVien
            // 
            this.lbNhanVien.AutoSize = true;
            this.lbNhanVien.Location = new System.Drawing.Point(20, 156);
            this.lbNhanVien.Name = "lbNhanVien";
            this.lbNhanVien.Size = new System.Drawing.Size(86, 20);
            this.lbNhanVien.TabIndex = 2;
            this.lbNhanVien.Text = "qlNhanVien";
            this.lbNhanVien.Click += new System.EventHandler(this.lbNhanVien_Click);
            // 
            // lbBanHang
            // 
            this.lbBanHang.AutoSize = true;
            this.lbBanHang.Location = new System.Drawing.Point(20, 196);
            this.lbBanHang.Name = "lbBanHang";
            this.lbBanHang.Size = new System.Drawing.Size(70, 20);
            this.lbBanHang.TabIndex = 3;
            this.lbBanHang.Text = "banHang";
            this.lbBanHang.Click += new System.EventHandler(this.lbBanHang_Click);
            // 
            // qlSp
            // 
            this.qlSp.AutoSize = true;
            this.qlSp.Location = new System.Drawing.Point(20, 74);
            this.qlSp.Name = "qlSp";
            this.qlSp.Size = new System.Drawing.Size(39, 20);
            this.qlSp.TabIndex = 4;
            this.qlSp.Text = "qlSp";
            this.qlSp.Click += new System.EventHandler(this.qlSp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 381);
            this.Controls.Add(this.qlSp);
            this.Controls.Add(this.lbBanHang);
            this.Controls.Add(this.lbNhanVien);
            this.Controls.Add(this.lbChucVu);
            this.Controls.Add(this.lbLoaiSp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLoaiSp;
        private System.Windows.Forms.Label lbChucVu;
        private System.Windows.Forms.Label lbNhanVien;
        private System.Windows.Forms.Label lbBanHang;
        private System.Windows.Forms.Label qlSp;
    }
}

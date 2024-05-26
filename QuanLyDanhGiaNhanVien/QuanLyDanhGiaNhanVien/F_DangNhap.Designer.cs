namespace QuanLyDanhGiaNhanVien {
	partial class F_DangNhap {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_DangNhap));
            this.label1 = new System.Windows.Forms.Label();
            this.tbTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMatKhau = new System.Windows.Forms.TextBox();
            this.btDangNhap = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btShow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản";
            // 
            // tbTaiKhoan
            // 
            this.tbTaiKhoan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTaiKhoan.Location = new System.Drawing.Point(304, 172);
            this.tbTaiKhoan.Name = "tbTaiKhoan";
            this.tbTaiKhoan.Size = new System.Drawing.Size(295, 30);
            this.tbTaiKhoan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // tbMatKhau
            // 
            this.tbMatKhau.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatKhau.Location = new System.Drawing.Point(304, 219);
            this.tbMatKhau.Name = "tbMatKhau";
            this.tbMatKhau.Size = new System.Drawing.Size(295, 30);
            this.tbMatKhau.TabIndex = 3;
            this.tbMatKhau.UseSystemPasswordChar = true;
            // 
            // btDangNhap
            // 
            this.btDangNhap.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangNhap.Location = new System.Drawing.Point(304, 300);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(137, 36);
            this.btDangNhap.TabIndex = 4;
            this.btDangNhap.Text = "Đăng nhập";
            this.btDangNhap.UseVisualStyleBackColor = true;
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // btThoat
            // 
            this.btThoat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Location = new System.Drawing.Point(481, 300);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(118, 36);
            this.btThoat.TabIndex = 5;
            this.btThoat.Text = "Trở về";
            this.btThoat.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Segoe Print", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(161, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(509, 130);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quản lý Đánh giá cán bộ\r\n  và quy trình điều trị";
            // 
            // btShow
            // 
            this.btShow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btShow.Location = new System.Drawing.Point(632, 216);
            this.btShow.Name = "btShow";
            this.btShow.Size = new System.Drawing.Size(87, 36);
            this.btShow.TabIndex = 7;
            this.btShow.Text = "Hiện";
            this.btShow.UseVisualStyleBackColor = true;
            this.btShow.Click += new System.EventHandler(this.btShow_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BackgroundImage = global::QuanLyDanhGiaNhanVien.Properties.Resources.hinh_nen1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btShow);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btThoat);
            this.panel1.Controls.Add(this.btDangNhap);
            this.panel1.Controls.Add(this.tbMatKhau);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbTaiKhoan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-4, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 376);
            this.panel1.TabIndex = 1;
            // 
            // F_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 371);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMatKhau;
        private System.Windows.Forms.Button btDangNhap;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btShow;
        private System.Windows.Forms.Panel panel1;
    }
}
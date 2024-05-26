namespace QuanLyDanhGiaNhanVien
{
    partial class FChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FChinh));
            this.pnTong = new System.Windows.Forms.Panel();
            this.pnBody = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TrangChuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.qLThongTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLyChucVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLyNhanVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qLyBenhNhanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qlXuatHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tổngQuanCôngTácĐiềuTrịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnTong.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTong
            // 
            this.pnTong.Controls.Add(this.pnBody);
            this.pnTong.Controls.Add(this.menuStrip1);
            this.pnTong.Location = new System.Drawing.Point(0, 0);
            this.pnTong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTong.Name = "pnTong";
            this.pnTong.Size = new System.Drawing.Size(1546, 776);
            this.pnTong.TabIndex = 0;
            // 
            // pnBody
            // 
            this.pnBody.Location = new System.Drawing.Point(3, 34);
            this.pnBody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnBody.Name = "pnBody";
            this.pnBody.Size = new System.Drawing.Size(1541, 740);
            this.pnBody.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrangChuToolStripMenuItem1,
            this.qLThongTinToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.thoátToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1546, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TrangChuToolStripMenuItem1
            // 
            this.TrangChuToolStripMenuItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.TrangChuToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TrangChuToolStripMenuItem1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrangChuToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("TrangChuToolStripMenuItem1.Image")));
            this.TrangChuToolStripMenuItem1.Name = "TrangChuToolStripMenuItem1";
            this.TrangChuToolStripMenuItem1.Size = new System.Drawing.Size(140, 28);
            this.TrangChuToolStripMenuItem1.Text = "Trang chủ";
            this.TrangChuToolStripMenuItem1.Click += new System.EventHandler(this.TrangChuToolStripMenuItem1_Click);
            // 
            // qLThongTinToolStripMenuItem
            // 
            this.qLThongTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qLyChucVuToolStripMenuItem,
            this.qLyNhanVienToolStripMenuItem,
            this.qLyBenhNhanToolStripMenuItem,
            this.qlXuatHangToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.tổngQuanCôngTácĐiềuTrịToolStripMenuItem,
            this.settingToolStripMenuItem});
            this.qLThongTinToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qLThongTinToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("qLThongTinToolStripMenuItem.Image")));
            this.qLThongTinToolStripMenuItem.Name = "qLThongTinToolStripMenuItem";
            this.qLThongTinToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.qLThongTinToolStripMenuItem.Text = "Quản lý Tài nguyên";
            this.qLThongTinToolStripMenuItem.Click += new System.EventHandler(this.qLThongTinToolStripMenuItem_Click);
            // 
            // qLyChucVuToolStripMenuItem
            // 
            this.qLyChucVuToolStripMenuItem.Image = global::QuanLyDanhGiaNhanVien.Properties.Resources.phân_công;
            this.qLyChucVuToolStripMenuItem.Name = "qLyChucVuToolStripMenuItem";
            this.qLyChucVuToolStripMenuItem.Size = new System.Drawing.Size(359, 28);
            this.qLyChucVuToolStripMenuItem.Text = "Quản lý Chức vụ";
            this.qLyChucVuToolStripMenuItem.Click += new System.EventHandler(this.qLyChucVuToolStripMenuItem_Click);
            // 
            // qLyNhanVienToolStripMenuItem
            // 
            this.qLyNhanVienToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("qLyNhanVienToolStripMenuItem.Image")));
            this.qLyNhanVienToolStripMenuItem.Name = "qLyNhanVienToolStripMenuItem";
            this.qLyNhanVienToolStripMenuItem.Size = new System.Drawing.Size(359, 28);
            this.qLyNhanVienToolStripMenuItem.Text = "Quản lý Nhân viên";
            this.qLyNhanVienToolStripMenuItem.Click += new System.EventHandler(this.qLyNhanVienToolStripMenuItem_Click);
            // 
            // qLyBenhNhanToolStripMenuItem
            // 
            this.qLyBenhNhanToolStripMenuItem.Image = global::QuanLyDanhGiaNhanVien.Properties.Resources.hoạt_động;
            this.qLyBenhNhanToolStripMenuItem.Name = "qLyBenhNhanToolStripMenuItem";
            this.qLyBenhNhanToolStripMenuItem.Size = new System.Drawing.Size(359, 28);
            this.qLyBenhNhanToolStripMenuItem.Text = "Quản lý Bệnh nhân";
            this.qLyBenhNhanToolStripMenuItem.Click += new System.EventHandler(this.qLyBenhNhanToolStripMenuItem_Click);
            // 
            // qlXuatHangToolStripMenuItem
            // 
            this.qlXuatHangToolStripMenuItem.Image = global::QuanLyDanhGiaNhanVien.Properties.Resources.sach;
            this.qlXuatHangToolStripMenuItem.Name = "qlXuatHangToolStripMenuItem";
            this.qlXuatHangToolStripMenuItem.Size = new System.Drawing.Size(359, 28);
            this.qlXuatHangToolStripMenuItem.Text = "Quản lý Quy định sao";
            this.qlXuatHangToolStripMenuItem.Click += new System.EventHandler(this.qlXuatHangToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.Image = global::QuanLyDanhGiaNhanVien.Properties.Resources.thưởng;
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(359, 28);
            this.quảnLýToolStripMenuItem.Text = "Quản lý Đánh giá";
            // 
            // tổngQuanCôngTácĐiềuTrịToolStripMenuItem
            // 
            this.tổngQuanCôngTácĐiềuTrịToolStripMenuItem.Image = global::QuanLyDanhGiaNhanVien.Properties.Resources.menu;
            this.tổngQuanCôngTácĐiềuTrịToolStripMenuItem.Name = "tổngQuanCôngTácĐiềuTrịToolStripMenuItem";
            this.tổngQuanCôngTácĐiềuTrịToolStripMenuItem.Size = new System.Drawing.Size(359, 28);
            this.tổngQuanCôngTácĐiềuTrịToolStripMenuItem.Text = "Tổng quan Công tác điều trị";
            this.tổngQuanCôngTácĐiềuTrịToolStripMenuItem.Click += new System.EventHandler(this.tổngQuanCôngTácĐiềuTrịToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Image = global::QuanLyDanhGiaNhanVien.Properties.Resources.setting;
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(359, 28);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.loginToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem1,
            this.logoutToolStripMenuItem});
            this.loginToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loginToolStripMenuItem.Image")));
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(146, 28);
            this.loginToolStripMenuItem.Text = "Đăng nhập";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // accountToolStripMenuItem1
            // 
            this.accountToolStripMenuItem1.Image = global::QuanLyDanhGiaNhanVien.Properties.Resources.account;
            this.accountToolStripMenuItem1.Name = "accountToolStripMenuItem1";
            this.accountToolStripMenuItem1.Size = new System.Drawing.Size(278, 28);
            this.accountToolStripMenuItem1.Text = "Thông tin tài khoản";
            this.accountToolStripMenuItem1.Click += new System.EventHandler(this.accountToolStripMenuItem1_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.logoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logoutToolStripMenuItem.Image")));
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(278, 28);
            this.logoutToolStripMenuItem.Text = "Đăng xuất";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem1
            // 
            this.thoátToolStripMenuItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.thoátToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.thoátToolStripMenuItem1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoátToolStripMenuItem1.ForeColor = System.Drawing.Color.Red;
            this.thoátToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("thoátToolStripMenuItem1.Image")));
            this.thoátToolStripMenuItem1.Name = "thoátToolStripMenuItem1";
            this.thoátToolStripMenuItem1.Size = new System.Drawing.Size(99, 28);
            this.thoátToolStripMenuItem1.Text = "Thoát";
            this.thoátToolStripMenuItem1.Click += new System.EventHandler(this.thoátToolStripMenuItem1_Click);
            // 
            // FChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1549, 779);
            this.Controls.Add(this.pnTong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đánh giá cán bộ và quy trình điều trị";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FChinh_FormClosing);
            this.pnTong.ResumeLayout(false);
            this.pnTong.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTong;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrangChuToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem qLThongTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLyNhanVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLyChucVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qLyBenhNhanToolStripMenuItem;
        private System.Windows.Forms.Panel pnBody;
        private System.Windows.Forms.ToolStripMenuItem qlXuatHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tổngQuanCôngTácĐiềuTrịToolStripMenuItem;
    }
}


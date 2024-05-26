namespace QuanLyDanhGiaNhanVien
{
    partial class F_QLQuyDinhSao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_QLQuyDinhSao));
            this.dgvQuyDinh = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbMa = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbTieuDe = new System.Windows.Forms.TextBox();
            this.btThem = new System.Windows.Forms.Button();
            this.btCapNhat = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGhiChu = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTuKhoa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyDinh)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQuyDinh
            // 
            this.dgvQuyDinh.AllowUserToAddRows = false;
            this.dgvQuyDinh.AllowUserToDeleteRows = false;
            this.dgvQuyDinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuyDinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvQuyDinh.Location = new System.Drawing.Point(12, 321);
            this.dgvQuyDinh.Name = "dgvQuyDinh";
            this.dgvQuyDinh.ReadOnly = true;
            this.dgvQuyDinh.RowHeadersWidth = 51;
            this.dgvQuyDinh.RowTemplate.Height = 24;
            this.dgvQuyDinh.Size = new System.Drawing.Size(1499, 404);
            this.dgvQuyDinh.TabIndex = 60;
            this.dgvQuyDinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuyDinh_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "STT";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mã quy định";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tiêu đề";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Chi tiết";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 400;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1521, 60);
            this.panel1.TabIndex = 44;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(514, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quản lý Quy định Chấm sao";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(76, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 22);
            this.label15.TabIndex = 64;
            this.label15.Text = "Mã";
            // 
            // tbMa
            // 
            this.tbMa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMa.Location = new System.Drawing.Point(178, 81);
            this.tbMa.Name = "tbMa";
            this.tbMa.ReadOnly = true;
            this.tbMa.Size = new System.Drawing.Size(304, 30);
            this.tbMa.TabIndex = 63;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(76, 120);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 22);
            this.label20.TabIndex = 62;
            this.label20.Text = "Tiêu đề";
            // 
            // tbTieuDe
            // 
            this.tbTieuDe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTieuDe.Location = new System.Drawing.Point(178, 117);
            this.tbTieuDe.Name = "tbTieuDe";
            this.tbTieuDe.Size = new System.Drawing.Size(1293, 30);
            this.tbTieuDe.TabIndex = 61;
            // 
            // btThem
            // 
            this.btThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Location = new System.Drawing.Point(177, 276);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(100, 35);
            this.btThem.TabIndex = 65;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCapNhat
            // 
            this.btCapNhat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhat.Location = new System.Drawing.Point(739, 276);
            this.btCapNhat.Name = "btCapNhat";
            this.btCapNhat.Size = new System.Drawing.Size(127, 35);
            this.btCapNhat.TabIndex = 67;
            this.btCapNhat.Text = "Cập nhật";
            this.btCapNhat.UseVisualStyleBackColor = true;
            this.btCapNhat.Click += new System.EventHandler(this.button2_Click);
            // 
            // btXoa
            // 
            this.btXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Location = new System.Drawing.Point(469, 276);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(100, 35);
            this.btXoa.TabIndex = 66;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 22);
            this.label2.TabIndex = 69;
            this.label2.Text = "Chi tiết";
            // 
            // tbGhiChu
            // 
            this.tbGhiChu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGhiChu.Location = new System.Drawing.Point(178, 153);
            this.tbGhiChu.Multiline = true;
            this.tbGhiChu.Name = "tbGhiChu";
            this.tbGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbGhiChu.Size = new System.Drawing.Size(1293, 117);
            this.tbGhiChu.TabIndex = 68;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(955, 283);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 22);
            this.label10.TabIndex = 116;
            this.label10.Text = "Tìm kiếm";
            // 
            // tbTuKhoa
            // 
            this.tbTuKhoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTuKhoa.Location = new System.Drawing.Point(1066, 276);
            this.tbTuKhoa.Name = "tbTuKhoa";
            this.tbTuKhoa.Size = new System.Drawing.Size(405, 30);
            this.tbTuKhoa.TabIndex = 115;
            this.tbTuKhoa.TextChanged += new System.EventHandler(this.tbTuKhoa_TextChanged);
            // 
            // F_QLQuyDinhSao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1523, 730);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbTuKhoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbGhiChu);
            this.Controls.Add(this.btCapNhat);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbMa);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbTieuDe);
            this.Controls.Add(this.dgvQuyDinh);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_QLQuyDinhSao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quy định Chấm sao";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuyDinh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuyDinh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbMa;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbTieuDe;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btCapNhat;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbTuKhoa;
    }
}
namespace QuanLyDanhGiaNhanVien
{
    partial class F_QLChucVu
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
            this.dgvChucVu = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbMa = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.btThem = new System.Windows.Forms.Button();
            this.btCapNhat = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGhiChu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucVu)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChucVu
            // 
            this.dgvChucVu.AllowUserToAddRows = false;
            this.dgvChucVu.AllowUserToDeleteRows = false;
            this.dgvChucVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChucVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvChucVu.Location = new System.Drawing.Point(12, 270);
            this.dgvChucVu.Name = "dgvChucVu";
            this.dgvChucVu.ReadOnly = true;
            this.dgvChucVu.RowHeadersWidth = 51;
            this.dgvChucVu.RowTemplate.Height = 24;
            this.dgvChucVu.Size = new System.Drawing.Size(1499, 455);
            this.dgvChucVu.TabIndex = 60;
            this.dgvChucVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChucVu_CellClick);
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
            this.Column2.HeaderText = "Mã chức vụ";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên chức vụ";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Ghi chú";
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
            this.label1.Location = new System.Drawing.Point(520, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quản lý Thông tin Chức vụ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(141, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 24);
            this.label15.TabIndex = 64;
            this.label15.Text = "Mã";
            // 
            // tbMa
            // 
            this.tbMa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMa.Location = new System.Drawing.Point(319, 81);
            this.tbMa.Name = "tbMa";
            this.tbMa.ReadOnly = true;
            this.tbMa.Size = new System.Drawing.Size(304, 30);
            this.tbMa.TabIndex = 63;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(141, 120);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(129, 24);
            this.label20.TabIndex = 62;
            this.label20.Text = "Tên chức vụ";
            // 
            // tbTen
            // 
            this.tbTen.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTen.Location = new System.Drawing.Point(319, 117);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(993, 30);
            this.tbTen.TabIndex = 61;
            // 
            // btThem
            // 
            this.btThem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Location = new System.Drawing.Point(398, 229);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(100, 35);
            this.btThem.TabIndex = 65;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCapNhat
            // 
            this.btCapNhat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhat.Location = new System.Drawing.Point(960, 229);
            this.btCapNhat.Name = "btCapNhat";
            this.btCapNhat.Size = new System.Drawing.Size(127, 35);
            this.btCapNhat.TabIndex = 67;
            this.btCapNhat.Text = "Cập nhật";
            this.btCapNhat.UseVisualStyleBackColor = true;
            this.btCapNhat.Click += new System.EventHandler(this.button2_Click);
            // 
            // btXoa
            // 
            this.btXoa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Location = new System.Drawing.Point(690, 229);
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
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 69;
            this.label2.Text = "Ghi chú";
            // 
            // tbGhiChu
            // 
            this.tbGhiChu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGhiChu.Location = new System.Drawing.Point(319, 153);
            this.tbGhiChu.Multiline = true;
            this.tbGhiChu.Name = "tbGhiChu";
            this.tbGhiChu.Size = new System.Drawing.Size(993, 70);
            this.tbGhiChu.TabIndex = 68;
            // 
            // F_QLChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1523, 730);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbGhiChu);
            this.Controls.Add(this.btCapNhat);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbMa);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.dgvChucVu);
            this.Controls.Add(this.panel1);
            this.Name = "F_QLChucVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_QLChucVu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucVu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChucVu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbMa;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btCapNhat;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
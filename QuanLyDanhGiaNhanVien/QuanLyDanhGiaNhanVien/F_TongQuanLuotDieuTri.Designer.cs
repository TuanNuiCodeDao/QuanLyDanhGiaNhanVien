namespace QuanLyDanhGiaNhanVien
{
    partial class F_TongQuanLuotDieuTri
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.dateThoiGian = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbSoLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTongLuot = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(503, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tổng quan lượt điều trị ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1521, 60);
            this.panel1.TabIndex = 22;
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column7,
            this.Column6,
            this.Column5,
            this.Column10,
            this.Column9,
            this.Column8});
            this.dgvNhanVien.Location = new System.Drawing.Point(12, 223);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.Size = new System.Drawing.Size(1499, 495);
            this.dgvNhanVien.TabIndex = 43;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            this.dgvNhanVien.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellDoubleClick);
            this.dgvNhanVien.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvNhanVien_RowPrePaint);
            // 
            // dateThoiGian
            // 
            this.dateThoiGian.CustomFormat = "dd/MM/yyyy";
            this.dateThoiGian.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateThoiGian.Location = new System.Drawing.Point(645, 81);
            this.dateThoiGian.Name = "dateThoiGian";
            this.dateThoiGian.Size = new System.Drawing.Size(294, 30);
            this.dateThoiGian.TabIndex = 106;
            this.dateThoiGian.ValueChanged += new System.EventHandler(this.dateThoiGian_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(433, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 23);
            this.label6.TabIndex = 105;
            this.label6.Text = "Thời gian";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(433, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(189, 23);
            this.label12.TabIndex = 127;
            this.label12.Text = "Số lượng buổi điều trị";
            // 
            // tbSoLuong
            // 
            this.tbSoLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbSoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSoLuong.Location = new System.Drawing.Point(645, 131);
            this.tbSoLuong.Name = "tbSoLuong";
            this.tbSoLuong.ReadOnly = true;
            this.tbSoLuong.Size = new System.Drawing.Size(294, 30);
            this.tbSoLuong.TabIndex = 126;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(433, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 23);
            this.label2.TabIndex = 129;
            this.label2.Text = "Tổng số lượt điều trị";
            // 
            // tbTongLuot
            // 
            this.tbTongLuot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tbTongLuot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTongLuot.Location = new System.Drawing.Point(645, 167);
            this.tbTongLuot.Name = "tbTongLuot";
            this.tbTongLuot.ReadOnly = true;
            this.tbTongLuot.Size = new System.Drawing.Size(294, 30);
            this.tbTongLuot.TabIndex = 128;
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
            this.Column2.HeaderText = "Mã nhân viên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Họ tên";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 140;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Chức vụ";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 140;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Ngày sinh";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Giới tính";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Số điện thoại";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Max sao";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 80;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Trạng thái";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Số lượt điều trị";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // F_TongQuanLuotDieuTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1523, 730);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTongLuot);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbSoLuong);
            this.Controls.Add(this.dateThoiGian);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.panel1);
            this.Name = "F_TongQuanLuotDieuTri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tổng quan lượt điều trị ";
            this.Load += new System.EventHandler(this.F_QLNhanVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.DateTimePicker dateThoiGian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTongLuot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}
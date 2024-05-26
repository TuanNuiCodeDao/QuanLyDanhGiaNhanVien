namespace QuanLyDanhGiaNhanVien
{
    partial class F_XemDanhSachDanhGia
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
            this.dgvDanhGia = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNoiDung = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhGia)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDanhGia
            // 
            this.dgvDanhGia.AllowUserToAddRows = false;
            this.dgvDanhGia.AllowUserToDeleteRows = false;
            this.dgvDanhGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column7,
            this.Column9});
            this.dgvDanhGia.Location = new System.Drawing.Point(12, 223);
            this.dgvDanhGia.Name = "dgvDanhGia";
            this.dgvDanhGia.ReadOnly = true;
            this.dgvDanhGia.RowHeadersWidth = 51;
            this.dgvDanhGia.RowTemplate.Height = 24;
            this.dgvDanhGia.Size = new System.Drawing.Size(1499, 505);
            this.dgvDanhGia.TabIndex = 44;
            this.dgvDanhGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhGia_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1521, 60);
            this.panel1.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(513, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh sách đánh giá điều trị";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 118;
            this.label4.Text = "Nội dung";
            // 
            // tbNoiDung
            // 
            this.tbNoiDung.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNoiDung.Location = new System.Drawing.Point(135, 70);
            this.tbNoiDung.Multiline = true;
            this.tbNoiDung.Name = "tbNoiDung";
            this.tbNoiDung.ReadOnly = true;
            this.tbNoiDung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNoiDung.Size = new System.Drawing.Size(1376, 138);
            this.tbNoiDung.TabIndex = 117;
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
            this.Column2.HeaderText = "Mã đánh giá";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Số sao";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 90;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Nội dung";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 300;
            // 
            // F_XemDanhSachDanhGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1523, 730);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNoiDung);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDanhGia);
            this.Name = "F_XemDanhSachDanhGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách đánh giá";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhGia)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhGia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}
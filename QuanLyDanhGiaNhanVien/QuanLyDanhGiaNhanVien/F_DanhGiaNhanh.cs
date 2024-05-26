using QuanLyDanhGiaBenhNhan.DAO;
using QuanLyDanhGiaNhanVien.DAO;
using QuanLyDanhGiaNhanVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDanhGiaNhanVien
{
    public partial class F_DanhGiaNhanh : Form
    {
        NhanVien nv;
        BenhNhan bn;
        int soSao = 1;
        public bool Changed { get; set; }
        public F_DanhGiaNhanh(NhanVien nv, BenhNhan bn)
        {
            InitializeComponent();
            this.nv = nv;
            this.bn = bn;
            soSao = nv.MaxSao;
            Changed = false;
            showData();
        }

        void setButtonSao(int soSao_)
        {
            bt1Sao.ForeColor = soSao_ < 1 ? System.Drawing.Color.DimGray : System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            bt2Sao.ForeColor = soSao_ < 2 ? System.Drawing.Color.DimGray : System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            bt3Sao.ForeColor = soSao_ < 3 ? System.Drawing.Color.DimGray : System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            bt4Sao.ForeColor = soSao_ < 4 ? System.Drawing.Color.DimGray : System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            bt5Sao.ForeColor = soSao_ < 5 ? System.Drawing.Color.DimGray : System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            bt6Sao.ForeColor = soSao_ < 6 ? System.Drawing.Color.DimGray : System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            bt7Sao.ForeColor = soSao_ < 7 ? System.Drawing.Color.DimGray : System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            bt8Sao.ForeColor = soSao_ < 8 ? System.Drawing.Color.DimGray : System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            bt9Sao.ForeColor = soSao_ < 9 ? System.Drawing.Color.DimGray : System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            bt10Sao.ForeColor = soSao_ < 10 ? System.Drawing.Color.DimGray : System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));

        }

        private void btSao_Click(object sender, EventArgs e)
        {
            soSao = int.Parse((sender as System.Windows.Forms.Button).Tag.ToString());
            soSao = Math.Max(soSao, 1);
            soSao = Math.Min(soSao, nv.MaxSao);

            setButtonSao(soSao);

            btXoa.Text = "Đánh giá " + soSao + " sao";
            if (soSao >= 8)
            {
                btXoa.BackColor = Color.Green;
            }
            else if (soSao >= 5)
            {
                btXoa.BackColor = Color.LightGreen;
            }
            else if (soSao >= 3)
            {
                btXoa.BackColor = Color.Orange;
            }
            else
            {
                btXoa.BackColor = Color.Red;
            }
        }

        void showData()
        {
            tbBenhNhan.Text = bn.MaBN + " - " + bn.HoTen + " - " + bn.SDT;
            ChucVu cv = ChucVuDAO.gI().getByMa(nv.MaCV);
            tbPhuTrach.Text = nv.MaNV + " - " + cv.TenCV + " - " + nv.HoTen + " - " + nv.SDT;
            tbSoDieuTri.Text = DieuTriDAO.gI().loadByMaNV_BN_ChuaDanhGia(nv.MaNV,bn.MaBN).Count+"";

            setButtonSao(soSao);
            bt1Sao.Click += btSao_Click;
            bt2Sao.Click += btSao_Click;
            bt3Sao.Click += btSao_Click;
            bt4Sao.Click += btSao_Click;
            bt5Sao.Click += btSao_Click;
            bt6Sao.Click += btSao_Click;
            bt7Sao.Click += btSao_Click;
            bt8Sao.Click += btSao_Click;
            bt9Sao.Click += btSao_Click;
            bt10Sao.Click += btSao_Click;
            if (nv.MaxSao >= 10) bt10Sao.Enabled = true;
            if (nv.MaxSao >= 9) bt9Sao.Enabled = true;
            if (nv.MaxSao >= 8) bt8Sao.Enabled = true;
            if (nv.MaxSao >= 7) bt7Sao.Enabled = true;
            if (nv.MaxSao >= 6) bt6Sao.Enabled = true;
            if (nv.MaxSao >= 5) bt5Sao.Enabled = true;
            if (nv.MaxSao >= 4) bt4Sao.Enabled = true;
            if (nv.MaxSao >= 3) bt3Sao.Enabled = true;
            if (nv.MaxSao >= 2) bt2Sao.Enabled = true;
            if (nv.MaxSao >= 1) bt1Sao.Enabled = true;
        }

        private void tbBenhNhan_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void tbPhuTrach_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_QLQuyDinhSao f = new F_QLQuyDinhSao(false);
            f.ShowDialog();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận đánh giá " + soSao + " sao ?\nThao tác không thể thực hiện lại !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                List<DieuTri> l = DieuTriDAO.gI().loadByMaNV_BN_ChuaDanhGia(nv.MaNV, bn.MaBN);
                foreach (DieuTri d in l)
                {
                    DanhGiaDAO.gI().them(new DanhGia(null, d.MaDT,nv.MaNV, DateTime.Now, soSao, tbNoiDung.Text));
                    Changed = true;
                }
                this.Close();
            }
        }

        private void pnDanhGia_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

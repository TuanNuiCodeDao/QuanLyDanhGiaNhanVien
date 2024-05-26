using QuanLyDanhGiaNhanVien.DAO;
using QuanLyDanhGiaNhanVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDanhGiaNhanVien
{
    public partial class F_ThongTinDangNhap : Form
    {
        private DangNhap dn;

        public DangNhap Dn { get => dn; set => dn = value; }

        public F_ThongTinDangNhap(DangNhap tk)
        {
            InitializeComponent();
            Dn = tk;
            loadThongTin();
        }
        private void loadThongTin()
        {
            tbTaiKhoan.Text = Dn.TaiKhoan;
            tbMatKhau.Text = Dn.MatKhau;
        }
        private void BtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool check(string s)
        {
            if (s.Length < 2)
                return false;
            for (int i = 0; i < s.Length; i++)
                if (s[i] == ' ')
                    return false;
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tbTaiKhoan.Text = tbTaiKhoan.Text.Trim();
            tbMatKhau.Text = tbMatKhau.Text.Trim();
            if (check(tbTaiKhoan.Text) == false)
            {
                MessageBox.Show("Tài khoản lỗi: Chứa ký tự trắng hoặc quá ngắn !", "Nhắc nhở");
                return;
            }
            if (check(tbMatKhau.Text) == false)
            {
                MessageBox.Show("Mật khẩu lỗi: Chứa ký tự trắng hoặc quá ngắn !", "Nhắc nhở");
                return;
            }
            DangNhap d = DangNhapDAO.gI().getByTaiKhoan(tbTaiKhoan.Text);
            if (d != null && d.MaNV != Dn.MaNV)
            {
                MessageBox.Show("Tài khoản đã tồn tại !", "Nhắc nhở");
                return;
            }
            DangNhapDAO.gI().suaByTaiKhoan(tbTaiKhoan.Text, tbMatKhau.Text, Dn.TaiKhoan);
            Dn = DangNhapDAO.gI().getByTaiKhoan(tbTaiKhoan.Text);
            MessageBox.Show("Cập nhật thành công !", "Thông báo");
            loadThongTin();
        }
    }
}

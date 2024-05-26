using QuanLyDanhGiaBenhNhan;
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

namespace QuanLyDanhGiaNhanVien
{
    public partial class FChinh : Form
    {
        private DangNhap dn;
        private Form formCon;
        public FChinh()
        {
            InitializeComponent();
            setLogOut();
        }

        private void OpenChildForm(Form childForm)
        {
            if (formCon != null)
            {
                formCon.Close();
            }
            formCon = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnBody.Controls.Add(childForm);
            pnBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void FChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Xác nhận thoát chương trình ?", "Xác nhận", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void setLogOut()
        {
            accountToolStripMenuItem1.Enabled = false;
            logoutToolStripMenuItem.Enabled = false;
            loginToolStripMenuItem.Text = "Đăng nhập"; 
            TrangChuToolStripMenuItem1.Enabled = false;
            qLThongTinToolStripMenuItem.Enabled = false;
            dn = null;
            OpenChildForm(new F_Nen());
        }    
        private void setNhanVien()
        {
            accountToolStripMenuItem1.Enabled = true;
            logoutToolStripMenuItem.Enabled = true;
            loginToolStripMenuItem.Text = "Tài khoản";
            TrangChuToolStripMenuItem1.Enabled = true;
            qLThongTinToolStripMenuItem.Enabled = false;
        }
        private void setAdmin()
        {
            accountToolStripMenuItem1.Enabled = true;
            logoutToolStripMenuItem.Enabled = true;
            loginToolStripMenuItem.Text = "Tài khoản";
            TrangChuToolStripMenuItem1.Enabled = true;
            qLThongTinToolStripMenuItem.Enabled = true;

        }
        private void checkLoaiDn()
        {
            if (dn.IsAdmin)
                setAdmin();
            else setNhanVien();
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginToolStripMenuItem.Text == "Đăng nhập")
            {
                F_DangNhap f = new F_DangNhap();
                f.ShowDialog();
                dn = f.Dn;
                if (dn != null)
                {
                    dn = DangNhapDAO.gI().getByTaiKhoan(dn.TaiKhoan);
                    checkLoaiDn();
                    OpenChildForm(new F_Nen());
                }
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận đăng xuất tài khoản ?","Xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                setLogOut();
            }
        }

        private void accountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_ThongTinDangNhap f = new F_ThongTinDangNhap(dn);
            f.ShowDialog();
            dn = f.Dn;
        }
        private void qLyNhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChucVuDAO.gI().loadDS().Count < 1)
            {
                MessageBox.Show("Hãy thêm chức vụ trước !", "Nhắc nhở");
                return;
            }
            OpenChildForm(new F_QLNhanVien());
        }

        private void qLyChucVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLChucVu(dn.IsAdmin));
        }

        private void qLyBenhNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLBenhNhan());
        }

        private void qlXuatHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLQuyDinhSao(dn.IsAdmin));
        }

        private void qLThongTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TrangChuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dn.IsAdmin)
            {
                OpenChildForm(new F_TrangChu());
            }
            else
            {
                OpenChildForm(new F_TongQuanDanhGia(dn.MaNV));
            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Setting f=new F_Setting();
            f.ShowDialog();
        }

        private void tổngQuanCôngTácĐiềuTrịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_TongQuanLuotDieuTri());
        }
    }
}

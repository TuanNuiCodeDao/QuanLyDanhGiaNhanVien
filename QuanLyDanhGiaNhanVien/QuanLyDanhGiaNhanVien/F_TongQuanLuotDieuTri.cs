using QuanLyDanhGiaNhanVien.DAO;
using QuanLyDanhGiaNhanVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDanhGiaNhanVien
{
    public partial class F_TongQuanLuotDieuTri : Form
    {
        public F_TongQuanLuotDieuTri()
        {
            InitializeComponent();
            loadDS();
        }
        private void loadDS()
        {
            dgvNhanVien.Rows.Clear();
            int stt = 0;
            int tongLuot = 0;
            List<NhanVien> l = NhanVienDAO.gI().loadDS();
            DateTime thoiGian = (DateTime)dateThoiGian.Value;
            foreach (NhanVien i in l)
            {
                int soLuong = DieuTriDAO.gI().loadByMaNV_ThoiGian(i.MaNV, thoiGian).Count;
                if (soLuong < 1) continue;
                stt++;
                tongLuot+= soLuong;
                ChucVu cv = ChucVuDAO.gI().getByMa(i.MaCV);
                dgvNhanVien.Rows.Add(stt, i.MaNV, i.HoTen, cv.TenCV, i.NgaySinh.ToString("dd/MM/yyyy"), i.GioiTinh ? "Nam" : "Nữ", i.SDT, i.MaxSao, i.TrangThai ? "On" : "Đã vô hiệu hóa", soLuong);
            }

            tbSoLuong.Text = DieuTriDAO.gI().loadByThoiGian(thoiGian).Count + " Buổi";
            tbTongLuot.Text = tongLuot + " Lượt";
        }


        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void F_QLNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            bool trangThai = dgvNhanVien.Rows[e.RowIndex].Cells[8].Value.ToString() == "On";
            if (trangThai)
            {
                dgvNhanVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else
            {
                dgvNhanVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
            }
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateThoiGian_ValueChanged(object sender, EventArgs e)
        {
            loadDS();
        }
    }
}

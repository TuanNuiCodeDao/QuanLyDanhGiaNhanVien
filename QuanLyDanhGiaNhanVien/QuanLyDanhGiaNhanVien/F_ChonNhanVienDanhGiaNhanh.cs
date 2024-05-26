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
    public partial class F_ChonNhanVienDanhGiaNhanh : Form
    {
        BenhNhan bn;
        public F_ChonNhanVienDanhGiaNhanh(BenhNhan i)
        {
            InitializeComponent();
            this.bn = i;
            label1.Text = label1 + " " + bn.HoTen + " (" +bn.SDT +")";
            loadDS();
            loadCBChucVu();
        }
        private void loadCBChucVu()
        {
            List<ChucVu> l = ChucVuDAO.gI().loadDS();
            cbChucVu.DataSource = l;
            cbChucVu.DisplayMember = "TenCV";
            if (l.Count > 0)
                cbChucVu.Text = l[0].TenCV;
        }
        private void loadDS()
        {
            tbMa.Text = "";
            dgvNhanVien.Rows.Clear();
            int stt = 0;
            List<NhanVien> l = NhanVienDAO.gI().loadDS();
            foreach (NhanVien i in l)
            {
                int soLuong = DieuTriDAO.gI().loadByMaNV_BN_ChuaDanhGia(i.MaNV, bn.MaBN).Count;
                if (soLuong < 1) continue;
                stt++;
                ChucVu cv = ChucVuDAO.gI().getByMa(i.MaCV);
                dgvNhanVien.Rows.Add(stt, i.MaNV, i.HoTen, cv.TenCV, i.NgaySinh.ToString("dd/MM/yyyy"), i.GioiTinh ? "Nam" : "Nữ", i.SDT, i.MaxSao, i.TrangThai ? "On" : "Đã vô hiệu hóa", soLuong);
            }
        }

        private void btThemNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien nv = NhanVienDAO.gI().getNhanVienByMa(tbMa.Text);
            if (nv == null)
            {
                MessageBox.Show("Hãy chọn nhân viên trước !", "Nhắc nhở");
                return;
            }

            if (DieuTriDAO.gI().loadByMaNV_BN_ChuaDanhGia(nv.MaNV, bn.MaBN).Count<1)
            {
                MessageBox.Show("Nhân viên này không có buổi điều trị phù hợp để đánh giá !", "Nhắc nhở");
                return;
            }

            F_DanhGiaNhanh f = new F_DanhGiaNhanh(nv, bn);
            f.ShowDialog();
            if (f.Changed) loadDS();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbMa.Text = Convert.ToString(dgvNhanVien.Rows[e.RowIndex].Cells[1].Value);
                NhanVien i = NhanVienDAO.gI().getNhanVienByMa(tbMa.Text);
                if (i == null)
                    return;
                tbHoTen.Text = i.HoTen;
                if (i.GioiTinh) rdNam.Checked = true;
                else rdNu.Checked = true;
                tbSDT.Text = i.SDT;
                dateNgaySinh.Value = i.NgaySinh;
                tbDiaChi.Text = i.DiaChi;
                tbTrangThai.Text = i.TrangThai ? "On" : "Đã vô hiệu hóa";
                tbTrangThai.BackColor = i.TrangThai ? Color.Green : Color.Red;
                ptAnh.Image = i.Anh;
                tbMaxSao.Text = i.MaxSao + " Sao";
                DangNhap dn = DangNhapDAO.gI().getByMaNV(tbMa.Text);
                ChucVu cv = ChucVuDAO.gI().getByMa(i.MaCV);
                cbChucVu.Text = cv.TenCV;
                textBox1.Text = Convert.ToString(dgvNhanVien.Rows[e.RowIndex].Cells[9].Value);

                List<DieuTri> l = DieuTriDAO.gI().loadByMaNV(i.MaNV);

                int dem = 0, sum = 0;
                foreach (DieuTri dt in l)
                {
                    DanhGia dg = DanhGiaDAO.gI().getByMaDT_NV(dt.MaDT,i.MaNV);
                    if (dg != null)
                    {
                        dem++;
                        sum += dg.SoSao;
                    }
                }
                if (dem > 0)
                {
                    float saoTrungBinh = (float)(sum / dem);
                    tbSaoTrungBinh.Text = Math.Round(saoTrungBinh, 1) + " Sao";
                    if (saoTrungBinh * 100 / i.MaxSao >= 80)
                    {
                        tbSaoTrungBinh.BackColor = Color.Green;
                    }
                    else if (saoTrungBinh * 100 / i.MaxSao >= 50)
                    {
                        tbSaoTrungBinh.BackColor = Color.LightGreen;
                    }
                    else if (saoTrungBinh * 100 / i.MaxSao >= 30)
                    {
                        tbSaoTrungBinh.BackColor = Color.Orange;
                    }
                    else
                    {
                        tbSaoTrungBinh.BackColor = Color.Red;
                    }
                }
                else tbSaoTrungBinh.Text = "Chưa đánh giá";
            }
            catch
            {
            }
        }

        private void ptAnh_Click(object sender, EventArgs e)
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

        private void cbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}

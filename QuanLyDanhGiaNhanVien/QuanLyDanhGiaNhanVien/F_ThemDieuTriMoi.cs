using DocumentFormat.OpenXml.InkML;
using QuanLyDanhGiaBenhNhan.DAO;
using QuanLyDanhGiaNhanVien.DAO;
using QuanLyDanhGiaNhanVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDanhGiaNhanVien
{
    public partial class F_ThemDieuTriMoi : Form
    {
        public List<string> LNV { get; set; }
        public string maBN;
        public bool Changed { get; set; }
        public F_ThemDieuTriMoi(string maBN)
        {
            InitializeComponent();
            LNV = new List<string>();
            this.maBN = maBN;
            Changed = false;
            showDataBenhNhan();
            loadDS();
        }

        void showDataBenhNhan()
        {
            BenhNhan bn = BenhNhanDAO.gI().getBenhNhanByMa(maBN);
            tbBenhNhan.Text = bn.MaBN + " - " + bn.HoTen + " - " + bn.SDT;
        }
        private void loadDS()
        {
            tbMa.Text = "";
            dgvNhanVien.Rows.Clear();
            int stt = 0;
            List<NhanVien> l = NhanVienDAO.gI().loadDSTimKiemOn(tbTuKhoa.Text);
            foreach (NhanVien i in l)
            {
                stt++;
                ChucVu cv = ChucVuDAO.gI().getByMa(i.MaCV);
                dgvNhanVien.Rows.Add(stt, i.MaNV, i.HoTen, cv.TenCV, i.NgaySinh.ToString("dd/MM/yyyy"), i.GioiTinh ? "Nam" : "Nữ", i.SDT);
            }
        }

        private void btThemNhanVien_Click(object sender, EventArgs e)
        {
            tbTuKhoa.Clear();
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
                tbChucVu.Text = cv.TenCV;

                List<DieuTri> l = DieuTriDAO.gI().loadByMaNV(i.MaNV);
                button2.Text = LNV.Contains(i.MaNV) ? "Bỏ chọn" : "Chọn";
                button2.BackColor= LNV.Contains(i.MaNV) ? Color.Red : Color.Green;

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
                else
                {
                    tbSaoTrungBinh.Text = "Chưa đánh giá";
                    tbSaoTrungBinh.BackColor = tbHoTen.BackColor;
                }
            }
            catch
            {
            }
        }

        private void tbTuKhoa_TextChanged(object sender, EventArgs e)
        {
            loadDS();
        }

        private void dgvNhanVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (LNV.Contains(Convert.ToString(dgvNhanVien.Rows[e.RowIndex].Cells[1].Value)))
            {
                dgvNhanVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LNV.Count<1)
            {
                MessageBox.Show("Chưa có nhân viên nào được chọn !", "Nhắc nhở");
                return;
            }

            DieuTriDAO.gI().them(new DieuTri(null, maBN, LNV, (DateTime)dateBD.Value, (DateTime)dateKT.Value));

            Changed = true;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NhanVien nv = NhanVienDAO.gI().getNhanVienByMa(tbMa.Text);
            if (nv == null)
            {
                MessageBox.Show("Hãy chọn nhân viên trước !", "Nhắc nhở");
                return;
            }

            if (LNV.Contains(nv.MaNV))
            {
                LNV.Remove(nv.MaNV);
                MessageBox.Show("Hủy phụ trách thành công !", "Thông báo");
            }
            else
            {
                LNV.Add(nv.MaNV);
                MessageBox.Show("Thêm phụ trách thành công !", "Thông báo");
            }

            button2.Text = LNV.Contains(nv.MaNV) ? "Bỏ chọn" : "Chọn";
            button2.BackColor = LNV.Contains(nv.MaNV) ? Color.Red : Color.Green;

            loadDS();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận hủy bỏ tiến trình !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbMa.Text = Convert.ToString(dgvNhanVien.Rows[e.RowIndex].Cells[1].Value);
                NhanVien nv = NhanVienDAO.gI().getNhanVienByMa(tbMa.Text);
                if (nv == null)
                    return;

                if (LNV.Contains(nv.MaNV))
                {
                    LNV.Remove(nv.MaNV);
                    MessageBox.Show("Hủy phụ trách thành công !", "Thông báo");
                }
                else
                {
                    LNV.Add(nv.MaNV);
                    MessageBox.Show("Thêm phụ trách thành công !", "Thông báo");
                }

                button2.Text = LNV.Contains(nv.MaNV) ? "Bỏ chọn" : "Chọn";
                button2.BackColor = LNV.Contains(nv.MaNV) ? Color.Red : Color.Green;

                loadDS();
            }
            catch
            {
            }
        }
    }
}

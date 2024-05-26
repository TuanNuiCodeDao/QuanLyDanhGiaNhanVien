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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace QuanLyDanhGiaNhanVien
{
    public partial class F_TongQuanDanhGia : Form
    {
        public string maNV { get; set; }
        public F_TongQuanDanhGia(string maNV)
        {
            InitializeComponent();
            this.maNV=maNV;
            loadCbTime();
            loadThongTin();
        }

        string loadDieuKien()
        {
            if (cbCustom.Text == "Tất cả") return "";
            return " (YEAR(ThoiGianBD)="+((DateTime)dateThoiGian.Value).Year+ "  AND Month(ThoiGianBD)=" + ((DateTime)dateThoiGian.Value).Month+") ";
        }

        void loadThongTin()
        {
            tbMa.Text = maNV;
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
            ChucVu cv = ChucVuDAO.gI().getByMa(i.MaCV);
            tbChucVu.Text = cv.TenCV;
            tbMaxSao.Text = i.MaxSao + " sao";

            List<DieuTri> l = new List<DieuTri>();
            if (cbCustom.Text == "Tất cả")
            {
                l = DieuTriDAO.gI().loadByMaNV(maNV);
            }
            else
            {
                l = DieuTriDAO.gI().loadDSTheoNamThang_NV(maNV,((DateTime)dateThoiGian.Value).Year, ((DateTime)dateThoiGian.Value).Month);
            }
            int dem = 0, sum = 0;
            foreach (DieuTri dt in l)
            {
                DanhGia dg = DanhGiaDAO.gI().getByMaDT_NV(dt.MaDT,maNV);
                if (dg != null)
                {
                    dem++;
                    sum += dg.SoSao;
                }
            }

            tbSoLuong.Text = l.Count + "";
            tbSoLuongDaDanhGia.Text = dem + "";
            if (dem > 0)
            {
                float saoTrungBinh = (float)(sum / dem);
                tbSaoTrungBinh.Text = Math.Round(saoTrungBinh, 1) + " sao";
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

        private void loadCbTime()
        {
            cbCustom.Items.Clear();
            cbCustom.Items.Add("Tất cả");
            cbCustom.Items.Add("Tháng " + ((DateTime)dateThoiGian.Value).ToString("MM/yyyy"));
            cbCustom.Text = cbCustom.Items[1].ToString();
        }

        private void ptAnh_Click(object sender, EventArgs e)
        {
            
        }

        private void F_QLNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void cbCustom_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadThongTin();
        }

        private void dateThoiGian_ValueChanged(object sender, EventArgs e)
        {
            loadCbTime();
            loadThongTin();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_QLQuyDinhSao f = new F_QLQuyDinhSao(false);
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_XemDanhSachDanhGia f = new F_XemDanhSachDanhGia(maNV);
            f.ShowDialog();
        }
    }
}

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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace QuanLyDanhGiaNhanVien
{
    public partial class F_TrangChu : Form
    { 
        public F_TrangChu()
        {
            InitializeComponent();
            loadCbTime();
            loadThongTin();
        }

        void loadThongTin()
        {
            tbSoLuongNhanVien.Text = NhanVienDAO.gI().loadDS().Count+"";
            tbSoLuongBenhNhan.Text = BenhNhanDAO.gI().loadDS().Count + "";
            List<DieuTri> l = new List<DieuTri>();
            if (cbCustom.Text == "Tất cả")
            {
                l = DieuTriDAO.gI().loadDS();
            }
            else
            {
                l = DieuTriDAO.gI().loadDSTheoNamThang(((DateTime)dateThoiGian.Value).Year, ((DateTime)dateThoiGian.Value).Month);
            }

            int dem = 0, sum = 0;
            foreach (DieuTri dt in l)
            {
                foreach (string maNV in dt.ListMaNV) {
                    DanhGia dg = DanhGiaDAO.gI().getByMaDT_NV(dt.MaDT,maNV);
                    if (dg != null)
                    {
                        dem++;
                        sum += dg.SoSao;
                    }
                }
            }

            tbSoLuong.Text = l.Count + "";
            tbSoLuongDaDanhGia.Text = dem + "";
            if (dem > 0)
            {
                float saoTrungBinh = (float)(sum / dem);
                tbSaoTrungBinh.Text = Math.Round(saoTrungBinh, 1) + "";
                if (saoTrungBinh >= 8)
                {
                    tbSaoTrungBinh.BackColor = Color.Green;
                }
                else if (saoTrungBinh >= 5)
                {
                    tbSaoTrungBinh.BackColor = Color.LightGreen;
                }
                else if (saoTrungBinh >= 3)
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
    }
}

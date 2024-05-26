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
    public partial class F_DieuTri : Form
    {
        BenhNhan bn;
        public F_DieuTri(BenhNhan bn)
        {
            InitializeComponent();
            this.bn = bn;
            loadDataBN();
            loadDataDieuTri();
        }

        void loadDataBN()
        {
            if (bn == null)
            {
                this.Close();
                return;
            }
            tbMa.Text = bn.MaBN;
            tbHoTen.Text = bn.HoTen;
            tbSDT.Text = bn.SDT;
            tbGioiTinh.Text = bn.GioiTinh ? "Nam" : "Nữ";
            tbNgaySinh.Text = bn.NgaySinh.ToString("dd/MM/yyyy");
            ptAnh.Image = bn.Anh;
        }

        Button getButtonThemDieuTri()
        {
            Button btThem = new Button() { Width = 220, Height = 130 };
            btThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btThem.Text = "Thêm mới";
            btThem.Click += btThemDieuTri_Click;
            btThem.Tag = -1;
            btThem.BackColor = Color.Green;

            return btThem;
        }
        public void btThemDieuTri_Click(object sender, EventArgs e)
        {
            F_ThemDieuTriMoi f = new F_ThemDieuTriMoi(bn.MaBN);
            f.ShowDialog();
            if (f.Changed)
            {
                loadDataDieuTri();
            }
        }

        public void btOTherDieuTri_Click(object sender, EventArgs e)
        {
            F_DanhGiaDieuTri f = new F_DanhGiaDieuTri(DieuTriDAO.gI().getByMa((sender as Button).Tag.ToString()));
            f.ShowDialog();
            if (f.Changed)
            {
                loadDataDieuTri();
            }
        }


        void loadDataDieuTri()
        {
            flPn.Controls.Clear();
            List<DieuTri> l;
            if (checkAll.Checked) l = DieuTriDAO.gI().loadByMaBN(bn.MaBN);
            else l = DieuTriDAO.gI().loadByMaBN_ChuaDone(bn.MaBN);
            int dem = 0, sum = 0;
            foreach (DieuTri dt in l)
            {
                List<DanhGia> lDg = dt.GetListDanhGia();
                foreach(DanhGia g in lDg)
                {
                    dem++;
                    sum += g.SoSao;
                }
                if (lDg.Count== dt.ListMaNV.Count)
                {

                    Button bt = new Button() { Width = 220, Height = 130 };
                    string s = "Từ " + dt.ThoiGianBD.ToString("dd/MM/yyyy HH:mm")
                            + "\r\nĐến" + dt.ThoiGianKT.ToString("dd/MM/yyyy HH:mm");
                    s += "\r\n   (Đã đánh giá hoàn tất)";
                    bt.Text = s;
                    bt.Click += btOTherDieuTri_Click;
                    bt.Tag = dt.MaDT;
                    bt.BackColor = Color.Silver;
                    bt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    bt.ForeColor = Color.Blue;

                    flPn.Controls.Add(bt);
                }
                else
                {
                    Button bt = new Button() { Width = 220, Height = 130 };
                    string s = "Từ " + dt.ThoiGianBD.ToString("dd/MM/yyyy HH:mm")
                            + "\r\nĐến" + dt.ThoiGianKT.ToString("dd/MM/yyyy HH:mm");
                    s += "\r\n   (Đã đánh giá "+ lDg.Count + "/"+ dt.ListMaNV.Count + "phụ trách)";
                    bt.Text = s;
                    bt.Click += btOTherDieuTri_Click;
                    bt.Tag = dt.MaDT;
                    bt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    bt.BackColor = Color.Yellow;
                    flPn.Controls.Add(bt);
                }
            }

            tbSoLuong.Text = l.Count + "";
            tbSoLuongDaDanhGia.Text = dem + "";
            if (dem > 0)
            {
                tbSaoTrungBinh.Text = Math.Round((float)(sum / dem), 1) + "";
            }
            else tbSaoTrungBinh.Text = "Chưa đánh giá";

            flPn.Controls.Add(getButtonThemDieuTri());
            flPn.VerticalScroll.Value = flPn.VerticalScroll.Maximum;
            flPn.PerformLayout();
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            loadDataDieuTri();
        }
    }
}

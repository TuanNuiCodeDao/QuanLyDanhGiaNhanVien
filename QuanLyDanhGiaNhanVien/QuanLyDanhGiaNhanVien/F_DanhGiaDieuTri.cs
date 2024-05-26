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
    public partial class F_DanhGiaDieuTri : Form
    {
        public DieuTri dt;
        public bool Changed { get; set; }
        public F_DanhGiaDieuTri(DieuTri dt)
        {
            InitializeComponent();
            this.dt = dt;
            Changed = false;
            showDataBenhNhan();
            loadDS();
        }

        void showDataBenhNhan()
        {
            BenhNhan bn = BenhNhanDAO.gI().getBenhNhanByMa(dt.MaBN);
            tbBenhNhan.Text = bn.MaBN + " - " + bn.HoTen + " - " + bn.SDT;
        }
        private void loadDS()
        {
            tbMa.Text = "";
            dgvNhanVien.Rows.Clear();
            int stt = 0;
            foreach (string maNV  in dt.ListMaNV)
            {
                stt++;
                NhanVien i=NhanVienDAO.gI().getNhanVienByMa(maNV);
                ChucVu cv = ChucVuDAO.gI().getByMa(i.MaCV);
                DanhGia dg = DanhGiaDAO.gI().getByMaDT_NV(dt.MaDT, maNV);
                string s;
                if (dg == null) s = "Chưa đánh giá";
                else s="Đã đánh giá "+dg.SoSao+"/"+i.MaxSao+" sao";
                dgvNhanVien.Rows.Add(stt, i.MaNV, i.HoTen, cv.TenCV, i.NgaySinh.ToString("dd/MM/yyyy"), i.GioiTinh ? "Nam" : "Nữ", i.SDT,s);
            }
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
                ptAnh.Image = i.Anh;
                tbMaxSao.Text = i.MaxSao + " Sao";
                DangNhap dn = DangNhapDAO.gI().getByMaNV(tbMa.Text);
                ChucVu cv = ChucVuDAO.gI().getByMa(i.MaCV);
                tbChucVu.Text = cv.TenCV;

                DanhGia dg = DanhGiaDAO.gI().getByMaDT_NV(dt.MaDT, i.MaNV);
                button2.Text = dg==null?"Đánh giá":"Xem chi tiết";

                if (dg!=null)
                {
                    tbSoSao.Text = dg.SoSao + " Sao";
                    if (dg.SoSao * 100 / i.MaxSao >= 80)
                    {
                        tbSoSao.BackColor = Color.Green;
                    }
                    else if (dg.SoSao * 100 / i.MaxSao >= 50)
                    {
                        tbSoSao.BackColor = Color.LightGreen;
                    }
                    else if (dg.SoSao * 100 / i.MaxSao >= 30)
                    {
                        tbSoSao.BackColor = Color.Orange;
                    }
                    else
                    {
                        tbSoSao.BackColor = Color.Red;
                    }
                }
                else
                {
                    tbSoSao.Text = "Chưa đánh giá";
                    tbSoSao.BackColor = Color.LightGreen;
                }
            }
            catch
            {
            }
        }

        private void dgvNhanVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DanhGia dg = DanhGiaDAO.gI().getByMaDT_NV(dt.MaDT, Convert.ToString(dgvNhanVien.Rows[e.RowIndex].Cells[1].Value));
            if (dg!=null)
            {
                dgvNhanVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            F_DanhGia f = new F_DanhGia(dt, nv.MaNV);
            f.ShowDialog();
            if (f.Changed)
            {
                Changed= true;
                loadDS();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa dữ liệu điều trị ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Changed = true;
                DieuTriDAO.gI().xoa(dt.MaDT);
                MessageBox.Show("Xóa thành công !", "Thông báo");
                this.Close();
            }
        }
    }
}

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

namespace QuanLyDanhGiaNhanVien
{
    public partial class F_ChonBenhNhanDanhGiaNhanh : Form
    {
        NhanVien nv;
        public F_ChonBenhNhanDanhGiaNhanh(NhanVien i)
        {
            InitializeComponent();
            this.nv = i;
            label1.Text = label1 + " " + nv.HoTen + " (" + nv.SDT + ")";
            loadDS();
        }
        private void loadDS()
        {
            tbMa.Text = "";
            dgvBenhNhan.Rows.Clear();
            int stt = 0;
            List<BenhNhan> l = BenhNhanDAO.gI().loadDS();
            foreach (BenhNhan i in l)
            {
                int soLuong = DieuTriDAO.gI().loadByMaNV_BN_ChuaDanhGia(nv.MaNV,i.MaBN).Count;
                if (soLuong < 1) continue;
                stt++;
                dgvBenhNhan.Rows.Add(stt, i.MaBN, i.HoTen, i.NgaySinh.ToString("dd/MM/yyyy"), i.GioiTinh ? "Nam" : "Nữ", i.SDT, soLuong,i.DiaChi);
            }
        }

        private void btThemNhanVien_Click(object sender, EventArgs e)
        {
            BenhNhan bn = BenhNhanDAO.gI().getBenhNhanByMa(tbMa.Text);
            if (bn == null)
            {
                MessageBox.Show("Hãy chọn bệnh nhân trước !", "Nhắc nhở");
                return;
            }

            if (DieuTriDAO.gI().loadByMaNV_BN_ChuaDanhGia(nv.MaNV, bn.MaBN).Count < 1)
            {
                MessageBox.Show("Bệnh nhân này không có buổi điều trị phù hợp để đánh giá !", "Nhắc nhở");
                return;
            }

            F_DanhGiaNhanh f = new F_DanhGiaNhanh(nv, bn);
            f.ShowDialog(); 
            if(f.Changed) loadDS();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbMa.Text = Convert.ToString(dgvBenhNhan.Rows[e.RowIndex].Cells[1].Value);
                BenhNhan i = BenhNhanDAO.gI().getBenhNhanByMa(tbMa.Text);
                if (i == null)
                    return;
                tbHoTen.Text = i.HoTen;
                if (i.GioiTinh) rdNam.Checked = true;
                else rdNu.Checked = true;
                tbSDT.Text = i.SDT;
                dateNgaySinh.Value = i.NgaySinh;
                tbDiaChi.Text = i.DiaChi;
                ptAnh.Image = i.Anh;
                textBox1.Text = Convert.ToString(dgvBenhNhan.Rows[e.RowIndex].Cells[6].Value);
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
            
        }

        private void dgvNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

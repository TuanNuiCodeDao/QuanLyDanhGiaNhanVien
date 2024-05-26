using DocumentFormat.OpenXml.Wordprocessing;
using QuanLyDanhGiaBenhNhan.DAO;
using QuanLyDanhGiaNhanVien;
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

namespace QuanLyDanhGiaBenhNhan
{
    public partial class F_QLBenhNhan : Form
    {
        public F_QLBenhNhan()
        {
            InitializeComponent();
            loadDS();
        }
        private void loadDS()
        {
            tbMa.Text = "";
            dgvBenhNhan.Rows.Clear();
            int stt = 0;
            List<BenhNhan> l = BenhNhanDAO.gI().loadDSTimKiem(tbTuKhoa.Text);
            foreach (BenhNhan i in l)
            {
                stt++;
                dgvBenhNhan.Rows.Add(stt,new Button(), i.MaBN, i.HoTen,  i.NgaySinh.ToString("dd/MM/yyyy"), i.GioiTinh ? "Nam" : "Nữ", i.SDT, i.DiaChi);
            }
        }

        private void btXoaBenhNhan_Click(object sender, EventArgs e)
        {
            BenhNhan bn = BenhNhanDAO.gI().getBenhNhanByMa(tbMa.Text);
            if (bn == null)
            {
                MessageBox.Show("Bệnh nhân không tồn tại !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa bệnh nhân " + bn.HoTen + " ?\nMọi dữ liệu liên quan sẽ bị mất !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                BenhNhanDAO.gI().xoa(tbMa.Text);
                loadDS();
                MessageBox.Show("Xóa thành công !", "Thông báo");
            }
        }

        private void btCapNhatBenhNhan_Click(object sender, EventArgs e)
        {
            BenhNhan bn = BenhNhanDAO.gI().getBenhNhanByMa(tbMa.Text);
            if (bn == null)
            {
                MessageBox.Show("Hãy chọn bệnh nhân cần cập nhật thông tin trước !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống !", "Nhắc nhở");
                return;
            }
            if (DataProvider.gI().checkSDT(tbSDT.Text) == false)
            {
                MessageBox.Show("SĐT phải là chuỗi 9->12 ký tự số !", "Nhắc nhở");
                return;
            }
            BenhNhan bn2 = BenhNhanDAO.gI().getBenhNhanBySDT(tbSDT.Text);
            if (bn2 != null && bn2.MaBN != tbMa.Text)
            {
                MessageBox.Show("Số điện thoại '" + tbSDT.Text + "' đã được bệnh nhân khác sử dụng !", "Nhắc nhở");
                return;
            }
            BenhNhanDAO.gI().sua(new BenhNhan(bn.MaBN, tbHoTen.Text, (DateTime)dateNgaySinh.Value,
               rdNam.Checked, tbSDT.Text, tbDiaChi.Text, ptAnh.Image));
            loadDS();
            MessageBox.Show("Cập nhật thành công !", "Thông báo");
        }

        private void btThemBenhNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống !", "Nhắc nhở");
                return;
            }
            if (DataProvider.gI().checkSDT(tbSDT.Text) == false)
            {
                MessageBox.Show("SĐT phải là chuỗi 9->12 ký tự số !", "Nhắc nhở");
                return;
            }
            BenhNhan bn = BenhNhanDAO.gI().getBenhNhanBySDT(tbSDT.Text);
            if (bn != null)
            {
                MessageBox.Show("Số điện thoại '" + tbSDT.Text + "' đã được bệnh nhân khác sử dụng !", "Nhắc nhở");
                return;
            }
            BenhNhanDAO.gI().them(new BenhNhan(null, tbHoTen.Text, (DateTime)dateNgaySinh.Value,
               rdNam.Checked, tbSDT.Text, tbDiaChi.Text, ptAnh.Image));
            loadDS();
            MessageBox.Show("Thêm mới thành công !", "Thông báo");
        }

        private void dgvBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    string ma = Convert.ToString(dgvBenhNhan.Rows[e.RowIndex].Cells[2].Value);
                    if (DieuTriDAO.gI().loadByMaBN_ChuaDanhGia(ma).Count < 1)
                    {
                        MessageBox.Show("Bệnh nhân "+ma+" chưa có buổi điều trị nào phù hợp để đánh giá nhanh !", "Nhắc nhở");
                        return;
                    }
                    BenhNhan i = BenhNhanDAO.gI().getBenhNhanByMa(tbMa.Text);

                    F_ChonNhanVienDanhGiaNhanh f = new F_ChonNhanVienDanhGiaNhanh(i);
                    f.ShowDialog();

                    return;
                }
                else if(e.RowIndex>=0)
                {
                    tbMa.Text = Convert.ToString(dgvBenhNhan.Rows[e.RowIndex].Cells[2].Value);
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
                }
            }
            catch
            {
            }
        }

        private void ptAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh";
            openFileDialog.Filter = "Files hình ảnh|*.jpg;*.jpeg;*.png";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ptAnh.Image = Image.FromFile(openFileDialog.FileName);
                }
                catch
                {
                    ptAnh.Image = null;
                }
            }
        }

        private void F_QLBenhNhan_Load(object sender, EventArgs e)
        {

        }

        private void tbTuKhoa_TextChanged(object sender, EventArgs e)
        {
            loadDS();
        }

        private void dgvBenhNhan_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BenhNhan bn = BenhNhanDAO.gI().getBenhNhanByMa(tbMa.Text);
            if (bn == null)
            {
                MessageBox.Show("Hãy chọn bệnh nhân trước !", "Nhắc nhở");
                return;
            }
            F_DieuTri f = new F_DieuTri(bn);
            f.ShowDialog();
        }
    }
}

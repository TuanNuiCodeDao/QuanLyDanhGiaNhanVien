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
    public partial class F_QLNhanVien : Form
    {
        public F_QLNhanVien()
        {
            InitializeComponent();
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
            List<NhanVien> l = NhanVienDAO.gI().loadDSTimKiem(tbTuKhoa.Text);
            foreach (NhanVien i in l)
            {
                stt++;
                ChucVu cv = ChucVuDAO.gI().getByMa(i.MaCV);
                dgvNhanVien.Rows.Add(stt, new Button(), i.MaNV, i.HoTen, cv.TenCV, i.NgaySinh.ToString("dd/MM/yyyy"), i.GioiTinh ? "Nam" : "Nữ", i.SDT,i.MaxSao, i.TrangThai ? "On" : "Đã vô hiệu hóa", i.DiaChi);
            }
        }

        private void btXoaNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien nv = NhanVienDAO.gI().getNhanVienByMa(tbMa.Text);
            if (nv == null)
            {
                MessageBox.Show("Nhân viên không tồn tại !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa nhân viên " + nv.HoTen + " ?\nMọi dữ liệu liên quan sẽ bị mất !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                NhanVienDAO.gI().xoa(tbMa.Text);
                loadDS();
                MessageBox.Show("Xóa thành công !", "Thông báo");
            }
        }

        private void btCapNhatNhanVien_Click(object sender, EventArgs e)
        {
            ChucVu cv = ChucVuDAO.gI().getByTen(cbChucVu.Text);
            if (cv == null)
            {
                MessageBox.Show("Hãy thêm chức vụ trước !", "Nhắc nhở");
                return;
            }
            NhanVien nv = NhanVienDAO.gI().getNhanVienByMa(tbMa.Text);
            if (nv == null)
            {
                MessageBox.Show("Hãy chọn nhân viên cần cập nhật thông tin trước !", "Nhắc nhở");
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
            NhanVien nv2 = NhanVienDAO.gI().getNhanVienBySDT(tbSDT.Text);
            if (nv2 != null && nv2.MaNV != tbMa.Text)
            {
                MessageBox.Show("Số điện thoại '" + tbSDT.Text + "' đã được nhân viên khác sử dụng !", "Nhắc nhở");
                return;
            }
            NhanVienDAO.gI().sua(new NhanVien(nv.MaNV, cv.MaCV, tbHoTen.Text, (DateTime)dateNgaySinh.Value,
               rdNam.Checked, tbSDT.Text, nv.TrangThai, tbDiaChi.Text, ptAnh.Image,(int)nudMaxSao.Value));
            loadDS();
            MessageBox.Show("Cập nhật thành công !", "Thông báo");
        }

        private void btThemNhanVien_Click(object sender, EventArgs e)
        {
            ChucVu cv = ChucVuDAO.gI().getByTen(cbChucVu.Text);
            if (cv == null)
            {
                MessageBox.Show("Hãy thêm chức vụ trước !", "Nhắc nhở");
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
            NhanVien nv = NhanVienDAO.gI().getNhanVienBySDT(tbSDT.Text);
            if (nv != null)
            {
                MessageBox.Show("Số điện thoại '" + tbSDT.Text + "' đã được nhân viên khác sử dụng !", "Nhắc nhở");
                return;
            }
            NhanVienDAO.gI().them(new NhanVien(null, cv.MaCV, tbHoTen.Text, (DateTime)dateNgaySinh.Value,
               rdNam.Checked, tbSDT.Text, true, tbDiaChi.Text, ptAnh.Image,10));
            loadDS();
            MessageBox.Show("Thêm mới thành công !", "Thông báo");
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    string ma = Convert.ToString(dgvNhanVien.Rows[e.RowIndex].Cells[2].Value);
                    if (DieuTriDAO.gI().loadByMaNV_ChuaDanhGia(ma).Count < 1)
                    {
                        MessageBox.Show("Nhân viên " + ma + " chưa có buổi điều trị nào phù hợp để đánh giá nhanh !", "Nhắc nhở");
                        return;
                    }
                    NhanVien i = NhanVienDAO.gI().getNhanVienByMa(ma);

                    F_ChonBenhNhanDanhGiaNhanh f = new F_ChonBenhNhanDanhGiaNhanh(i);
                    f.ShowDialog();
                    return;
                }
                else if (e.RowIndex >= 0)
                {

                    tbMa.Text = Convert.ToString(dgvNhanVien.Rows[e.RowIndex].Cells[2].Value);
                    NhanVien i = NhanVienDAO.gI().getNhanVienByMa(tbMa.Text);
                    if (i == null)
                        return;
                    tbHoTen.Text = i.HoTen;
                    if (i.GioiTinh) rdNam.Checked = true;
                    else rdNu.Checked = true;
                    tbSDT.Text = i.SDT;
                    dateNgaySinh.Value = i.NgaySinh;
                    tbDiaChi.Text = i.DiaChi;
                    tbMa.BackColor = i.TrangThai ? Color.Green : Color.Red;
                    nudMaxSao.Value = i.MaxSao;
                    ptAnh.Image = i.Anh;
                    DangNhap dn = DangNhapDAO.gI().getByMaNV(tbMa.Text);
                    ChucVu cv = ChucVuDAO.gI().getByMa(i.MaCV);
                    cbChucVu.Text = cv.TenCV;
                    tbTaiKhoan.Text = dn.TaiKhoan;
                    tbMatKhau.Text = dn.MatKhau;
                    btVoHieu_MoKhoa.Text = i.TrangThai ? "Vô hiệu hóa" : "Mở khóa";
                    btVoHieu_MoKhoa.BackColor = i.TrangThai ? Color.Red : tbHoTen.BackColor;
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

        private void F_QLNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void tbTuKhoa_TextChanged(object sender, EventArgs e)
        {
            loadDS();
        }

        private void btVoHieu_MoKhoa_Click(object sender, EventArgs e)
        {
            NhanVien nv = NhanVienDAO.gI().getNhanVienByMa(tbMa.Text);
            if (nv == null)
            {
                MessageBox.Show("Hãy chọn nhân viên cần " + btVoHieu_MoKhoa.Text + " trước !", "Nhắc nhở");
                return;
            }

            if (nv.TrangThai)
            {
                if (MessageBox.Show("Xác nhận vô hiệu hóa nhân viên " + nv.HoTen + " ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    NhanVienDAO.gI().voHieu(tbMa.Text);
                    loadDS();
                }
            }
            else 
            {
                if (MessageBox.Show("Xác nhận mở khóa nhân viên " + nv.HoTen + " ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    NhanVienDAO.gI().moKhoa(tbMa.Text);
                    loadDS();
                }
            }
        }

        private void dgvNhanVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            bool trangThai = dgvNhanVien.Rows[e.RowIndex].Cells[9].Value.ToString()=="On";
            if (trangThai)
            {
                dgvNhanVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else
            {
                dgvNhanVien.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien nv = NhanVienDAO.gI().getNhanVienByMa(tbMa.Text);
            if (nv == null)
            {
                MessageBox.Show("Hãy chọn nhân viên cần xem tổng quan trước !", "Nhắc nhở");
                return;
            }

            F_TongQuanDanhGia f = new F_TongQuanDanhGia(nv.MaNV);
            f.ShowDialog();
        }
    }
}

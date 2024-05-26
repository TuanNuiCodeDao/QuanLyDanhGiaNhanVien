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
    public partial class F_QLQuyDinhSao : Form
    {
        public F_QLQuyDinhSao(bool isAdmin)
        {
            InitializeComponent();
            loadDS();
            setButton(isAdmin);
        }
        private void setButton(bool isAdmin)
        {
            btThem.Enabled = isAdmin;
            btXoa.Enabled = isAdmin;
            btCapNhat.Enabled = isAdmin;
            tbGhiChu.ReadOnly = !isAdmin;
            tbTieuDe.ReadOnly = !isAdmin;
        }
        private void loadDS()
        {
            dgvQuyDinh.Rows.Clear();
            int stt = 0;
            List<QuyDinh> l = QuyDinhDAO.gI().loadDSTimKiem(tbTuKhoa.Text);
            foreach (QuyDinh i in l)
            {
                stt++;
                dgvQuyDinh.Rows.Add(stt, i.MaQD, i.TieuDe, i.ChiTiet);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTieuDe.Text))
            {
                MessageBox.Show("Tên quy định không được để trống !", "Nhắc nhở");
                return;
            }
            if (QuyDinhDAO.gI().getByTieuDe(tbTieuDe.Text) != null)
            {
                MessageBox.Show("Quy định '" + tbTieuDe.Text + "' đã tồn tại !", "Nhắc nhở");
                return;
            }
            QuyDinhDAO.gI().them(new QuyDinh(null, tbTieuDe.Text, tbGhiChu.Text));
            loadDS();
            MessageBox.Show("Thêm mới thành công !", "Thông báo");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMa.Text))
            {
                MessageBox.Show("Hãy chọn quy định cần xóa trước !", "Nhắc nhở");
                return;
            }
            QuyDinh cv = QuyDinhDAO.gI().getByMa(tbMa.Text);
            if (MessageBox.Show("Xác nhận xóa quy định " + cv.TieuDe + " ?\nMọi dữ liệu liên quan sẽ bị mất !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                QuyDinhDAO.gI().xoa(tbMa.Text);
                loadDS();
                MessageBox.Show("Xóa thành công !", "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMa.Text))
            {
                MessageBox.Show("Hãy chọn quy định cần xóa trước !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbTieuDe.Text))
            {
                MessageBox.Show("Tên quy định không được để trống !", "Nhắc nhở");
                return;
            }
            QuyDinh dm = QuyDinhDAO.gI().getByTieuDe(tbTieuDe.Text);
            if (dm != null && dm.MaQD != tbMa.Text)
            {
                MessageBox.Show("Quy định '" + tbTieuDe.Text + "' đã tồn tại !", "Nhắc nhở");
                return;
            }
            QuyDinhDAO.gI().sua(new QuyDinh(tbMa.Text, tbTieuDe.Text, tbGhiChu.Text));
            loadDS();
            MessageBox.Show("Cập nhật thành công !", "Thông báo");
        }

        private void dgvQuyDinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbMa.Text = Convert.ToString(dgvQuyDinh.Rows[e.RowIndex].Cells[1].Value);
                QuyDinh i = QuyDinhDAO.gI().getByMa(tbMa.Text);
                if (i == null)
                    return;
                tbTieuDe.Text = i.TieuDe;
                tbGhiChu.Text = i.ChiTiet;
            }
            catch
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbTuKhoa_TextChanged(object sender, EventArgs e)
        {
            loadDS();
        }
    }
}

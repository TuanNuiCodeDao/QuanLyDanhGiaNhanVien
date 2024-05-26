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
    public partial class F_QLChucVu : Form
    {
        public F_QLChucVu(bool isAdmin)
        {
            InitializeComponent();
            loadDS();
            setButton(isAdmin);
        }
        private void setButton(bool isAdmin)
        {
            btThem.Enabled = isAdmin;
            btXoa.Enabled= isAdmin;
            btCapNhat.Enabled= isAdmin;
        }
        private void loadDS()
        {
            dgvChucVu.Rows.Clear();
            int stt = 0;
            List<ChucVu> l = ChucVuDAO.gI().loadDS();
            foreach (ChucVu i in l)
            {
                stt++;
                dgvChucVu.Rows.Add(stt,i.MaCV,i.TenCV,i.GhiChu);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Tên chức vụ không được để trống !", "Nhắc nhở");
                return;
            }
            if (ChucVuDAO.gI().getByTen(tbTen.Text) != null)
            {
                MessageBox.Show("Chức vụ '" + tbTen.Text + "' đã tồn tại !", "Nhắc nhở");
                return;
            }
            ChucVuDAO.gI().them(new ChucVu(null,tbTen.Text,tbGhiChu.Text));
            loadDS();
            MessageBox.Show("Thêm mới thành công !", "Thông báo");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMa.Text))
            {
                MessageBox.Show("Hãy chọn chức vụ cần xóa trước !", "Nhắc nhở");
                return;
            }
            ChucVu cv = ChucVuDAO.gI().getByMa(tbMa.Text);
            if (MessageBox.Show("Xác nhận xóa chức vụ "+cv.TenCV+" ?\nMọi dữ liệu liên quan sẽ bị mất !", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                ChucVuDAO.gI().xoa(tbMa.Text);
                loadDS();
                MessageBox.Show("Xóa thành công !", "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMa.Text))
            {
                MessageBox.Show("Hãy chọn chức vụ cần xóa trước !", "Nhắc nhở");
                return;
            }
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Tên chức vụ không được để trống !", "Nhắc nhở");
                return;
            }
            ChucVu dm = ChucVuDAO.gI().getByTen(tbTen.Text);
            if (dm != null&&dm.MaCV!=tbMa.Text)
            {
                MessageBox.Show("Chức vụ '" + tbTen.Text + "' đã tồn tại !", "Nhắc nhở");
                return;
            }
            ChucVuDAO.gI().sua(new ChucVu(tbMa.Text,tbTen.Text,tbGhiChu.Text));
            loadDS();
            MessageBox.Show("Cập nhật thành công !", "Thông báo");
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbMa.Text = Convert.ToString(dgvChucVu.Rows[e.RowIndex].Cells[1].Value);
                ChucVu i = ChucVuDAO.gI().getByMa(tbMa.Text);
                if(i==null)
                    return;
                tbTen.Text = i.TenCV;
                tbGhiChu.Text = i.GhiChu;
            }
            catch
            { 
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

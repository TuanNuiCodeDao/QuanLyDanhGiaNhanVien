using QuanLyDanhGiaNhanVien.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDanhGiaNhanVien
{
    public partial class F_Setting : Form
    {
        public F_Setting()
        {
            InitializeComponent();
            loadThongTin();
        }

        void loadThongTin()
        {
            tbMailGui.Text = ThongTinDAO.gI().GmailGui;
            tbMatKhauAppMail.Text = ThongTinDAO.gI().MatKhauAppMail;
            tbMailNhan.Text = ThongTinDAO.gI().GmailNhan;
            tbNoiLuu.Text = ThongTinDAO.gI().NoiLuu;
            nudTanSuat.Value = ThongTinDAO.gI().TanSuat;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("chrome.exe", "https://myaccount.google.com/u/3/apppasswords?utm_source=google-account&utm_medium=myaccountsecurity&utm_campaign=tsv-settings&rapt=AEjHL4M-LojgD-7mS4MIm5bZkqQcyrgjzziPl0344S44lO8XeZEZWOv9JCO79byEoCKS_s42d_Yc3IOW2toCNs-gsrjyuCG0IA");
        }

        private void nudTanSuat_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbNoiLuu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Chọn nơi lưu";
            folderBrowserDialog.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbNoiLuu.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbInput_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn tập tin .xlsx";
            openFileDialog.Filter = "Tệp tin sao lưu (*.xlsx)|*.xlsx";
            openFileDialog.Multiselect = false;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbInput.Text = openFileDialog.FileName;
            }
        }

        private void btVoHieu_MoKhoa_Click(object sender, EventArgs e)
        {
            ThongTinDAO.gI().GmailGui = tbMailGui.Text;
            ThongTinDAO.gI().MatKhauAppMail = tbMatKhauAppMail.Text;
            ThongTinDAO.gI().GmailNhan = tbMailNhan.Text;
            ThongTinDAO.gI().NoiLuu = tbNoiLuu.Text;
            ThongTinDAO.gI().TanSuat = (int)nudTanSuat.Value;
            ThongTinDAO.gI().SaveData();
            MessageBox.Show("Lưu thông tin thành công", "Thông báo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadThongTin();
        }

        private async void btCapNhatNhanVien_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(ThongTinDAO.gI().NoiLuu))
            {
                MessageBox.Show("Thư mục nơi lưu không tồn tại !", "Nhắc nhở");
                return;
            }
            if (MessageBox.Show("Xác nhận sao lưu dữ liệu ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                ThongTinDAO.gI().SaoLuuData();
                    MessageBox.Show("Sao lưu dữ liệu thành công !", "Thông báo");
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(tbInput.Text))
            {
                MessageBox.Show("File đầu vào không tồn tại !", "Nhắc nhở");
                return;
            }

            try
            {
                ThongTinDAO.gI().SaoLuuData();
                MessageBox.Show("Sao lưu dữ liệu thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
            }

            try
            {
                ThongTinDAO.gI().PhucHoiData(tbInput.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

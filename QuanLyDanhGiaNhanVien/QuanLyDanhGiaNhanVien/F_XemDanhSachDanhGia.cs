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
    public partial class F_XemDanhSachDanhGia : Form
    {
        public F_XemDanhSachDanhGia(string maNV)
        {
            InitializeComponent();
            LoadDS(maNV);
        }

        public void LoadDS(string maNV)
        {
            dgvDanhGia.Rows.Clear();
            int stt = 0;
            List<DanhGia> l = DanhGiaDAO.gI().getByMaNV(maNV);
            foreach (DanhGia i in l)
            {
                stt++;
                dgvDanhGia.Rows.Add(stt,i.MaDG, i.SoSao+"  Sao",i.NoiDung);
            }
        }

        private void dgvDanhGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ma = Convert.ToString(dgvDanhGia.Rows[e.RowIndex].Cells[1].Value);
            DanhGia i = DanhGiaDAO.gI().getByMa(ma);
            if (i == null)
                return;
            tbNoiDung.Text = i.NoiDung;
        }
    }
}

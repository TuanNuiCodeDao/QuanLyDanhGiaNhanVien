using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhGiaNhanVien.DTO
{
    public class QuyDinh
    {
        public string MaQD { get; set; }
        public string TieuDe { get; set; }
        public string ChiTiet { get; set; }
        public QuyDinh()
        {

        }
        public QuyDinh(string maQD, string tieuDe, string chiTiet)
        {
            this.MaQD = maQD;
            this.TieuDe = tieuDe;
            this.ChiTiet = chiTiet;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhGiaNhanVien.DTO
{
    public class ChucVu
    {
        public string MaCV { get; set; }
        public string TenCV { get; set; }
        public string GhiChu { get; set; }
        public ChucVu()
        {

        }
        public ChucVu(string maCV, string tenCV, string ghiChu)
        {
            this.MaCV = maCV;
            this.TenCV = tenCV;
            this.GhiChu = ghiChu;
        }
    }
}

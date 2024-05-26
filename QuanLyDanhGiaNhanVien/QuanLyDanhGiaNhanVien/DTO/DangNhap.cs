using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhGiaNhanVien.DTO
{
    public class DangNhap
    {
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string MaNV { get; set; }
        public bool TrangThai { get; set; }
        public bool IsAdmin { get; set; }
        public DangNhap() { 
            IsAdmin = false;
        }

        public DangNhap(string maNV,string taiKhoan, string matKhau, bool trangThai, bool isAdmin)
        {
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            MaNV = maNV;
            TrangThai = trangThai;
            IsAdmin = isAdmin;
        }
    }
}

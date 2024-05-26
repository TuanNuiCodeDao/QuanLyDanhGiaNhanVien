using QuanLyDanhGiaNhanVien.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhGiaNhanVien.DTO
{
    public class BenhNhan
    {
        public string MaBN { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public Image Anh { get; set; }
        public BenhNhan() { }
        public BenhNhan(string maBN,string hoTen, DateTime ngaySinh, bool gioiTinh, string sdt,string diaChi, Image anh)
        {
            this.MaBN = maBN;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.SDT = sdt;
            this.DiaChi = diaChi;
            this.Anh = anh;
        }
    }
}

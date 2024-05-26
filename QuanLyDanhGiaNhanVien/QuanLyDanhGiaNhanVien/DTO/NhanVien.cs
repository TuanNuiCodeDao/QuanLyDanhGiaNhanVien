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
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string MaCV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT { get; set; }
        public bool TrangThai { get; set; }
        public string DiaChi { get; set; }
        public Image Anh { get; set; }
        public int MaxSao{get; set;}
        public NhanVien() { }
        public NhanVien(string maNV, string maCV, string hoTen,DateTime ngaySinh,bool gioiTinh, string sdt,bool trangThai, string diaChi, Image anh,int maxSao)
        {
            this.MaNV = maNV;
            this.MaCV = maCV;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.GioiTinh= gioiTinh;
            this.SDT = sdt;
            this.TrangThai=trangThai;
            this.DiaChi = diaChi;
            this.Anh = anh;
            this.MaxSao=maxSao;
        }
    }
}

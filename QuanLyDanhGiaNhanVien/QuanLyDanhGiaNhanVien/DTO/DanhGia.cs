using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhGiaNhanVien.DTO
{
    public class DanhGia
    {
        public string MaDG { get; set; }
        public string MaDT { get; set; }
        public string MaNV { get; set; }
        public DateTime ThoiGian { get; set; }
        public int SoSao { get; set; }
        public string NoiDung { get; set; }

        public DanhGia() { }
        public DanhGia(string maDG,string maDT,string maNV,  DateTime thoiGian,int soSao,string noiDung)
        {
            this.MaDG=maDG;
            this.MaDT = maDT;
            this.MaNV = maNV;
            this.ThoiGian = thoiGian;
            this.SoSao = soSao;
            this.NoiDung = noiDung;
        }
    }
}

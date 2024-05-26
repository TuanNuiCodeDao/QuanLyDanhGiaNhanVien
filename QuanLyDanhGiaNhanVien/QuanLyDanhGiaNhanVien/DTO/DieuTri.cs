using QuanLyDanhGiaNhanVien.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDanhGiaNhanVien.DTO
{
    public class DieuTri
    {
        public string MaDT { get; set; }
        public string MaBN { get; set; }
        public List<string> ListMaNV { get; set; }
        public DateTime ThoiGianBD { get; set; }
        public DateTime ThoiGianKT { get; set; }

        public DieuTri() { }
        public DieuTri(string maDT,string maBN, List<string> listMaNV, DateTime thoiGianBD,DateTime thoiGianKT)
        {
            this.MaDT = maDT;
            this.MaBN = maBN;
            this.ListMaNV = listMaNV;
            this.ThoiGianBD = thoiGianBD;
            this.ThoiGianKT = thoiGianKT;
        }

        public string getMaNVSaveFile()
        {
            string s = "";
            foreach(string i in ListMaNV)
            {
                if (!string.IsNullOrEmpty(s)) s+= "|" ;
                s += i;
            }
            return s;
        }

        public bool IsDoneDanhGia()
        {
            int i = 0;
            for (i = 0; i < ListMaNV.Count; i++)
                if (DanhGiaDAO.gI().getByMaDT_NV(MaDT, ListMaNV[i]) == null) break;

            if (i < ListMaNV.Count) return false;

            return true;
        }

        public List<DanhGia> GetListDanhGia()
        {
            List<DanhGia>ldg=new List<DanhGia>();
            for (int i = 0; i < ListMaNV.Count; i++)
            {
                DanhGia dg = DanhGiaDAO.gI().getByMaDT_NV(MaDT, ListMaNV[i]);
                if(dg!=null) ldg.Add(dg);
            }
            return ldg;
        }

        public int getSoDanhGia()
        {
            int dem=0;
            for (int i = 0; i < ListMaNV.Count; i++)
            {
                if (DanhGiaDAO.gI().getByMaDT_NV(MaDT, ListMaNV[i]) != null) dem++;
            }

            return dem;
        }
    }
}

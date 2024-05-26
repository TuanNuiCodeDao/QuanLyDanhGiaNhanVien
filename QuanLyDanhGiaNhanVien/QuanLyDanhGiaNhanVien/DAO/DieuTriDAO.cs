using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using QuanLyDanhGiaNhanVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Math;

namespace QuanLyDanhGiaNhanVien.DAO
{
    public class DieuTriDAO
    {
        private static DieuTriDAO instance;
        public static List<DieuTri> L { get; set; }
        public DieuTriDAO()
        {
            loadData();
        }
        public static DieuTriDAO gI()
        {
            if (instance == null) instance = new DieuTriDAO();
            return instance;
        }
        public void saveData()
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    string filepath = DataProvider.PathSave + "\\DieuTri.xlsx";
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Điều trị");

                    for (int i = 0; i < L.Count; i++)
                    {
                        worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(L[i].MaDT) ? DataProvider.GetStringMaHoa(L[i].MaDT) : "null";
                        worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(L[i].MaBN) ? DataProvider.GetStringMaHoa(L[i].MaBN) : "null";
                        worksheet.Cells[i + 1, 3].Value = DataProvider.GetStringMaHoa(L[i].getMaNVSaveFile());
                        worksheet.Cells[i + 1, 4].Value = L[i].ThoiGianBD != null ? DataProvider.GetStringMaHoa(L[i].ThoiGianBD.ToString("dd/MM/yyyy HH:mm:ss")) : "null";
                        worksheet.Cells[i + 1, 5].Value = L[i].ThoiGianKT != null ? DataProvider.GetStringMaHoa(L[i].ThoiGianKT.ToString("dd/MM/yyyy HH:mm:ss")) : "null";
                    }

                    package.SaveAs(new FileInfo(filepath));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu data thất bại: " + ex.ToString(), "Thông báo");
            }
        }

        private void loadData()
        {
            L = new List<DieuTri>();
            string filepath = DataProvider.PathSave + "\\DieuTri.xlsx";
            if (!File.Exists(filepath)) saveData();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filepath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet != null&& worksheet.Dimension!=null)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        L.Clear();

                        for (int row = 1; row <= rowCount; row++)
                        {
                            string maDT = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 1].GetValue<string>());
                            string maBN = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 2].GetValue<string>());
                            string sMaNV = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 3].GetValue<string>());
                            List<string> listMaNV = sMaNV.Split(new string[] { "|" }, StringSplitOptions.None).ToList();
                            DateTime thoiGianBD = DateTime.Parse(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 4].GetValue<string>()));
                            DateTime thoiGianKT = DateTime.Parse(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 5].GetValue<string>()));
                            L.Add(new DieuTri(maDT, maBN, listMaNV, thoiGianBD, thoiGianKT));
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("Không tìm thấy dữ liệu trong tệp data đánh giá", "Thông báo");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu thất bại: " + ex.ToString(), "Thông báo");
            }
        }
        public List<DieuTri> loadDS()
        {
            return L;
        }

        public List<DieuTri> loadByMaBN(string maBN)
        {
            List<DieuTri> l = new List<DieuTri>();
            foreach (DieuTri item in L)
            {
                if (item.MaBN == maBN)
                {
                    if (l.Count == 0) l.Add(item);
                    else
                    {
                        int i = 0;
                        for (i = 0; i < l.Count; i++)
                            if (l[i].ThoiGianBD > item.ThoiGianBD)
                                break;
                        if (i == l.Count) l.Add(item);
                        else l.Insert(i, item);
                    }
                }
            }
            return l;
        }
        public List<DieuTri> loadByMaBN_ChuaDone(string maBN)
        {
            List<DieuTri> l = new List<DieuTri>();
            foreach (DieuTri item in L)
            {
                if (item.MaBN == maBN && !item.IsDoneDanhGia())
                {
                    if (l.Count == 0) l.Add(item);
                    else
                    {
                        int i = 0;
                        for (i = 0; i < l.Count; i++)
                            if (l[i].ThoiGianBD > item.ThoiGianBD)
                                break;
                        if (i == l.Count) l.Add(item);
                        else l.Insert(i, item);
                    }
                }
            }
            return l;
        }

        public void SaveDS(List<DieuTri> newList)
        {
            L = newList;
            saveData();
        }


        public List<DieuTri> loadByThoiGian(DateTime thoiGian)
        {
            return L.FindAll(d=>d.ThoiGianBD.Year==thoiGian.Year && d.ThoiGianBD.Month==thoiGian.Month && d.ThoiGianBD.Day == thoiGian.Day);
        }

        public List<DieuTri> loadByMaNV_ThoiGian(string maNV,DateTime thoiGian)
        {
            return L.FindAll(d =>d.ListMaNV.Contains(maNV)&& d.ThoiGianBD.Year == thoiGian.Year && d.ThoiGianBD.Month == thoiGian.Month && d.ThoiGianBD.Day == thoiGian.Day);
        }

        public List<DieuTri> loadByMaNV_ChuaDanhGia(string maNV)
        {
            List<DieuTri> l = new List<DieuTri>();
            DateTime date = DateTime.Now;
            foreach (DieuTri item in L)
            {
                if (item.ListMaNV.Contains(maNV) && item.ThoiGianKT<date)
                {
                    if (DanhGiaDAO.gI().getByMaDT_NV(item.MaDT,maNV) == null) l.Add(item);
                }
            }
            return l;
        }

        public List<DieuTri> loadByMaBN_ChuaDanhGia(string maBN)
        {
            List<DieuTri> l = new List<DieuTri>();
            DateTime date = DateTime.Now;
            foreach (DieuTri item in L)
            {
                if (item.MaBN == maBN && item.ThoiGianKT < date)
                {
                    int i=0;
                    for (i = 0; i < item.ListMaNV.Count; i++)
                        if (DanhGiaDAO.gI().getByMaDT_NV(item.MaDT, item.ListMaNV[i]) == null) break;

                    if(i< item.ListMaNV.Count) l.Add(item);
                }
            }
            return l;
        }

        public List<DieuTri> loadByMaNV_BN_ChuaDanhGia(string maNV,string maBN)
        {
            List<DieuTri> l = new List<DieuTri>();
            DateTime date = DateTime.Now;
            foreach (DieuTri item in L)
            {
                if (item.MaBN == maBN &&item.ListMaNV.Contains(maNV) && item.ThoiGianKT < date)
                {
                    if (DanhGiaDAO.gI().getByMaDT_NV(item.MaDT, maNV) == null) l.Add(item);
                }
            }
            return l;
        }

        public List<DieuTri> loadByMaNV(string maNV)
        {
            List<DieuTri> l = new List<DieuTri>();
            foreach (DieuTri item in L)
            {
                if (item.ListMaNV.Contains(maNV))
                {
                    if (l.Count == 0) l.Add(item);
                    else
                    {
                        int i = 0;
                        for (i = 0; i < l.Count; i++)
                            if (l[i].ThoiGianBD > item.ThoiGianBD)
                                break;
                        if (i == l.Count) l.Add(item);
                        else l.Insert(i, item);
                    }
                }
            }
            return l;
        }

        public List<DieuTri> loadDSTheoNamThang(int nam, int thang)
        {
            List<DieuTri> l = new List<DieuTri>();
            foreach (DieuTri item in L)
            {
                if (item.ThoiGianBD.Year == nam && item.ThoiGianBD.Month == thang)
                    l.Add(item);
            }
            return l;
        }

        public List<DieuTri> loadDSTheoNamThang_NV(string maNV,int nam, int thang)
        {
            List<DieuTri> l = new List<DieuTri>();
            foreach (DieuTri item in L)
            {
                if (item.ListMaNV.Contains(maNV)&&item.ThoiGianBD.Year == nam && item.ThoiGianBD.Month == thang)
                    l.Add(item);
            }
            return l;
        }

        public DieuTri getByMa(string ma)
        {
            foreach (DieuTri item in L)
            {
                if (item.MaDT == ma) return item;
            }
            return null;
        }

        public string getNewMa()
        {
            if (L.Count == 0) return "DT00001";

            int ma = int.Parse(L[L.Count - 1].MaDT.Substring(2, 5)) + 1;
            if (ma < 10) return "DT0000" + ma;
            if (ma < 100) return "DT000" + ma;
            if (ma < 1000) return "DT00" + ma;
            if (ma < 10000) return "DT0" + ma;
            return "DT" + ma;
        }

        public void them(DieuTri i)
        {
            i.MaDT = getNewMa();
            L.Add(i);
            saveData();
        }
        public void xoa(string ma)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaDT == ma)
                {
                    DanhGiaDAO.gI().xoaByMaDT(ma);
                    L.RemoveAt(i);
                    saveData();
                    break;
                }
            }
        }
        public void resetData()
        {
            L.Clear();
            saveData();
        }

        public void xoaByMaNV(string maNV)
        {
            bool check = false;
            DanhGiaDAO.gI().xoaByMaNV(maNV);
            for (int i = L.Count - 1; i >= 0; i--)
            {
                if (L[i].ListMaNV.Contains(maNV))
                {
                    L[i].ListMaNV.Remove(maNV);
                    check = true;
                }
                if (L[i].ListMaNV.Count == 0)
                {
                    L.RemoveAt(i);
                    check = true;
                }
            }
            if (check) saveData();
        }

        public void xoaByMaBN(string maBN)
        {
            bool check = false;
            for (int i = L.Count - 1; i >= 0; i--)
            {
                if (L[i].MaBN == maBN)
                {
                    DanhGiaDAO.gI().xoaByMaDT(L[i].MaDT);
                    check = true;
                    L.RemoveAt(i);
                }
            }
            if (check) saveData();
        }

        public void sua(DieuTri e)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaDT == e.MaDT)
                {
                    L[i] = e;
                    saveData();
                    break;
                }
            }
        }
    }
}

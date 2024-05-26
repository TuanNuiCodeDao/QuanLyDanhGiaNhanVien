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
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace QuanLyDanhGiaNhanVien.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;
        public static List<NhanVien> L { get; set; }
        public NhanVienDAO() { 
            loadData();
        }
        public static NhanVienDAO gI()
        {
            if (instance == null) instance = new NhanVienDAO();
            return instance;
        }

        public void saveData()
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    string filepath = DataProvider.PathSave + "\\NhanVien.xlsx";
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Nhân viên");

                    for (int i = 0; i < L.Count; i++)
                    {
                        worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(L[i].MaNV) ? DataProvider.GetStringMaHoa(L[i].MaNV) : "null";
                        worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(L[i].MaCV) ? DataProvider.GetStringMaHoa(L[i].MaCV) : "null";
                        worksheet.Cells[i + 1, 3].Value = !String.IsNullOrEmpty(L[i].HoTen) ? DataProvider.GetStringMaHoa(L[i].HoTen) : "null";
                        worksheet.Cells[i + 1, 4].Value = L[i].NgaySinh != null ? DataProvider.GetStringMaHoa(L[i].NgaySinh.ToString("dd/MM/yyyy HH:mm:ss")) : "null";
                        worksheet.Cells[i + 1, 5].Value = L[i].GioiTinh != null ? DataProvider.GetStringMaHoa(L[i].GioiTinh ? "1" : "0") : "null";
                        worksheet.Cells[i + 1, 6].Value = !String.IsNullOrEmpty(L[i].SDT) ? DataProvider.GetStringMaHoa(L[i].SDT) : "null";
                        worksheet.Cells[i + 1, 7].Value = L[i].TrangThai != null ? DataProvider.GetStringMaHoa(L[i].TrangThai ? "1" : "0") : "null";
                        worksheet.Cells[i + 1, 8].Value = !String.IsNullOrEmpty(L[i].DiaChi) ? DataProvider.GetStringMaHoa(L[i].DiaChi) : "null";
                        if (L[i].Anh != null)
                        {
                            ExcelRichTextCollection richTextCollection = worksheet.Cells[i + 1, 9].RichText;
                            ExcelRichText richText = richTextCollection.Add(DataProvider.GetStringMaHoa(DataProvider.gI().getStringImage(L[i].Anh)));
                        }
                        else
                        {
                            worksheet.Cells[i + 1, 9].Value = "null";
                        }
                        worksheet.Cells[i + 1, 10].Value = DataProvider.GetStringMaHoa(L[i].MaxSao + "");
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
            L = new List<NhanVien>();
            string filepath = DataProvider.PathSave + "\\NhanVien.xlsx";
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
                            string maNV = worksheet.Cells[row, 1].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 1].GetValue<string>());
                            string maCV = worksheet.Cells[row, 2].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 2].GetValue<string>());
                            string hoTen = worksheet.Cells[row, 3].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 3].GetValue<string>());
                            DateTime ngaySinh = DateTime.Parse(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 4].GetValue<string>()));
                            bool gioiTinh = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 5].GetValue<string>()) == "1" ? true : false;
                            string sdt = worksheet.Cells[row, 6].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 6].GetValue<string>());
                            bool trangThai = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row,7].GetValue<string>()) == "1" ? true : false;
                            string diaChi = worksheet.Cells[row, 8].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 8].GetValue<string>());
                            int maxSao = int.Parse( DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 10].GetValue<string>()));
                            L.Add(new NhanVien(maNV,maCV, hoTen, ngaySinh, gioiTinh, sdt, trangThai, diaChi, DataProvider.gI().getImageFromByteString(worksheet.Cells[row, 9].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 9].GetValue<string>())),maxSao));
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("Không tìm thấy dữ liệu trong tệp data nhân viên", "Thông báo");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu thất bại: " + ex.ToString(), "Thông báo");
            }
        }
        public void resetData()
        {
            L.Clear();
            saveData();
        }

        public void SaveDS(List<NhanVien> newList)
        {
            L = newList;
            saveData();
        }

        public List<NhanVien> loadDSTimKiem(string tuKhoa)
        {
            List<NhanVien> l = new List<NhanVien>();
            foreach (NhanVien i in L)
            {
                if (i.MaNV.Contains(tuKhoa) || i.HoTen.Contains(tuKhoa) || i.SDT.Contains(tuKhoa) || i.DiaChi.Contains(tuKhoa))
                    l.Add(i);
            }

            return l;
        }

        public List<NhanVien> loadDSTimKiemOn(string tuKhoa)
        {
            List<NhanVien> l = new List<NhanVien>();
            foreach (NhanVien i in L)
            {
                if (i.TrangThai&&(i.MaNV.Contains(tuKhoa) || i.HoTen.Contains(tuKhoa) || i.SDT.Contains(tuKhoa) || i.DiaChi.Contains(tuKhoa)))
                    l.Add(i);
            }

            return l;
        }

        public  List<NhanVien> loadDS()
        {
            return L;
        }

        public  List<NhanVien> loadDSByMaChucVu(string maCV)
        {
            List<NhanVien> l = new List<NhanVien>();
            foreach (NhanVien i in L)
            {
                if (i.MaCV==maCV)
                    l.Add(i);
            }

            return l;
        }

        public  NhanVien getNhanVienByMa(string ma)
        {
            foreach (NhanVien i in L)
            {
                if (i.MaNV == ma) return i;
            }
            return null;
        }
        public  NhanVien getNhanVienBySDT(string sdt)
        {
            foreach (NhanVien i in L)
            {
                if (i.SDT == sdt) return i;
            }
            return null;
        }
        public string getNewMa()
        {
            if (L.Count == 0) return "NV0001";

            int ma = int.Parse(L[L.Count - 1].MaNV.Substring(2, 4)) + 1;
            if (ma < 10) return "NV000" + ma;
            if (ma < 100) return "NV00" + ma;
            if (ma < 1000) return "NV0" + ma;
            return "NV" + ma;
        }

        public void them(NhanVien i)
        {
            i.MaNV = getNewMa();
            L.Add(i);
            saveData();
            NhanVien nv = getNhanVienBySDT(i.SDT);
            DangNhapDAO.gI().them(nv);
        }

        public void xoaByMaCV(string maCV)
        {
            bool check = false;
            for(int i=L.Count-1; i >= 0; i--)
            {
                if (L[i].MaCV == maCV)
                {
                    DangNhapDAO.gI().xoaByMaNV(L[i].MaNV);
                    DieuTriDAO.gI().xoaByMaNV(L[i].MaNV);
                    check = true;
                    L.RemoveAt(i);
                }
            }
            if (check) saveData();
        }
        public void xoa(string ma)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaNV == ma)
                {
                    L.RemoveAt(i);
                    saveData();
                    DangNhapDAO.gI().xoaByMaNV(ma);
                    break;
                }
            }
        }

        public void sua(NhanVien e)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaNV == e.MaNV)
                {
                    L[i] = e;
                    saveData();
                    break;
                }
            }
        }

        public void voHieu(string maNV)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaNV == maNV)
                {
                    L[i].TrangThai=false;
                    saveData();
                    DangNhapDAO.gI().voHieu(maNV);
                    break;
                }
            }
        }

        public void moKhoa(string maNV)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaNV == maNV)
                {
                    L[i].TrangThai = true;
                    saveData();
                    DangNhapDAO.gI().moKhoa(maNV);
                    break;
                }
            }
        }
    }
}

using OfficeOpenXml.Style;
using OfficeOpenXml;
using QuanLyDanhGiaNhanVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;

namespace QuanLyDanhGiaNhanVien.DAO
{
    public class DangNhapDAO
    {
        private static DangNhapDAO instance;
        public static List<DangNhap> L { get; set; }
        public DangNhapDAO()
        {
            loadData();
        }
        public static DangNhapDAO gI()
        {
            if (instance == null) instance = new DangNhapDAO();
            return instance;
        }

        public List<DangNhap> loadDS() {
            return L;
        }

        void saveDataInit()
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    string filepath = DataProvider.PathSave + "\\DangNhap.xlsx";
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("DangNhap");

                    worksheet.Cells[1, 1].Value = DataProvider.GetStringMaHoa("admin");
                    worksheet.Cells[1, 2].Value = DataProvider.GetStringMaHoa("admin");
                    worksheet.Cells[1, 3].Value = DataProvider.GetStringMaHoa("1234");
                    worksheet.Cells[1, 4].Value = DataProvider.GetStringMaHoa("1");
                    worksheet.Cells[1, 5].Value = DataProvider.GetStringMaHoa("1");

                    package.SaveAs(new FileInfo(filepath));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu data thất bại: " + ex.ToString(), "Thông báo");
            }
        }

        public void saveData()
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    string filepath = DataProvider.PathSave + "\\DangNhap.xlsx";
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("DangNhap");

                    for (int i = 0; i < L.Count; i++)
                        {
                            worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(L[i].MaNV) ? DataProvider.GetStringMaHoa(L[i].MaNV) : "null";
                            worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(L[i].TaiKhoan) ? DataProvider.GetStringMaHoa(L[i].TaiKhoan) : "null";
                            worksheet.Cells[i + 1, 3].Value = !String.IsNullOrEmpty(L[i].MatKhau) ? DataProvider.GetStringMaHoa(L[i].MatKhau) : "null";
                            worksheet.Cells[i + 1, 4].Value = L[i].TrangThai != null ? DataProvider.GetStringMaHoa(L[i].TrangThai ? "1" : "0") : "null";
                            worksheet.Cells[i + 1, 5].Value = L[i].IsAdmin != null ? DataProvider.GetStringMaHoa(L[i].IsAdmin ? "1" : "0") : "null";
                        }

                    package.SaveAs(new FileInfo(filepath));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu data thất bại: " + ex.ToString(), "Thông báo");
            }
        }

        public void SaveDS(List<DangNhap> newList)
        {
            L = newList;
            if (L.Count < 1) L.Add(new DangNhap("admin", "admin", "1234", true, true));
            saveData();
        }

        public void resetData()
        {
            L.Clear();
            for(int i=L.Count-1; i>0; i--)
            {
                L.RemoveAt(i);
            }
            saveData();
        }

        private void loadData()
        {
            L = new List<DangNhap>();
            string filepath = DataProvider.PathSave + "\\DangNhap.xlsx";
            if (!File.Exists(filepath)) saveDataInit();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(new FileInfo(filepath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet != null && worksheet.Dimension != null)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        L.Clear();

                        for (int row = 1; row <= rowCount; row++)
                        {
                            string maNV = worksheet.Cells[row, 1].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 1].GetValue<string>());
                            string taiKhoan = worksheet.Cells[row, 2].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 2].GetValue<string>());
                            string matKhau = worksheet.Cells[row, 3].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 3].GetValue<string>());
                            bool trangThai = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 4].GetValue<string>()) == "1";
                            bool isAdmin = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 5].GetValue<string>()) == "1";
                            L.Add(new DangNhap(maNV, taiKhoan, matKhau, trangThai, isAdmin));
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("Không tìm thấy dữ liệu trong tệp data đăng nhập", "Thông báo");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu thất bại: " + ex.ToString(), "Thông báo");
            }
        }

        public DangNhap getByTaiKhoan(string taiKhoan)
        {
            
            foreach (DangNhap dangNhap in L)
            {
                if (dangNhap.TaiKhoan == taiKhoan) return dangNhap;
            }
            return null;
        }
        public DangNhap getByTaiKhoanMatKhau(string taiKhoan, string matKhau)
        {
            foreach (DangNhap dangNhap in L)
            {
               // MessageBox.Show(dangNhap.MatKhau);
                if (dangNhap.TaiKhoan == taiKhoan && dangNhap.MatKhau == matKhau) return dangNhap;
            }
            return null;
        }
        public DangNhap getByMaNV(string maNV)
        {
            foreach (DangNhap dangNhap in L)
            {
                if (dangNhap.MaNV == maNV) return dangNhap;
            }
            return null;
        }
        public string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            text = text.Replace(" ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        private string getTaiKhoan(string ten)
        {
            ten = ConvertToUnSign(ten);
            string tk = "";
            ten = ten.ToLower();
            for (int i = 0; i < ten.Length; i++)
                if (ten[i] >= 'a' && ten[i] <= 'z')
                {
                    tk += ten[i];
                }
            int j = 1;
            while (getByTaiKhoan(tk + j) != null)
                j++;
            tk += j;
            return tk;
        }
        public void them(NhanVien nv)
        {
            L.Add(new DangNhap(nv.MaNV,getTaiKhoan(nv.HoTen), "1234", true, false));
            saveData();
        }

        public void xoaByMaNV(string maNV)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaNV == maNV)
                {
                    L.RemoveAt(i);
                    saveData();
                    break;
                }
            }
        }

        public void suaByTaiKhoan(string taiKhoan, string matKhau, string tkCu)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].TaiKhoan == tkCu)
                {
                    L[i].TaiKhoan = taiKhoan;
                    L[i].MatKhau = matKhau;
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
                    L[i].TrangThai = false;
                    saveData();
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
                    break;
                }
            }
        }
    }
}

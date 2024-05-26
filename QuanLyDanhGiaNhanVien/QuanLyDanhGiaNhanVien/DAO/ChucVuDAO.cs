using OfficeOpenXml.Style;
using OfficeOpenXml;
using QuanLyDanhGiaBenhNhan.DAO;
using QuanLyDanhGiaNhanVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDanhGiaNhanVien.DAO
{
    public class ChucVuDAO
    {
        private static ChucVuDAO instance;
        public static List<ChucVu> L { get; set; }
        public ChucVuDAO()
        {
            loadData();
        }
        public static ChucVuDAO gI()
        {
            if (instance == null) instance = new ChucVuDAO();
            return instance;
        }
        public void resetData()
        {
            L.Clear();
            saveData();
        }

        public void SaveDS(List<ChucVu> newList)
        {
            L = newList;
            saveData();
        }
        public void saveData()
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    string filepath = DataProvider.PathSave + "\\ChucVu.xlsx";
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Chức vụ");

                    for (int i = 0; i < L.Count; i++)
                    {
                        worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(L[i].MaCV) ? DataProvider.GetStringMaHoa(L[i].MaCV) : "null";
                        worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(L[i].TenCV) ? DataProvider.GetStringMaHoa(L[i].TenCV) : "null";

                        if (!String.IsNullOrEmpty(L[i].GhiChu))
                        {
                            ExcelRichTextCollection richTextCollection = worksheet.Cells[i + 1, 3].RichText;
                            ExcelRichText richText = richTextCollection.Add(DataProvider.GetStringMaHoa(L[i].GhiChu));
                        }
                        else
                        {
                            worksheet.Cells[i + 1, 3].Value = "null";
                        }
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
            L = new List<ChucVu>();
            string filepath = DataProvider.PathSave + "\\ChucVu.xlsx";
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
                            string ma = worksheet.Cells[row, 1].Value==null?"": DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 1].GetValue<string>());
                            string ten = worksheet.Cells[row, 2].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 2].GetValue<string>());
                            string ghiChu = worksheet.Cells[row, 3].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 3].GetValue<string>());
                            
                            L.Add(new ChucVu(ma,ten,ghiChu));
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("Không tìm thấy dữ liệu trong tệp data chức vụ", "Thông báo");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu thất bại: " + ex.ToString(), "Thông báo");
            }
        }

        public string getNewMa()
        {
            if (L.Count == 0) return "CV001";

            int ma = int.Parse(L[L.Count - 1].MaCV.Substring(2, 3)) + 1;
            if (ma < 10) return "CV00" + ma;
            if (ma < 100) return "CV0" + ma;
            return "CV" + ma;
        }

        public void them(ChucVu i)
        {
            i.MaCV = getNewMa();
            L.Add(i);
            saveData();
        }
        public void xoa(string ma)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaCV == ma)
                {
                    L.RemoveAt(i);
                    saveData();
                    NhanVienDAO.gI().xoaByMaCV(ma);
                    break;
                }
            }
        }

        public void sua(ChucVu cv)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaCV == cv.MaCV)
                {
                    L[i] = cv;
                    saveData();
                    break;
                }
            }
        }

        public  List<ChucVu> loadDS()
        {
            return L;
        }
        public ChucVu getByMa(string ma)
        {
            foreach (ChucVu i in L)
            {
                if (i.MaCV == ma) return i;
            }

            return null;
        }
        public ChucVu getByTen(string tenCV)
        {
            foreach (ChucVu i in L)
            {
                if (i.TenCV == tenCV) return i;
            }

            return null;
        }
    }
}

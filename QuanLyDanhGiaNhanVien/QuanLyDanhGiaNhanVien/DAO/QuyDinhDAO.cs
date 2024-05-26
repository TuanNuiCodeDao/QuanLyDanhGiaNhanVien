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

namespace QuanLyDanhGiaNhanVien.DAO
{
    public class QuyDinhDAO
    {
        private static QuyDinhDAO instance;
        public static List<QuyDinh> L { get; set; }
        public QuyDinhDAO() { 
            loadData();
        }
        public static QuyDinhDAO gI()
        {
            if (instance == null) instance = new QuyDinhDAO();
            return instance;
        }
        public void saveData()
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    string filepath = DataProvider.PathSave + "\\QuyDinh.xlsx";
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Quy định");

                    for (int i = 0; i < L.Count; i++)
                    {
                        worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(L[i].MaQD) ? DataProvider.GetStringMaHoa(L[i].MaQD) : "null";
                        worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(L[i].TieuDe) ? DataProvider.GetStringMaHoa(L[i].TieuDe) : "null";

                        if (!String.IsNullOrEmpty(L[i].ChiTiet))
                        {
                            ExcelRichTextCollection richTextCollection = worksheet.Cells[i + 1, 3].RichText;
                            ExcelRichText richText = richTextCollection.Add(DataProvider.GetStringMaHoa(L[i].ChiTiet));
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
        public void resetData()
        {
            L.Clear();
            saveData();
        }

        public void SaveDS(List<QuyDinh> newList)
        {
            L = newList;
            saveData();
        }

        private void loadData()
        {
            L = new List<QuyDinh>();
            string filepath = DataProvider.PathSave + "\\QuyDinh.xlsx";
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
                            string ma = worksheet.Cells[row, 1].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 1].GetValue<string>());
                            string ten = worksheet.Cells[row, 2].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 2].GetValue<string>());
                            string noiDung = worksheet.Cells[row,3].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 3].GetValue<string>());
                            L.Add(new QuyDinh(ma, ten, noiDung));
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

        public List<QuyDinh> loadDS()
        {
            return L;
        }
        public List<QuyDinh> loadDSTimKiem(string tuKhoa)
        {
            List<QuyDinh> l = new List<QuyDinh>();
            foreach (QuyDinh i in L)
            {
                if (i.MaQD.Contains(tuKhoa) || i.TieuDe.Contains(tuKhoa) || i.ChiTiet.Contains(tuKhoa))
                    l.Add(i);
            }

            return l;
        }
        
        public QuyDinh getByMa(string MaQD)
        {
            foreach (QuyDinh i in L)
            {
                if (i.MaQD == MaQD) return i;
            }
            return null;
        }
        public QuyDinh getByTieuDe(string tenQD)
        {
            foreach (QuyDinh i in L)
            {
                if (i.TieuDe == tenQD) return i;
            }
            return null;
        }
        public string getNewMa()
        {
            if (L.Count == 0) return "QD001";

            int ma = int.Parse(L[L.Count - 1].MaQD.Substring(2, 3)) + 1;
            if (ma < 10) return "QD00" + ma;
            if (ma < 100) return "QD0" + ma;
            return "QD" + ma;
        }

        public void them(QuyDinh i)
        {
            i.MaQD = getNewMa();
            L.Add(i);
            saveData();
        }
        public void xoa(string ma)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaQD == ma)
                {
                    L.RemoveAt(i);
                    saveData();
                    break;
                }
            }
        }

        public void sua(QuyDinh item)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaQD == item.MaQD)
                {
                    L[i] = item;
                    saveData();
                    break;
                }
            }
        }
    }
}

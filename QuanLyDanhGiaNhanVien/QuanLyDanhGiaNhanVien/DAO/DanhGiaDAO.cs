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
    public class DanhGiaDAO
    {
        private static DanhGiaDAO instance;
        public static List<DanhGia> L { get; set; }
        public DanhGiaDAO() {
            loadData();
        }
        public static DanhGiaDAO gI()
        {
            if (instance == null) instance = new DanhGiaDAO();
            return instance;
        }
        public void resetData()
        {
            L.Clear();
            saveData();
        }
        public List<DanhGia> loadDS()
        {
            return L;
        }

        public List<DanhGia> getByMaNV(string maNV)
        {
            return L.FindAll(d => d.MaNV == maNV);
        }

        public DanhGia getByMa(string ma)
        {
            return L.Find(d => d.MaDG == ma);
        }

        public DanhGia getByMaDT_NV(string maDT,string maNV)
        {
            return L.Find(d => d.MaDT == maDT && d.MaNV==maNV);
        }

        public void saveData()
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    string filepath = DataProvider.PathSave + "\\DanhGia.xlsx";
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Đánh giá");

                    for (int i = 0; i < L.Count; i++)
                    {
                        worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(L[i].MaDG) ? DataProvider.GetStringMaHoa(L[i].MaDG) : "null";
                        worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(L[i].MaDT) ? DataProvider.GetStringMaHoa(L[i].MaDT) : "null";
                        worksheet.Cells[i + 1, 3].Value = !String.IsNullOrEmpty(L[i].MaNV) ? DataProvider.GetStringMaHoa(L[i].MaNV) : "null";
                        worksheet.Cells[i + 1, 4].Value = L[i].ThoiGian != null ? DataProvider.GetStringMaHoa(L[i].ThoiGian.ToString("dd/MM/yyyy HH:mm:ss")) : "null";
                        worksheet.Cells[i + 1, 5].Value = !String.IsNullOrEmpty(L[i].SoSao.ToString()) ? DataProvider.GetStringMaHoa(L[i].SoSao.ToString()) : "null";

                        if (!String.IsNullOrEmpty(L[i].NoiDung))
                        {
                            ExcelRichTextCollection richTextCollection = worksheet.Cells[i + 1, 6].RichText;
                            ExcelRichText richText = richTextCollection.Add(DataProvider.GetStringMaHoa(L[i].NoiDung));
                        }
                        else
                        {
                            worksheet.Cells[i + 1, 6].Value = "null";
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
            L = new List<DanhGia>();
            string filepath = DataProvider.PathSave + "\\DanhGia.xlsx";
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
                            string maDG = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 1].GetValue<string>());
                            string maDT = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 2].GetValue<string>());
                            string maNV = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 3].GetValue<string>());
                            DateTime thoiGian = DateTime.Parse(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 4].GetValue<string>()));
                            int soSao =int.Parse( DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 5].GetValue<string>()));
                            string noiDung = worksheet.Cells[row, 6] == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 6].GetValue<string>());
                            L.Add(new DanhGia(maDG, maDT, maNV, thoiGian,soSao, noiDung));
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

        public string getNewMa()
        {
            if (L.Count == 0) return "DG00001";

            int ma = int.Parse(L[L.Count - 1].MaDG.Substring(2, 5)) + 1;
            if (ma < 10) return "DG0000" + ma;
            if (ma < 100) return "DG000" + ma;
            if (ma < 1000) return "DG00" + ma;
            if (ma < 1000) return "DG0" + ma;
            return "DG" + ma;
        }

        public void them(DanhGia i)
        {
            i.MaDG = getNewMa();
            L.Add(i);
            saveData();
        }
        public void xoa(string ma)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaDG == ma)
                {
                    L.RemoveAt(i);
                    saveData();
                    break;
                }
            }
        }

        public void xoaByMaDT(string maDT)
        {
            bool check = false;
            for (int i = L.Count - 1; i >= 0; i--)
            {
                if (L[i].MaDT == maDT)
                {
                    check = true;
                    L.RemoveAt(i);
                }
            }
            if (check) saveData();
        }

        public void xoaByMaNV(string maNV)
        {
            bool check = false;
            for (int i = L.Count - 1; i >= 0; i--)
            {
                if (L[i].MaNV == maNV)
                {
                    check = true;
                    L.RemoveAt(i);
                }
            }
            if (check) saveData();
        }

        public void sua(DanhGia e)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaDG == e.MaDG)
                {
                    L[i] = e;
                    saveData();
                    break;
                }
            }
        }

        public void SaveDS(List<DanhGia> newList)
        {
            L = newList;
            saveData();
        }
    }
}

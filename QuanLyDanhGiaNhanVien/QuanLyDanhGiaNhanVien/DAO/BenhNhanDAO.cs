using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuanLyDanhGiaNhanVien.DAO;
using QuanLyDanhGiaNhanVien.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyDanhGiaBenhNhan.DAO
{
    public class BenhNhanDAO
    {
        private static BenhNhanDAO instance;
        public static List<BenhNhan> L { get; set; }
        public BenhNhanDAO() {
            loadData();
        }
        public static BenhNhanDAO gI()
        {
            if (instance == null) instance = new BenhNhanDAO();
            return instance;
        }

        public void saveData()
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    string filepath = DataProvider.PathSave + "\\BenhNhan.xlsx";
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Bệnh nhân");

                    for (int i = 0; i < L.Count; i++)
                    {
                        worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(L[i].MaBN) ? DataProvider.GetStringMaHoa(L[i].MaBN) : "null";
                        worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(L[i].HoTen) ? DataProvider.GetStringMaHoa(L[i].HoTen) : "null";
                        worksheet.Cells[i + 1, 3].Value = L[i].NgaySinh != null ? DataProvider.GetStringMaHoa(L[i].NgaySinh.ToString("dd/MM/yyyy HH:mm:ss")) : "null";
                        worksheet.Cells[i + 1, 4].Value = L[i].GioiTinh != null ? DataProvider.GetStringMaHoa(L[i].GioiTinh ? "1" : "0") : "null";
                        worksheet.Cells[i + 1, 5].Value = !String.IsNullOrEmpty(L[i].SDT) ? DataProvider.GetStringMaHoa(L[i].SDT) : "null";
                        worksheet.Cells[i + 1, 6].Value = !String.IsNullOrEmpty(L[i].DiaChi) ? DataProvider.GetStringMaHoa(L[i].DiaChi) : "null";

                        if (L[i].Anh != null)
                        {
                            ExcelRichTextCollection richTextCollection = worksheet.Cells[i + 1, 7].RichText;
                            ExcelRichText richText = richTextCollection.Add(DataProvider.GetStringMaHoa(DataProvider.gI().getStringImage(L[i].Anh)));
                        }
                        else
                        {
                            worksheet.Cells[i + 1, 7].Value = "null";
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
            L = new List<BenhNhan>();
            string filepath = DataProvider.PathSave + "\\BenhNhan.xlsx";
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
                            string maBN = worksheet.Cells[row, 1].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 1].GetValue<string>());
                            string hoTen = worksheet.Cells[row, 2].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 2].GetValue<string>());
                            DateTime ngaySinh =DateTime.Parse(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 3].GetValue<string>()));
                            bool gioiTinh = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 4].GetValue<string>()) == "1" ? true : false;
                            string sdt = worksheet.Cells[row, 5].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 5].GetValue<string>());
                            string diaChi = worksheet.Cells[row,6].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 6].GetValue<string>());
                            BenhNhan benhNhan = new BenhNhan(maBN, hoTen, ngaySinh, gioiTinh, sdt, diaChi, DataProvider.gI().getImageFromByteString(worksheet.Cells[row, 7].Value == null ? "" : DataProvider.GetStringGiaiMaHoa(worksheet.Cells[row, 7].GetValue<string>())));
                            L.Add(benhNhan);
                        }
                    }
                    //else
                    //{
                    //    MessageBox.Show("Không tìm thấy dữ liệu trong tệp data bệnh nhân", "Thông báo");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu thất bại: " + ex.ToString(), "Thông báo");
            }
        }


        public List<BenhNhan> loadDSTimKiem(string tuKhoa)
        {
            List<BenhNhan> l = new List<BenhNhan>();
            foreach (BenhNhan i in L)
            {
                if(i.MaBN.Contains(tuKhoa) || i.HoTen.Contains(tuKhoa)||i.SDT.Contains(tuKhoa)||i.DiaChi.Contains(tuKhoa))
                l.Add(i);
            }

            return l;
        }

        public List<BenhNhan> loadDS()
        {
            return L;
        }

        public void resetData()
        {
            L.Clear();
            saveData();
        }

        public void SaveDS(List<BenhNhan> newList)
        {
            L = newList;
            saveData();
        }

        public BenhNhan getBenhNhanByMa(string ma)
        {
            foreach (BenhNhan i in L)
            {
                if (i.MaBN == ma) return i;
            }

            return null;
        }
        public BenhNhan getBenhNhanBySDT(string sdt)
        {
            foreach (BenhNhan i in L)
            {
                if (i.SDT == sdt) return i;
            }

            return null;
        }

        public string getNewMa()
        {
            if (L.Count == 0) return "BN0001";

            int ma = int.Parse( L[L.Count - 1].MaBN.Substring(2,4))+1;
            if (ma < 10) return "BN000" + ma;
            if (ma < 100) return "BN00" + ma;
            if (ma < 1000) return "BN0" + ma;
            return "BN" + ma;
        } 

        public void them(BenhNhan i)
        {
            i.MaBN = getNewMa();
            L.Add(i);
            saveData();
        }
        public void xoa(string maBN)
        {
            for(int i=0;i<L.Count;i++)
            {
                if (L[i].MaBN == maBN)
                {
                    L.RemoveAt(i);
                    saveData();
                    DieuTriDAO.gI().xoaByMaBN(L[i].MaBN);
                    break;
                }
            }
        }

        public void sua(BenhNhan bn)
        {
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].MaBN == bn.MaBN)
                {
                    L[i] = bn;
                    saveData();
                    break;
                }
            }
        }
    }
}

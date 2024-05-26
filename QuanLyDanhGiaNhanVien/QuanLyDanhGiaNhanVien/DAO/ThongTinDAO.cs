using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using QuanLyDanhGiaNhanVien.DTO;
using ClosedXML.Excel;
using OfficeOpenXml;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Security.Principal;
using OfficeOpenXml.Style;
using QuanLyDanhGiaBenhNhan.DAO;
using DocumentFormat.OpenXml.Spreadsheet;

namespace QuanLyDanhGiaNhanVien.DAO
{
    internal class ThongTinDAO
    {
        private static ThongTinDAO instance;
        private static string path;
        public string GmailGui { get; set; }
        public string MatKhauAppMail { get; set; }
        public string GmailNhan { get; set; }
        public string NoiLuu { get; set; }
        public int TanSuat { get; set; }
        public long LastTimeSaoLuu { get; set; }

        public ThongTinDAO()
        {
            path = DataProvider.PathSave + "\\DataHide.txt";
            loadData();
        }

        public void check()
        {

        }


        public bool SendMail(MailMessage mailMessage)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(GmailGui, MatKhauAppMail);
                smtp.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail: " + ex.ToString());
                return false;
            }
        }

        public void SaoLuuData()
        {
            if (!Directory.Exists(NoiLuu))
            {
                NoiLuu = "C:\\DataTam";
                if(!Directory.Exists(NoiLuu))
                    Directory.CreateDirectory(NoiLuu);
            }

            DirectorySecurity directorySecurity = Directory.GetAccessControl(NoiLuu);

            SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            FileSystemAccessRule rule = new FileSystemAccessRule(everyone, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow);

            directorySecurity.AddAccessRule(rule);
            Directory.SetAccessControl(NoiLuu, directorySecurity);

            try
            {
                DateTime dt = DateTime.Now;
                string fileName = "SaoLuu_" + dt.Day + "_" + dt.Month + "_" + dt.Year + "_" + dt.Hour + "_" + dt.Minute + "_" + dt.Second;
                string filePath = NoiLuu + @"\" + fileName;

                string filepathExel = filePath + ".xlsx";

                try
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Bệnh nhân");
                        List<BenhNhan> lBN = BenhNhanDAO.gI().loadDS();
                        for (int i = 0; i < lBN.Count; i++)
                        {
                            worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(lBN[i].MaBN) ? DataProvider.GetStringMaHoa(lBN[i].MaBN) : "null";
                            worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(lBN[i].HoTen) ? DataProvider.GetStringMaHoa(lBN[i].HoTen) : "null";
                            worksheet.Cells[i + 1, 3].Value = lBN[i].NgaySinh != null ? DataProvider.GetStringMaHoa(lBN[i].NgaySinh.ToString("dd/MM/yyyy HH:mm:ss")) : "null";
                            worksheet.Cells[i + 1, 4].Value = lBN[i].GioiTinh != null ? DataProvider.GetStringMaHoa(lBN[i].GioiTinh ? "1" : "0") : "null";
                            worksheet.Cells[i + 1, 5].Value = !String.IsNullOrEmpty(lBN[i].SDT) ? DataProvider.GetStringMaHoa(lBN[i].SDT) : "null";
                            worksheet.Cells[i + 1, 6].Value = !String.IsNullOrEmpty(lBN[i].DiaChi) ? DataProvider.GetStringMaHoa(lBN[i].DiaChi) : "null";

                            if (lBN[i].Anh != null)
                            {
                                ExcelRichTextCollection richTextCollection = worksheet.Cells[i + 1, 7].RichText;
                                ExcelRichText richText = richTextCollection.Add(DataProvider.GetStringMaHoa(DataProvider.gI().getStringImage(lBN[i].Anh)));
                            }
                            else
                            {
                                worksheet.Cells[i + 1, 7].Value = "null";
                            }
                        }

                        // Tạo và điền dữ liệu vào bảng "Chức vụ"
                        worksheet = package.Workbook.Worksheets.Add("Chức vụ");
                        List<ChucVu> lCV = ChucVuDAO.gI().loadDS();
                        for (int i = 0; i < lCV.Count; i++)
                        {
                            worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(lCV[i].MaCV) ? DataProvider.GetStringMaHoa(lCV[i].MaCV) : "null";
                            worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(lCV[i].TenCV) ? DataProvider.GetStringMaHoa(lCV[i].TenCV) : "null";

                            if (!String.IsNullOrEmpty(lCV[i].GhiChu))
                            {
                                ExcelRichTextCollection richTextCollection = worksheet.Cells[i + 1, 3].RichText;
                                ExcelRichText richText = richTextCollection.Add(DataProvider.GetStringMaHoa(lCV[i].GhiChu));
                            }
                            else
                            {
                                worksheet.Cells[i + 1, 3].Value = "null";
                            }
                        }

                        // Tạo và điền dữ liệu vào bảng "Đăng nhập"
                        worksheet = package.Workbook.Worksheets.Add("Đăng nhập");
                        List<DangNhap> lDN = DangNhapDAO.gI().loadDS();
                        for (int i = 0; i < lDN.Count; i++)
                        {
                            worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(lDN[i].MaNV) ? DataProvider.GetStringMaHoa(lDN[i].MaNV) : "null";
                            worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(lDN[i].TaiKhoan) ? DataProvider.GetStringMaHoa(lDN[i].TaiKhoan) : "null";
                            worksheet.Cells[i + 1, 3].Value = !String.IsNullOrEmpty(lDN[i].MatKhau) ? DataProvider.GetStringMaHoa(lDN[i].MatKhau) : "null";
                            worksheet.Cells[i + 1, 4].Value = lDN[i].TrangThai != null ? DataProvider.GetStringMaHoa(lDN[i].TrangThai ? "1" : "0") : "null";
                            worksheet.Cells[i + 1, 5].Value = lDN[i].IsAdmin != null ? DataProvider.GetStringMaHoa(lDN[i].IsAdmin ? "1" : "0") : "null";
                        }


                        // Tạo và điền dữ liệu vào bảng "Đánh giá"
                        worksheet = package.Workbook.Worksheets.Add("Đánh giá");
                        List<DanhGia> lDG = DanhGiaDAO.gI().loadDS();
                        for (int i = 0; i < lDG.Count; i++)
                        {
                            worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(lDG[i].MaDG) ? DataProvider.GetStringMaHoa(lDG[i].MaDG) : "null";
                            worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(lDG[i].MaDT) ? DataProvider.GetStringMaHoa(lDG[i].MaDT) : "null";
                            worksheet.Cells[i + 1, 3].Value = !String.IsNullOrEmpty(lDG[i].MaDT) ? DataProvider.GetStringMaHoa(lDG[i].MaDT) : "null";
                            worksheet.Cells[i + 1, 4].Value = lDG[i].ThoiGian != null ? DataProvider.GetStringMaHoa(lDG[i].ThoiGian.ToString("dd/MM/yyyy HH:mm:ss")) : "null";
                            worksheet.Cells[i + 1, 5].Value = DataProvider.GetStringMaHoa(lDG[i].SoSao+"");

                            if (!String.IsNullOrEmpty(lDG[i].NoiDung))
                            {
                                ExcelRichTextCollection richTextCollection = worksheet.Cells[i + 1, 6].RichText;
                                ExcelRichText richText = richTextCollection.Add(DataProvider.GetStringMaHoa(lDG[i].NoiDung));
                            }
                            else
                            {
                                worksheet.Cells[i + 1, 6].Value = "null";
                            }
                        }

                        // Tạo và điền dữ liệu vào bảng "Điều trị"
                        worksheet = package.Workbook.Worksheets.Add("Điều trị");
                        List<DieuTri> lDT = DieuTriDAO.gI().loadDS();
                        for (int i = 0; i < lDT.Count; i++)
                        {
                            worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(lDT[i].MaDT) ? DataProvider.GetStringMaHoa(lDT[i].MaDT) : "null";
                            worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(lDT[i].MaBN) ? DataProvider.GetStringMaHoa(lDT[i].MaBN) : "null";
                            worksheet.Cells[i + 1, 3].Value = DataProvider.GetStringMaHoa(lDT[i].getMaNVSaveFile());
                            worksheet.Cells[i + 1, 4].Value = lDT[i].ThoiGianBD != null ? DataProvider.GetStringMaHoa(lDT[i].ThoiGianBD.ToString("dd/MM/yyyy HH:mm:ss")) : "null";
                            worksheet.Cells[i + 1, 5].Value = lDT[i].ThoiGianKT != null ? DataProvider.GetStringMaHoa(lDT[i].ThoiGianKT.ToString("dd/MM/yyyy HH:mm:ss")) : "null";
                        }


                        // Tạo và điền dữ liệu vào bảng "Nhân viên"
                        worksheet = package.Workbook.Worksheets.Add("Nhân viên");
                        List<NhanVien> lNV = NhanVienDAO.gI().loadDS();
                        for (int i = 0; i < lNV.Count; i++)
                        {
                            worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(lNV[i].MaNV) ? DataProvider.GetStringMaHoa(lNV[i].MaNV) : "null";
                            worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(lNV[i].MaCV) ? DataProvider.GetStringMaHoa(lNV[i].MaCV) : "null";
                            worksheet.Cells[i + 1, 3].Value = !String.IsNullOrEmpty(lNV[i].HoTen) ? DataProvider.GetStringMaHoa(lNV[i].HoTen) : "null";
                            worksheet.Cells[i + 1, 4].Value = lNV[i].NgaySinh != null ? DataProvider.GetStringMaHoa(lNV[i].NgaySinh.ToString("dd/MM/yyyy HH:mm:ss")) : "null";
                            worksheet.Cells[i + 1, 5].Value = lNV[i].GioiTinh != null ? DataProvider.GetStringMaHoa(lNV[i].GioiTinh ? "1" : "0") : "null";
                            worksheet.Cells[i + 1, 6].Value = !String.IsNullOrEmpty(lNV[i].SDT) ? DataProvider.GetStringMaHoa(lNV[i].SDT) : "null";
                            worksheet.Cells[i + 1, 7].Value = lNV[i].TrangThai != null ? DataProvider.GetStringMaHoa(lNV[i].TrangThai ? "1" : "0") : "null";
                            worksheet.Cells[i + 1, 8].Value = !String.IsNullOrEmpty(lNV[i].DiaChi) ? DataProvider.GetStringMaHoa(lNV[i].DiaChi) : "null";

                            if (lNV[i].Anh!=null)
                            {
                                ExcelRichTextCollection richTextCollection = worksheet.Cells[i + 1, 9].RichText;
                                ExcelRichText richText = richTextCollection.Add(DataProvider.GetStringMaHoa(DataProvider.gI().getStringImage(lNV[i].Anh)));
                            }
                            else
                            {
                                worksheet.Cells[i + 1, 9].Value = "null";
                            }

                            worksheet.Cells[i + 1, 10].Value = DataProvider.GetStringMaHoa(lNV[i].MaxSao + "");
                        }

                        // Tạo và điền dữ liệu vào bảng "Quy định"
                        worksheet = package.Workbook.Worksheets.Add("Quy định");
                        List<QuyDinh> lQD = QuyDinhDAO.gI().loadDS();
                        for (int i = 0; i < lQD.Count; i++)
                        {
                            worksheet.Cells[i + 1, 1].Value = !String.IsNullOrEmpty(lQD[i].MaQD) ? DataProvider.GetStringMaHoa(lQD[i].MaQD) : "null";
                            worksheet.Cells[i + 1, 2].Value = !String.IsNullOrEmpty(lQD[i].TieuDe) ? DataProvider.GetStringMaHoa(lQD[i].TieuDe) : "null";

                            if (!String.IsNullOrEmpty(lQD[i].ChiTiet))
                            {
                                ExcelRichTextCollection richTextCollection = worksheet.Cells[i + 1, 3].RichText;
                                ExcelRichText richText = richTextCollection.Add(DataProvider.GetStringMaHoa(lQD[i].ChiTiet));
                            }
                            else
                            {
                                worksheet.Cells[i + 1, 3].Value = "null";
                            }
                        }


                        package.SaveAs(new FileInfo(filepathExel));
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    MessageBox.Show("Lỗi trong sao lưu data : " + ex.ToString());
                }

                //DataProvider.gI().saoLuu(filePath + ".bak");

                try
                {
                    MailMessage mailMessage = new MailMessage(GmailGui, GmailNhan, "Sao lưu dữ liệu phầm mềm đánh giá nhân viên", "");
                    mailMessage.Attachments.Clear();
                    mailMessage.Attachments.Add(new Attachment(filePath+".xlsx"));
                    mailMessage.SubjectEncoding = Encoding.Unicode;
                    mailMessage.BodyEncoding = Encoding.UTF8; 
                    mailMessage.Headers.Add("Content-Type", "text/plain; charset=UTF-8");
                    mailMessage.Body = "Đã sao lưu dữ liệu vào thời gian : " + dt.ToString("dd/MM/yyyy HH:mm:ss");
                    SendMail(mailMessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi gửi mail sao lưu");
                }

               LastTimeSaoLuu= ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong sao lưu data : " + ex.ToString());
            }
        }

        public void PhucHoiData(string filePath)
        {
            List<BenhNhan> lBN = new List<BenhNhan>();
            List<ChucVu> lCV = new List<ChucVu>();
            List<DanhGia> lDG = new List<DanhGia>();
            List<DieuTri> lDT = new List<DieuTri>();
            List<NhanVien> lNV = new List<NhanVien>();
            List<QuyDinh> lQD = new List<QuyDinh>();
            List<DangNhap> lDN = new List<DangNhap>();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets["Bệnh nhân"];

                    if (worksheet != null && worksheet.Dimension != null)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        for (int i = 1; i <= rowCount; i++)
                        {
                            BenhNhan bn = new BenhNhan
                            {
                                MaBN = worksheet.Cells[i, 1].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 1].Text) : null,
                                HoTen = worksheet.Cells[i, 2].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 2].Text) : null,
                                NgaySinh = worksheet.Cells[i, 3].Text != "null" ? DateTime.ParseExact(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 3].Text), "dd/MM/yyyy HH:mm:ss", null) : DateTime.Now,
                                GioiTinh = worksheet.Cells[i, 4].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 4].Text) == "1" : false,
                                SDT = worksheet.Cells[i, 5].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 5].Text) : null,
                                DiaChi = worksheet.Cells[i, 6].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 6].Text) : null,
                                Anh = worksheet.Cells[i, 7].Text != "null" ? DataProvider.gI().getImageFromByteString(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 7].Text)) : null
                            };
                            lBN.Add(bn);
                        }
                    }
                    

                    // Phục hồi dữ liệu bảng "Chức vụ"
                    worksheet = package.Workbook.Worksheets["Chức vụ"];

                    if (worksheet != null && worksheet.Dimension != null)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        for (int i = 1; i <= rowCount; i++)
                        {
                            ChucVu cv = new ChucVu
                            {
                                MaCV = worksheet.Cells[i, 1].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 1].Text) : null,
                                TenCV = worksheet.Cells[i, 2].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 2].Text) : null,
                                GhiChu = worksheet.Cells[i, 3].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 3].Text) : null
                            };
                            lCV.Add(cv);
                        }
                    }
                    

                    // Phục hồi dữ liệu bảng "Đăng nhập"
                    worksheet = package.Workbook.Worksheets["Đăng nhập"];

                    if (worksheet != null && worksheet.Dimension != null)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        for (int i = 1; i <= rowCount; i++)
                        {
                            DangNhap dn = new DangNhap
                            {
                                MaNV = worksheet.Cells[i, 1].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 1].Text) : null,
                                TaiKhoan = worksheet.Cells[i, 2].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 2].Text) : null,
                                MatKhau = worksheet.Cells[i, 3].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 3].Text) : null,
                                TrangThai = worksheet.Cells[i, 4].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 4].Text) == "1" : false,
                                IsAdmin = worksheet.Cells[i, 5].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 5].Text) == "1" : false
                            };
                            lDN.Add(dn);
                        }
                    }
                    

                    // Phục hồi dữ liệu bảng "Đánh giá"
                    worksheet = package.Workbook.Worksheets["Đánh giá"];

                    if (worksheet != null && worksheet.Dimension != null)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        for (int i = 1; i <= rowCount; i++)
                        {
                            DanhGia dg = new DanhGia
                            {
                                MaDG = worksheet.Cells[i, 1].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 1].Text) : null,
                                MaDT = worksheet.Cells[i, 2].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 2].Text) : null,
                                ThoiGian = worksheet.Cells[i, 4].Text != "null" ? DateTime.ParseExact(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 4].Text), "dd/MM/yyyy HH:mm:ss", null) : DateTime.Now,
                                SoSao = worksheet.Cells[i, 5].Text != "null" ? int.Parse(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 5].Text)) : 0,
                                NoiDung = worksheet.Cells[i, 6].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 6].Text) : null
                            };
                            lDG.Add(dg);
                        }
                    }
                    

                    // Phục hồi dữ liệu bảng "Điều trị"
                    worksheet = package.Workbook.Worksheets["Điều trị"];

                    if (worksheet != null && worksheet.Dimension != null)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        for (int i = 1; i <= rowCount; i++)
                        {
                            string sMaNV = DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 3].GetValue<string>());
                            List<string> listMaNV = sMaNV.Split(new string[] { "|" }, StringSplitOptions.None).ToList();
                            DieuTri dt = new DieuTri
                            {
                                MaDT = worksheet.Cells[i, 1].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 1].Text) : null,
                                MaBN = worksheet.Cells[i, 2].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 2].Text) : null,
                                ListMaNV = listMaNV,
                                ThoiGianBD = worksheet.Cells[i, 4].Text != "null" ? DateTime.ParseExact(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 4].Text), "dd/MM/yyyy HH:mm:ss", null) : DateTime.Now,
                                ThoiGianKT = worksheet.Cells[i, 5].Text != "null" ? DateTime.ParseExact(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 5].Text), "dd/MM/yyyy HH:mm:ss", null) : DateTime.Now
                            };
                            lDT.Add(dt);
                        }
                    }
                    

                    // Phục hồi dữ liệu bảng "Nhân viên"
                    worksheet = package.Workbook.Worksheets["Nhân viên"];

                    if (worksheet != null && worksheet.Dimension != null)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        for (int i = 1; i <= rowCount; i++)
                        {
                            NhanVien nv = new NhanVien
                            {
                                MaNV = worksheet.Cells[i, 1].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 1].Text) : null,
                                MaCV = worksheet.Cells[i, 2].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 2].Text) : null,
                                HoTen = worksheet.Cells[i, 3].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 3].Text) : null,
                                NgaySinh = worksheet.Cells[i, 4].Text != "null" ? DateTime.ParseExact(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 4].Text), "dd/MM/yyyy HH:mm:ss", null) : DateTime.Now,
                                GioiTinh = worksheet.Cells[i, 5].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 5].Text) == "1" : false,
                                SDT = worksheet.Cells[i, 6].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 6].Text) : null,
                                TrangThai = worksheet.Cells[i, 7].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 7].Text) == "1" : false,
                                DiaChi = worksheet.Cells[i, 8].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 8].Text) : null,
                                Anh = worksheet.Cells[i, 9].Text != "null" ? DataProvider.gI().getImageFromByteString(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 9].Text)) : null,
                                MaxSao = worksheet.Cells[i, 10].Text != "null" ? int.Parse(DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 10].Text)) : 0
                            };
                            lNV.Add(nv);
                        }
                    }

                    // Phục hồi dữ liệu bảng "Quy định"
                    worksheet = package.Workbook.Worksheets["Quy định"];
                    if (worksheet != null && worksheet.Dimension != null)
                    {
                        int rowCount = worksheet.Dimension.Rows;
                        for (int i = 1; i <= rowCount; i++)
                        {
                            QuyDinh qd = new QuyDinh
                            {
                                MaQD = worksheet.Cells[i, 1].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 1].Text) : null,
                                TieuDe = worksheet.Cells[i, 2].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 2].Text) : null,
                                ChiTiet = worksheet.Cells[i, 3].Text != "null" ? DataProvider.GetStringGiaiMaHoa(worksheet.Cells[i, 3].Text) : null
                            };
                            lQD.Add(qd);
                        }
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong phục hồi data: " + ex.ToString());
                return;
            }
            BenhNhanDAO.gI().SaveDS(lBN);
            ChucVuDAO.gI().SaveDS(lCV);
            DangNhapDAO.gI().SaveDS(lDN);
            DanhGiaDAO.gI().SaveDS(lDG);
            DieuTriDAO.gI().SaveDS(lDT);
            NhanVienDAO.gI().SaveDS(lNV);
            QuyDinhDAO.gI().SaveDS(lQD);

            MessageBox.Show("Phục hồi dữ liệu thành công, vui lòng khởi động lại ứng dụng !", "Thông báo");
            Environment.Exit(0);
        }

        public void checkSaoLuuTuDong()
        {
            long now = ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
            if (now - 3600 * 24 * 1000 * TanSuat > LastTimeSaoLuu) SaoLuuData();
        }

        void loadData()
        {
            //MessageBox.Show(path);
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine(DataProvider.GetStringMaHoa("Temp"));
                        sw.WriteLine(DataProvider.GetStringMaHoa("Temp"));
                        sw.WriteLine(DataProvider.GetStringMaHoa("Temp"));
                        sw.WriteLine(DataProvider.GetStringMaHoa("Temp"));
                        sw.WriteLine(DataProvider.GetStringMaHoa("1"));
                        sw.WriteLine(DataProvider.GetStringMaHoa("0"));
                        sw.WriteLine(DataProvider.GetStringMaHoa(DataProvider.keyVersion));
                    }
                }

                try
                {
                    string keyVer = "";
                    try
                    {
                        using (StreamReader sr = new StreamReader(path))
                        {
                            GmailGui = DataProvider.GetStringGiaiMaHoa(sr.ReadLine());
                            MatKhauAppMail = DataProvider.GetStringGiaiMaHoa(sr.ReadLine());
                            GmailNhan = DataProvider.GetStringGiaiMaHoa(sr.ReadLine());
                            NoiLuu = DataProvider.GetStringGiaiMaHoa(sr.ReadLine());
                            TanSuat = int.Parse(DataProvider.GetStringGiaiMaHoa(sr.ReadLine()));
                            LastTimeSaoLuu = long.Parse(DataProvider.GetStringGiaiMaHoa(sr.ReadLine()));
                            keyVer = DataProvider.GetStringGiaiMaHoa(sr.ReadLine());
                        }
                    }catch (Exception ex) { }
                    if (keyVer != DataProvider.keyVersion)
                    {
                        SaoLuuData();
                        DataProvider.gI().ResetData();
                        SaveData();
                    }
                }
                catch (Exception e) { }
            }
            catch (Exception e)
            {
                MessageBox.Show("Có lỗi xảy ra !!!", "Thông báo");
            }
        }

        public void SaveData()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(DataProvider.GetStringMaHoa(GmailGui));
                writer.WriteLine(DataProvider.GetStringMaHoa(MatKhauAppMail));
                writer.WriteLine(DataProvider.GetStringMaHoa(GmailNhan));
                writer.WriteLine(DataProvider.GetStringMaHoa(NoiLuu));
                writer.WriteLine(DataProvider.GetStringMaHoa(TanSuat.ToString()));
                writer.WriteLine(DataProvider.GetStringMaHoa(LastTimeSaoLuu.ToString()));
                writer.WriteLine(DataProvider.GetStringMaHoa(DataProvider.keyVersion));
            }
        }

        public static ThongTinDAO gI()
        {
            if (instance == null) instance = new ThongTinDAO();
            return instance;
        }
    }
}

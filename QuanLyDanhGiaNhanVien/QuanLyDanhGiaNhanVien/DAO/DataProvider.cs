using QuanLyDanhGiaBenhNhan.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyDanhGiaNhanVien.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        private static string connectionStr;
        public const string maHoaFalse = "RmFsc2U=";
        public const string maHoaTrue = "VHJ1ZQ==";
        public const string keyVersion = "1.0.0";
        public static string PathSave { get; set; } = "C:\\ABX_Hide";
        public DataProvider()
        {
            //connectionStr = "Data Source=DESKTOP-BASKPIT\\MSSQLSERVER01;Initial Catalog=QuanLyDanhGiaNhanVien;Integrated Security=True";
        }


        public void init()
        {
            if (!Directory.Exists(PathSave))
                Directory.CreateDirectory(PathSave);
            ThongTinDAO.gI().check();
        }

        public static DataProvider gI()
        {
            if(instance == null) instance = new DataProvider();
            return instance;
        }

        public void saoLuu(string path)
        {
            
            try
            {
                string Sql = "BACKUP DATABASE QuanLyDanhGiaNhanVien TO DISK = '" + path+"'";
                using (SqlConnection CON = new SqlConnection(connectionStr))
                using (SqlCommand cmdBackup = new SqlCommand(Sql, CON))
                {
                    CON.Open();
                    cmdBackup.ExecuteNonQuery();
                    CON.Close();
                }
            }
            catch (Exception e) {
               // Console.WriteLine(e.ToString());
                MessageBox.Show("Lỗi sao lưu dữ liệu: "+e.ToString(), "Nhắc nhở");
            }
        }

        public void ResetData()
        {
            try
            {
                BenhNhanDAO.gI().resetData();
                ChucVuDAO.gI().resetData();
                DangNhapDAO.gI().resetData();
                DanhGiaDAO.gI().resetData();
                DieuTriDAO.gI().resetData();
                NhanVienDAO.gI().resetData();
                QuyDinhDAO.gI().resetData();
            }
            catch (Exception e) { }
        }

        public static string GetStringMaHoa(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            byte[] bytesToEncode = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytesToEncode);
        }
        public static string GetStringGiaiMaHoa(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";
            if (input=="null") return "";
            byte[] bytesToDecode = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(bytesToDecode);
        }

        public string locString(string s)
        {
            return s;
        }

        public string getDateSql(DateTime d)
        {
            string dSql = d.Year + "-" + d.Month + "-" + d.Day;
            return dSql;
        }
        public string getDinhDanhHangNghin(int i)
        {
            return String.Format("{0:###,###,##0}", i);
        }
        public string getStringImage(Image image)
        {
            if(image == null) return "";
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imageData = ms.ToArray();
                    string base64String = Convert.ToBase64String(imageData);
                    return base64String;
                }
            }
            catch
            {
                return "";
            }
        }
        public Image getImageFromByteString(string byteString)
        {
            if (byteString == "null") return null;
            try
            {


                byte[] imgBytes = Convert.FromBase64String(byteString);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                ms.Write(imgBytes, 0, imgBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }catch
            {
                return null;
            }
        }
        public bool checkSDT(string s)
        {
            if (s.Length > 12 || s.Length < 9)
                return false;
            for (int i = 0; i < s.Length; i++)
                if (s[i] > '9' || s[i] < '0')
                    return false;
            return true;
		}
        public string getDateTimeSql(DateTime d)
        {
            string dSql = d.Year + "-" + d.Month + "-" + d.Day + " " + d.Hour + ":" + d.Minute + ":" + d.Second;
            return dSql;
        }
        public DataTable RunQuery(string query, object[] parameter = null)
        {
			DataTable data = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Lỗi");
            }
            return data;
        }
    }
}

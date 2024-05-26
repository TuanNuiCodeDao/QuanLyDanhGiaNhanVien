using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDanhGiaNhanVien
{
    public partial class F_Nen : Form
    {
        public F_Nen()
        {
            InitializeComponent();
            loadAnh();
        }

        async  void loadAnh()
        {
            await Task.Run(() =>
            {
                this.BackgroundImage = global::QuanLyDanhGiaNhanVien.Properties.Resources.hinh_nen;
            });
        }
    }
}

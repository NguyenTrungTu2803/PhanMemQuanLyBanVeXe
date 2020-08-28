using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANGNHAP
{
    public partial class HoaDonTinhTien : Form
    {
        public HoaDonTinhTien()
        {
            InitializeComponent();
        }
        //FrmLoaiXe7Cho LoaiXe = new FrmLoaiXe7Cho();
        public void HoaDonTinhTien_Load(object sender, EventArgs e)
        {
            txtTuyenDuong.Text =Tuyen.ToString();
            txtSoGhe.Text = Ghe.ToString();
            txtGiaCuoc.Text = Tien.ToString();
            txtSoXe.Text = SoXe.ToString();
            txtGioKH.Text = Ngay.ToString();
            txtGio.Text = Gio.ToString();
            txtHanhKhach.Text = THK.ToString();
            txtSDTHK.Text = SDT.ToString();
        }
        public string Tuyen = "";
        public string Ghe = "";
        public string Tien = "";
        public string SoXe = "";
        public string Ngay = "";
        public string Gio = "";
        public string SDT = "";
        public string THK = "";
    }
}

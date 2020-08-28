using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANGNHAP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           //Application.Run(new frmPhanQuyen());
           //Application.Run(new frmlogin());
           Application.Run(new frmMain());
            //Application.Run(new frmCapPass());
            //Application.Run(new RePortDSNV());
            //Application.Run(new frmChiTietTuyenXe());
            //Application.Run(new FrmLoaiXe7Cho());
            //Application.Run(new HoaDonTinhTien());
        }
    }
}

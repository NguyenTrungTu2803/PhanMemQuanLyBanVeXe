using DANGNHAP.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANGNHAP
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string usermame = txtusername.Text;
            string password = txtmatkhau.Text;
            if (Login(usermame, password))
            {
                frmMain f = new frmMain();
                this.Hide(); // Ẩn form đăng nhập.
                f.Show(); // Hiển thị form dialog 
                //this.Show(); // khi close hiển thị lại form đăng nhập.
            }
            else
            {
                MessageBox.Show("Nhập sai mật khẩu hoặc Tên đăng nhâp");
                txtmatkhau.Clear();
                txtusername.Clear();
                txtusername.Focus();
            }
        }

        bool Login(string username, string password)
        {
            return AcountDAO.Instance.Login(username, password);
        }
        private void butthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

        }
    }
}

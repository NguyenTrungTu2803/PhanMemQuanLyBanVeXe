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
    public partial class frmCapPass : Form
    {
        public frmCapPass()
        {
            InitializeComponent();
            btnDongY.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCapPass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            String s = "Update dbo.ACCOUNTDAILY Set password = N'"+txtPassMoi.Text+"' Where Id = N'"+txtIDNguoiDung.Text+"'";
            SqlConnection con = new SqlConnection(ConnectionStringDatagril.connectionString);
            con.Open();
            SqlCommand com = new SqlCommand(s, con);
            if (com.ExecuteNonQuery().ToString() == "1")
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Cấp pass thành công");
                txtIDNguoiDung.Clear();
                txtPassMoi.Clear();
            }
            else
            {
                MessageBox.Show("ID người dùng không hợp lệ nhập lại ID", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtIDNguoiDung.Focus();
                txtIDNguoiDung.Clear();

            }
            con.Close();           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (txtPassMoi.Text.Trim().Length != 0 && txtIDNguoiDung.Text.Trim().Length != 0)
                btnDongY.Enabled = true;
            else
                btnDongY.Enabled = false;
        }
    }
}

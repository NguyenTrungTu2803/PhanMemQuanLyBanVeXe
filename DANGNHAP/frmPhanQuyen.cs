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
    public partial class frmPhanQuyen : Form
    {
        public frmPhanQuyen()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            ////string quey = "Select * From dbo.ACCOUNTDAILY Where UserName = N'TRUNG TU'";
            //SqlConnection con = new SqlConnection(ConnectionStringDatagril.connectionString);
            //SqlCommand com = new SqlCommand("Select * From dbo.PhanQuyen Where Id = N'DH001'", con);
            //SqlDataReader DR = com.ExecuteReader();
            //con.Open();
            //while (DR.Read())
            //{
            //    DR.GetValue(1).ToString();
            //}
            //MessageBox.Show(DR.GetValue(1).ToString());
            //con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhanQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Thoát khỏi phân quyền truy cập", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (txtID.Text.Trim().Length != 0 && (cbCX.Checked || cbTD.Checked || cbTX.Checked || cbVe.Checked || cbXe.Checked))
                btnDongY.Enabled = true;
            else { btnDongY.Enabled = false; }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            int xe = 0, tx = 0, td = 0, cx = 0, bv = 0;
            if (cbCX.Checked)
                cx = 1;
            else { }
            if (cbTD.Checked)
                td = 1;
            else { }
            if (cbTX.Checked)
                tx = 1;
            else { }
            if (cbVe.Checked)
                bv = 1;
            else { }
            if (cbXe.Checked)
                xe = 1;
            else{}
            if (MessageBox.Show("Bạn có muốn phân quyền cho nhân viên "+txtID.Text+"","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                String quye = "Select IdNhanVien From dbo.PhanQuyen";             
                SqlCommand com = new SqlCommand(quye, connection);
                int flag = 0;
                try
                {
                    connection.Open();
                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        if (dr.GetValue(0).ToString() == txtID.Text)
                            flag = 1;
                    }
                    connection.Close();
                    String ss = "";
                    if (flag == 0)
                        ss = "Insert Into PhanQuyen Values (N'" + txtID.Text + "', N'" + xe + "', N'" + tx + "', N'" + td + "', N'" + cx + "', N'" + bv + "')";
                    else
                        ss = "Update PhanQuyen Set Xe = N'" + xe + "', TuyenXe = N'" + tx + "', ThoiDiem = N'" + td + "', ChuyenXe = N'" + cx + "', BanVe = N'" + bv + "' Where IdNhanVien = N'" + txtID.Text + "')";
                    SqlCommand comm = new SqlCommand(ss, connection);
                    try
                    {
                        connection.Open();
                        comm.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Nhân viên " + txtID.Text + " đã được cấp quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtID.Clear(); cbCX.Checked = false; cbTD.Checked = false; cbTX.Checked = false; cbVe.Checked = false; cbXe.Checked = false;

                    }
                    catch { MessageBox.Show("Cấp quyền không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); txtID.Clear(); }
                }
                catch { MessageBox.Show("Cấp quyền không thành công!"); }
            }
            else {}
        }
    }
}












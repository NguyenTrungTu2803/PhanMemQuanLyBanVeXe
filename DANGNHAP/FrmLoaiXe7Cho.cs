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
    public partial class FrmLoaiXe7Cho : Form
    {
        public FrmLoaiXe7Cho()
        {
            InitializeComponent();
        }
        
        SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
        public int k = 0;
        private void btnTaiXe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chỗ này của tài xế bạn ơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btn1Xe7_Click(object sender, EventArgs e)
        {
            if (btn1Xe7.BackColor == Color.AliceBlue) { btn1Xe7.BackColor = Color.SteelBlue; }
            else if (btn1Xe7.BackColor == Color.Yellow) { MessageBox.Show("Chỗ này đã đặc chỗ ", "Thông báo"); btn1Xe7.BackColor = Color.Yellow; }
            else { btn1Xe7.BackColor = Color.AliceBlue; }
            txtSoGhe.Text = btn1Xe7.Text;
        }

        private void btn2Xe7_Click(object sender, EventArgs e)
        {
            if (btn2Xe7.BackColor == Color.AliceBlue) { btn2Xe7.BackColor = Color.SteelBlue; }
            else if (btn2Xe7.BackColor == Color.Yellow) { MessageBox.Show("Chỗ này đã đặc chỗ ", "Thông báo"); btn2Xe7.BackColor = Color.Yellow; }
            else { btn2Xe7.BackColor = Color.AliceBlue; }
            txtSoGhe.Text = btn2Xe7.Text;
        }

        private void btn3Xe7_Click(object sender, EventArgs e)
        {
            if (btn3Xe7.BackColor == Color.AliceBlue) { btn3Xe7.BackColor = Color.SteelBlue; }
            else if (btn3Xe7.BackColor == Color.Yellow) { MessageBox.Show("Chỗ này đã đặc chỗ ", "Thông báo"); btn3Xe7.BackColor = Color.Yellow; }
            else { btn3Xe7.BackColor = Color.AliceBlue; }
            txtSoGhe.Text = btn3Xe7.Text;
        }

        private void btn4Xe7_Click(object sender, EventArgs e)
        {
            if (btn4Xe7.BackColor == Color.AliceBlue) { btn4Xe7.BackColor = Color.SteelBlue; }
            else if (btn4Xe7.BackColor == Color.Yellow) { MessageBox.Show("Chỗ này đã đặc chỗ ", "Thông báo"); btn4Xe7.BackColor = Color.Yellow; }
            else { btn4Xe7.BackColor = Color.AliceBlue; }
            txtSoGhe.Text = btn4Xe7.Text;
        }

        private void btn5Xe7_Click(object sender, EventArgs e)
        {
            if (btn5Xe7.BackColor == Color.AliceBlue) { btn5Xe7.BackColor = Color.SteelBlue; }
            else if (btn5Xe7.BackColor == Color.Yellow) { MessageBox.Show("Chỗ này đã đặc chỗ ", "Thông báo"); btn5Xe7.BackColor = Color.Yellow; }
            else { btn5Xe7.BackColor = Color.AliceBlue; }
            txtSoGhe.Text = btn5Xe7.Text;
        }

        private void btn6Xe7_Click(object sender, EventArgs e)
        {
            if (btn6Xe7.BackColor == Color.AliceBlue) { btn6Xe7.BackColor = Color.SteelBlue; }
            else if (btn6Xe7.BackColor == Color.Yellow) { MessageBox.Show("Chỗ này đã đặc chỗ ", "Thông báo"); btn6Xe7.BackColor = Color.Yellow; }
            else { btn6Xe7.BackColor = Color.AliceBlue; }
            txtSoGhe.Text = btn6Xe7.Text;
        }

        private void txtNhapTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (txtNhapTien.Text.Trim().Length != 0)
            {
                int ThanhTien = Convert.ToInt32(txtNhapTien.Text);
                if (btn1Xe7.BackColor == Color.SteelBlue) k += ThanhTien;
                if (btn2Xe7.BackColor == Color.SteelBlue) k += ThanhTien;
                if (btn3Xe7.BackColor == Color.SteelBlue) k += ThanhTien;
                if (btn4Xe7.BackColor == Color.SteelBlue) k += ThanhTien;
                if (btn5Xe7.BackColor == Color.SteelBlue) k += ThanhTien;
                if (btn6Xe7.BackColor == Color.SteelBlue) k += ThanhTien;
                if (MessageBox.Show("Tổng tiền của khách là " + k.ToString() + "\nBạn có muốn in hóa đơn và tính tiền", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (btn1Xe7.BackColor == Color.SteelBlue) { /*btn1Xe7.Enabled = false;*/ btn1Xe7.BackColor = Color.Yellow; }
                    if (btn2Xe7.BackColor == Color.SteelBlue) { /*btn2Xe7.Enabled = false;*/ btn2Xe7.BackColor = Color.Yellow; }
                    if (btn3Xe7.BackColor == Color.SteelBlue) { /*btn3Xe7.Enabled = false;*/ btn3Xe7.BackColor = Color.Yellow; }
                    if (btn4Xe7.BackColor == Color.SteelBlue) { /*btn4Xe7.Enabled = false;*/ btn4Xe7.BackColor = Color.Yellow; }
                    if (btn5Xe7.BackColor == Color.SteelBlue) { /*btn5Xe7.Enabled = false;*/ btn5Xe7.BackColor = Color.Yellow; }
                    if (btn6Xe7.BackColor == Color.SteelBlue) { /*btn6Xe7.Enabled = false; */btn6Xe7.BackColor = Color.Yellow; }
                    HoaDonTinhTien hoadon = new HoaDonTinhTien();
                    hoadon.Tuyen = s.ToString();
                    hoadon.Ghe = txtSoGhe.Text;
                    hoadon.Tien = ThanhTien.ToString();
                    hoadon.Gio = GioDi.ToString();
                    hoadon.Ngay= NgayDi.ToString();
                    hoadon.SoXe = SoXe.ToString();
                    hoadon.SDT = STDHK.ToString();
                    hoadon.THK = TenHanhKhach.ToString();
                    hoadon.Show();
                    connection.Open();
                    SqlCommand comm = new SqlCommand("Insert into BanVe(IdChuyen, TenHanhKhach, SDTHanhKhach) Values('CX0001', N'"+TenHanhKhach.ToString()+"', N'"+STDHK.ToString()+"')", connection);
                    comm.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                }
            }
            else { MessageBox.Show("Bạn chưa nhập tiền để thanh toán", "Thông báo"); }
            ThayDoiDuLieu();
        }

        private void btnXoaghe_Click(object sender, EventArgs e)
        {
            if (txtSoGhe.Text.Trim().Length != 0 && !KTSGhe(txtSoGhe.Text))
                MessageBox.Show("Số ghế không hợp lệ", "Thông báo");
            if (txtSoGhe.Text.Trim().Length == 0)
                MessageBox.Show("Chưa nhập hoặc chọn số ghế", "Thông báo");
            if (txtSoGhe.Text == "1" && btn1Xe7.BackColor == Color.Yellow)
            {
                if (MessageBox.Show("Bạn chắc muốn xóa số ghế " + btn1Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btn1Xe7.BackColor = Color.AliceBlue;
                }
            }
            if (txtSoGhe.Text == "2" && btn2Xe7.BackColor == Color.Yellow)
            {
                if (MessageBox.Show("Bạn chắc muốn xóa số ghế " + btn2Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btn2Xe7.BackColor = Color.AliceBlue;
                }
            }
            if (txtSoGhe.Text == "3" && btn3Xe7.BackColor == Color.Yellow)
            {
                if (MessageBox.Show("Bạn chắc muốn xóa số ghế " + btn3Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btn3Xe7.BackColor = Color.AliceBlue;
                }
            }
            if (txtSoGhe.Text == "4" && btn4Xe7.BackColor == Color.Yellow)
            {
                if (MessageBox.Show("Bạn chắc muốn xóa số ghế " + btn4Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btn4Xe7.BackColor = Color.AliceBlue;
                }
            }
            if (txtSoGhe.Text == "5" && btn5Xe7.BackColor == Color.Yellow)
            {
                if (MessageBox.Show("Bạn chắc muốn xóa số ghế " + btn5Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btn5Xe7.BackColor = Color.AliceBlue;
                }
            }
            if (txtSoGhe.Text == "6" && btn6Xe7.BackColor == Color.Yellow)
            {
                if (MessageBox.Show("Bạn chắc muốn xóa số ghế " + btn6Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btn6Xe7.BackColor = Color.AliceBlue;
                }
            }
            ThayDoiDuLieu();
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (txtSoGhe.Text.Trim().Length != 0 && !KTSGhe(txtSoGhe.Text))
                MessageBox.Show("Số ghế không hợp lệ", "Thông báo");
            if (txtSoGhe.Text.Trim().Length == 0)
                MessageBox.Show("Số ghế chưa chọn", "Thông báo");
            else
            {
                if (txtSoGhe.Text == "1" && btn1Xe7.BackColor == Color.SteelBlue)
                {
                    if (MessageBox.Show("Bạn chắc muốn thay đổi số ghế " + btn1Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btn1Xe7.BackColor = Color.Yellow;
                    }
                }
                else if (txtSoGhe.Text == "1" && btn1Xe7.BackColor == Color.Yellow) { MessageBox.Show("Số ghế đã được chọn!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); return; }

                if (txtSoGhe.Text == "2" && btn2Xe7.BackColor == Color.SteelBlue)
                {
                    if (MessageBox.Show("Bạn chắc thay đổi số ghế " + btn2Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btn2Xe7.BackColor = Color.Yellow; MessageBox.Show("Thay đổi thành công", "Thông báo");
                    }
                }
                else if (txtSoGhe.Text == "2" && btn2Xe7.BackColor == Color.Yellow) { MessageBox.Show("Số ghế đã được chọn !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error); return; }

                if (txtSoGhe.Text == "3" && btn3Xe7.BackColor == Color.SteelBlue)
                {
                    if (MessageBox.Show("Bạn chắc muốn thay đổi số ghế " + btn3Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btn3Xe7.BackColor = Color.Yellow; MessageBox.Show("Thay đổi thành công", "Thông báo");
                    }
                }
                else if (txtSoGhe.Text == "3" && btn3Xe7.BackColor == Color.Yellow) { MessageBox.Show("Số ghế " + btn3Xe7.Text + " đã được chọn !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error); return; }

                if (txtSoGhe.Text == "4" && btn4Xe7.BackColor == Color.SteelBlue)
                {
                    if (MessageBox.Show("Bạn chắc muốn thay đổi số ghế " + btn4Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btn4Xe7.BackColor = Color.Yellow; MessageBox.Show("Thay đổi thành công", "Thông báo");
                    }
                }
                else if (txtSoGhe.Text == "4" && btn4Xe7.BackColor == Color.Yellow) { MessageBox.Show("Số ghế " + btn4Xe7.Text + " đã được chọn !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error); return; }

                if (txtSoGhe.Text == "5" && btn5Xe7.BackColor == Color.SteelBlue)
                {
                    if (MessageBox.Show("Bạn chắc muốn thay đổi số ghế " + btn5Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btn5Xe7.BackColor = Color.Yellow;
                        MessageBox.Show("Thay đổi thành công", "Thông báo");
                    }
                }
                else if (txtSoGhe.Text == "5" && btn5Xe7.BackColor == Color.Yellow) { MessageBox.Show("Số ghế " + btn5Xe7.Text + " đã được chọn !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error); return; }

                if (txtSoGhe.Text == "6" && btn6Xe7.BackColor == Color.SteelBlue)
                {
                    if (MessageBox.Show("Bạn chắc muốn thay đổi số ghế " + btn6Xe7.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btn6Xe7.BackColor = Color.Yellow;
                        MessageBox.Show("Thay đổi thành công", "Thông báo");
                    }
                }
                else if (txtSoGhe.Text == "6" && btn6Xe7.BackColor == Color.Yellow) { MessageBox.Show("Số ghế " + btn6Xe7.Text + " đã được chọn !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error); return; }
                ThayDoiDuLieu();
            }
        }
        public void LoadXe7Cho()
        {
            connection.Open();
            SqlCommand comm = new SqlCommand("Select * from Xe7Cho", connection);
            SqlDataReader rd = comm.ExecuteReader();
            int flag1 = 0; int flag2 = 0; int flag3 = 0; int flag4 = 0; int flag5 = 0; int flag6 = 0;
            while (rd.Read())
            {
                if (rd.GetValue(1).ToString() == "1")
                    flag1 = 1;
                if (rd.GetValue(2).ToString() == "2")
                    flag2 = 1;
                if (rd.GetValue(3).ToString() == "3")
                    flag3 = 1;
                if (rd.GetValue(4).ToString() == "4")
                    flag4 = 1;
                if (rd.GetValue(5).ToString() == "5")
                    flag5 = 1;
                if (rd.GetValue(6).ToString() == "6")
                    flag6 = 1;
            }
            connection.Close();
            if (flag1 == 1)
                btn1Xe7.BackColor = Color.Yellow;
            else btn1Xe7.BackColor = Color.AliceBlue;
            if (flag2 == 1)
                btn2Xe7.BackColor = Color.Yellow;
            else btn2Xe7.BackColor = Color.AliceBlue;
            if (flag3 == 1)
                btn3Xe7.BackColor = Color.Yellow;
            else btn3Xe7.BackColor = Color.AliceBlue;
            if (flag4 == 1)
                btn4Xe7.BackColor = Color.Yellow;
            else btn4Xe7.BackColor = Color.AliceBlue;
            if (flag5 == 1)
                btn5Xe7.BackColor = Color.Yellow;
            else btn5Xe7.BackColor = Color.AliceBlue;
            if (flag6 == 1)
                btn6Xe7.BackColor = Color.Yellow;
            else btn6Xe7.BackColor = Color.AliceBlue;
        }
        public void ThayDoiDuLieu()
        {
            int so1 = 0; int so2 = 0; int so3 = 0; int so4 = 0; int so5 = 0; int so6 = 0;
            if (btn1Xe7.BackColor == Color.Yellow)
                so1 = 1;
            else so1 = 0;
            if (btn2Xe7.BackColor == Color.Yellow)
                so2 = 2;
            else so2 = 0;
            if (btn3Xe7.BackColor == Color.Yellow)
                so3 = 3;
            else so3 = 0;
            if (btn4Xe7.BackColor == Color.Yellow)
                so4 = 4;
            else so4 = 0;
            if (btn5Xe7.BackColor == Color.Yellow)
                so5 = 5;
            else so5 = 0;
            if (btn6Xe7.BackColor == Color.Yellow)
                so6 = 6;
            else so6 = 0;
            try
            {
                connection.Open();
                SqlCommand com = new SqlCommand("Update Xe7Cho Set So1 ='" + so1 + "', So2 ='" + so2 + "', So3 ='" + so3 + "', So4 ='" + so4 + "', So5 ='" + so5 + "', So6 ='" + so6 + "', Tien ='" + k + "' Where IdSoGhe = '1'", connection);
                com.ExecuteNonQuery();
                connection.Close();
                LoadXe7Cho();
                k = 0;
            }
            catch { MessageBox.Show("Load dữ liệu không thành công", "Thông báo"); }
        }
        bool KTSGhe(string s)
        {
            int k = Convert.ToInt32(s);
            if (k < 0 || k > 6)
                return false;
            return true;
        }
        private void FrmLoaiXe7Cho_Load(object sender, EventArgs e)
        {
            LoadXe7Cho(); ThayDoiDuLieu();
        }

        private void btnPhieuThanhToan_Click(object sender, EventArgs e)
        {
            //HoaDonTinhTien TT = new HoaDonTinhTien();
          
            //TT.Show();
        }
        public string s = "";
        public string NgayDi = "";
        public string GioDi = "";
        public string SoXe = "";
        public string TenHanhKhach = "";
        public string STDHK = "";
        public string IdChuyen = "";
        private void txtNhapTien_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) { e.Handled = true; }
        }
    }
}

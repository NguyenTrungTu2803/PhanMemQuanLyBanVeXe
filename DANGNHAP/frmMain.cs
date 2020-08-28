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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        FrmLoaiXe7Cho choxe = new FrmLoaiXe7Cho();
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))   
                e.Handled = true;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Người dùng
            dtwAcountDaiLy.DataSource = getAllAcountDaily().Tables[0]; cobGioiTinh.SelectedIndex = 0;
            this.LoadCombobox(); cobLoaiND.SelectedIndex = 1; Enable();
            //Xe
            EnbleXe();
            dtwXe.DataSource = GetAllXe().Tables[0]; sizeand_Xe();  this.LoadXe(); this.LoadHieuXe();  cobSoXe.SelectedIndex = 0;

            //Tuyến Xe
            this.LoadTuyenXe(); dtwTX.DataSource = getAllTX().Tables[0]; SizeTuyenXe(); ComboboxTX();
             //Thời điểm
            loadThoiDiem(); GetThoiDiem(); TaoCloumsThoiDIem();
            //Chuyến xe
            LoadChuyenXe(); ComboBoxChuyenXe(); DesignChuyenXe();
            //Bán ve
            LoadBanVe(); dtwThongTinCX.DataSource = GetAllXe().Tables[0]; SizedtwThongTinKhachHang(); SizedtThongTinCX(); LoadComboBoxTTCX();
        }
        void sizeand_Xe()
        {
            dtwXe.Columns[0].HeaderText = "Số xe";
            dtwXe.Columns[1].HeaderText = "Hiệu xe";
            dtwXe.Columns[2].HeaderText = "Đời xe";
            dtwXe.Columns[3].HeaderText = "Số chỗ ngồi";
            dtwXe.Columns[0].Width = 200;
            dtwXe.Columns[1].Width = 400;
            dtwXe.Columns[2].Width = 150;
            dtwXe.Columns[3].Width = 200;
        }
        public void LoadCombobox()
        {           
            //Sài xong rồi hủy.
            string quyery = "Select IDLoaiND from LoaiNguoiDung";
            using (SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString))
            {
                connection.Open();
                DataSet data = new DataSet();
                SqlCommand com = new SqlCommand(quyery, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(data);
                cobLoaiND.DataSource = data.Tables[0];
                cobLoaiND.DisplayMember = "IDLoaiND";
                connection.Close();
            }
        }
        public void LoadXe()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString))
            {
                connection.Open();
                DataSet data = new DataSet();
                SqlCommand com = new SqlCommand("Select So_Xe from Xe", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(data);
                cobSoXe.DataSource = data.Tables[0];
                cobSoXe.DisplayMember = "So_Xe";                             
                connection.Close();
            }
            
        }
        void LoadTuyenXe()
        {
            cobTenTuyen.Enabled = false;
            cobDDDi.Enabled = false;
            cobDDDen.Enabled = false;
            btnLuuTX.Enabled = false;
            btnHuyTX.Enabled = false;
        }
        public void LoadHieuXe()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString))
            {
                connection.Open();
                DataSet data = new DataSet();
                SqlCommand com = new SqlCommand("Select Hieu_Xe from Xe", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(data);
                cobHieuXe.DataSource = data.Tables[0];
                cobHieuXe.DisplayMember = "Hieu_Xe";
                DataSet d = new DataSet();
                SqlCommand comm = new SqlCommand("Select So_Cho_Ngoi from Xe", connection);
                SqlDataAdapter ad = new SqlDataAdapter(comm);
                ad.Fill(d);
                cobChoNgoi.DataSource = d.Tables[0];
                cobChoNgoi.DisplayMember = "So_Cho_Ngoi";
                connection.Close();
            }
        }
        void Enable()
        {
            txtHoTen.Enabled = false;
            txtPassWord.Enabled = false;
            txtSDT.Enabled = false;
            txtUserName.Enabled = false;
            cobGioiTinh.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnHuyXe.Enabled = false;
            btnLuuXe.Enabled = false;
        }
        void EnbleXe()
        {
            cobChoNgoi.Enabled = false;
            cobHieuXe.Enabled = false;
            txtDoiXe.Enabled = false;
        }
        DataSet getAllAcountDaily()
        {
            DataSet data = new DataSet();
            //Sài xong rồi hủy.
            string quyery = "Select * from ACCOUNTDAILY";
            using(SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(quyery, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        DataSet getAllTX()
        {
            DataSet data = new DataSet();
            //Sài xong rồi hủy.
            string quyery = "Select * from TuyenXe";
            using (SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(quyery, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        void SizeTuyenXe()
        {
            dtwTX.Columns[0].HeaderText = "Mã số tuyến";
            dtwTX.Columns[1].HeaderText = "Tên tuyến";
            dtwTX.Columns[2].HeaderText = "Địa điểm đi";
            dtwTX.Columns[3].HeaderText = "Địa điểm đến";

            dtwTX.Columns[0].Width = 100;
            dtwTX.Columns[1].Width = 400;
            dtwTX.Columns[2].Width = 150;
            dtwTX.Columns[3].Width = 150;
        }
        DataSet GetAllXe()
        {
            DataSet data = new DataSet();
            string query = "Select * From Xe";
            using(SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();                
            }
            return data;
        }
        void ComboboxTX()
        {
           SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
           connection.Open();
           DataSet data = new DataSet();
           SqlCommand com = new SqlCommand("Select * from TuyenXe", connection);
           SqlDataAdapter adapter = new SqlDataAdapter(com);
           adapter.Fill(data);
           cobMaTuyen.DataSource = data.Tables[0];
           cobMaTuyen.ValueMember = "IdTuyen";
           cobTenTuyen.DataSource = data.Tables[0];
           cobTenTuyen.ValueMember = "TenTuyen";
           cobDDDi.DataSource = data.Tables[0];
           cobDDDi.DisplayMember = "DiaDiemDi";
           cobDDDen.DataSource = data.Tables[0];
           cobDDDen.DisplayMember = "DiaDiemDen";
            //-------------------------------------
           cobMST.DataSource = data.Tables[0];
           cobMST.ValueMember = "IdTuyen";
           cobTX.DataSource = data.Tables[0];
           cobTX.DisplayMember = "TenTuyen";
           connection.Close();
            
        }
        String TangTUDong()
        {
            for (int i = 0; i < dtwAcountDaiLy.Rows.Count; i++)
            {
                if(i < 9)
                    ID.HeaderText = ((i < 9) ? "DH00" + (i + 1) : "" + (i + 1)).ToString();
                if(i < 99 && i > 9)
                    ID.HeaderText = ((i < 99) ? "DH0" + (i + 1) : "" + (i + 1)).ToString();
            }
            return ID.HeaderText;
        }
        void loadThoiDiem()
        {
            btnLuuTD.Enabled = false;
            btnHuyTD.Enabled = false;
            cobMaTD.Enabled = false;
        }
        void GetThoiDiem()
        {
            SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
            DataSet data = new DataSet();
            connection.Open();
            SqlCommand com = new SqlCommand("Select * from ThoiDiem", connection);
            SqlDataAdapter adap = new SqlDataAdapter(com);
            adap.Fill(data);
            dtwThoiDiem.DataSource = data.Tables[0];
            connection.Close();
        }
        void TaoCloumsThoiDIem()
        {
            dtwThoiDiem.Columns[0].HeaderText = "Mã thời điểm";
            dtwThoiDiem.Columns[1].HeaderText = "Ngày khởi hành";
            dtwThoiDiem.Columns[2].HeaderText = "Giờ Khởi Hành";
            dtwThoiDiem.Columns[0].Width = 107;
            dtwThoiDiem.Columns[1].Width = 200;
            dtwThoiDiem.Columns[2].Width = 150;
        }
        void LoadChuyenXe()
        {
            cobTuyenXe.Enabled = false;
            cobNgayDi.Enabled = false;
            cobTuyenXe.Enabled = false;
            cobGioDi.Enabled = false;
            cobSX.Enabled = false;
            btnHuyCX.Enabled = false;
            btnLuuCX.Enabled = false;
            btnSuaCX.Enabled = true;
            btnThemCX.Enabled = true;
            btnXoaCX.Enabled = true;
        }
        void ComboBoxChuyenXe()
        {
            SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
            connection.Open();
            DataSet data = new DataSet();
            SqlCommand com = new SqlCommand("Select * from ChuyenXe", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(com);
            adapter.Fill(data);
            dtwChuyenXe.DataSource = data.Tables[0];
            cobMaSoC.DataSource = data.Tables[0];
            //cobMaSoC.ValueMember = "IdChuyen";
            cobMaSoC.DisplayMember = "IdChuyen";
            cobTuyenXe.DataSource = data.Tables[0];
            cobTuyenXe.ValueMember = "IdTuyen";
            cobSX.DataSource = data.Tables[0];
            cobSX.DisplayMember = "So_Xe";
            cobGioDi.DataSource = data.Tables[0];
            cobGioDi.DisplayMember = "Gio";
            cobNgayDi.DataSource = data.Tables[0];
            cobNgayDi.DisplayMember = "NgayDi";

        }
        void DesignChuyenXe()
        {
            dtwChuyenXe.Columns[0].HeaderText = "Mã chuyến xe";
            dtwChuyenXe.Columns[1].HeaderText = "Mã tuyến xe";
            dtwChuyenXe.Columns[2].HeaderText = "Ngày đi";
            dtwChuyenXe.Columns[3].HeaderText = "Giờ đi";
            dtwChuyenXe.Columns[4].HeaderText = "Số xe";
            dtwChuyenXe.Columns[0].Width = 150;
            dtwChuyenXe.Columns[1].Width = 150;
            dtwChuyenXe.Columns[2].Width = 160;
            dtwChuyenXe.Columns[3].Width = 100;
            dtwChuyenXe.Columns[4].Width = 150;
        }
        bool KiemTraNgay(string s)
        {
            string[] str = s.Split('/');
            int[] a = new int[s.Length];
            if (str.Length < 1)
                return false;
            else if (str.Length > 3)
                return false;
            else
            {
                try
                {
                    a[0] = Convert.ToInt32(str[0]);
                    a[1] = Convert.ToInt32(str[1]);
                    a[2] = Convert.ToInt32(str[2]);
                    if (a[1] == 2 && a[0] > 29)
                        return false;
                    if (a[2] < 2018 || a[2] > 2100)
                        return false;
                    if (a[1] > 13 || a[1] < 1)
                        return false;
                    if ((a[1] == 4 || a[1] == 6 || a[1] == 9 || a[1] == 11) && a[0] > 30)
                        return false;
                    if ((a[1] == 1 || a[1] == 3 || a[1] == 5 || a[1] == 7 || a[1] == 8 || a[1] == 10 || a[1] == 12) && a[0] > 31)
                        return false;
                }
                catch { return false; }
            }
            return true;
        }
        bool KTMaTuyen(string s)
        {
            SqlConnection conn = new SqlConnection(ConnectionStringDatagril.connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand("Select Count (*) From TuyenXe Where IdTuyen = N'"+cobTuyenXe.Text+"'", conn);
            int kq = (int)comm.ExecuteScalar();          
            conn.Close();
            if (kq == 0)
                return false;
            return true;
        }
        bool KTSoXe(string s)
        {
            SqlConnection conn = new SqlConnection(ConnectionStringDatagril.connectionString);
            conn.Open();
            SqlCommand comm = new SqlCommand("Select Count (*) From Xe Where So_Xe = N'" + cobSX.Text + "'", conn);
            int kq = (int)comm.ExecuteScalar();
            conn.Close();
            if (kq == 0)
                return false;
            return true;
        }
        public void LoadBanVe()
        {
            SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
            connection.Open();
            DataSet data = new DataSet();
            SqlCommand com = new SqlCommand("Select BanVe.IdVe, BanVe.TenHanhKhach, BanVe.SDTHanhKhach, TuyenXe.TenTuyen, ChuyenXe.NgayDi, ChuyenXe.Gio, Xe.So_Xe From ChuyenXe Join BanVe on (BanVe.IdChuyen = ChuyenXe.IdChuyen) Join TuyenXe on (ChuyenXe.IdTuyen = TuyenXe.IdTuyen) Join Xe on (Xe.So_Xe = ChuyenXe.So_Xe)", connection);
            SqlDataAdapter adap = new SqlDataAdapter(com);
            adap.Fill(data);
            connection.Close();
            dtwThongTinHanhKhach.DataSource = data.Tables[0];
            cobMaSoVe.DataSource = data.Tables[0];
            cobMaSoVe.ValueMember = "IdVe";
        }
        void SizedtwThongTinKhachHang()
        {
            dtwThongTinHanhKhach.Columns[0].HeaderText = "Mã số Vé";
            dtwThongTinHanhKhach.Columns[1].HeaderText = "Tên Hành khách";
            dtwThongTinHanhKhach.Columns[2].HeaderText = "Số điện thoại";
            dtwThongTinHanhKhach.Columns[3].HeaderText = "Tên tuyến xe";
            dtwThongTinHanhKhach.Columns[4].HeaderText = "Ngày đi";
            dtwThongTinHanhKhach.Columns[5].HeaderText = "Giờ  đi";
            dtwThongTinHanhKhach.Columns[6].HeaderText = "Biển số xe";

            dtwThongTinHanhKhach.Columns[0].Width = 100;
            dtwThongTinHanhKhach.Columns[1].Width = 200;
            dtwThongTinHanhKhach.Columns[2].Width = 200;
            dtwThongTinHanhKhach.Columns[3].Width = 150;
            dtwThongTinHanhKhach.Columns[4].Width = 150;
            dtwThongTinHanhKhach.Columns[5].Width = 100;
            dtwThongTinHanhKhach.Columns[6].Width = 100;
        }

        void SizedtThongTinCX()
        {
            dtwThongTinCX.Columns[0].HeaderText = "Biển số xe";
            dtwThongTinCX.Columns[1].HeaderText = "Hiệu xe";
            dtwThongTinCX.Columns[2].HeaderText = "Đời xe";
            dtwThongTinCX.Columns[3].HeaderText = "Số chỗ ngồi";
            dtwThongTinCX.Columns[0].Width = 100;
            dtwThongTinCX.Columns[1].Width = 200;
            dtwThongTinCX.Columns[2].Width = 200;
            dtwThongTinCX.Columns[3].Width = 100;
        }
        HoaDonTinhTien hoadon = new HoaDonTinhTien();
        public void LoadComboBoxTTCX()
        {
            SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
            connection.Open();
            SqlCommand comm = new SqlCommand("Select TuyenXe.TenTuyen, ChuyenXe.NgayDi, ChuyenXe.Gio, ChuyenXe.So_Xe From ChuyenXe Join TuyenXe on (TuyenXe.IdTuyen = ChuyenXe.IdTuyen)", connection);
            DataSet data = new DataSet();
            SqlDataAdapter adap = new SqlDataAdapter(comm);
            adap.Fill(data);
            connection.Close();
            cobChonTuyen.DataSource = data.Tables[0];
            cobChonTuyen.DisplayMember = "TenTuyen";
            cobChonNgay.DataSource = data.Tables[0];
            cobChonNgay.DisplayMember = "NgayDi";
            cobChonXe.DataSource = data.Tables[0];
            cobChonXe.DisplayMember = "So_Xe";
            cobGio.DataSource = data.Tables[0];
            cobGio.DisplayMember = "Gio";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = true;
            txtPassWord.Enabled = true;
            txtSDT.Enabled = true;
            txtUserName.Enabled = true;
            cobGioiTinh.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = true;
        }
        private void cobGioiTinh_DropDownStyleChanged(object sender, EventArgs e)
        {
            cobGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình", "Thoát chương trình", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length == 0){MessageBox.Show("Chưa nhập UserName"); txtUserName.Focus();}
            else if (txtHoTen.Text.Trim().Length == 0){MessageBox.Show("Chưa nhập họ tên"); txtHoTen.Focus();}
            else if (txtPassWord.Text.Trim().Length == 0){MessageBox.Show("Chưa nhập PassWord"); txtPassWord.Focus();}
            else if (txtSDT.Text.Trim().Length == 0){MessageBox.Show("Chưa nhập số điện thoại"); txtSDT.Focus();}
            else if (txtSDT.Text.Trim().Length < 10 || txtSDT.Text.Trim().Length > 11){MessageBox.Show("Số điện thoại không đúng"); txtSDT.Focus(); txtSDT.Clear();}
            else if (cobGioiTinh.SelectedIndex < 0){MessageBox.Show("Chưa chọn giớ tính"); cobGioiTinh.Focus();}
            else
            {
                string quyey = "INSERT INTO dbo.ACCOUNTDAILY VALUES (N'"+TangTUDong().ToString()+"', N'"+txtUserName.Text+"', N'"+txtHoTen.Text+"', N'"+txtPassWord.Text+"', N'"+cobGioiTinh.Text+"', N'"+txtSDT.Text+"', N'"+cobLoaiND.Text+"')";

                SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
                connection.Open();
                int dem = 0;
                for (int i = 0; i < dtwAcountDaiLy.Rows.Count-1; i++)
                {
                    if (txtPassWord.Text == dtwAcountDaiLy.Rows[i].Cells[3].Value.ToString() && txtUserName.Text == dtwAcountDaiLy.Rows[i].Cells[1].Value.ToString())
                    {
                        MessageBox.Show("PassWord và UserName đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassWord.Clear();
                        txtUserName.Clear();
                        txtUserName.Focus();
                        dem++;
                    }
                }
                if (dem == 0)
                {
                    SqlCommand com = new SqlCommand(quyey, connection);
                    com.ExecuteNonQuery();
                    connection.Close();
                    dtwAcountDaiLy.DataSource = getAllAcountDaily().Tables[0];
                    MessageBox.Show("Thêm thành công");
                    Enable();
                    btnThem.Enabled = true;
                }
            }
        }

        private void dtwAcountDaiLy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dtwAcountDaiLy.Rows[e.RowIndex];
                txtHoTen.Text = row.Cells[2].Value.ToString();
                txtUserName.Text = row.Cells[1].Value.ToString();
                txtSDT.Text = row.Cells[5].Value.ToString();
                txtPassWord.Text = row.Cells[3].Value.ToString();
                cobGioiTinh.Text = row.Cells[4].Value.ToString();
                cobLoaiND.Text = row.Cells[6].Value.ToString();
                txtID.Text = row.Cells[0].Value.ToString();
            }
            catch { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtSDT.Clear();
            txtPassWord.Clear();
            txtHoTen.Clear();
            Enable();
            btnThem.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string quyey = "Delete from dbo.ACCOUNTDAILY Where Id = N'"+txtID.Text+"'";
            SqlConnection con = new SqlConnection(ConnectionStringDatagril.connectionString);
            con.Open();
            if (txtID.Text.Trim().Length != 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa ID : " + txtID.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SqlCommand com = new SqlCommand(quyey, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    dtwAcountDaiLy.DataSource = getAllAcountDaily().Tables[0];
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
            }
            else if (txtID.Text.Trim().Length == 0)
                MessageBox.Show("Bạn chưa chọn ID để xóa", "Thông báo");
            else { }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string quyey = "Update dbo.ACCOUNTDAILY Set username = N'"+txtUserName.Text+"', password = N'"+txtPassWord.Text+"', SDT = N'"+txtSDT.Text+"', Name = N'"+txtHoTen.Text+"', GioiTinh = N'"+cobGioiTinh.Text+"' where Id = N'"+txtID.Text+"'";
            SqlConnection con = new SqlConnection(ConnectionStringDatagril.connectionString);
            con.Open();
            if (txtID.Text.Trim().Length != 0)
            {
                if (MessageBox.Show("Bạn chắc muốn thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SqlCommand com = new SqlCommand(quyey, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    dtwAcountDaiLy.DataSource = getAllAcountDaily().Tables[0];
                    MessageBox.Show("Update thành công");
                }
            }
            else if (txtID.Text.Trim().Length == 0)
                MessageBox.Show("Bạn chưa chọn ID để sửa", "Thông báo");
            else { }
        }

        private void btnCapPass_Click(object sender, EventArgs e)
        {
            frmCapPass fr = new frmCapPass();
            fr.ShowDialog();
            fr.Close();
            dtwAcountDaiLy.DataSource = getAllAcountDaily().Tables[0];
        }       
        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            frmPhanQuyen fr = new frmPhanQuyen();
            fr.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToString();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            RePortDSNV r = new RePortDSNV();
            r.ShowDialog();
        }

        private void btnQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 0;
        }

        private void btnQuanLyXe_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 1;
        }

        private void btnQuanLyTuyenXe_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabMain.SelectedIndex = 5;
        }
        private void btnThemXe_Click(object sender, EventArgs e)
        {
            btnLuuXe.Enabled = true;
            btnHuyXe.Enabled = true;
            btnThemXe.Enabled = false;
            btnXoaXe.Enabled = false;
            btnSuaXe.Enabled = false;
            cobChoNgoi.Enabled = true;
            cobHieuXe.Enabled = true;
            txtDoiXe.Enabled = true;
            cobSoXe.SelectedIndex = -1;
            cobHieuXe.SelectedIndex = -1;
            cobChoNgoi.SelectedIndex = -1;
            txtDoiXe.Clear();
        }
        private void btnHuyXe_Click(object sender, EventArgs e)
        {
            btnThemXe.Enabled = true;
            btnXoaXe.Enabled = true;
            btnSuaXe.Enabled = true;
            btnLuuXe.Enabled = false;
            btnHuyXe.Enabled = false;
            //cobSoXe.Enabled = false;
            cobHieuXe.Enabled = false;
            txtDoiXe.Enabled = false;
            cobChoNgoi.Enabled = false;
            cobChoNgoi.SelectedIndex = 0;
            cobHieuXe.SelectedIndex = 0;
            cobSoXe.SelectedIndex = 0;
        }
        private void dtwXe_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dtwXe.Rows[e.RowIndex];
                txtDoiXe.Text = row.Cells[2].Value.ToString();
                cobChoNgoi.Text = row.Cells[3].Value.ToString();
                cobHieuXe.Text = row.Cells[1].Value.ToString();
                cobSoXe.Text = row.Cells[0].Value.ToString();
            }
            catch { }
        }
        private void btnXoaXe_Click(object sender, EventArgs e)
        {
            string quyey = "Delete from dbo.Xe Where So_Xe = N'" + cobSoXe.Text + "'";
            SqlConnection con = new SqlConnection(ConnectionStringDatagril.connectionString);
            con.Open();
            if (cobSoXe.Text.Trim().Length != 0)
            {
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa ID : " + cobSoXe.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        SqlCommand com = new SqlCommand();
                        com.CommandText = quyey;
                        com.Connection = con;
                        com.ExecuteNonQuery();
                        con.Close();
                        dtwXe.DataSource = GetAllXe().Tables[0];
                        MessageBox.Show("Xóa thành công");
                    }
                }
                catch { }
                dtwThongTinCX.DataSource = GetAllXe().Tables[0];
            }
            else if (cobSoXe.Text.Trim().Length == 0)
                MessageBox.Show("Bạn chưa chọn số xe để xóa", "Thông báo");
            else { }
        }
        void SuaXe()
        {
            cobSoXe.Enabled = false;
            btnThemXe.Enabled = false;
            btnXoaXe.Enabled = false;
            btnLuuXe.Enabled = true;
            btnHuyXe.Enabled = true;
            cobHieuXe.Enabled = true;
            cobChoNgoi.Enabled = true;
            txtDoiXe.Enabled = true;
            btnLuuXe.Enabled = false;
            //btnSuaXe.Enabled = false;
        }
        private void btnSuaXe_Click(object sender, EventArgs e)
        {
            SuaXe();
            string quyey = "Update dbo.Xe Set Hieu_Xe = N'"+ cobHieuXe.Text +"', Doi_Xe = N'"+ txtDoiXe.Text +"', So_Cho_Ngoi = '"+ Convert.ToInt32(cobChoNgoi.Text)+"' Where So_Xe = N'"+ cobSoXe.Text +"'";
            SqlConnection con = new SqlConnection(ConnectionStringDatagril.connectionString);
            con.Open();
            if (cobHieuXe.Text.Trim().Length != 0 && cobChoNgoi.Text.Trim().Length != 0 && txtDoiXe.Text.Trim().Length != 0)
            {
                if (MessageBox.Show("Bạn chắc muốn thay đổi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SqlCommand com = new SqlCommand(quyey, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    dtwXe.DataSource = GetAllXe().Tables[0];
                    MessageBox.Show("Update thành công");
                }
            }
            else if (cobSoXe.Text.Trim().Length == 0)
                MessageBox.Show("Bạn chưa chọn để sửa", "Thông báo");
            else { MessageBox.Show("Thông tin không để trống"); }
            dtwThongTinCX.DataSource = GetAllXe().Tables[0];
        }
        void LuuXe()
        {
            btnLuuXe.Enabled = false;
            btnHuyXe.Enabled = false;
        }
        private void btnLuuXe_Click(object sender, EventArgs e)
        {
            if (cobSoXe.Text.Trim().Length == 0){ MessageBox.Show("Số xe không trống"); cobSoXe.Focus();}
            else if (cobHieuXe.Text.Trim().Length == 0) { MessageBox.Show("Hiệu xe không trống"); cobHieuXe.Focus(); }
            else if (txtDoiXe.Text.Trim().Length == 0) { MessageBox.Show("Đời xe không trống"); txtDoiXe.Focus(); }
            else if (cobChoNgoi.Text.Trim().Length == 0) { MessageBox.Show("Số chỗ ngồi không trống"); cobChoNgoi.Focus(); }
            else
            {
                string quyey = "INSERT INTO dbo.Xe VALUES (N'"+ cobSoXe.Text +"', N'"+cobHieuXe.Text+"', N'"+txtDoiXe.Text+"', N'"+Convert.ToInt32(cobChoNgoi.Text)+"')";

                SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
                connection.Open();
                int dem = 0;
                for (int i = 0; i < dtwXe.Rows.Count-1; i++)
                {
                    if (cobSoXe.Text == dtwXe.Rows[i].Cells[0].Value.ToString() && cobHieuXe.Text == dtwXe.Rows[i].Cells[1].Value.ToString() && cobChoNgoi.Text == dtwXe.Rows[i].Cells[3].Value.ToString() && txtDoiXe.Text == dtwXe.Rows[i].Cells[2].Value.ToString())
                    {
                        MessageBox.Show("Đã tồn tại Xe", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cobChoNgoi.SelectedIndex = -1;
                        cobHieuXe.SelectedIndex = -1;
                        cobSoXe.SelectedIndex = -1;
                        txtDoiXe.Clear();
                        dem++;
                    }
                    else if (cobSoXe.Text == dtwXe.Rows[i].Cells[0].Value.ToString()) { MessageBox.Show("Số xe đã có"); cobSoXe.Focus(); dem++; }
                    else { }
                }
                if (dem == 0)
                {
                    SqlCommand com = new SqlCommand(quyey, connection);
                    com.ExecuteNonQuery();
                    connection.Close();
                    dtwXe.DataSource = GetAllXe().Tables[0];
                    MessageBox.Show("Thêm thành công");
                }
                dtwThongTinCX.DataSource = GetAllXe().Tables[0];
            }
        }
        private void dtwTX_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dtwTX.Rows[e.RowIndex];
                cobDDDi.Text = row.Cells[2].Value.ToString();
                cobDDDen.Text = row.Cells[3].Value.ToString();
                cobTenTuyen.Text = row.Cells[1].Value.ToString();
                cobMaTuyen.Text = row.Cells[0].Value.ToString();
            }
            catch { }
        }
        private void btnThemTX_Click(object sender, EventArgs e)
        {
            cobDDDi.Enabled = true;
            cobDDDen.Enabled = true;
            cobTenTuyen.Enabled = true;
            cobMaTuyen.Enabled = true;
            dtwTX.Enabled = false;
            btnThemTX.Enabled = false;
            btnHuyTX.Enabled = true;
            btnLuuTX.Enabled = true;
            btnSuaTX.Enabled = false;
            btnXoaTX.Enabled = false;
            cobTenTuyen.SelectedIndex = -1;
            cobMaTuyen.SelectedIndex = -1;
            cobDDDen.SelectedIndex = -1;
            cobDDDi.SelectedIndex = -1;
        }
        private void btnHuyTX_Click(object sender, EventArgs e)
        {
            cobDDDi.Enabled = false;
            cobDDDen.Enabled = false;
            cobTenTuyen.Enabled = false;
            dtwTX.Enabled = true;
            btnThemTX.Enabled = true;
            btnHuyTX.Enabled = false;
            btnLuuTX.Enabled = false;
            btnSuaTX.Enabled = true;
            btnXoaTX.Enabled = true;
            cobTenTuyen.SelectedIndex = 0;
            cobMaTuyen.SelectedIndex = 0;
            cobDDDen.SelectedIndex = 0;
            cobDDDi.SelectedIndex = 0;
        }
        private void btnXoaTX_Click(object sender, EventArgs e)
        {
            string quyey = "Delete from dbo.TuyenXe Where  IdTuyen = N'" + cobMaTuyen.Text + "'";
            SqlConnection con = new SqlConnection(ConnectionStringDatagril.connectionString);
            con.Open();
            if (cobMaTuyen.Text.Trim().Length != 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa ID : " + cobMaTuyen.Text + " của tuyến xe", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SqlCommand com = new SqlCommand(quyey, con);
                    com.ExecuteNonQuery();
                    con.Close();
                    dtwTX.DataSource = getAllTX().Tables[0];
                    MessageBox.Show("Xóa thành công");
                    GetThoiDiem(); ComboboxTX();
                }
            }
            else if (cobMaTuyen.Text.Trim().Length == 0)
                MessageBox.Show("Bạn chưa chọn để xóa", "Thông báo");
            else { }
        }
        private void btnSuaTX_Click(object sender, EventArgs e)
        {
            cobDDDi.Enabled = true;
            cobDDDen.Enabled = true;
            cobTenTuyen.Enabled = true;
            dtwTX.Enabled = false;
            btnThemTX.Enabled = false;
            btnHuyTX.Enabled = true;
            btnLuuTX.Enabled = true;
            btnSuaTX.Enabled = false;
            btnXoaTX.Enabled = false;
            dtwTX.Enabled = true;
            cobMaTuyen.Enabled = false;
        }
        private void btnLuuTX_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
            if (dtwTX.Enabled == true)
            {
                String s = "Update dbo.TuyenXe Set TenTuyen = N'" + cobTenTuyen.Text + "', DiaDiemDi = N'" + cobDDDi.Text + "', DiaDiemDen = N'" + cobDDDen.Text + "' Where IdTuyen = N'" + cobMaTuyen.Text + "'";
                try
                {
                    if (cobDDDen.Text.Trim().Length != 0 && cobDDDi.Text.Trim().Length != 0 && cobTenTuyen.Text.Trim().Length != 0)
                    {                       
                        connection.Open();
                        SqlCommand com = new SqlCommand(s, connection);
                        com.ExecuteNonQuery();
                        connection.Close();
                        dtwTX.DataSource = getAllTX().Tables[0];
                        MessageBox.Show("Thực hiện sửa thành công");
                        GetThoiDiem(); ComboboxTX(); LoadComboBoxTTCX();
                    }
                    else if (cobTenTuyen.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập tên tuyến"); cobTenTuyen.Focus(); }
                    else if (cobDDDi.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập địa điểm đi"); cobDDDi.Focus(); }
                    else if (cobDDDen.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập địa điểm đến"); cobDDDen.Focus(); }
                    else { }
                }
                catch { MessageBox.Show("Không thực hiện được"); }
            }
            else
            {
                int dem = 0;
                if (cobDDDen.Text.Trim().Length != 0 && cobDDDi.Text.Trim().Length != 0 && cobMaTuyen.Text.Trim().Length != 0 && cobTenTuyen.Text.Trim().Length != 0)
                {
                    for (int i = 0; i < dtwTX.Rows.Count - 1; i++)
                    {
                        if (cobMaTuyen.Text == dtwTX.Rows[i].Cells[0].Value.ToString())
                        {
                            MessageBox.Show("Trùng mã tuyến");
                            dem++;
                        }
                        else
                        {
                            if (cobTenTuyen.Text == dtwTX.Rows[i].Cells[1].Value.ToString() && cobDDDen.Text == dtwTX.Rows[i].Cells[2].Value.ToString() && cobDDDi.Text == dtwTX.Rows[i].Cells[3].Value.ToString())
                            {
                                MessageBox.Show("Đã tồn tại");
                                dem++; 
                            }
                        }
                    }
                    if (dem == 0)
                    {
                        try
                        {
                            connection.Open();
                            SqlCommand com = new SqlCommand("INSERT INTO dbo.TuyenXe VALUES (N'" + cobMaTuyen.Text + "',N'" + cobTenTuyen.Text + "', N'" + cobDDDi.Text + "', N'" + cobDDDen.Text + "')", connection);
                            com.ExecuteNonQuery();
                            connection.Close();
                            dtwTX.DataSource = getAllTX().Tables[0];
                            MessageBox.Show("Thực hiện thêm thành công");
                            //for (int i = 0; i < dtwTX.Rows.Count - 1; i++)
                            //dtwTX.Rows[dtwTX.Rows.Count - 1].Selected = true;
                            GetThoiDiem(); ComboboxTX(); LoadComboBoxTTCX();
                        }
                        catch { MessageBox.Show("Tên Tuyến đã có"); }
                    }
                    
                }
                else if (cobMaTuyen.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập mã tuyến"); cobMaTuyen.Focus(); }
                else if (cobTenTuyen.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập tên tuyến"); cobTenTuyen.Focus(); }
                else if (cobDDDi.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập địa điểm đi"); cobDDDi.Focus(); }
                else if (cobDDDen.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập địa điểm đến"); cobDDDen.Focus(); }
                else { }
            }          
        }
        private void btnThemTD_Click(object sender, EventArgs e)
        {           
            cobMaTD.Enabled = false;
            btnThemTD.Enabled = false;
            btnSuaTD.Enabled = false;
            btnXoaTD.Enabled = false;
            btnHuyTD.Enabled = true;
            btnLuuTD.Enabled = true;
            rdThem.Checked = true;
            rdSua.Checked = false;
        }
        private void btnHuyTD_Click(object sender, EventArgs e)
        {
            cobMaTD.Enabled = true;
            btnThemTD.Enabled = true;
            btnSuaTD.Enabled = true;
            btnXoaTD.Enabled = true;
            btnHuyTD.Enabled = false;
            btnLuuTD.Enabled = false;
        }
        private void btnXemTX_Click(object sender, EventArgs e)
        {
            frmChiTietTuyenXe fr = new frmChiTietTuyenXe();
            fr.ShowDialog();
        }
        private void btnDongY_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
            if (cobMST.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập mã số tuyến xe"); cobMST.Focus(); }
            else if (cobTX.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập tên tuyến xe"); cobTX.Focus(); }
            else if (cobTX.Text.Trim().Length != 0 && cobMST.Text.Trim().Length != 0)
            {
                try
                {
                    connection.Open();
                    SqlCommand comm = new SqlCommand("Select TuyenXe.IdTuyen, ChiTietTuyen.IdThoiDiem, ThoiDiem.Ngay, ThoiDiem.Gio, TuyenXe.TenTuyen From TuyenXe Join ChiTietTuyen on (TuyenXe.IdTuyen = ChiTietTuyen.IdTuyen) Join ThoiDiem on (ThoiDiem.IdThoiDiem = ChiTietTuyen.IdThoiDiem)", connection);
                    comm.ExecuteNonQuery();
                    connection.Close();
                }
                catch { }
            }
            else { }
        }
        private void dtwThoiDiem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dtwThoiDiem.Rows[e.RowIndex];
                cobMaTD.Text = row.Cells[0].Value.ToString();
                dtpTD.Text = row.Cells[1].Value.ToString();
                txtGioKhoiHanh.Text = row.Cells[2].Value.ToString();
            }
            catch { }
        }
        private void btnSuaTD_Click(object sender, EventArgs e)
        {
            cobMaTD.Enabled = false;
            btnThemTD.Enabled = false;
            btnSuaTD.Enabled = false;
            btnXoaTD.Enabled = false;
            btnHuyTD.Enabled = true;
            btnLuuTD.Enabled = true;
            rdSua.Checked = true;
            rdThem.Checked = false;
        }
        private void btnLuuTD_Click(object sender, EventArgs e)
        {
            string ngay = dtpTD.Value.ToString("MM/dd/yyyy");
            SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
            if (rdSua.Checked)
            {
                try
                {
                    if (cobMaTD.Text.Trim().Length == 0) { MessageBox.Show("Chưa chọn mã thời điểm"); cobMaTD.Focus(); }
                    else if (dtpTD.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập thời gian khởi hành"); dtpTD.Focus(); }
                    else if (txtGioKhoiHanh.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập mã thời điểm"); txtGioKhoiHanh.Focus(); }
                    else if (cobMaTD.Text.Trim().Length != 0 && dtpTD.Text.Trim().Length != 0 && txtGioKhoiHanh.Text.Trim().Length != 0)
                    {
                        if (MessageBox.Show("Bạn muốn sửa thông tin của mã thời điểm "+ cobMaTD.Text +"","Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            connection.Open();
                            SqlCommand comm = new SqlCommand("Update ThoiDiem Set Ngay = N'" + ngay + "', Gio = N'" + txtGioKhoiHanh.Text + "' Where IdThoiDiem = N'" + cobMaTD.Text + "'", connection);
                            comm.ExecuteNonQuery();
                            connection.Close();
                            GetThoiDiem();
                            MessageBox.Show("Cập nhập thành công");
                            GetThoiDiem(); ComboboxTX(); LoadBanVe(); LoadComboBoxTTCX();
                        }
                    }
                    else { }
                }
                catch { MessageBox.Show("Cập nhật không thành công"); }
            }
            if(rdThem.Checked)
            {
                if (dtpTD.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập thời gian khởi hành"); dtpTD.Focus(); }
                else if (txtGioKhoiHanh.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập giờ khởi hành"); txtGioKhoiHanh.Focus(); }
                else if (cobMaTD.Text.Trim().Length != 0 && dtpTD.Text.Trim().Length != 0 && txtGioKhoiHanh.Text.Trim().Length != 0)
                {
                    if (MessageBox.Show("Bạn muốn thêm thời điểm cho xe " + cobMaTD.Text + "", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        connection.Open();
                        SqlCommand comm = new SqlCommand("INSERT INTO ThoiDiem(Ngay, Gio) VALUES(N'" + dtpTD.Text + "', N'" + txtGioKhoiHanh.Text + "')", connection);
                        comm.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Thêm thành công"); GetThoiDiem();
                        GetThoiDiem(); ComboboxTX(); LoadBanVe(); LoadComboBoxTTCX();
                    }
                }
            }
        }
        private void btnXoaTD_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
            if (cobMaTD.Text.Trim().Length == 0) { MessageBox.Show("Chưa chọn mã thời điểm"); cobMaTD.Focus(); }
            else if (txtGioKhoiHanh.Text.Trim().Length == 0) { MessageBox.Show("Chưa chọn giờ khởi hành"); txtGioKhoiHanh.Focus(); }
            else if (cobMaTD.Text.Trim().Length != 0 && txtGioKhoiHanh.Text.Trim().Length != 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa MÃ THỜI ĐIỂM "+ cobMaTD.Text +"", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    connection.Open();
                    SqlCommand comm = new SqlCommand("Delete ChiTietTuyen from ThoiDiem, ChiTietTuyen Where ThoiDiem.IdThoiDiem = ChiTietTuyen.IdThoiDiem and ChiTietTuyen.IdThoiDiem = '" + cobMaTD.Text + "'", connection);
                    comm.ExecuteNonQuery();
                    SqlCommand com = new SqlCommand("Delete from ThoiDiem Where IdThoiDiem = N'" + cobMaTD.Text + "'", connection);
                    com.ExecuteNonQuery();
                    connection.Close();
                    dtwTX.DataSource = getAllTX().Tables[0]; GetThoiDiem(); MessageBox.Show("Xóa thành công"); ComboboxTX();
                    cobMaTD.SelectedIndex = -1; txtGioKhoiHanh.Clear();
                }
            }
            else { }
        }
        private void btnThemCX_Click(object sender, EventArgs e)
        {
            cobMaSoC.Enabled = false;
            cobNgayDi.Enabled = true;
            cobTuyenXe.Enabled = true;
            cobGioDi.Enabled = true;
            cobSX.Enabled = true;
            btnHuyCX.Enabled = true;
            btnLuuCX.Enabled = true;
            btnThemCX.Enabled = false;
            btnXoaCX.Enabled = false;
            btnSuaCX.Enabled = false;
            dtwChuyenXe.Enabled = false;
            cobSX.DropDownStyle = ComboBoxStyle.DropDown;
            cobMaSoC.SelectedIndex = -1; cobNgayDi.SelectedIndex = -1; cobSX.SelectedIndex = -1; cobTuyenXe.SelectedIndex = -1; cobGioDi.SelectedIndex = -1;
        }
        private void btnSuaCX_Click(object sender, EventArgs e)
        {
            cobMaSoC.Enabled = false;
            cobNgayDi.Enabled = true;
            cobTuyenXe.Enabled = true;
            cobGioDi.Enabled = true;
            cobSX.Enabled = true;
            btnHuyCX.Enabled = true;
            btnLuuCX.Enabled = true;
            btnThemCX.Enabled = false;
            btnXoaCX.Enabled = false;
            btnSuaCX.Enabled = false;
            cobTuyenXe.SelectedIndex = 0;
            cobTuyenXe.SelectedIndex = 0;
        }
        private void btnHuyCX_Click(object sender, EventArgs e)
        {
            LoadChuyenXe();
            dtwChuyenXe.Enabled = true;
            cobMaSoC.Enabled = true;
            cobMaSoC.SelectedIndex = 0; cobNgayDi.SelectedIndex = 0; cobSX.SelectedIndex = 0; cobTuyenXe.SelectedIndex = 0; cobGioDi.SelectedIndex = 0;
        }
        private void btnLuuCX_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
            if (dtwChuyenXe.Enabled == true)
            {               
                 if (cobMaSoC.Text.Trim().Length != 0 && cobTuyenXe.Text.Trim().Length != 0 && cobGioDi.Text.Trim().Length != 0 && cobSX.Text.Trim().Length != 0 && cobNgayDi.Text.Trim().Length != 0 && KiemTraNgay(cobNgayDi.Text) && KTMaTuyen(cobTuyenXe.Text) && KTSoXe(cobSX.Text))
                  {
                      if (MessageBox.Show("Bạn muốn sửa chuyến xe", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                      {
                          connection.Open();
                          string ngay = Convert.ToDateTime(cobNgayDi.Text).ToString("MM/dd/yyyy");
                          string s = "Update ChuyenXe Set IdTuyen = N'" + cobTuyenXe.Text + "', NgayDi = '" + ngay + "', Gio = N'" + cobGioDi.Text + "', So_Xe = N'" + cobSX.Text + "' Where IdChuyen = N'" + cobMaSoC.Text + "'";
                          SqlCommand comm = new SqlCommand(s, connection);
                          comm.ExecuteNonQuery();
                          connection.Close();
                          ComboBoxChuyenXe();
                          MessageBox.Show("Cập nhật thành công", "Thông báo");
                      }
                  }
                 else if (cobMaSoC.Text.Trim().Length == 0) { MessageBox.Show("Chưa chọn mã số chuyến xe", "Thông báo"); }
                 else if (cobTuyenXe.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập mã số Tuyến xe", "Thông báo"); }
                 else if (cobGioDi.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập giờ xe chạy", "Thông báo"); }
                 else if (cobSX.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập biển số xe", "Thông báo"); }
                 else if (KiemTraNgay(cobNgayDi.Text) == false) { MessageBox.Show("Ngày nhập không đúng"); }
                 else if (!KTMaTuyen(cobTuyenXe.Text)) { MessageBox.Show("Mã tuyến nhập không có", "Thông báo"); }
                 else if (!KTSoXe(cobSX.Text)) { MessageBox.Show("Số xe chưa được thêm ", "Thông báo"); }
                 else { }   
            }
            else
            {
                if (cobTuyenXe.Text.Trim().Length != 0 && cobGioDi.Text.Trim().Length != 0 && cobSX.Text.Trim().Length != 0 && cobNgayDi.Text.Trim().Length != 0 && KiemTraNgay(cobNgayDi.Text) && KTMaTuyen(cobTuyenXe.Text) && KTSoXe(cobSX.Text))
                {
                    if (MessageBox.Show("Bạn muốn thêm chuyến xe","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        connection.Open();
                        string ngay = Convert.ToDateTime(cobNgayDi.Text).ToString("dd/MM/yyyy");
                        string s = "INSERT INTO ChuyenXe(IdTuyen, So_Xe, NgayDi, Gio) Values(N'" + cobTuyenXe.Text + "', N'" + cobSX.Text + "', N'" + ngay + "', N'" + cobGioDi.Text + "')";
                        SqlCommand comm = new SqlCommand(s, connection);
                        comm.ExecuteNonQuery();
                        connection.Close();
                        ComboBoxChuyenXe();
                        MessageBox.Show("Thêm thành công", "Thông báo");
                    }
                }
                else if (cobTuyenXe.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập mã số Tuyến xe", "Thông báo"); }
                else if (cobGioDi.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập giờ xe chạy", "Thông báo"); }
                else if (cobSX.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập biển số xe"); }
                else if (KiemTraNgay(cobNgayDi.Text) == false) { MessageBox.Show("Ngày nhập không đúng", "Thông báo"); }
                else if (!KTMaTuyen(cobTuyenXe.Text)) { MessageBox.Show("Mã tuyến nhập không có", "Thông báo"); }
                else if (!KTSoXe(cobSX.Text)) { MessageBox.Show("Số xe chưa được thêm", "Thông báo"); }
                else { } 
            }
            LoadBanVe(); GetThoiDiem(); ComboboxTX(); LoadComboBoxTTCX();
        }
        private void cobNgayDi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '/'))
                e.Handled = true;
        }

        private void dtwThongTinHanhKhach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dtwThongTinHanhKhach.Rows[e.RowIndex];
                txtSoDT.Text = row.Cells[2].Value.ToString();
                txtTenHanhKhach.Text = row.Cells[1].Value.ToString();
                cobMaSoVe.Text = row.Cells[0].Value.ToString();
            }
            catch { }
        }

        private void btnChonChoNGoi_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
            connection.Open();
            try
            {
                SqlCommand comm = new SqlCommand("Select Xe.So_Cho_Ngoi from Xe Where So_Xe = N'" + cobChonXe.Text + "'", connection);
                DataSet data = new DataSet();
                SqlDataAdapter adap = new SqlDataAdapter(comm);
                adap.Fill(data);
                cob.DataSource = data.Tables[0];
                cob.DisplayMember = "So_Cho_Ngoi";
                connection.Close();               
            }           
            catch { MessageBox.Show("Số xe không hợp lệ", "Thông báo"); }
            if (cob.Text == "7")
            {
                choxe.s = cobChonTuyen.Text;
                choxe.GioDi = cobGio.Text;
                choxe.NgayDi = cobChonNgay.Text;
                choxe.SoXe = cobChonXe.Text;
                choxe.STDHK = txtSoDT.Text;
                choxe.TenHanhKhach = txtTenHanhKhach.Text;
                connection.Open();
                SqlCommand comm = new SqlCommand("Select IdChuyen From ChuyenXe ", connection);
                connection.Close();
                choxe.ShowDialog();              
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {          
            frmlogin fr = new frmlogin();
            this.Hide(); 
            fr.ShowDialog();            
            //this.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dtpTD_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}

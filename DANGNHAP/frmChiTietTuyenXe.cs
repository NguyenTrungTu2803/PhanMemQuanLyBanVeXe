using DANGNHAP.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DANGNHAP
{
    public partial class frmChiTietTuyenXe : Form
    {
        public frmChiTietTuyenXe()
        {
            InitializeComponent();
        }
        public SqlConnection connection = new SqlConnection(ConnectionStringDatagril.connectionString);
        private void frmChiTietTuyenXe_Load(object sender, EventArgs e)
        {
            LoadcobChiTiet();
            LoaddtwThiHien();
            ThemHeartDTGV();       
        }
        void LoadcobChiTiet()
        {
            DataSet data = new DataSet();
            connection.Open();
            SqlCommand com = new SqlCommand("Select * From TuyenXe", connection);
            SqlDataAdapter adap = new SqlDataAdapter(com);
            adap.Fill(data);
            cobMaTuyenXe.DataSource = data.Tables[0];
            cobTenTuyenXe.DataSource = data.Tables[0];
            cobMaTuyenXe.ValueMember = "IdTuyen";
            cobTenTuyenXe.DisplayMember = "TenTuyen";
            connection.Close();
        }
        void LoaddtwThiHien()
        {
            DataSet dat = new DataSet();
            connection.Open();
            SqlCommand comm = new SqlCommand("	Select TuyenXe.IdTuyen, ChiTietTuyen.IdThoiDiem, ThoiDiem.Ngay, ThoiDiem.Gio, TuyenXe.TenTuyen From TuyenXe Join ChiTietTuyen on (TuyenXe.IdTuyen = ChiTietTuyen.IdTuyen) Join ThoiDiem on (ThoiDiem.IdThoiDiem = ChiTietTuyen.IdThoiDiem)", connection);
            SqlDataAdapter adap = new SqlDataAdapter(comm);
            adap.Fill(dat);
            dtwChiTiet.DataSource = dat.Tables[0];
            connection.Close();
        }
        void ThemHeartDTGV()
        {
            dtwChiTiet.Columns[0].HeaderText = "Mã số tuyến";
            dtwChiTiet.Columns[1].HeaderText = "Thời điểm";
            dtwChiTiet.Columns[2].HeaderText = "Ngày Khởi Hành";
            dtwChiTiet.Columns[3].HeaderText = "Giờ Khởi Hành";
            dtwChiTiet.Columns[4].HeaderText = "Tên tuyến";
            dtwChiTiet.Columns[0].Width = 107;
            dtwChiTiet.Columns[1].Width = 100;
            dtwChiTiet.Columns[2].Width = 150;
            dtwChiTiet.Columns[3].Width = 150;
            dtwChiTiet.Columns[4].Width = 150;
        }
        //Nguồn intternet..............................................
        private void CheckExist(DataTable tbl, string filterExpression)
        {
            if (filterExpression == "")
            {
                return;
            }
            DataRow[] rows = tbl.Select(filterExpression);
            if (rows.Length <= 0)
            {
                return;
            }
            //Thể hiện dữ liệu tìm được ra dtwChiTiet
            tbl = ((DataTable)this.dtwChiTiet.DataSource).Clone();
            for (int i = 0; i < rows.Length; i++)
            {
                DataRow row = tbl.NewRow();
                row[0] = rows[i].ItemArray[0].ToString();
                row[1] = rows[i].ItemArray[1].ToString();
                row[2] = rows[i].ItemArray[2].ToString();
                row[3] = rows[i].ItemArray[3].ToString();
                row[4] = rows[i].ItemArray[4].ToString();
                tbl.Rows.Add(row);
            }
            dtwChiTiet.DataSource = tbl;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            if (btnHienThi.Text == "Lọc danh sách theo mã tuyến")
            {
                string filter = "IdTuyen='" + cobMaTuyenXe.Text + "'";
                CheckExist((DataTable)this.dtwChiTiet.DataSource, filter);
                btnHienThi.Text = "Hiện thị tất cả danh sách";
            }
            else if (btnHienThi.Text == "Hiện thị tất cả danh sách")
            {
                btnHienThi.Text = "Lọc danh sách theo mã tuyến";
                LoaddtwThiHien();
            }
            else{}
            
        }

        private void btn_Thoát_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (cobMSTX.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập mã số tuyến xe"); cobMSTX.Focus(); }
            else if(cobMTD.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập mã thời điểm"); cobMTD.Focus(); }
            else if (txtGKH.Text.Trim().Length == 0) { MessageBox.Show("Chưa nhập giờ khởi hành"); txtGKH.Focus(); }
            else if (cobMSTX.Text.Trim().Length != 0 && cobMTD.Text.Trim().Length != 0 && txtGKH.Text.Trim().Length != 0)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa tuyến xe ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    connection.Open();
                    SqlCommand comm = new SqlCommand("Delete ChiTietTuyen From TuyenXe, ThoiDiem Where ChiTietTuyen.IdTuyen = '" + cobMSTX.Text + "' and TuyenXe.IdTuyen = '" + cobMSTX.Text + "' and ThoiDiem.IdThoiDiem = '" + cobMTD.Text + "' and ChiTietTuyen.IdThoiDiem = '" + cobMTD.Text + "'", connection);
                    comm.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Xóa thành công");
                    LoaddtwThiHien();
                }
                else { }
            }
            else { }
        }

        private void dtwChiTiet_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dtwChiTiet.Rows[e.RowIndex];
            cobMSTX.Text = row.Cells[0].Value.ToString();
            cobMTD.Text = row.Cells[1].Value.ToString();
            dtpNgay.Text = row.Cells[2].Value.ToString();
            txtGKH.Text = row.Cells[3].Value.ToString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANGNHAP.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return DataProvider.instance;
            }
            private set { instance = value; }
        }
        // Lấy đường link kết nối
        private string connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=QUANLYVEXE;Integrated Security=True";
        //trả về kết quả của table
        public DataTable ExcuteQuery(string quey, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection sqp = new SqlConnection(connection)) // khởi tạo sql kết nối xuống server VS
            {
                sqp.Open(); // mở lấy dữ liệu

                SqlCommand command = new SqlCommand(quey, sqp); // câu truy vấn thực thi lệnh quey trên sqlconnection

                if (parameter != null)
                {
                    string[] listpara = quey.Split(' ');
                    int i = 0;
                    foreach (string item in listpara) // với mỗi item thì add vào.
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter datadapter = new SqlDataAdapter(command); // trung gian lấy đữ liệu cho câu truy vấn
                datadapter.Fill(data); // đổ đữ liệu data vào datadapter. 
                sqp.Close();
            }
            return data;
        }
        // trả về số dòng thành công
        public int ExcuteNonQuery(string quey, object[] parameter = null)
        {
            int data = 0; // 0 dòng thành công;
            using (SqlConnection sqp = new SqlConnection(connection)) // khởi tạo sql kết nối xuống server VS
            {
                sqp.Open(); // mở lấy dữ liệu

                SqlCommand command = new SqlCommand(quey, sqp); // câu truy vấn thực thi lệnh quey trên sqlconnection

                if (parameter != null)
                {
                    string[] listpara = quey.Split(' ');
                    int i = 0;
                    foreach (string item in listpara) // với mỗi item thì add vào.
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();// khi update delete... return về số dòng thành công
                sqp.Close();
            }
            return data;
        }
        // số lượng trả ra là object
        public object ExcuteScalar(string quey, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection sqp = new SqlConnection(connection)) // khởi tạo sql kết nối xuống server VS
            {
                sqp.Open(); // mở lấy dữ liệu

                SqlCommand command = new SqlCommand(quey, sqp); // câu truy vấn thực thi lệnh quey trên sqlconnection

                if (parameter != null)
                {
                    string[] listpara = quey.Split(' ');
                    int i = 0;
                    foreach (string item in listpara) // với mỗi item thì add vào.
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar(); // trả về cái dòng cột đầu tiên trong bản kết quả
                sqp.Close();
            }
            return data;
        }
    }
}

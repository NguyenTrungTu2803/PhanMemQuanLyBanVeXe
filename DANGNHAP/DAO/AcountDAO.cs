using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DANGNHAP.DAO
{
    public class AcountDAO
    {
        private static AcountDAO instance;

        public static AcountDAO Instance // ham trung gian thuc thi cho frmlogin
        {
            get 
            {
                if (instance == null)
                    instance = new AcountDAO();
                return instance;
            }
            private set {instance = value;}
        }
        private AcountDAO() { } // Hàm dự phòng khi xảy ra lỗi

        public bool Login(string username, string password)
        {
            string quye = "USP_LOGIN @Username , @password";
            DataTable result = DataProvider.Instance.ExcuteQuery(quye, new object[] {username, password});

            return result.Rows.Count > 0;
        }

    }
}

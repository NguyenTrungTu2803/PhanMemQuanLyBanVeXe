﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANGNHAP.DAO
{
    public class AccountcongtyDAO
    {
        private static AccountcongtyDAO instance;

        public static AccountcongtyDAO Instance // ham trung gian thuc thi cho frmlogin
        {
            get 
            {
                if (instance == null)
                    instance = new AccountcongtyDAO();
                return instance;
            }
            private set {instance = value;}
        }
        private AccountcongtyDAO() { } // Hàm dự phòng khi xảy ra lỗi

        public bool Login(string password)
        {
            string quye = "USP_LOGINCONGTY @password";
            DataTable result = DataProvider.Instance.ExcuteQuery(quye, new object[] {password});

            return result.Rows.Count > 0;
        }
    }
}

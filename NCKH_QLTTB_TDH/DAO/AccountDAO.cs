using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }


        // kiem tra tai khoan trong CSDL
        public bool Login(String username, String password)
        {
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });

            return result.Rows.Count > 0;
        }

        // Cap nhat tai khoan trong CSDL
        public bool UpdateAccount(string userName, string passWord, string newPassWord)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("EXEC USP_UpdateAccount @userName , @passWord , @newpassWord", new object[] { userName, passWord, newPassWord });
            return result > 0;
        }

        // Tim kiem tai khoan trong CSDL
        public DTO.AccountDTO GetAccountByUserName(String username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Account WHERE Ten_dang_nhap = '" + username + "'");
            foreach (DataRow row in data.Rows)
            {
                return new DTO.AccountDTO(row);
            }

            return null;
        }

    }

}

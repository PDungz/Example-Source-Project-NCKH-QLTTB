using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLTTB_TDH.DAO
{
    public class InformationAccountDAO
    {
        private static InformationAccountDAO instance;

        public static InformationAccountDAO Instance
        {
            get { if (instance == null) instance = new InformationAccountDAO(); return instance; }
            private set => instance = value;
        }

        private InformationAccountDAO() { }

        // Tim thong tin tai khoan dang nhap
        public DTO.InformationAccountDTO GetAccountById(int Id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Thong_tin_nguoi_dang_nhap WHERE Account_Id = " + Id);
            DataRow dr = data.Rows[0];
            return new DTO.InformationAccountDTO(dr);
        }


        // Cap nhat thong tin nguoi dung    
        public bool UpdateInformationAccount(string Ma_nql, string Ten, DateTime Ngay_sinh, string Gioi_tinh, string Chuc_vu, string Email, string SDT, string Dia_chi, string Phong_cong_tac)
        {
            string Ngay_sinh_Inf = String.Format("{0:yyyy-MM-dd}", Ngay_sinh);
            string query = string.Format("UPDATE Thong_tin_nguoi_dang_nhap\r\nSET Ten = N'{0}' , Ngay_sinh = '{1}' , Gioi_tinh = N'{2}' , Chuc_vu = N'{3}', Email = '{4}', SDT = '{5}', Dia_chi = N'{6}' , Phong_cong_tac = N'{7}'\r\nWHERE Ma_nql = '{8}';", Ten, Ngay_sinh_Inf, Gioi_tinh , Chuc_vu, Email, SDT, Dia_chi, Phong_cong_tac, Ma_nql);
           
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);
            return result > 0;
        }


    }
}

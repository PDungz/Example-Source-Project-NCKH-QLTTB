using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLTTB_TDH.DAO
{
    public class ManagerDAO
    {
        private static ManagerDAO instance;

        public static ManagerDAO Instance
        {
            get { if (instance == null) instance = new ManagerDAO(); return instance; }
            set => instance = value;
        }

        private ManagerDAO() { }

        // Lay ra danh sach Hang thiet bi trong CSDL
        public List<DTO.ManagerDTO> GetListManager()
        {
            List<DTO.ManagerDTO> list = new List<DTO.ManagerDTO>();
            string query = "SELECT * FROM Can_Bo_QL";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow Mr in data.Rows)
            {
                DTO.ManagerDTO Item = new DTO.ManagerDTO(Mr);
                list.Add(Item);
            }
            return list;
        }

        // Lay ra thong tin tin nguoi quan ly dau tien
        public DTO.ManagerDTO GetManagerByCode(String Ma_cbql)
        {
            DTO.ManagerDTO equ = null;
            string query = "SELECT * FROM Can_Bo_QL WHERE Ma_cbql = '" + Ma_cbql + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow Mr in data.Rows)
            {
                equ = new DTO.ManagerDTO(Mr);
                return equ;
            }
            return equ;
        }

        // Kiem tra Nguoi quan ly
        public bool Check_Manager(string Ma_NQL)
        {
            string query = string.Format("SELECT * FROM Can_Bo_QL WHERE Ma_cbql = '{0}'", Ma_NQL);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // Tim loai thiet bi
        public List<DTO.ManagerDTO> Search_Equipment(string Ten)
        {
            List<DTO.ManagerDTO> list = new List<DTO.ManagerDTO>();
            string query = string.Format("SELECT * FROM Can_Bo_QL WHERE dbo.fuConvertToUnsign1(Ten) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", Ten);

            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow item in data.Rows)
            {
                DTO.ManagerDTO Item = new DTO.ManagerDTO(item);
                list.Add(Item);
            }
            return list;
        }

        // Them Thong tin nguoi quan ly vao CSDL
        public bool InsertManager(string Ma_cbql, string Ten, DateTime Ngay_sinh, string Gioi_tinh, string Dia_chi, string SDT, string Email, string Chuc_vu, string Ghi_chu)
        {
            string Ngay_sinh_cb = string.Format("{0:yyyy-MM-dd}", Ngay_sinh);
            string query = string.Format("INSERT INTO Can_Bo_QL (Ma_cbql, Ten, Ngay_sinh, Gioi_tinh, Dia_chi, SDT, Email, Chuc_vu, Ghi_chu) VALUES ('{0}', N'{1}', '{2}', N'{3}', N'{4}', '{5}', '{6}', N'{7}', N'{8}');", Ma_cbql, Ten, Ngay_sinh_cb, Gioi_tinh, Dia_chi, SDT, Email, Chuc_vu, Ghi_chu);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Xoa thong tin thhiet bi khoi CSDL
        public bool DeleteManager(int Id)
        {
            string query = string.Format("DELETE FROM Can_Bo_QL WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Sua thong tin thiet bi trong CSDL
        public bool UpdateManager(int Id, string Ma_cbql, string Ten, DateTime Ngay_sinh, string Gioi_tinh, string Dia_chi, string SDT, string Email, string Chuc_vu, string Ghi_chu)
        {
            string Ngay_sinh_cb = String.Format("{0:yyyy-MM-dd}", Ngay_sinh);
            string query = string.Format("UPDATE Can_Bo_QL SET Ma_cbql = '{0}', Ten = N'{1}', Ngay_sinh = '{2}', Gioi_tinh = N'{3}', Dia_chi = N'{4}', SDT = '{5}', Email = '{6}', Chuc_vu = N'{7}', Ghi_chu = N'{8}' WHERE Id = {9};", Ma_cbql, Ten, Ngay_sinh_cb, Gioi_tinh, Dia_chi, SDT, Email, Chuc_vu, Ghi_chu, Id);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }


    }
}

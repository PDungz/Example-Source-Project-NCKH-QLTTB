using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QLTTB_TDH.DAO
{
    public class RoomManageDAO
    {
        private static RoomManageDAO instance;

        public static RoomManageDAO Instance
        {
            get { if (instance == null) instance = new RoomManageDAO(); return instance; }
            set => instance = value;
        }

        private RoomManageDAO() { }

        // Lay thonng tin danh sach loai thiet bi tu CSDL
        public List<DTO.RoomManageDTO> GetListRoomManage()
        {
            List<DTO.RoomManageDTO> list = new List<DTO.RoomManageDTO>();
            string query = "SELECT * FROM Phong_Ban";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow Rm in data.Rows)
            {
                DTO.RoomManageDTO Item = new DTO.RoomManageDTO(Rm);
                list.Add(Item);
            }
            return list;
        }
       
        // Kiem tra thong tin phong quan ly
        public bool Check_RoomManage(string Ma_pql)
        {
            string query = string.Format("SELECT * FROM Phong_Ban WHERE Ma_phong = '{0}'", Ma_pql);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // Kiem tra Ma nguoi quan ly
        public bool Check_RoomManage_Code_Manager(string Ma_nql)
        {
            string query = string.Format("SELECT * FROM Phong_Ban WHERE Ma_cbql = '{0}'", Ma_nql);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // Kiem tra Ten phong quan ly
        public bool Check_RoomManage_Name(string Ten_phong)
        {
            string query = string.Format("SELECT * FROM Phong_Ban WHERE dbo.fuConvertToUnsign1(Ten_phong) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", Ten_phong);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }


        // Lay ra thong tin phong dau tien theo ma phong
        public DTO.RoomManageDTO GetRoomManageByCodeRoom(String Ma_phong)
        {
            DTO.RoomManageDTO rm = null;
            string query = "SELECT * FROM Phong_Ban WHERE Ma_phong = '" + Ma_phong + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow Rm in data.Rows)
            {
                rm = new DTO.RoomManageDTO(Rm);
                return rm;
            }
            return rm;
        }

        // Tim phong quan ly
        public List<DTO.RoomManageDTO> Search_RoomManage(string Ten_phong)
        {
            List<DTO.RoomManageDTO> list = new List<DTO.RoomManageDTO>();
            string query = string.Format("SELECT * FROM Phong_Ban WHERE dbo.fuConvertToUnsign1(Ten_phong) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", Ten_phong);

            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow item in data.Rows)
            {
                DTO.RoomManageDTO Item = new DTO.RoomManageDTO(item);
                list.Add(Item);
            }
            return list;
        }

        // Lay ra thong tin phong dau tien theo ten phong
        public DTO.RoomManageDTO GetRoomManageByNameRoom(String Ten_phong)
        {
            DTO.RoomManageDTO rm = null;
            string query = "SELECT * FROM Phong_Ban WHERE Ten_phong = N'" + Ten_phong + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow Rm in data.Rows)
            {
                rm = new DTO.RoomManageDTO(Rm);
                return rm;
            }
            return rm;
        }

        // Them phong quan ly vao CSDL
        public bool InsertRoomManage(string Ma_phong, string Ten_phong, string Dia_chi, string Email, string So_dien_thoai, string Ma_cbql, string Ghi_chu)
        {
            string query = string.Format("INSERT INTO Phong_Ban (Ma_phong, Ten_phong, Dia_chi, Email, So_dien_thoai, Ma_cbql, Ghi_chu) VALUES ('{0}', N'{1}', N'{2}', '{3}', '{4}', '{5}', N'{6}');", Ma_phong, Ten_phong, Dia_chi, Email, So_dien_thoai, Ma_cbql, Ghi_chu);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Xoa thong tin phong quan ly khoi CSDL
        public bool DeleteRoomManage(int Id)
        {
            string query = string.Format("DELETE FROM Phong_Ban WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Sua thong tin phong quan ly trong CSDL
        public bool UpdateRoomManage(int Id, string Ma_phong, string Ten_phong, string Dia_chi, string Email, string So_dien_thoai, string Ma_cbql, string Ghi_chu)
        {
            string query = string.Format("UPDATE Phong_Ban SET Ma_phong = '{0}', Ten_phong = N'{1}', Dia_chi = N'{2}', Email = '{3}', So_dien_thoai = '{4}', Ma_cbql = '{5}', Ghi_chu = N'{6}' WHERE Id = {7};", Ma_phong, Ten_phong, Dia_chi, Email, So_dien_thoai, Ma_cbql, Ghi_chu, Id);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }



    }
}

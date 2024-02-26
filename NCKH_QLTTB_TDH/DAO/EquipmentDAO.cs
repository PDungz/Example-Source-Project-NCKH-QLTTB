using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QLTTB_TDH.DAO
{
    public class EquipmentDAO
    {
        private static EquipmentDAO instance;

        public static EquipmentDAO Instance
        {
            get { if (instance == null) instance = new EquipmentDAO(); return instance; }
            private set { instance = value; }
        }

        private EquipmentDAO() { }

        // Lay thonng tin danh sach thiet bi tu CSDL
        public List<DTO.EquipmentDTO> GetListEquipment()
        {
            List<DTO.EquipmentDTO> list = new List<DTO.EquipmentDTO>();
            string query = "SELECT * FROM Thiet_Bi";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow EqR in data.Rows)
            {
                DTO.EquipmentDTO Item = new DTO.EquipmentDTO(EqR);
                list.Add(Item);
            }
            return list;
        }

        // Lay thonng tin danh sach thiet bi trong mot phong ban
        public List<DTO.EquipmentDTO> GetListEquipment_Room(String Ma_phong)
        {
            List<DTO.EquipmentDTO> list = new List<DTO.EquipmentDTO>();
            string str = "";
            if(Ma_phong != " ")
            {
                str = "WHERE Ma_Phong_Ban = '" + Ma_phong + "'";
            }
            string query = "SELECT * FROM Thiet_Bi " + str;
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow EqR in data.Rows)
            {
                DTO.EquipmentDTO Item = new DTO.EquipmentDTO(EqR);
                list.Add(Item);
            }
            return list;
        }

        // Dem so luong thiet bi 
        public int GetListEquipment_Count(String Ma_phong)
        {
            string str = "";
            if (Ma_phong != " ")
            {
                str = "WHERE Ma_Phong_Ban = '" + Ma_phong + "'";
            }
            string query = "SELECT * FROM Thiet_Bi " + str;
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            return data.Rows.Count;
        }

        // kiem tra Ma thiet bị da co trong CSDL
        public bool Check_Equipment(string Ma_tb)
        {
            string query = string.Format("SELECT * FROM Thiet_Bi WHERE Ma_tb = '{0}'", Ma_tb);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // Kiem tra Ten thiet bi
        public bool Check_Equipment_Name(string Ten_tb)
        {
            string query = string.Format("SELECT * FROM Thiet_Bi WHERE dbo.fuConvertToUnsign1(Ten_TB) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", Ten_tb);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // Kiem tra Ma loai thiet bi
        public bool Check_Equipment_Code_EquipmentType(string Ma_ltb)
        {
            string query = string.Format("SELECT * FROM Thiet_Bi WHERE Ma_loai = '{0}'", Ma_ltb);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // Kiem tra Ma phong quan ly
        public bool Check_Equipment_Code_RoomManage(string Ma_pb)
        {
            string query = string.Format("SELECT * FROM Thiet_Bi WHERE Ma_Phong_Ban = '{0}'", Ma_pb);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // Tim kiem thiet bi theo ten
        public List<DTO.EquipmentDTO> Search_Equipment(string Ten_tb)
        {
            List<DTO.EquipmentDTO> list = new List<DTO.EquipmentDTO>();
            string query = string.Format("SELECT * FROM Thiet_Bi WHERE dbo.fuConvertToUnsign1(Ten_TB) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", Ten_tb);

            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow EqR in data.Rows)
            {
                DTO.EquipmentDTO Item = new DTO.EquipmentDTO(EqR);
                list.Add(Item);
            }
            return list;
        }

        // Them thiet bi vao CSDL
        public bool InsertEquipment(string Ma_tb, string Ten_tb, int So_luong, DateTime Ngay_nhap, string Trang_thai, string Ma_loai, string Ma_Phong_Ban, string Ghi_chu)
        {
            string Ngay_nhap_sr = String.Format("{0:yyyy-MM-dd}", Ngay_nhap);
            string query = string.Format("INSERT dbo.Thiet_Bi (Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu) VALUES ('{0}', N'{1}', {2}, '{3}', N'{4}', '{5}', '{6}', N'{7}')", Ma_tb, Ten_tb, So_luong, Ngay_nhap_sr, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Sua thong tin thiet bi trong CSDL
        public bool UpdateEquipment(int Id, string Ma_tb, string Ten_tb, int So_luong, DateTime Ngay_nhap, string Trang_thai, string Ma_loai, string Ma_Phong_Ban, string Ghi_chu)
        {
            string Ngay_nhap_sr = String.Format("{0:yyyy-MM-dd}", Ngay_nhap);
            string query = string.Format("UPDATE Thiet_Bi SET Ma_tb = '{0}', Ten_tb = N'{1}', So_luong = {2}, Ngay_nhap = '{3}', Trang_thai = N'{4}', Ma_loai = '{5}', Ma_Phong_Ban = '{6}', Ghi_chu = N'{7}' WHERE Id = {8};", Ma_tb, Ten_tb, So_luong, Ngay_nhap_sr, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu, Id);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Xoa thong tin thhiet bi khoi CSDL
        public bool DeleteEquipment(int Id)
        {
            string query = string.Format("DELETE FROM Thiet_Bi WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }
    }

}

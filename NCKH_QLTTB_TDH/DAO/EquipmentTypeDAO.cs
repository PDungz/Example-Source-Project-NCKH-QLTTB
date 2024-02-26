using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DAO
{
    public class EquipmentTypeDAO
    {
        private static EquipmentTypeDAO instance;

        public static EquipmentTypeDAO Instance
        {
            get { if (instance == null) instance = new EquipmentTypeDAO(); return instance; }
            set => instance = value;
        }

        private EquipmentTypeDAO() { }

        // Lay thonng tin danh sach loai thiet bi tu CSDL
        public List<DTO.EquipmentTypeDTO> GetListEquipmentType()
        {
            List<DTO.EquipmentTypeDTO> list = new List<DTO.EquipmentTypeDTO>();
            string query = "SELECT * FROM Loai_TB";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow EqT in data.Rows)
            {
                DTO.EquipmentTypeDTO Item = new DTO.EquipmentTypeDTO(EqT);
                list.Add(Item);
            }
            return list;
        }

        // Lay ra thong tin tin Loai thiet bi dau tien
        public DTO.EquipmentTypeDTO GetEquipmentTypeByCodeType(String Ma_loai)
        {
            DTO.EquipmentTypeDTO equ = null;
            string query = "SELECT * FROM Loai_TB WHERE Ma_loai = '" + Ma_loai + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow EqT in data.Rows)
            {
                equ = new DTO.EquipmentTypeDTO(EqT);
                return equ;
            }
            return equ;
        }

        // kiem tra Ma loai thiet bị da co trong CSDL
        public bool Check_EquipmentType(string Ma_ltb)
        {
            string query = string.Format("SELECT * FROM Loai_TB WHERE Ma_loai = '{0}'", Ma_ltb);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // kiem tra Ma loai thiet bị da co trong CSDL
        public bool Check_EquipmentType_CP(string Ma_htb)
        {
            string query = string.Format("SELECT * FROM Loai_TB WHERE Ma_hang = '{0}'", Ma_htb);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // kiem tra Ten loai thiet bị da co trong CSDL
        public bool Check_EquipmentType_Name(string Ten_loai)
        {
            string query = string.Format("SELECT * FROM Loai_TB WHERE dbo.fuConvertToUnsign1(Ten_loai) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", Ten_loai);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // Tim loai thiet bi
        public List<DTO.EquipmentTypeDTO> Search_EquipmentType(string Ten_loai)
        {
            List<DTO.EquipmentTypeDTO> list = new List<DTO.EquipmentTypeDTO>();
            string query = string.Format("SELECT * FROM Loai_TB WHERE dbo.fuConvertToUnsign1(Ten_loai) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", Ten_loai);

            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow item in data.Rows)
            {
                DTO.EquipmentTypeDTO Item = new DTO.EquipmentTypeDTO(item);
                list.Add(Item);
            }
            return list;
        }

        // Them loai thiet bi vao CSDL
        public bool InsertEquipmentType(string Ma_hang, string Ten_hang, string Lien_He_tong_dai, string Ghi_chu)
        {
            string query = string.Format("INSERT INTO Loai_TB (Ma_loai, Ten_loai, Ma_hang, Ghi_chu) VALUES ('{0}', N'{1}', '{2}', N'{3}');", Ma_hang, Ten_hang, Lien_He_tong_dai, Ghi_chu);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Xoa thong tin loai thiet bi
        public bool DeleteEquipmentType(int Id)
        {
            string query = string.Format("DELETE FROM Loai_TB WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Sua thong tin loai thiet bi trong CSDL
        public bool UpdateEquipmentType(int Id, string Ma_hang, string Ten_hang, string Lien_He_tong_dai, string Ghi_chu)
        {
            string query = string.Format("UPDATE Loai_TB SET Ma_loai = '{0}', Ten_loai = N'{1}', Ma_hang = '{2}', Ghi_chu = N'{3}' WHERE Id = {4};", Ma_hang, Ten_hang, Lien_He_tong_dai, Ghi_chu, Id);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DAO
{
    public class StatisticalDAO
    {
        private static StatisticalDAO instance;

        public static StatisticalDAO Instance 
        {
            get { if(instance == null) instance = new StatisticalDAO(); return instance;}
            set => instance = value; 
        }

        private StatisticalDAO() { }

        // Lay danh sach thong ke tu CSDL
        public List<DTO.StatisticalDTO> GetListStatistical()
        {
            List<DTO.StatisticalDTO> list = new List<DTO.StatisticalDTO>();
            string query = "SELECT * FROM Thong_Ke_TB";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow Stl in data.Rows)
            {
                DTO.StatisticalDTO Item = new DTO.StatisticalDTO(Stl);
                list.Add(Item);
            }
            return list;
        }

        // Lay ra thong tin Thiet bi da duoc thong ke
        public DTO.StatisticalDTO GetStatistical_Code_Et(String Ma_tb)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Thong_Ke_TB WHERE Ma_tb = '" + Ma_tb + "'");
            DataRow stl = data.Rows[0];
            return new DTO.StatisticalDTO(stl);
        }

        //  Lay danh sach thong ke theo theo phong
        public List<DTO.StatisticalDTO> GetListStatistical_CodeRoom(String Ma_phong)
        {
            List<DTO.StatisticalDTO> list = new List<DTO.StatisticalDTO>();
            string str = "";
            if(Ma_phong != null)
            {
                str = "WHERE Ma_Phong_Ban = '" + Ma_phong + "'";
            }
            string query = "SELECT * FROM Thong_Ke_TB " + str;
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow Stl in data.Rows)
            {
                DTO.StatisticalDTO Item = new DTO.StatisticalDTO(Stl);
                list.Add(Item);
            }
            return list;
        }

        //  Lay danh sach thong ke theo ten phong va ngay 
        public List<DTO.StatisticalDTO> GetListStatistical_CodeRoom_Time(String Ma_phong, DateTime Ngay_TK)
        {
            List<DTO.StatisticalDTO> list = new List<DTO.StatisticalDTO>();
            string Ngay = String.Format("{0:yyyy-MM-dd}", Ngay_TK);
            string query = String.Format("SELECT * FROM Thong_Ke_TB WHERE  Ma_Phong_Ban = '{0}' AND Ngay_cap_nhat = '{1}'", Ma_phong, Ngay);
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow Stl in data.Rows)
            {
                DTO.StatisticalDTO Item = new DTO.StatisticalDTO(Stl);
                list.Add(Item);
            }
            return list;
        }

        // Kiem tra thong tin thiet bi duoc thong ke
        public bool Check_Statistical_Code_Et(string Ma_tb)
        {
            string query = string.Format("SELECT * FROM Thong_Ke_TB WHERE Ma_tb = '{0}'", Ma_tb);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // Them thong ke vao CSDL
        public bool InsertStatistical(string Ma_tb, string Ten_tb, int So_luong, DateTime Ngay_nhap, string Trang_thai, string Ma_loai, string Ma_Phong_Ban, string Ghi_chu, DateTime Ngay_cap_nhat, string Ghi_chu_ng_cn)
        {
            string Ngay_nhap_TB = String.Format("{0:yyyy-MM-dd}", Ngay_nhap);
            string Ngay_TK = String.Format("{0:yyyy-MM-dd}", Ngay_cap_nhat);
            string query = string.Format("INSERT INTO Thong_Ke_TB (Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu, Ngay_cap_nhat, Ghi_chu_ng_cn) VALUES ('{0}', N'{1}', {2}, '{3}', N'{4}', '{5}', '{6}', N'{7}', '{8}', N'{9}')", Ma_tb, Ten_tb, So_luong, Ngay_nhap_TB, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu, Ngay_TK, Ghi_chu_ng_cn);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }
    }
}

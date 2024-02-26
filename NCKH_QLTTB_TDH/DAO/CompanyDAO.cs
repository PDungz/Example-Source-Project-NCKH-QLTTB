using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DAO
{
    public class CompanyDAO
    {
        private static CompanyDAO instance;

        public static CompanyDAO Instance
        {
            get { if (instance == null) instance = new CompanyDAO(); return instance; }
            set => instance = value;
        }

        private CompanyDAO() { }

        // Lay ra danh sach Hang thiet bi trong CSDL
        public List<DTO.CompanyDTO> GetListCompany()
        {
            List<DTO.CompanyDTO> list = new List<DTO.CompanyDTO>();
            string query = "SELECT * FROM Hang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow CpR in data.Rows)
            {
                DTO.CompanyDTO Item = new DTO.CompanyDTO(CpR);
                list.Add(Item);
            }
            return list;
        }

        // kiem tra Ma Hang da co trong CSDL
        public bool Check_Company(string Ma_Hang_HTB)
        {
            string query = string.Format("SELECT * FROM Hang WHERE Ma_hang = '{0}'", Ma_Hang_HTB);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        // Tim kiem hang
        public List<DTO.CompanyDTO> Search_Equipment(string Ten_hang)
        {
            List<DTO.CompanyDTO> list = new List<DTO.CompanyDTO>();
            string query = string.Format("SELECT * FROM Hang WHERE dbo.fuConvertToUnsign1(Ten_hang) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", Ten_hang);

            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow item in data.Rows)
            {
                DTO.CompanyDTO Item = new DTO.CompanyDTO(item);
                list.Add(Item);
            }
            return list;
        }


        // Them Hang thiet bi vao CSDL
        public bool InsertCompany(string Ma_hang, string Ten_hang, string Lien_He_tong_dai, string Ghi_chu)
        {
            string query = string.Format("INSERT INTO Hang (Ma_hang, Ten_hang, Lien_He_tong_dai, Ghi_chu) VALUES ('{0}', N'{1}', '{2}', N'{3}')", Ma_hang, Ten_hang, Lien_He_tong_dai, Ghi_chu);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Xoa thong tin hang thiet bi
        public bool DeleteCompany(int Id)
        {
            string query = string.Format("DELETE FROM Hang WHERE Id = {0}", Id);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Sua thong tin Hang thiet bi trong CSDL
        public bool UpdateCompany(int Id, string Ma_hang, string Ten_hang, string Lien_He_tong_dai, string Ghi_chu)
        {
            string query = string.Format("UPDATE Hang SET Ma_hang = '{0}', Ten_hang = N'{1}', Lien_He_tong_dai = '{2}', Ghi_chu = N'{3}' WHERE Id = {4};", Ma_hang, Ten_hang, Lien_He_tong_dai, Ghi_chu, Id);
            int result = DataProvider.Instance.ExcuteNonQuery(query, null);

            return result > 0;
        }

        // Lay ra thong tin Hang dau tien
        public DTO.CompanyDTO GetCompanyByCodeCp(String Ma_hang)
        {
            DTO.CompanyDTO equ = null;
            string query = "SELECT * FROM Hang WHERE Ma_hang = '" + Ma_hang + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, null);
            foreach (DataRow EqT in data.Rows)
            {
                equ = new DTO.CompanyDTO(EqT);
                return equ;
            }
            return equ;
        }

    }

}

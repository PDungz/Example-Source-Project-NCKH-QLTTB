using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DTO
{
    public class ManagerDTO
    {
        private int Id;
        private string Ma_cbql;
        private string Ten;
        private DateTime Ngay_sinh;
        private string Gioi_tinh;
        private string Dia_chi;
        private string SDT;
        private string Email;
        private string Chuc_vu;
        private string Ghi_chu;

        public ManagerDTO(int Id, string Ma_cbql, string Ten, DateTime Ngay_sinh, string Gioi_tinh, string Dia_chi, string SDT, string Email, string Chuc_vu, string Ghi_chu)
        {
            this.Id = Id;
            this.Ma_cbql = Ma_cbql;
            this.Ten = Ten;
            this.Ngay_sinh = Ngay_sinh;
            this.Gioi_tinh = Gioi_tinh;
            this.Dia_chi = Dia_chi;
            this.SDT = SDT;
            this.Email = Email;
            this.Chuc_vu = Chuc_vu;
            this.Ghi_chu = Ghi_chu;
        }

        public ManagerDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Ma_cbql = row["Ma_cbql"].ToString();
            this.Ten = row["Ten"].ToString();
            this.Ngay_sinh = (DateTime)row["Ngay_sinh"];
            this.Gioi_tinh = row["Gioi_tinh"].ToString();
            this.Dia_chi = row["Dia_chi"].ToString();
            this.SDT = row["SDT"].ToString();
            this.Email = row["Email"].ToString();
            this.Chuc_vu = row["Chuc_vu"].ToString();
            this.Ghi_chu = row["Ghi_chu"].ToString();
        }


        public int Id_Mr { get => Id; set => Id = value; }
        public string Ma_cbql_Mr { get => Ma_cbql; set => Ma_cbql = value; }
        public string Ten_Mr { get => Ten; set => Ten = value; }
        public DateTime Ngay_sinh_Mr { get => Ngay_sinh; set => Ngay_sinh = value; }
        public string Gioi_tinh_Mr { get => Gioi_tinh; set => Gioi_tinh = value; }
        public string Dia_chi_Mr { get => Dia_chi; set => Dia_chi = value; }
        public string SDT_Mr { get => SDT; set => SDT = value; }
        public string Email_Mr { get => Email; set => Email = value; }
        public string Chuc_vu_Mr { get => Chuc_vu; set => Chuc_vu = value; }
        public string Ghi_chu_Mr { get => Ghi_chu; set => Ghi_chu = value; }
    }
}

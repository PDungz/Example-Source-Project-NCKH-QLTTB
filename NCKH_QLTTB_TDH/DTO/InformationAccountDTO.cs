using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DTO
{
    public class InformationAccountDTO
    {
        private int Id;
        private string Ma_nql;
        private string Ten;
        private DateTime Ngay_sinh;
        private string Gioi_tinh;
        private string Chuc_vu;
        private string Email;
        private string SDT;
        private string Dia_chi;
        private string Phong_cong_tac;
        private int Account_Id;

        public InformationAccountDTO(int Id, string Ma_nql, string Ten, DateTime Ngay_sinh, string Gioi_tinh, string Chuc_vu, string Email, string SDT, string Dia_chi, string Phong_cong_tac, int Account_Id)
        {
            this.Id = Id;
            this.Ma_nql = Ma_nql;
            this.Ten = Ten;
            this.Ngay_sinh = Ngay_sinh;
            this.Gioi_tinh = Gioi_tinh;
            this.Chuc_vu = Chuc_vu;
            this.Email = Email;
            this.SDT = SDT;
            this.Dia_chi = Dia_chi;
            this.Phong_cong_tac = Phong_cong_tac;
            this.Account_Id = Account_Id;

        }

        public InformationAccountDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Ma_nql = row["Ma_nql"].ToString();
            this.Ten = row["Ten"].ToString();
            this.Ngay_sinh = (DateTime)row["Ngay_sinh"];
            this.Gioi_tinh = row["Gioi_tinh"].ToString();
            this.Chuc_vu = row["Chuc_vu"].ToString();
            this.Email = row["Email"].ToString();
            this.SDT = row["SDT"].ToString();
            this.Dia_chi = row["Dia_chi"].ToString();
            this.Phong_cong_tac = row["Phong_cong_tac"].ToString();
            this.Account_Id = (int)row["Account_Id"];
        }

        public int Id_Info_A { get => Id; set => Id = value; }
        public string Ma_nql_Info_A { get => Ma_nql; set => Ma_nql = value; }
        public string Ten_Info_A { get => Ten; set => Ten = value; }
        public DateTime Ngay_sinh_Info_A { get => Ngay_sinh; set => Ngay_sinh = value; }
        public string Gioi_tinh_Info_A { get => Gioi_tinh; set => Gioi_tinh = value; }
        public string Chuc_vu_Info_A { get => Chuc_vu; set => Chuc_vu = value; }
        public string Email_Info_A { get => Email; set => Email = value; }
        public string SDT_Info_A { get => SDT; set => SDT = value; }
        public string Dia_chi_Info_A { get => Dia_chi; set => Dia_chi = value; }
        public string Phong_cong_tac_Info_A { get => Phong_cong_tac; set => Phong_cong_tac = value; }
        public int Account_Id_Info_A { get => Account_Id; set => Account_Id = value; }
    }
}

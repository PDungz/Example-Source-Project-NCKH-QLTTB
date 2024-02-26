using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DTO
{
    public class RoomManageDTO
    {
        private int Id;
        private string Ma_phong;
        private string Ten_phong;
        private string Dia_chi;
        private string Email;
        private string So_dien_thoai;
        private string Ma_cbql;
        private string Ghi_chu;

        public RoomManageDTO(int Id, string Ma_phong, string Ten_phong, string Dia_chi, string Email, string So_dien_thoai, string Ma_cbql, string Ghi_chu)
        {
            this.Id = Id;
            this.Ma_phong = Ma_phong;
            this.Ten_phong = Ten_phong;
            this.Dia_chi = Dia_chi;
            this.Email = Email;
            this.So_dien_thoai = So_dien_thoai;
            this.Ma_cbql = Ma_cbql;
            this.Ghi_chu = Ghi_chu;
        }

        public RoomManageDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Ma_phong = row["Ma_phong"].ToString();
            this.Ten_phong = row["Ten_phong"].ToString();
            this.Dia_chi = row["Dia_chi"].ToString();
            this.Email = row["Email"].ToString();
            this.So_dien_thoai = row["So_dien_thoai"].ToString();
            this.Ma_cbql = row["Ma_cbql"].ToString();
            this.Ghi_chu = row["Ghi_chu"].ToString();
        }

        public int Id_Rm { get => Id; set => Id = value; }
        public string Ma_phong_Rm { get => Ma_phong; set => Ma_phong = value; }
        public string Ten_phong_Rm { get => Ten_phong; set => Ten_phong = value; }
        public string Dia_chi_Rm { get => Dia_chi; set => Dia_chi = value; }
        public string Email_Rm { get => Email; set => Email = value; }
        public string So_dien_thoai_Rm { get => So_dien_thoai; set => So_dien_thoai = value; }
        public string Ma_cbql_Rm { get => Ma_cbql; set => Ma_cbql = value; }
        public string Ghi_chu_Rm { get => Ghi_chu; set => Ghi_chu = value; }
    }
}

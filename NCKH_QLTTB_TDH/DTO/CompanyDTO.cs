using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DTO
{
    public class CompanyDTO
    {
        private int Id;
        private string Ma_hang;
        private string Ten_hang;
        private string Lien_He_tong_dai;
        private string Ghi_chu;

        public CompanyDTO(int Id, string Ma_hang, string Ten_hang, string Lien_He_tong_dai, string Ghi_chu)
        {
            this.Id = Id;
            this.Ma_hang = Ma_hang;
            this.Ten_hang = Ten_hang;
            this.Lien_He_tong_dai = Lien_He_tong_dai;
            this.Ghi_chu_Cp = Ghi_chu;
        }

        public CompanyDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Ma_hang = row["Ma_hang"].ToString();
            this.Ten_hang = row["Ten_hang"].ToString();
            this.Lien_He_tong_dai = row["Lien_He_tong_dai"].ToString();
            this.Ghi_chu_Cp = row["Ghi_chu"].ToString();
        }

        public int Id_Cp { get => Id; set => Id = value; }
        public string Ma_hang_Cp { get => Ma_hang; set => Ma_hang = value; }
        public string Ten_hang_CP { get => Ten_hang; set => Ten_hang = value; }
        public string Lien_He_tong_dai_Cp { get => Lien_He_tong_dai; set => Lien_He_tong_dai = value; }
        public string Ghi_chu_Cp { get => Ghi_chu; set => Ghi_chu = value; }
    }
}

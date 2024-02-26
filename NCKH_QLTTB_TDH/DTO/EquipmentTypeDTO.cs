using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DTO
{
    public class EquipmentTypeDTO
    {
        private int Id;
        private string Ma_loai;
        private string Ten_loai;
        private string Ma_hang;
        private string Ghi_chu;

        public EquipmentTypeDTO(int Id, string Ma_loai, string Ten_loai, string Ma_hang, string Ghi_chu)
        {
            this.Id = Id;
            this.Ma_loai = Ma_loai;
            this.Ten_loai = Ten_loai;
            this.Ma_hang = Ma_hang;
            this.Ghi_chu = Ghi_chu;
        }

        public EquipmentTypeDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Ma_loai = row["Ma_loai"].ToString();
            this.Ten_loai = row["Ten_loai"].ToString();
            this.Ma_hang = row["Ma_hang"].ToString();
            this.Ghi_chu = row["Ghi_chu"].ToString();
        }

        public int Id_Et { get => Id; set => Id = value; }
        public string Ma_loai_Et { get => Ma_loai; set => Ma_loai = value; }
        public string Ten_loai_Et { get => Ten_loai; set => Ten_loai = value; }
        public string Ma_hang_Et { get => Ma_hang; set => Ma_hang = value; }
        public string Ghi_chu_Et { get => Ghi_chu; set => Ghi_chu = value; }
    }
}

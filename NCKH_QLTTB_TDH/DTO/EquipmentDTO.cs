using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DTO
{
    public class EquipmentDTO
    {
        private int Id;
        private string Ma_tb;
        private string Ten_tb;
        private int So_luong;
        private DateTime Ngay_nhap;
        private string Trang_thai;
        private string Ma_loai;
        private string Ma_Phong_Ban;
        private string Ghi_chu;

        public EquipmentDTO(int Id, string Ma_tb, string Ten_tb, int So_luong, DateTime Ngay_nhap, string Trang_thai, string Ma_loai, string Ma_Phong_Ban, string Ghi_chu)
        {
            this.Id = Id;
            this.Ma_tb = Ma_tb;
            this.Ten_tb = Ten_tb;
            this.So_luong = So_luong;
            this.Ngay_nhap = Ngay_nhap;
            this.Trang_thai = Trang_thai;
            this.Ma_loai = Ma_loai;
            this.Ma_Phong_Ban = Ma_Phong_Ban;
            this.Ghi_chu = Ghi_chu;
        }

        public EquipmentDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Ma_tb = row["Ma_tb"].ToString();
            this.Ten_tb = row["Ten_tb"].ToString();
            this.So_luong = (int)row["So_luong"];
            this.Ngay_nhap = (DateTime)row["Ngay_nhap"];
            this.Trang_thai = row["Trang_thai"].ToString();
            this.Ma_loai = row["Ma_loai"].ToString();
            this.Ma_Phong_Ban = row["Ma_Phong_Ban"].ToString();
            this.Ghi_chu = row["Ghi_chu"].ToString();
        }

        public int Id_Eq { get => Id; set => Id = value; }
        public string Ma_tb_Eq { get => Ma_tb; set => Ma_tb = value; }
        public string Ten_tb_Eq { get => Ten_tb; set => Ten_tb = value; }
        public int So_luong_Eq { get => So_luong; set => So_luong = value; }
        public DateTime Ngay_nhap_Eq { get => Ngay_nhap; set => Ngay_nhap = value; }
        public string Trang_thai_Eq { get => Trang_thai; set => Trang_thai = value; }
        public string Ma_loai_Eq { get => Ma_loai; set => Ma_loai = value; }
        public string Ma_Phong_Ban_Eq { get => Ma_Phong_Ban; set => Ma_Phong_Ban = value; }
        public string Ghi_chu_Eq { get => Ghi_chu; set => Ghi_chu = value; }
    }
}

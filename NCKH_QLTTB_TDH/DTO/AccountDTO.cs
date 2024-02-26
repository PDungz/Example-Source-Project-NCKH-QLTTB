using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTB_TDH.DTO
{
    public class AccountDTO
    {
        private int Id;

        private string Ten_dang_nhap;

        private string Mat_khau;
        private int Quyen_truy_cap;

        public AccountDTO(int Id, string Ten_dang_nhap, string Mat_khau, int Quyen_truy_cap)
        {
            this.Id = Id;
            this.Ten_dang_nhap = Ten_dang_nhap;
            this.Mat_khau = Mat_khau;
            this.Quyen_truy_cap = Quyen_truy_cap;
        }

        public AccountDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Ten_dang_nhap = row["Ten_dang_nhap"].ToString();
            this.Mat_khau = row["Mat_khau"].ToString();
            this.Quyen_truy_cap = (int)row["Quyen_truy_cap"];
        }

        public int Id_A { get => Id; set => Id = value; }
        public string Ten_dang_nhap_A { get => Ten_dang_nhap; set => Ten_dang_nhap = value; }
        public string Mat_khau_A { get => Mat_khau; set => Mat_khau = value; }
        public int Quyen_truy_cap_A { get => Quyen_truy_cap; set => Quyen_truy_cap = value; }
    }
}

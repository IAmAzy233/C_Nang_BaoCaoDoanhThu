using System;
using System.Collections.Generic;

namespace DoAn1_BanFinal.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitietdonhang = new HashSet<Chitietdonhang>();
        }

        public string SpId { get; set; }
        public string DmId { get; set; }
        public string HaId { get; set; }
        public string SpTen { get; set; }
        public string SpHangsanxuat { get; set; }
        public string SpKichthuocmanhinh { get; set; }
        public string SpDophangiai { get; set; }
        public string SpHedieuhanh { get; set; }
        public string SpChipxuli { get; set; }
        public string SpRam { get; set; }
        public string SpRom { get; set; }
        public string SpDungluongpin { get; set; }
        public int? SpDongia { get; set; }
        public string SpHinhanh { get; set; }

        public virtual Danhmuc Dm { get; set; }
        public virtual ICollection<Chitietdonhang> Chitietdonhang { get; set; }
    }
}

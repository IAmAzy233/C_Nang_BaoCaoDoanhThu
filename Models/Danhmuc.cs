using System;
using System.Collections.Generic;

namespace DoAn1_BanFinal.Models
{
    public partial class Danhmuc
    {
        public Danhmuc()
        {
            Sanpham = new HashSet<Sanpham>();
        }

        public string DmId { get; set; }
        public string DmTen { get; set; }

        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}

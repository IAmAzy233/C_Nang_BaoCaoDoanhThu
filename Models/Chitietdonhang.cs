using System;
using System.Collections.Generic;

namespace DoAn1_BanFinal.Models
{
    public partial class Chitietdonhang
    {
        public string CtDhId { get; set; }
        public string SpId { get; set; }
        public string DhId { get; set; }
        public string CtDhSoluong { get; set; }
        public int CtDhThanhtien { get; set; }

        public virtual Donhang Dh { get; set; }
        public virtual Sanpham Sp { get; set; }
    }
}

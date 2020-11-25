using System;
using System.Collections.Generic;

namespace DoAn1_BanFinal.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Donhang = new HashSet<Donhang>();
        }

        public string KhId { get; set; }
        public string KhTen { get; set; }
        public string KhDiachi { get; set; }
        public string KhSdt { get; set; }

        public virtual ICollection<Donhang> Donhang { get; set; }
    }
}

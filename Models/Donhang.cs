using System;
using System.Collections.Generic;

namespace DoAn1_BanFinal.Models
{
    public partial class Donhang
    {
        public Donhang()
        {
            Chitietdonhang = new HashSet<Chitietdonhang>();
        }

        public string DhId { get; set; }
        public DateTime DhThoigianmua { get; set; }
        public string DhTinhtrangdonhang { get; set; }
        public string DhTinhtranggiaohang { get; set; }
        public string KhId { get; set; }
        public int DhTongtien { get; set; }

        public virtual Khachhang Kh { get; set; }
        public virtual ICollection<Chitietdonhang> Chitietdonhang { get; set; }
    }
}

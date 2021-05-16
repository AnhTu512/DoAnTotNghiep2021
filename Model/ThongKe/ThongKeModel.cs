using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ThongKe
{
    public class ThongKeModel
    {
        public long DonHangID { set; get; }
        public long ProductID { set; get; }
        public int SoLuong { set; get; }
        public int Gia { set; get; }
        public DateTime? CreateDate { set; get; }
        public bool DaXacNhan { set; get; }
        public bool DaGiaoXong { set; get; }
    }
}

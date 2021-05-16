using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ThongKe;
using PagedList;

namespace Model.Dao
{
    public class ThongKeDao
    {
        DB_Nong_San db = null;
        public ThongKeDao()
        {
            db = new DB_Nong_San();
        }
        public IEnumerable<ThongKeModel> ListThongKe(string month,string date, int page , int pagesize)
        {

            var model = (from a in db.DonHangs
                         join b in db.ChiTietDonHangs
                         on a.ID equals b.DonHangID
                         select new
                         {
                             DonHangID = b.DonHangID,
                             ProductID = b.ProductID,
                             SoLuong = b.SoLuong,
                             Gia = b.Gia,
                             CreateDate = a.CreateDate,
                             DaXacNhan = a.DaXacNhan,
                             DaGiaoXong = a.DaGiaoXong
                         }).AsEnumerable().Select(x => new ThongKeModel()
                         {
                             DonHangID = x.DonHangID,
                             ProductID = x.ProductID,
                             SoLuong = x.SoLuong,
                             Gia = x.Gia,
                             CreateDate = x.CreateDate,
                             DaXacNhan = x.DaXacNhan,
                             DaGiaoXong = x.DaGiaoXong
                         });

            if (!string.IsNullOrEmpty(date))
            {
                model = model.Where(x => ((DateTime)x.CreateDate) == DateTime.Parse(date));
            }
            if (!string.IsNullOrEmpty(month))
            {
                model = model.Where(x => month.Contains(x.CreateDate.ToString()));
            }
            return model.OrderBy(x => x.DonHangID).ToPagedList(page, pagesize);
        }
        
    }
}

using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DonHangDao
    {
        DB_Nong_San db = null;
        public DonHangDao()
        {
            db = new DB_Nong_San();
        }
        public long Insert(DonHang order)
        {
            db.DonHangs.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public bool Update(DonHang entity)
        {
            try
            {
                var donhang = db.DonHangs.Find(entity.ID);
                donhang.ShipAddress = entity.ShipAddress;
                donhang.ShipEmail = entity.ShipEmail;
                donhang.ShipSDT = entity.ShipSDT;
                donhang.DaXacNhan = entity.DaXacNhan;
                donhang.DaGiaoXong = entity.DaGiaoXong;
                //if(donhang.DaXacNhan ==true)
                //{
                //    var model =(from a in db.DonHangs
                //                join b in db.ChiTietDonHangs on a.ID equals b.DonHangID
                //                select new
                //                {
                //                    DonHangID = a.ID,
                //                    ProductID = b.ProductID
                //                } ).AsEnumerable().Select(x => new ChiTietDonHang()
                //                {
                //                    DonHangID = x.DonHangID,
                //                    ProductID = x.ProductID
                //                });
                //    long id = model.Single(x => x.ProductID);


                //}    
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Xoa(int id)
        {
            try
            {
                var chitietdonhang = db.ChiTietDonHangs.Find(id);
                var donhang = db.DonHangs.Find(id);
                db.ChiTietDonHangs.Remove(chitietdonhang);
                db.DonHangs.Remove(donhang);

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ChangeStatus(long id)
        {
            var donhang = db.DonHangs.Find(id);
            donhang.DaXacNhan = !donhang.DaXacNhan;
            return donhang.DaXacNhan;
        }
        public IEnumerable<DonHang> ListAllPaging(int page, int pagesize)
        {
            return db.DonHangs.OrderByDescending(x => x.DaXacNhan).ToPagedList(page, pagesize);
        }
        public IEnumerable<DonHang> ListCreateDate(DateTime date, int page, int pagesize)
        {
            return db.DonHangs.Where(x => x.CreateDate == date && x.DaXacNhan == true).OrderByDescending(x => x.DaXacNhan).ToPagedList(page, pagesize);
        }
        public DonHang ViewDetail(long id)
        {
            return db.DonHangs.Find(id);
        }
        
    }
}

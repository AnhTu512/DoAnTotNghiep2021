using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class KhachHangDao
    {
        DB_Nong_San db = null;
        public KhachHangDao()
        {
            db = new DB_Nong_San();
        }
        public long Insert(KhachHang entity)
        {
            db.KhachHangs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(KhachHang entity)
        {
            try
            {
                var khachhang = db.KhachHangs.Find(entity.ID);
                khachhang.Name = entity.Name;
                khachhang.DiaChi = entity.DiaChi;
                khachhang.Email = entity.Email;
                khachhang.SDT = entity.SDT;
                khachhang.Status = entity.Status;
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
                var khachhang = db.KhachHangs.Find(id);
                db.KhachHangs.Remove(khachhang);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<KhachHang> ListAllPaging(string searchString, int page, int pagesize)
        {
            IQueryable<KhachHang> model = db.KhachHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public KhachHang ViewDetail(long id)
        {
            return db.KhachHangs.Find(id);
        }
    }
}

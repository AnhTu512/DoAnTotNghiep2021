using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TinTucDao
    {
        DB_Nong_San db = null;
        public TinTucDao()
        {
            db = new DB_Nong_San();
        }
        public long Insert(TinTuc entity)
        {
            db.TinTucs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(TinTuc entity)
        {
            try
            {
                var tinTuc = db.TinTucs.Find(entity.ID);
                tinTuc.Name = entity.Name;
                tinTuc.HinhAnh = entity.HinhAnh;
                tinTuc.MoTa = entity.MoTa;
                tinTuc.NoiDung = entity.NoiDung;
                tinTuc.TuKhoa = entity.TuKhoa;
                tinTuc.NgayDang = DateTime.Now;
                tinTuc.MetaTitle = entity.MetaTitle;
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
                var tinTuc = db.TinTucs.Find(id);
                db.TinTucs.Remove(tinTuc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<TinTuc> ListAllPaging(string searchString,int page, int pagesize)
        {
            IQueryable<TinTuc> model = db.TinTucs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public IEnumerable<TinTuc> ListTinTuc(int page, int pagesize)
        {
            return db.TinTucs.OrderByDescending(x => x.Name).ToPagedList(page, pagesize);
        }
        public List<TinTuc> ListAll()
        {
            return db.TinTucs.ToList();
        }
        public TinTuc ViewDetail(long id)
        {
            return db.TinTucs.Find(id);
        }
        public TinTuc GetByID(string name)
        {
            return db.TinTucs.SingleOrDefault(x => x.Name == name);
        }
    }
}

using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        DB_Nong_San db = null;
        public ProductDao()
        {
            db = new DB_Nong_San();
        }
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Product entity)
        {
            try
            {
                var nongSan = db.Products.Find(entity.ID);
                nongSan.Name = entity.Name ;
                nongSan.Code = entity.Code ;
                nongSan.MetaTitle = entity.MetaTitle ;
                nongSan.MoTa = entity.MoTa ;
                nongSan.HinhAnh = entity.HinhAnh ;
                nongSan.Gia = entity.Gia ;
                nongSan.GiaKhuyenMai = entity.GiaKhuyenMai ;
                nongSan.SoLuong = entity.SoLuong ;
                nongSan.Loai = entity.Loai ;
                nongSan.Status = entity.Status ;
                nongSan.TopHot = entity.TopHot ;
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
                var nongSan = db.Products.Find(id);
                db.Products.Remove(nongSan);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<string> ListName(string keword)
        {
            return db.Products.Where(x => x.Name.Contains(keword)).Select(x => x.Name).ToList();
        }
        
        public IEnumerable<Product> Search(string keyword , int page, int pagesize)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).OrderByDescending(x => x.Name).ToPagedList(page, pagesize);
        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public IEnumerable<Product> ListProduct(int page, int pagesize)
        {
            return db.Products.OrderByDescending(x => x.Name).ToPagedList(page, pagesize);
        }
        public IEnumerable<Product> ListRauCu(int page, int pagesize)
        {
            var raucu = db.Products.Where(x => x.Loai == "Rau").OrderBy(x => x.Name).ToPagedList(page, pagesize);
            return raucu;
        }
        public IEnumerable<Product> ListQua(int page, int pagesize)
        {
            var qua = db.Products.Where(x => x.Loai == "Qua").OrderBy(x => x.Name).ToPagedList(page, pagesize);
            return qua;
        }
        public IEnumerable<Product> ListMonNgon(int page, int pagesize)
        {
            var monngon = db.Products.Where(x => x.Loai == "MonNgon").OrderBy(x => x.Name).ToPagedList(page, pagesize);
            return monngon;
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
        public Product GetByID(string name)
        {
            return db.Products.SingleOrDefault(x => x.Name == name);
        }
        public List<Product> ListNewNongSan(int top)
        {
            return db.Products.OrderByDescending(x => x.Name).Take(top).ToList();
        }
        public List<Product> SanPhamLienQuan(long id)
        {
            var nongsan = db.Products.Find(id);
            return db.Products.Where(x => x.ID != id && x.Loai == nongsan.Loai ).ToList();
        }
        public List<Product> ListNongSan(int page = 1 , int pageSize = 2)
        {
            var model = db.Products.OrderBy(x => x.ID).Skip((page -1)* pageSize).Take(pageSize).ToList();
            return model;
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.Name).Take(top).ToList();
        }
    }
}

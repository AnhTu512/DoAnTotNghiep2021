using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Common;

namespace Model.Dao
{
    public class TaiKhoanDao
    {
        DB_Nong_San db = null;
        public TaiKhoanDao()
        {
            db = new DB_Nong_San();
        }
        public long Insert(TaiKhoan entity)
        {
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(TaiKhoan entity)
        {
            try
            {
                var taikhoan = db.TaiKhoans.Find(entity.ID);
                if (entity.Pass != null)
                {
                    taikhoan.Pass = entity.Pass;
                }
                taikhoan.TenNguoiDung = entity.TenNguoiDung;
                taikhoan.Status = entity.Status;
                taikhoan.SDT = entity.SDT;
                taikhoan.Email = entity.Email;
                taikhoan.ID_Group = entity.ID_Group;
                db.SaveChanges();
                return true;
            }
            catch ( Exception)
            {
                return false;
            }
        }
        public bool ChangeStatus (long id)
        {
            var taikhoan = db.TaiKhoans.Find(id);
            taikhoan.Status = !taikhoan.Status;
            return taikhoan.Status;
        }
        public bool Xoa(int id)
        {
            try
            {
                var taikhoan = db.TaiKhoans.Find(id);
                db.TaiKhoans.Remove(taikhoan);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckTenTK(string tenTK)
        {
            return db.TaiKhoans.Count(x => x.TenTK == tenTK) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.TaiKhoans.Count(x => x.Email == email) > 0;
        }
        public IEnumerable<TaiKhoan> ListAllPaging(int page, int pagesize)
        {
            // sau viết code tạo biến ra dễ debug !
            return db.TaiKhoans.OrderByDescending(x => x.TenTK).ToPagedList(page, pagesize);
        }
        public TaiKhoan ViewDetail(int id)
        {
            return db.TaiKhoans.Find(id);
        }
        public TaiKhoan GetByID(string tenTK)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.TenTK == tenTK);
        }
        public List<string> GetListCredential(string tenTK)
        {
            var user = db.TaiKhoans.Single(x => x.TenTK == tenTK);
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.ID
                        join c in db.Roles on a.RoleID equals c.ID
                        where b.ID == user.ID_Group
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }
        public int Login(string tenTK, string pass, bool isLoginAdmin =false)
        {
            var result = db.TaiKhoans.SingleOrDefault(x => x.TenTK == tenTK );
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(isLoginAdmin == true )
                {
                    if (result.ID_Group == CommonConstant.ADMIN_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Pass == pass)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                    
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Pass == pass)
                            return 1;
                        else
                            return -2;
                    }
                }
                
            }
        }
    }
}

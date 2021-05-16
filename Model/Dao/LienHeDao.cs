using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LienHeDao
    {
        DB_Nong_San db = null;
        public LienHeDao()
        {
            db = new DB_Nong_San();
        }
        public LienHe GetActiveLienHe()
        {
            return db.LienHes.Single(x => x.Status == true);
        }
        public int InsertFeedBack(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
        public IEnumerable<Feedback> ListAllPaging( int page, int pagesize)
        {
            IQueryable<Feedback> model = db.Feedbacks;
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);
        }
        public Feedback ViewDetail(long id)
        {
            return db.Feedbacks.Find(id);
        }
    }
}
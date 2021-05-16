using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ChiTietDonHangDao
    {
        DB_Nong_San db = null;
        public ChiTietDonHangDao()
        {
            db = new DB_Nong_San();
        }
        public bool Insert(ChiTietDonHang detail)
        {
            try
            {
                db.ChiTietDonHangs.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}

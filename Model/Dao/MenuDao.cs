using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        DB_Nong_San db = null;
        public MenuDao()
        {
            db = new DB_Nong_San();
        }
        public List<Menu> ListByGoupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId && x.Status == true).OrderBy(x => x.DisplayOder).ToList();
        }
    }
}

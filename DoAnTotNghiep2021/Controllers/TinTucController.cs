using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace DoAnTotNghiep2021.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TinTuc(int page=1 , int pageSize =6)
        {
            var tintuc = new TinTucDao();
            var model = tintuc.ListTinTuc(page, pageSize);
            return View(model);
        }
        public ActionResult ChiTietTinTuc(long id)
        {
            var tintuc = new TinTucDao().ViewDetail(id);
            ViewBag.TinTuc = new TinTucDao().ViewDetail(tintuc.ID);
            return View(tintuc);
        }
    }
}
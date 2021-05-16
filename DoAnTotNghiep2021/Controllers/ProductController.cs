using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace DoAnTotNghiep2021.Controllers
{
    public class ProductController : Controller
    {
        // GET: NongSan
        public ActionResult Index()
        {
            return View();
        }
        //View SP
        public ActionResult NongSan(int page= 1 , int pageSize =4)
        {
            var nongsan = new ProductDao();
            var model = nongsan.ListProduct(page, pageSize);
            return View(model);

        }
        //chi tiết SP
        public ActionResult Detail(long id)
        {
            var nongsan = new ProductDao().ViewDetail(id);
            ViewBag.NongSan = new ProductDao().ViewDetail(nongsan.ID);
            ViewBag.SanPhamLienQuan = new ProductDao().SanPhamLienQuan(id);
            return View(nongsan);
        }
        public JsonResult ListName(string q)
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                status =true
            }, JsonRequestBehavior.AllowGet
            );
        }
        public ActionResult Search(string keyword, int page = 1, int pageSize = 8)
        {
            var nongsan = new ProductDao();
            var model = nongsan.Search(keyword,page, pageSize);
            ViewBag.Keyword = keyword;
            return View(model);

        }
        public ActionResult RauCu(int page = 1, int pageSize = 4)
        {
            var raucu = new ProductDao();
            var model = raucu.ListRauCu(page, pageSize);
            return View(model);
        }
        public ActionResult TraiCay(int page = 1, int pageSize = 4)
        {
            var traicay = new ProductDao();
            var model = traicay.ListQua(page, pageSize);
            return View(model);
        }
        public ActionResult MonNgon(int page = 1, int pageSize = 4)
        {
            var monngon = new ProductDao();
            var model = monngon.ListMonNgon(page, pageSize);
            return View(model);
        }

    }
}
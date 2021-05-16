using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace DoAnTotNghiep2021.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new KhachHangDao();
            var model = dao.ListAllPaging(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var khachHang = new KhachHangDao().ViewDetail(id);
            return View(khachHang);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                var result = dao.Update(khachHang);
                if (result)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tài khoản không thành công");
                }
            }
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            new KhachHangDao().Xoa(id);
            return RedirectToAction("Index");
        }
    }
}
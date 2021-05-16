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
    public class DonHangController : BaseController
    {
        // GET: Admin/DonHang
        [HasCredential(RoleID = "VIEW_DONHANG")]
        public ActionResult DonHang(int page = 1, int pagesize = 10)
        {
            var dao = new DonHangDao();
            var model = dao.ListAllPaging(page, pagesize);
            return View(model);
        }
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var dao = new DonHangDao();
            var model = dao.ListAllPaging(page, pagesize);
            return View(model);
        }
        [HasCredential(RoleID = "EDIT_DONHANG")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var donhang = new DonHangDao().ViewDetail(id);
            return View(donhang);
        }
        [HasCredential(RoleID = "EDIT_DONHANG")]
        [HttpPost]
        public ActionResult Edit(DonHang donhang)
        {
            if (ModelState.IsValid)
            {
                var dao = new DonHangDao();
                var result = dao.Update(donhang);
                if (result)
                {
                    return RedirectToAction("Index", "DonHang");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật đơn hàng không thành công");
                }
            }
            return View("Index");
        }
        [HasCredential(RoleID = "DELETE_DONHANG")]
        public ActionResult Delete(int id)
        {
            new ProductDao().Xoa(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new DonHangDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
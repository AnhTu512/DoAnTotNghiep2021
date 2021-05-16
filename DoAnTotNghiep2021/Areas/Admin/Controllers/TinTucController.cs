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
    public class TinTucController : BaseController
    {
        // GET: Admin/TinTuc
        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Index(string searchString,int page=1, int pagesize=10)
        {
            var dao = new TinTucDao();
            var model = dao.ListAllPaging(searchString,page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HasCredential(RoleID = "ADD_TINTUC")]
        [HttpGet]
        public ActionResult Create()
        {
            //SetViewBag();
            return View();
        }
        [HasCredential(RoleID = "ADD_TINTUC")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(TinTuc tintuc)
        {
            if (ModelState.IsValid)
            {
                var dao = new TinTucDao();
                long id = dao.Insert(tintuc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "TinTuc");
                }
                else
                    ModelState.AddModelError("", "Thêm Tin tức không thành công");
            }
            return View("Index");
        }
        [HasCredential(RoleID = "EDIT_TINTUC")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tinTuc = new TinTucDao().ViewDetail(id);
            return View(tinTuc);
        }
        [HasCredential(RoleID = "EDIT_TINTUC")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                var dao = new TinTucDao();
                var result = dao.Update(tinTuc);
                if (result)
                {
                    return RedirectToAction("Index", "TinTuc");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật tin tức không thành công");
                }
            }
            return View("Index");
        }
        [HasCredential(RoleID = "DELETE_TINTUC")]
        public ActionResult Delete(int id)
        {
            new TinTucDao().Xoa(id);
            return RedirectToAction("Index");
        }
        //public void SetViewBag(long? selectedId)
        //{
        //    var dao = new TinTuc();
        //    ViewBag.TinTucID = new SelectList(dao.ListAll(), "ID", "LoaiTinTuc", selectedId);
        //}
    }
}
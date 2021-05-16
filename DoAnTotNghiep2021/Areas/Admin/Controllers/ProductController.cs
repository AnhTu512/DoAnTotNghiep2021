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
    public class ProductController : Controller
    {
        // GET: Admin/product
        [HasCredential(RoleID = "VIEW_PRODUCT")]
        public ActionResult Index(string searchString,int page = 1 , int pagesize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString ,page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HasCredential(RoleID = "ADD_PRODUCT")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HasCredential(RoleID = "ADD_PRODUCT")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Insert(product);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                    ModelState.AddModelError("", "Thêm nông sản không thành công");
            }
            return View("Index");
        }
        [HasCredential(RoleID = "EDIT_PRODUCT")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }
        [HasCredential(RoleID = "EDIT_PRODUCT")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật nông sản không thành công");
                }
            }
            return View("Index");
        }
        [HasCredential(RoleID = "DELETE_PRODUCT")]
        public ActionResult Delete(int id)
        {
            new ProductDao().Xoa(id);
            return RedirectToAction("Index");
        }
    }
}
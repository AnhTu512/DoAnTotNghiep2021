using DoAnTotNghiep2021.Common;
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
    public class TaiKhoanController : Controller
    {
        // GET: Admin/TaiKhoan
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index(int page =1 , int pagesize = 10)
        {
            var dao = new TaiKhoanDao();
            var model = dao.ListAllPaging(page, pagesize);
            return View(model);
        }

        [HasCredential(RoleID = "ADD_USER")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HasCredential(RoleID = "ADD_USER")]
        [HttpPost]
        public ActionResult Create(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();

                var encryptedMd5Pas = Encryptor.MD5Hash(taikhoan.Pass);
                taikhoan.Pass = encryptedMd5Pas;

                long id = dao.Insert(taikhoan);
                if (id > 0)
                {
                    return RedirectToAction("Index", "TaiKhoan");
                }
                else
                    ModelState.AddModelError("", "Thêm tài khoản không thành công");
            }
            return View("Index");
        }
        [HasCredential(RoleID = "EDIT_USER")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var taikhoan = new TaiKhoanDao().ViewDetail(id);
            return View(taikhoan);
        }
        [HasCredential(RoleID = "EDIT_USER")]
        [HttpPost]
        public ActionResult Edit(TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();
                if (!string.IsNullOrEmpty(taikhoan.Pass))
                {
                    var encryptedMD5Pas = Encryptor.MD5Hash(taikhoan.Pass);
                    taikhoan.Pass = encryptedMD5Pas;
                }
                var result = dao.Update(taikhoan);
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
        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
            new TaiKhoanDao().Xoa(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new TaiKhoanDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        
    }
}
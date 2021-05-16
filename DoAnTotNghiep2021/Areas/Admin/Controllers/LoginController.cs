using DoAnTotNghiep2021.Areas.Admin.Models;
using DoAnTotNghiep2021.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnTotNghiep2021.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();
                var result = dao.Login(model.TenTK, Encryptor.MD5Hash(model.Pass));
                if (result ==1)
                {
                    var user = dao.GetByID(model.TenTK);
                    var userSesstion = new TaiKhoanDangNhap();
                    userSesstion.TenTK = user.TenTK;
                    userSesstion.UserID = user.ID;
                    var listCredentials = dao.GetListCredential(model.TenTK);
                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SECTION, userSesstion);
                    return RedirectToAction("Index", "Home");
                }
                else if (result ==0)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
                else if (result ==-1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
                else if(result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập");
                }
                else ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
            }
            return View("Index");
        }
    }
}
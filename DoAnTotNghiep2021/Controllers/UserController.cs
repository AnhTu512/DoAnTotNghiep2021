using DoAnTotNghiep2021.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotDetect.Web;
using BotDetect.Web.Mvc;
using DoAnTotNghiep2021.Common;

namespace DoAnTotNghiep2021.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();
                var result = dao.Login(model.TenTK, Encryptor.MD5Hash(model.Pass));
                if (result == 1)
                {
                    var user = dao.GetByID(model.TenTK);
                    var userSession = new TaiKhoanDangNhap();
                    userSession.TenTK = user.TenTK;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SECTION, userSession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDao();

                if (dao.CheckTenTK(model.TenTK))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var taikhoan = new TaiKhoan();
                    var khachhang = new KhachHang();
                    var khachhangdao = new KhachHangDao();

                    taikhoan.TenNguoiDung =khachhang.Name = model.TenNguoiDung;
                    taikhoan.Pass = Encryptor.MD5Hash(model.Pass);
                    taikhoan.SDT = khachhang.SDT = model.SDT;
                    taikhoan.Email = khachhang.Email = model.Email;
                    taikhoan.Address =khachhang.DiaChi = model.Address;
                    taikhoan.Status = khachhang.Status = true;
                    taikhoan.TenTK = khachhang.TenTK = model.TenTK;
                    khachhang.NgayTao = DateTime.Now;
                    taikhoan.ID_Group = "MEMBER";
                    khachhangdao.Insert(khachhang);
                    var result = dao.Insert(taikhoan);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                }
            }    
             
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SECTION] = null;
            return Redirect("/");
        }
    }
}
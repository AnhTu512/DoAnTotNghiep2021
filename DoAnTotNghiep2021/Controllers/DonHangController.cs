using Common;
using DoAnTotNghiep2021.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DoAnTotNghiep2021.Controllers
{
    public class DonHangController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: DonHang
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart !=null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if(jsonItem !=null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            }) ;
        }
        public ActionResult AddItem(long productId , int soluong)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if(cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product == product)
                        {
                            item.SoLuong += soluong;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.SoLuong = soluong;
                    list.Add(item);
                }
                //gán vào session
                Session[CartSession] = list;
                
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Product = product;
                item.SoLuong = soluong;
                var list = new List<CartItem>();
                list.Add(item);

                //gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
            var order = new DonHang();
            order.CreateDate = DateTime.Now;
            order.ShipAddress = address;
            order.ShipSDT = mobile;
            order.ShipName = shipName;
            order.ShipEmail = email;

            try
            {
                var id = new DonHangDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new Model.Dao.ChiTietDonHangDao();
                int total = 0;
                foreach (var item in cart)
                {
                    var chitietdonhang = new ChiTietDonHang();
                    chitietdonhang.ProductID = item.Product.ID;
                    chitietdonhang.DonHangID = id;
                    chitietdonhang.Gia = item.Product.Gia;
                    chitietdonhang.SoLuong = item.SoLuong;
                    detailDao.Insert(chitietdonhang);

                    total += (item.Product.Gia * item.SoLuong);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", shipName);
                content = content.Replace("{{Phone}}", mobile);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Address}}", address);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(email, "Đơn hàng mới từ Nông Sản Thanh Hà", content);
                new MailHelper().SendMail(toEmail, "Đơn hàng mới từ Nông Sản Thanh Hà", content);
            }
            catch (Exception ex)
            {
                //ghi log
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/thanh-cong");
        }

        public ActionResult Success()
        {
            return View();
        }
        public ActionResult Errors()
        {
            return View();
        }
    }
}
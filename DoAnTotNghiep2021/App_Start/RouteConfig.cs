using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoAnTotNghiep2021
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Nong San",
                url: "nong-san/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "NongSan", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );
            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            routes.MapRoute(
                name: "List Rau Cu",
                url: "rau-cu",
                defaults: new { controller = "Product", action = "RauCu", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );
            routes.MapRoute(
                name: "List Trai Cay",
                url: "trai-cay",
                defaults: new { controller = "Product", action = "TraiCay", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );
            routes.MapRoute(
                name: "List Mon Ngon",
                url: "san-pham-tu-nong-san",
                defaults: new { controller = "Product", action = "MonNgon", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );

            routes.MapRoute(
                name: "List Nong San",
                url: "nong-san",
                defaults: new { controller = "Product", action = "NongSan", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );
            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );
            routes.MapRoute(
                name: "Chi Tiet Tin Tuc",
                url: "chi-tiet-tin-tuc/{metatitle}-{id}",
                defaults: new { controller = "TinTuc", action = "ChiTietTinTuc", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );

            routes.MapRoute(
                name: "Chi Tiet Nong San",
                url: "chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );
            routes.MapRoute(
                name: "About",
                url: "gioi-thieu",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );
            routes.MapRoute(
                name: "Gio Hang",
                url: "gio-hang",
                defaults: new { controller = "DonHang", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );
            routes.MapRoute(
                name: "Them Gio Hang",
                url: "them-gio-hang",
                defaults: new { controller = "DonHang", action = "AddItem", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );
            routes.MapRoute(
                name: "TinTuc",
                url: "tin-tuc",
                defaults: new { controller = "TinTuc", action = "TinTuc", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
            );
            routes.MapRoute(
               name: "Payment",
               url: "thanh-toan",
               defaults: new { controller = "DonHang", action = "Payment", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
           );
            routes.MapRoute(
               name: "Success",
               url: "thanh-cong",
               defaults: new { controller = "DonHang", action = "Success", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
           );
            routes.MapRoute(
               name: "Errors",
               url: "loi-thanh-toan",
               defaults: new { controller = "DonHang", action = "Errors", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
           );

            routes.MapRoute(
               name: "Login",
               url: "dang-nhap",
               defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
           );
            routes.MapRoute(
               name: "Register",
               url: "dang-ky",
               defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
           );
            routes.MapRoute(
              name: "Lien He",
              url: "lien-he",
              defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "DoAnTotNghiep2021.Controllers" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },namespaces : new [] { "DoAnTotNghiep2021.Controllers" }
            );

            
        }
    }
}

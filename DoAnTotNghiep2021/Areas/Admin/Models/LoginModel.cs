using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnTotNghiep2021.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời bạn nhập thông tin tên tài khoản")]
        public string TenTK { set; get; }
        [Required(ErrorMessage = "Mời bạn nhập thông tin mật khẩu")]
        public string Pass { set; get; }
        public bool RememberMe { set; get; }
    }
}
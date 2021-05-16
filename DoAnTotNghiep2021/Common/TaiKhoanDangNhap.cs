using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnTotNghiep2021.Common
{
    [Serializable]
    public class TaiKhoanDangNhap
    {
        public long UserID { set; get; }
        public string TenTK { set; get;  }
        public string ID_Group { set; get; }
    }
}
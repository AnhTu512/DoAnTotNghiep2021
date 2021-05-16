namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        public long ID { get; set; }

        [StringLength(20)]
        public string TenTK { get; set; }

        [StringLength(50)]
        public string Pass { get; set; }

        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        public bool Status { get; set; }

        public int? SDT { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(50)]
        public string ID_Group { get; set; }

        public int? ProvinceID { get; set; }

        public int? DistrictID { get; set; }

        [StringLength(250)]
        public string Address { get; set; }
    }
}

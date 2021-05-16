namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        public long ID { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(250)]
        public string NameSP { get; set; }

        public int? Gia { get; set; }

        public int? GiaKhuyenMai { get; set; }

        public int? SoLuong { get; set; }

        public int? Status { get; set; }

        public decimal? TongTien { get; set; }
    }
}

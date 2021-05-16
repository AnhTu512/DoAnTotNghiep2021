namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        public DateTime? NgayTao { get; set; }

        public bool Status { get; set; }

        [StringLength(20)]
        public string TenTK { get; set; }
    }
}

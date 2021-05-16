namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public string MoTa { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        public int Gia { get; set; }

        public int? GiaKhuyenMai { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(50)]
        public string Loai { get; set; }

        public bool Status { get; set; }

        public DateTime? TopHot { get; set; }
        [StringLength(20)]
        public string DVTinh { get; set; }
    }
}

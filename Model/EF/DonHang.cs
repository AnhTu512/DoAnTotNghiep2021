namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        public long ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public long? CustomerID { get; set; }

        [StringLength(250)]
        public string ShipName { get; set; }

        [StringLength(250)]
        public string ShipEmail { get; set; }

        [StringLength(250)]
        public string ShipAddress { get; set; }

        [StringLength(50)]
        public string ShipSDT { get; set; }

        public bool DaXacNhan { get; set; }
        public bool DaGiaoXong { get; set; }
    }
}

namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        [StringLength(20)]
        public string LoaiTinTuc { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        public DateTime? NgayDang { get; set; }

        [StringLength(50)]
        public string TuKhoa { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }
    }
}

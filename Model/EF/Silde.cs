namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Silde")]
    public partial class Silde
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? DisplayOder { get; set; }

        [StringLength(250)]
        public string MoTa { get; set; }

        public bool? Status { get; set; }

        [StringLength(250)]
        public string Link { get; set; }
    }
}

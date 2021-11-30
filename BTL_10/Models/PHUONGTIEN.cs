namespace BTL_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHUONGTIEN")]
    public partial class PHUONGTIEN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MAPHUONGTIEN { get; set; }

        [StringLength(100)]
        public string TENPHUONGTIEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SOCHO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MATOUR { get; set; }

        public virtual TOUR TOUR { get; set; }
    }
}

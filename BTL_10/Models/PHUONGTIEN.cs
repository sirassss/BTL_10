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
        [StringLength(10)]
        public string MAPHUONGTIEN { get; set; }

        [Required]
        [StringLength(10)]
        public string MATOUR { get; set; }

        [StringLength(100)]
        public string TENPHUONGTIEN { get; set; }

        public virtual TOUR TOUR { get; set; }
    }
}

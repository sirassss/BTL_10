namespace BTL_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANGKY")]
    public partial class DANGKY
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MATOUR { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MAKHACH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SLVE { get; set; }

        public virtual KHACH KHACH { get; set; }

        public virtual TOUR TOUR { get; set; }
    }
}

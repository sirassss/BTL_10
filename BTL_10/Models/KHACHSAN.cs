namespace BTL_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHSAN")]
    public partial class KHACHSAN
    {
        [Key]
        [StringLength(10)]
        public string MAKS { get; set; }

        [Required]
        [StringLength(10)]
        public string MATOUR { get; set; }

        [StringLength(100)]
        public string TENKS { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        public virtual TOUR TOUR { get; set; }
    }
}

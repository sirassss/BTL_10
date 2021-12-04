namespace BTL_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BLOG")]
    public partial class BLOG
    {
        [Key]
        [StringLength(10)]
        public string MABAIVIET { get; set; }

        [StringLength(1000)]
        public string TIEUDE { get; set; }

        [StringLength(1000)]
        public string ANH { get; set; }

        [StringLength(1000)]
        public string TOMTAT { get; set; }

        [Column(TypeName = "ntext")]
        public string NOIDUNG { get; set; }

        public DateTime? NGAYKHOITAO { get; set; }

        [Required]
        [StringLength(10)]
        public string MADANHMUCBLOG { get; set; }

        [Required]
        [StringLength(10)]
        public string ID { get; set; }

        public virtual ADMIN ADMIN { get; set; }

        public virtual DANHMUCBLOG DANHMUCBLOG { get; set; }
    }
}

namespace BTL_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HUONGDANVIEN")]
    public partial class HUONGDANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HUONGDANVIEN()
        {
            TOURs = new HashSet<TOUR>();
        }

        [Key]
        [StringLength(10)]
        public string MAHDV { get; set; }

        [StringLength(100)]
        public string TENHDV { get; set; }

        public bool? PHAI { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOUR> TOURs { get; set; }
    }
}

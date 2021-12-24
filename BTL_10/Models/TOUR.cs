namespace BTL_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOUR")]
    public partial class TOUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOUR()
        {
            KHACHes = new HashSet<KHACH>();
            DENs = new HashSet<DEN>();
        }
        public TOUR(string MATOUR)
        {
            this.MATOUR = MATOUR;
        }

        [Key]
        [StringLength(10)]
        public string MATOUR { get; set; }

        [StringLength(100)]
        public string TENTOUR { get; set; }

        public DateTime? NGAYBD { get; set; }

        public DateTime? NGAYKT { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIA { get; set; }

        [Required]
        [StringLength(10)]
        public string MAHDV { get; set; }

        [Column(TypeName = "ntext")]
        public string CHITIETTOUR { get; set; }

        [StringLength(1000)]
        public string ANH { get; set; }

        [Required]
        [StringLength(10)]
        public string MAKS { get; set; }

        [Required]
        [StringLength(10)]
        public string MAPHUONGTIEN { get; set; }

        public virtual HUONGDANVIEN HUONGDANVIEN { get; set; }

        public virtual KHACHSAN KHACHSAN { get; set; }

        public virtual PHUONGTIEN PHUONGTIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHACH> KHACHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEN> DENs { get; set; }
    }
    
}

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
            KHACHSANs = new HashSet<KHACHSAN>();
            PHUONGTIENs = new HashSet<PHUONGTIEN>();
            KHACHes = new HashSet<KHACH>();
            DIEMTHAMQUANs = new HashSet<DIEMTHAMQUAN>();
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

        public virtual HUONGDANVIEN HUONGDANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHACHSAN> KHACHSANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHUONGTIEN> PHUONGTIENs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHACH> KHACHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEMTHAMQUAN> DIEMTHAMQUANs { get; set; }
    }
}

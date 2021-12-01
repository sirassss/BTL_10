namespace BTL_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIEMTHAMQUAN")]
    public partial class DIEMTHAMQUAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIEMTHAMQUAN()
        {
            TOURs = new HashSet<TOUR>();
        }

        [Key]
        [StringLength(10)]
        public string MADD { get; set; }

        [StringLength(100)]
        public string TENDD { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(1000)]
        public string MOTADIEMDEN { get; set; }

        [StringLength(1000)]
        public string ANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOUR> TOURs { get; set; }
    }
}

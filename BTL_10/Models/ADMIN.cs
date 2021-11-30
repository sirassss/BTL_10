namespace BTL_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADMIN()
        {
            BLOGs = new HashSet<BLOG>();
        }

        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(20)]
        public string TENDN { get; set; }

        [StringLength(8)]
        public string MK { get; set; }

        [StringLength(20)]
        public string LOAITK { get; set; }

        [StringLength(100)]
        public string HOTEN { get; set; }

        [StringLength(10)]
        public string TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BLOG> BLOGs { get; set; }
    }
}

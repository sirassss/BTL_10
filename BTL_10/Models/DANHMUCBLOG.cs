namespace BTL_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHMUCBLOG")]
    public partial class DANHMUCBLOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANHMUCBLOG()
        {
            BLOGs = new HashSet<BLOG>();
        }

        [Key]
        [StringLength(10)]
        public string MADANHMUCBLOG { get; set; }

        [StringLength(100)]
        public string TENDANHMUCBLOG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BLOG> BLOGs { get; set; }
    }
}

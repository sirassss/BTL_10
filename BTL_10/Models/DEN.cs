namespace BTL_10.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEN")]
    public partial class DEN
    {

        public DEN() { }

        public DEN(string mATOUR, string mADD)
        {
            MATOUR = mATOUR;
            MADD = mADD;
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MATOUR { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MADD { get; set; }

        public virtual TOUR TOUR { get; set; }

        public virtual DIEMTHAMQUAN DIEMTHAMQUAN { get; set; }
    }
}

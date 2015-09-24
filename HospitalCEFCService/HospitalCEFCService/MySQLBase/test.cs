namespace HospitalCEFCService.MySQLBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hospitalbase.test")]
    public partial class test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int patientNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? testdate { get; set; }

        [StringLength(100)]
        public string testhead { get; set; }

        [StringLength(11)]
        public string amount { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string remarks { get; set; }

        public virtual patient patient { get; set; }
    }
}

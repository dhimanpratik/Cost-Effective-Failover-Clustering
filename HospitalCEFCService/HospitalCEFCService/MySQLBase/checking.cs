namespace HospitalCEFCService.MySQLBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hospitalbase.checking")]
    public partial class checking
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int docID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int patientNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? checkDate { get; set; }

        [StringLength(11)]
        public string fee { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string remarks { get; set; }

        public virtual doctor doctor { get; set; }

        public virtual patient patient { get; set; }
    }
}

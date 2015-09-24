namespace HospitalCEFCService.MySQLBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hospitalbase.patient")]
    public partial class patient
    {
        public patient()
        {
            checkings = new HashSet<checking>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int patientNo { get; set; }

        [Required]
        [StringLength(100)]
        public string PatientName { get; set; }

        public int? age { get; set; }

        [Column(TypeName = "char")]
        [StringLength(20)]
        public string sex { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [Column(TypeName = "date")]
        public DateTime regDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime disDate { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string remarks { get; set; }

        public int empID { get; set; }

        public virtual employee employee { get; set; }

        public virtual test test { get; set; }

        public virtual ICollection<checking> checkings { get; set; }
    }
}

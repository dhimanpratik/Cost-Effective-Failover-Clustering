namespace HospitalCEFCService.MySQLBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hospitalbase.doctor")]
    public partial class doctor
    {
        public doctor()
        {
            checkings = new HashSet<checking>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int docID { get; set; }

        [Required]
        [StringLength(100)]
        public string docName { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(30)]
        public string contact { get; set; }

        [StringLength(100)]
        public string faculty { get; set; }

        public virtual ICollection<checking> checkings { get; set; }
    }
}

namespace HospitalCEFCService.MySQLBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hospitalbase.employee")]
    public partial class employee
    {
        public employee()
        {
            patients = new HashSet<patient>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int empID { get; set; }

        [Required]
        [StringLength(100)]
        public string empName { get; set; }

        public int counterNo { get; set; }

        public virtual ICollection<patient> patients { get; set; }
    }
}

namespace HospitalCEFCService.MySQLBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MySQL_Model : DbContext
    {
        public MySQL_Model()
            : base("name=MySQL_Model")
        {
        }

        public virtual DbSet<doctor> doctors { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<checking> checkings { get; set; }
        public virtual DbSet<test> tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<doctor>()
                .Property(e => e.docName)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.contact)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .Property(e => e.faculty)
                .IsUnicode(false);

            modelBuilder.Entity<doctor>()
                .HasMany(e => e.checkings)
                .WithRequired(e => e.doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.empName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.patients)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.PatientName)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.sex)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .Property(e => e.remarks)
                .IsUnicode(false);

            modelBuilder.Entity<patient>()
                .HasOptional(e => e.test)
                .WithRequired(e => e.patient);

            modelBuilder.Entity<patient>()
                .HasMany(e => e.checkings)
                .WithRequired(e => e.patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<checking>()
                .Property(e => e.fee)
                .IsUnicode(false);

            modelBuilder.Entity<checking>()
                .Property(e => e.remarks)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.testhead)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.amount)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.remarks)
                .IsUnicode(false);
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CSIMedia
{
    public partial class CSIMediaContext : DbContext
    {
        public CSIMediaContext()
            : base("name=CSIMediaContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<SortData> SortDatas { get; set; }
        public virtual DbSet<sortdata1> sortdata1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SortData>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<SortData>()
                .Property(e => e.SortedNumbers)
                .IsUnicode(false);

            modelBuilder.Entity<SortData>()
                .Property(e => e.SortDirection)
                .IsUnicode(false);

            modelBuilder.Entity<sortdata1>()
                .Property(e => e.SortedNumbers)
                .IsUnicode(false);

            modelBuilder.Entity<sortdata1>()
                .Property(e => e.SortDirection)
                .IsUnicode(false);
        }
    }
}

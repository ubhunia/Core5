using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core5.Models
{
    public partial class TestCoreContext : DbContext
    {
        public TestCoreContext()
        {
        }

        public TestCoreContext(DbContextOptions<TestCoreContext> options): base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
# warning See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Database=TestCore;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(x => x.ProductId)
                    .HasName("PK__Products__B40CC6CD34E0CD47");

                entity.Property(e => e.Category)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

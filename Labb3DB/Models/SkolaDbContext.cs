using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3DB.Models
{
    public partial class SkolaDbContext : DbContext
    {
        public SkolaDbContext()
        {
        }

        public SkolaDbContext(DbContextOptions<SkolaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Betyg> Betyg { get; set; }
        public virtual DbSet<Elever> Elever { get; set; }
        public virtual DbSet<Klasser> Klasser { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-JCAKF9L;Initial Catalog = Skola;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Betyg>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Betyg1)
                    .HasColumnName("Betyg")
                    .HasMaxLength(3);

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.Kurs).HasMaxLength(50);

                entity.Property(e => e.Personnummer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Personal)
                    .WithMany()
                    .HasForeignKey(d => d.PersonalId)
                    .HasConstraintName("FK_Betyg_Personal");

                entity.HasOne(d => d.PersonnummerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Personnummer)
                    .HasConstraintName("FK_Betyg_Elever");
            });

            modelBuilder.Entity<Elever>(entity =>
            {
                entity.HasKey(e => e.Personnummer);

                entity.Property(e => e.Personnummer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Efternamn).HasMaxLength(50);

                entity.Property(e => e.Förnamn).HasMaxLength(50);

                entity.Property(e => e.Kön).HasMaxLength(50);

                entity.HasOne(d => d.Klass)
                    .WithMany(p => p.Elever)
                    .HasForeignKey(d => d.KlassId)
                    .HasConstraintName("FK_Elever_Klasser");
            });

            modelBuilder.Entity<Klasser>(entity =>
            {
                entity.HasKey(e => e.KlassId);

                entity.Property(e => e.KlassId).ValueGeneratedNever();

                entity.Property(e => e.KlassNamn).HasMaxLength(50);
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.Property(e => e.PersonalId).ValueGeneratedNever();

                entity.Property(e => e.Befattning).HasMaxLength(50);

                entity.Property(e => e.Efternamn).HasMaxLength(50);

                entity.Property(e => e.Förnamn).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

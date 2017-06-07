using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pgEfCore.Models
{
    public partial class CalCalcDbContext : DbContext
    {
        public CalCalcDbContext(DbContextOptions<CalCalcDbContext> options) : base(options)
        {

        }

        //public CalCalcDbContext() 
        //{

        //}

        public virtual DbSet<Additive> Additive { get; set; }
        public virtual DbSet<AdditiveList> AdditiveList { get; set; }
        public virtual DbSet<CalEntry> CalEntry { get; set; }
        public virtual DbSet<DextroseConcentration> DextroseConcentration { get; set; }
        public virtual DbSet<Enteral> Enteral { get; set; }
        public virtual DbSet<FluidInfusion> FluidInfusion { get; set; }
        public virtual DbSet<FormulaList> FormulaList { get; set; }
        public virtual DbSet<Parenteral> Parenteral { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"User ID=postgres;Password=bigsky01;Host=localhost;Port=5432;Database=CalCalc;Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Additive>(entity =>
            {
                entity.HasOne(d => d.AdditiveList)
                    .WithMany(p => p.Additive)
                    .HasForeignKey(d => d.AdditiveListId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Additive_AdditiveList");

                entity.HasOne(d => d.CalEntry)
                    .WithMany(p => p.Additive)
                    .HasForeignKey(d => d.CalEntryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Additive_Entry");
            });

            modelBuilder.Entity<AdditiveList>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChoOfKcal).HasColumnName("CHO % of kcal");

                entity.Property(e => e.KcalUnit)
                    .HasColumnName("Kcal/unit")
                    .HasColumnType("decimal");

                entity.Property(e => e.LipidOfKcal).HasColumnName("Lipid % of kcal");

                entity.Property(e => e.Manufacturer).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ProteinOfKcal).HasColumnName("Protein % of kcal");
            });

            modelBuilder.Entity<CalEntry>(entity =>
            {
                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.Hours).HasColumnType("decimal");

                entity.Property(e => e.Weight).HasColumnType("decimal");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.CalEntry)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_CalEntries_Subjects");
            });

            modelBuilder.Entity<DextroseConcentration>(entity =>
            {
                entity.Property(e => e.Concentration)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.KcalMl).HasColumnType("decimal");
            });

            modelBuilder.Entity<Enteral>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.CalEntry)
                    .WithMany(p => p.Enteral)
                    .HasForeignKey(d => d.CalEntryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Enteral_CalEntry");

                entity.HasOne(d => d.FormulaList)
                    .WithMany(p => p.Enteral)
                    .HasForeignKey(d => d.FormulaListId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Enteral_FormulaList");
            });

            modelBuilder.Entity<FluidInfusion>(entity =>
            {
                entity.HasOne(d => d.CalEntry)
                    .WithMany(p => p.FluidInfusion)
                    .HasForeignKey(d => d.CalEntryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FluidInfusions_CalEntries");

                entity.HasOne(d => d.DextroseConcentration)
                    .WithMany(p => p.FluidInfusion)
                    .HasForeignKey(d => d.DextroseConcentrationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FluidInfusions_DextroseConcentrations");
            });

            modelBuilder.Entity<FormulaList>(entity =>
            {
                entity.Property(e => e.Cho).HasColumnName("CHO");

                entity.Property(e => e.KcalML)
                    .HasColumnName("Kcal_mL")
                    .HasColumnType("decimal");

                entity.Property(e => e.KcalOz)
                    .HasColumnName("Kcal_oz")
                    .HasColumnType("decimal");

                entity.Property(e => e.Manufacturer).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Parenteral>(entity =>
            {
                entity.Property(e => e.Amino).HasColumnType("decimal");

                entity.Property(e => e.Dextrose).HasColumnType("decimal");

                entity.Property(e => e.Lipid).HasColumnType("decimal");

                entity.Property(e => e.Volume).HasColumnType("decimal");

                entity.HasOne(d => d.CalEntry)
                    .WithMany(p => p.Parenteral)
                    .HasForeignKey(d => d.CalEntryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Parenteral_CalEntry");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.Property(e => e.LongName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Subjects_Sites");
            });
        }
    }
}
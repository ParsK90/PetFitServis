using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PetServis.Models
{
    public partial class PetContext : DbContext
    {
        public PetContext()
        {
        }

        public PetContext(DbContextOptions<PetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PetAsi> PetAsi { get; set; }
        public virtual DbSet<PetAsiHareket> PetAsiHareket { get; set; }
        public virtual DbSet<PetBakim> PetBakim { get; set; }
        public virtual DbSet<PetBakimTur> PetBakimTur { get; set; }
        public virtual DbSet<PetHayvan> PetHayvan { get; set; }
        public virtual DbSet<PetHayvanCins> PetHayvanCins { get; set; }
        public virtual DbSet<PetHayvanCinsTur> PetHayvanCinsTur { get; set; }
        public virtual DbSet<PetMusteri> PetMusteri { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("SERVER=127.0.0.1;Database=Pet;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetAsi>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(256);

                entity.Property(e => e.EkAciklama).HasMaxLength(256);

                entity.Property(e => e.EklenmeTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<PetAsiHareket>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(256);

                entity.Property(e => e.EkAciklama).HasMaxLength(256);

                entity.Property(e => e.EklenmeTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Asi)
                    .WithMany(p => p.PetAsiHareket)
                    .HasForeignKey(d => d.AsiId)
                    .HasConstraintName("FK_PetAsiHareketWithAsiId");

                entity.HasOne(d => d.Hayvan)
                    .WithMany(p => p.PetAsiHareket)
                    .HasForeignKey(d => d.HayvanId)
                    .HasConstraintName("FK_PetAsiHareketWithHayvanId");
            });

            modelBuilder.Entity<PetBakim>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(256);

                entity.Property(e => e.EkAciklama).HasMaxLength(256);

                entity.Property(e => e.EklenmeTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.BakimTur)
                    .WithMany(p => p.PetBakim)
                    .HasForeignKey(d => d.BakimTurId)
                    .HasConstraintName("FK_PetBakimWithBakimTurId");

                entity.HasOne(d => d.Hayvan)
                    .WithMany(p => p.PetBakim)
                    .HasForeignKey(d => d.HayvanId)
                    .HasConstraintName("FK_PetBakimWithHayvanId");
            });

            modelBuilder.Entity<PetBakimTur>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(256);

                entity.Property(e => e.EkAciklama).HasMaxLength(256);

                entity.Property(e => e.EklenmeTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<PetHayvan>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(256);

                entity.Property(e => e.Chip)
                    .HasMaxLength(72)
                    .IsUnicode(false);

                entity.Property(e => e.Cinsiyet)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.DogumTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkAciklama).HasMaxLength(256);

                entity.Property(e => e.EklenmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Renk).HasMaxLength(64);

                entity.HasOne(d => d.HayvanCinsTur)
                    .WithMany(p => p.PetHayvan)
                    .HasForeignKey(d => d.HayvanCinsTurId)
                    .HasConstraintName("FK_PetHayvanWithHayvanCinsTurId");

                entity.HasOne(d => d.Sahip)
                    .WithMany(p => p.PetHayvan)
                    .HasForeignKey(d => d.SahipId)
                    .HasConstraintName("FK_PetHayvanWithSahipId");
            });

            modelBuilder.Entity<PetHayvanCins>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(256);

                entity.Property(e => e.EklenmeTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<PetHayvanCinsTur>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(256);

                entity.Property(e => e.EkAciklama).HasMaxLength(256);

                entity.Property(e => e.EklenmeTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.HayvanCins)
                    .WithMany(p => p.PetHayvanCinsTur)
                    .HasForeignKey(d => d.HayvanCinsId)
                    .HasConstraintName("FK_PetHayvanCinsTurWithHayvanCinsId");
            });

            modelBuilder.Entity<PetMusteri>(entity =>
            {
                entity.Property(e => e.Aciklama).HasMaxLength(256);

                entity.Property(e => e.Adres).HasMaxLength(512);

                entity.Property(e => e.EkAciklama).HasMaxLength(256);

                entity.Property(e => e.EklenmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Mail)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Sifre)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

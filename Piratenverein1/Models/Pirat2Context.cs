using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Piratenverein1.Models;

public partial class Pirat2Context : DbContext
{
    public Pirat2Context()
    {
    }

    public Pirat2Context(DbContextOptions<Pirat2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<EhemaligePirat> EhemaligePirats { get; set; }

    public virtual DbSet<KinderPirat> KinderPirats { get; set; }

    public virtual DbSet<NormalPirat> NormalPirats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Pirat2;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EhemaligePirat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_id_8");

            entity.ToTable("Ehemalige_Pirat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alt).HasColumnName("alt");
            entity.Property(e => e.Nachname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nachname");
            entity.Property(e => e.Vorname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vorname");
        });

        modelBuilder.Entity<KinderPirat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_id_7");

            entity.ToTable("Kinder_Pirat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alt).HasColumnName("alt");
            entity.Property(e => e.Nachname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nachname");
            entity.Property(e => e.Vorname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vorname");
        });

        modelBuilder.Entity<NormalPirat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_id_6");

            entity.ToTable("Normal_Pirat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alt).HasColumnName("alt");
            entity.Property(e => e.Nachname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nachname");
            entity.Property(e => e.Vorname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vorname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

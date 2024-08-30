using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Models;

public partial class InvoicesContext : DbContext
{
    public InvoicesContext()
    {
    }

    public InvoicesContext(DbContextOptions<InvoicesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BuildPlace> BuildPlaces { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Kit> Kits { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=127.0.0.1;Database=invoices;Username=postgres;Password=mclooter131;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuildPlace>(entity =>
        {
            entity.HasKey(e => e.BuildPlaceId).HasName("build_place_pk");

            entity.ToTable("build_place");

            entity.Property(e => e.BuildPlaceId).HasColumnName("build_place_id");
            entity.Property(e => e.KitId).HasColumnName("kit_id");
            entity.Property(e => e.PartId).HasColumnName("part_id");

            entity.HasOne(d => d.Kit).WithMany(p => p.BuildPlaces)
                .HasForeignKey(d => d.KitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("build_place_kit_fk");

            entity.HasOne(d => d.Part).WithMany(p => p.BuildPlaces)
                .HasForeignKey(d => d.PartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("build_place_part_fk");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("invoice_pk");

            entity.ToTable("invoice");

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.InvoiceFinishDate).HasColumnName("invoice_finish_date");
            entity.Property(e => e.InvoiceStatus)
                .HasMaxLength(20)
                .HasColumnName("invoice_status");
            entity.Property(e => e.KitCount).HasColumnName("kit_count");
            entity.Property(e => e.KitId).HasColumnName("kit_id");
            entity.Property(e => e.PartCount).HasColumnName("part_count");
            entity.Property(e => e.PartId).HasColumnName("part_id");

            entity.HasOne(d => d.Kit).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.KitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_kit_fk");

            entity.HasOne(d => d.Part).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_part_fk");
        });

        modelBuilder.Entity<Kit>(entity =>
        {
            entity.HasKey(e => e.KitId).HasName("kit_pk");

            entity.ToTable("kit");

            entity.Property(e => e.KitId).HasColumnName("kit_id");
            entity.Property(e => e.KitCount).HasColumnName("kit_count");
            entity.Property(e => e.KitFinishDate).HasColumnName("kit_finish_date");
            entity.Property(e => e.KitName)
                .HasMaxLength(20)
                .HasColumnName("kit_name");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.PartId).HasName("part_pk");

            entity.ToTable("part");

            entity.Property(e => e.PartId).HasColumnName("part_id");
            entity.Property(e => e.KitId).HasColumnName("kit_id");
            entity.Property(e => e.PartCount).HasColumnName("part_count");
            entity.Property(e => e.PartFinishDate).HasColumnName("part_finish_date");
            entity.Property(e => e.PartName)
                .HasMaxLength(20)
                .HasColumnName("part_name");

            entity.HasOne(d => d.Kit).WithMany(p => p.Parts)
                .HasForeignKey(d => d.KitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("part_kit_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

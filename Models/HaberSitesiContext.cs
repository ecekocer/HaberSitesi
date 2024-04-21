using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HaberSitesi.Models;

public partial class HaberSitesiContext : DbContext
{
    public HaberSitesiContext()
    {
    }

    public HaberSitesiContext(DbContextOptions<HaberSitesiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Haber> Habers { get; set; }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    public virtual DbSet<KullaniciTuru> KullaniciTurus { get; set; }

    public virtual DbSet<KullaniciTuruYetki> KullaniciTuruYetkis { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuTuru> MenuTurus { get; set; }

    public virtual DbSet<Yetki> Yetkis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=HaberSitesi;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Haber>(entity =>
        {
            entity.ToTable("Haber");

            entity.Property(e => e.HaberId).HasColumnName("HaberID");
            entity.Property(e => e.Baslik).IsUnicode(false);
            entity.Property(e => e.Gorsel)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.Metin).HasColumnType("text");
            entity.Property(e => e.Tarih).HasColumnType("datetime");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Habers)
                .HasForeignKey(d => d.KategoriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Haber_Kategori");
        });

        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.ToTable("Kategori");

            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.KategoriAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.ToTable("Kullanici");

            entity.Property(e => e.KullaniciId).HasColumnName("KullaniciID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
            entity.Property(e => e.KullaniciTuruId).HasColumnName("KullaniciTuruID");
            entity.Property(e => e.Parola)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.KullaniciTuru).WithMany(p => p.Kullanicis)
                .HasForeignKey(d => d.KullaniciTuruId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kullanici_KullaniciTuru");
        });

        modelBuilder.Entity<KullaniciTuru>(entity =>
        {
            entity.ToTable("KullaniciTuru");

            entity.Property(e => e.KullaniciTuruId).HasColumnName("KullaniciTuruID");
            entity.Property(e => e.KullaniciTuruAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<KullaniciTuruYetki>(entity =>
        {
            entity.ToTable("KullaniciTuruYetki");

            entity.Property(e => e.KullaniciTuruYetkiId).HasColumnName("KullaniciTuruYetkiID");
            entity.Property(e => e.KullaniciTuruId).HasColumnName("KullaniciTuruID");
            entity.Property(e => e.YetkiId).HasColumnName("YetkiID");

            entity.HasOne(d => d.KullaniciTuru).WithMany(p => p.KullaniciTuruYetkis)
                .HasForeignKey(d => d.KullaniciTuruId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KullaniciTuruYetki_KullaniciTuru");

            entity.HasOne(d => d.Yetki).WithMany(p => p.KullaniciTuruYetkis)
                .HasForeignKey(d => d.YetkiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KullaniciTuruYetki_Yetki");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.MenuId).HasColumnName("MenuID");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MenuAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MenuTuruId).HasColumnName("MenuTuruID");
            entity.Property(e => e.Url).IsUnicode(false);

            entity.HasOne(d => d.MenuTuru).WithMany(p => p.Menus)
                .HasForeignKey(d => d.MenuTuruId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_MenuTuru");
        });

        modelBuilder.Entity<MenuTuru>(entity =>
        {
            entity.ToTable("MenuTuru");

            entity.Property(e => e.MenuTuruId).HasColumnName("MenuTuruID");
            entity.Property(e => e.MenuTuruAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Yetki>(entity =>
        {
            entity.ToTable("Yetki");

            entity.Property(e => e.YetkiId).HasColumnName("YetkiID");
            entity.Property(e => e.YetkiAdi)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

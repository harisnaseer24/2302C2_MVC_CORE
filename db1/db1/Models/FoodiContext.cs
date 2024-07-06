using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace db1.Models;

public partial class FoodiContext : DbContext
{
    public FoodiContext()
    {
    }

    public FoodiContext(DbContextOptions<FoodiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chef> Chefs { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=.;initial catalog=foodi;user id=sa;password=aptech; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chef>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chefs__3214EC07F2EFB55E");

            entity.Property(e => e.Experience)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("experience");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Speciality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("speciality");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__menu__3214EC07A81ADDD2");

            entity.ToTable("menu");

            entity.Property(e => e.Descrp)
                .HasMaxLength(250)
                .HasColumnName("descrp");
            entity.Property(e => e.Namee)
                .HasMaxLength(250)
                .HasColumnName("namee");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

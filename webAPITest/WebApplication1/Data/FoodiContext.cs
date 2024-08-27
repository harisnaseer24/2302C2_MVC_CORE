using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public partial class FoodiContext : DbContext
{
    public FoodiContext()
    {
    }

    public FoodiContext(DbContextOptions<FoodiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Chef> Chefs { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Categori__17B6DD06356CF6C0");

            entity.Property(e => e.CatId).HasColumnName("catId");
            entity.Property(e => e.Catdesc)
                .HasMaxLength(50)
                .HasColumnName("catdesc");
            entity.Property(e => e.Catname)
                .HasMaxLength(50)
                .HasColumnName("catname");
        });

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

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Items__DD36D5624BD0468B");

            entity.Property(e => e.PId).HasColumnName("pId");
            entity.Property(e => e.CatId).HasColumnName("catId");
            entity.Property(e => e.Desc)
                .HasMaxLength(50)
                .HasColumnName("desc");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Pimage)
                .HasMaxLength(255)
                .HasColumnName("pimage");

            entity.HasOne(d => d.Cat).WithMany(p => p.Items)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK_Items_ToTable");
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

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product__3214EC0752002588");

            entity.ToTable("product");

            entity.Property(e => e.Catid).HasColumnName("catid");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(250)
                .HasColumnName("imagepath");
            entity.Property(e => e.Proname)
                .HasMaxLength(250)
                .HasColumnName("proname");
            entity.Property(e => e.Qty).HasColumnName("qty");

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.Catid)
                .HasConstraintName("FK_product_ToTable");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07829CD82B");

            entity.HasIndex(e => e.Email, "AK_Users_Column").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("((2))")
                .HasColumnName("roleId");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

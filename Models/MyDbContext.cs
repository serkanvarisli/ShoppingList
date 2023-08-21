using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShoppingList.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-R44CUI4\\MSSQLSERVER05;Database=ShoppingList;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Category");

            entity.Property(e => e.CategoryName).HasColumnType("text");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("List");

            entity.Property(e => e.ListName).HasColumnType("ntext");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Product");

            entity.Property(e => e.ProductBrand).HasColumnType("ntext");
            entity.Property(e => e.ProductDetail).HasColumnType("ntext");
            entity.Property(e => e.ProductImage).HasColumnType("image");
            entity.Property(e => e.ProductName).HasColumnType("ntext");
            entity.Property(e => e.ProductQuantity).HasColumnType("ntext");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User");

            entity.Property(e => e.Password).HasColumnType("ntext");
            entity.Property(e => e.UserEmail).HasColumnType("ntext");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName).HasColumnType("ntext");
            entity.Property(e => e.UserSurname).HasColumnType("ntext");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

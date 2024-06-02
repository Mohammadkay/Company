using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Domain.Models;

public partial class ZzV10Context : DbContext
{
    public ZzV10Context()
    {
    }

    public ZzV10Context(DbContextOptions<ZzV10Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<CpService> CpServices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<ServiceDetail> ServiceDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=Eska@123;database=zz_v1.0", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("attachments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AttachmentPath).HasColumnType("text");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CreationUser).HasMaxLength(100);
            entity.Property(e => e.ModificationDate).HasColumnType("datetime");
            entity.Property(e => e.ModificationUser).HasMaxLength(100);
        });

        modelBuilder.Entity<CpService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cp_services");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CreationUser).HasMaxLength(100);
            entity.Property(e => e.ModificationDate).HasColumnType("datetime");
            entity.Property(e => e.ModificationUser).HasMaxLength(100);
            entity.Property(e => e.ServiceName1).HasMaxLength(255);
            entity.Property(e => e.ServiceName2).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.ServiceId, "orders_ibfk_1");

            entity.HasIndex(e => e.UserId, "orders_ibfk_2");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CreationUser).HasMaxLength(100);
            entity.Property(e => e.ModificationDate).HasColumnType("datetime");
            entity.Property(e => e.ModificationUser).HasMaxLength(100);

            entity.HasOne(d => d.Service).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("orders_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("orders_ibfk_2");
        });

        modelBuilder.Entity<ServiceDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("service_details");

            entity.HasIndex(e => e.ServiceId, "service_details_ibfk_1");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CreationUser).HasMaxLength(100);
            entity.Property(e => e.Details1).HasMaxLength(5000);
            entity.Property(e => e.Details2).HasMaxLength(5000);
            entity.Property(e => e.ModificationDate).HasColumnType("datetime");
            entity.Property(e => e.ModificationUser).HasMaxLength(100);

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceDetails)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("service_details_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CreationUser).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.ModificationDate).HasColumnType("datetime");
            entity.Property(e => e.ModificationUser).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

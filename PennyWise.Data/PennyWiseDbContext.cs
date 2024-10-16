﻿using Microsoft.EntityFrameworkCore;
using PennyWise.Data.Models;

namespace PennyWise.Data
{
    public partial class PennyWiseDbContext : DbContext
    {
        public PennyWiseDbContext()
        {
        }

        public PennyWiseDbContext(DbContextOptions<PennyWiseDbContext> options) : base(options) { }

        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Wish> Wishes { get; set; }
        public virtual DbSet<Mobile> Mobiles { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>(entity =>
            {
                entity.ToTable("Expense");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.ExpenseTitle)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .IsRequired();

                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<Wish>(entity =>
            {
                entity.ToTable("Wish");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.WishName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql("GETDATE()");
            });

         
            modelBuilder.Entity<Mobile>(entity =>
            {
                entity.ToTable("Mobile");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.DateUpdated)
                    .HasDefaultValueSql("GETDATE()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

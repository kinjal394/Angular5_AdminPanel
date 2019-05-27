﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Admin_API.Models
{
    public partial class AdminAng5DBContext : DbContext
    {
        public AdminAng5DBContext()
        {
        }

        public AdminAng5DBContext(DbContextOptions<AdminAng5DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminLogins> AdminLogins { get; set; }
        public virtual DbSet<CountryMaster> CountryMaster { get; set; }
        public virtual DbSet<CurrencyMaster> CurrencyMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-BRR56Q3\\SQLEXPRESS1;Initial Catalog=AdminAng5DB;Persist Security Info=True;User ID=sa;Password=k8469882853");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminLogins>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mobileno).HasMaxLength(25);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CountryMaster>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CurrencyMaster>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(225)
                    .IsUnicode(false);
            });
        }
    }
}

﻿using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StolovkaWebAPI.Domain;

namespace StolovkaWebAPI.Data
{
    public partial class StolovkaDbContext : IdentityDbContext
    {
        public StolovkaDbContext(DbContextOptions<StolovkaDbContext> options)
            : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Canteen> Canteens { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Cashiers> Cashiers { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //to do
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=stolovka_db;Username=stolovka_supervisor;Password=stolovka123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Canteen>(entity =>
            //{
            //    entity.ToTable("canteens");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.Address)
            //        .IsRequired()
            //        .HasColumnName("address")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasColumnName("name")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.Worktime)
            //        .IsRequired()
            //        .HasColumnName("worktime")
            //        .HasMaxLength(30);
            //});

            //modelBuilder.Entity<Card>(entity =>
            //{
            //    entity.HasKey(e => e.CardNumberCrypted)
            //        .HasName("cards_pkey");

            //    entity.ToTable("cards");

            //    entity.Property(e => e.CardNumberCrypted)
            //        .HasColumnName("card_number_crypted")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.AddedAt).HasColumnName("added_at");

            //    entity.Property(e => e.RecognizeableName)
            //        .HasColumnName("recognizeable_name")
            //        .HasColumnType("character varying");
            //});

            //modelBuilder.Entity<Cashiers>(entity =>
            //{
            //    entity.ToTable("cashiers");

            //    entity.HasIndex(e => e.Login)
            //        .HasName("cashiers_login_key")
            //        .IsUnique();

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.CanteenId)
            //        .IsRequired()
            //        .HasColumnName("canteen_id")
            //        .HasColumnType("character varying");

            //    entity.Property(e => e.Login)
            //        .IsRequired()
            //        .HasColumnName("login")
            //        .HasMaxLength(65);

            //    entity.Property(e => e.PasswordCrypted)
            //        .IsRequired()
            //        .HasColumnName("password_crypted")
            //        .HasColumnType("character varying");

            //    entity.Property(e => e.Role)
            //        .IsRequired()
            //        .HasColumnName("role")
            //        .HasColumnType("character varying");

            //    entity.HasOne(d => d.Canteen)
            //        .WithMany(p => p.Cashiers)
            //        .HasForeignKey(d => d.CanteenId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("cashiers_canteen_id_fkey");
            //});

            //modelBuilder.Entity<Dish>(entity =>
            //{
            //    entity.HasKey(e => e.DishId)
            //        .HasName("dishes_pkey");

            //    entity.ToTable("dishes");

            //    entity.Property(e => e.DishId)
            //        .HasColumnName("dish_id")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.CanteenId)
            //        .IsRequired()
            //        .HasColumnName("canteen_id")
            //        .HasColumnType("character varying");

            //    entity.Property(e => e.DishName)
            //        .IsRequired()
            //        .HasColumnName("dish_name")
            //        .HasMaxLength(65);

            //    entity.Property(e => e.DishPrice)
            //        .HasColumnName("dish_price")
            //        .HasColumnType("numeric");

            //    entity.HasOne(d => d.Canteen)
            //        .WithMany(p => p.Dishes)
            //        .HasForeignKey(d => d.CanteenId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("dishes_canteen_id_fkey");
            //});

            //modelBuilder.Entity<Order>(entity =>
            //{
            //    entity.HasKey(e => e.OrderId)
            //        .HasName("orders_pkey");

            //    entity.ToTable("orders");

            //    entity.Property(e => e.OrderId)
            //        .HasColumnName("order_id")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.CanteenId)
            //        .IsRequired()
            //        .HasColumnName("canteen_id")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.CreatedAt).HasColumnName("created_at");

            //    entity.Property(e => e.Description)
            //        .IsRequired()
            //        .HasColumnName("description")
            //        .HasColumnType("character varying");

            //    entity.Property(e => e.ProcessedAt).HasColumnName("processed_at");

            //    entity.Property(e => e.Status)
            //        .IsRequired()
            //        .HasColumnName("status")
            //        .HasColumnType("character varying");

            //    entity.Property(e => e.UserId)
            //        .IsRequired()
            //        .HasColumnName("user_id")
            //        .HasMaxLength(255);

            //    entity.HasOne(d => d.Canteen)
            //        .WithMany(p => p.Orders)
            //        .HasForeignKey(d => d.CanteenId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("orders_canteen_id_fkey");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.Orders)
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("orders_user_id_fkey");
            //});

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("users");

            //    entity.HasIndex(e => e.Email)
            //        .HasName("users_email_key")
            //        .IsUnique();

            //    entity.HasIndex(e => e.Token)
            //        .HasName("users_token_key")
            //        .IsUnique();

            //    entity.Property(e => e.Id)
            //        .HasColumnName("id")
            //        .HasMaxLength(255);

            //    entity.Property(e => e.Cards)
            //        .HasColumnName("card")
            //        .HasColumnType("character varying");

            //    entity.Property(e => e.Email)
            //        .IsRequired()
            //        .HasColumnName("email")
            //        .HasColumnType("character varying");

            //    entity.Property(e => e.Firstname)
            //        .HasColumnName("firstname")
            //        .HasMaxLength(65);

            //    entity.Property(e => e.Lastname)
            //        .HasColumnName("lastname")
            //        .HasMaxLength(65);

            //    entity.Property(e => e.Token)
            //        .IsRequired()
            //        .HasColumnName("token")
            //        .HasColumnType("character varying");
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StolovkaWebAPI.Data;

namespace StolovkaWebAPI.Migrations
{
    [DbContext(typeof(StolovkaDbContext))]
    partial class StolovkaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("character varying(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.Canteen", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("address")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Worktime")
                        .IsRequired()
                        .HasColumnName("worktime")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("canteens");
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.Cards", b =>
                {
                    b.Property<string>("CardNumberCrypted")
                        .HasColumnName("card_number_crypted")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("AddedAt")
                        .HasColumnName("added_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RecognizeableName")
                        .HasColumnName("recognizeable_name")
                        .HasColumnType("character varying");

                    b.HasKey("CardNumberCrypted")
                        .HasName("cards_pkey");

                    b.ToTable("cards");
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.Cashiers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("CanteenId")
                        .IsRequired()
                        .HasColumnName("canteen_id")
                        .HasColumnType("character varying");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("login")
                        .HasColumnType("character varying(65)")
                        .HasMaxLength(65);

                    b.Property<string>("PasswordCrypted")
                        .IsRequired()
                        .HasColumnName("password_crypted")
                        .HasColumnType("character varying");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnName("role")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.HasIndex("CanteenId");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasName("cashiers_login_key");

                    b.ToTable("cashiers");
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.Dishes", b =>
                {
                    b.Property<string>("DishId")
                        .HasColumnName("dish_id")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("CanteenId")
                        .IsRequired()
                        .HasColumnName("canteen_id")
                        .HasColumnType("character varying");

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnName("dish_name")
                        .HasColumnType("character varying(65)")
                        .HasMaxLength(65);

                    b.Property<decimal>("DishPrice")
                        .HasColumnName("dish_price")
                        .HasColumnType("numeric");

                    b.HasKey("DishId")
                        .HasName("dishes_pkey");

                    b.HasIndex("CanteenId");

                    b.ToTable("dishes");
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.Orders", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("CanteenId")
                        .IsRequired()
                        .HasColumnName("canteen_id")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("character varying");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnName("processed_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("character varying");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_id")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("OrderId")
                        .HasName("orders_pkey");

                    b.HasIndex("CanteenId");

                    b.HasIndex("UserId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.RefreshToken", b =>
                {
                    b.Property<string>("Token")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Invalidated")
                        .HasColumnType("boolean");

                    b.Property<string>("JwtId")
                        .HasColumnType("text");

                    b.Property<bool>("Used")
                        .HasColumnType("boolean");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Token");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.Users", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnName("id")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Card")
                        .HasColumnName("card")
                        .HasColumnType("character varying");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("character varying");

                    b.Property<string>("Firstname")
                        .HasColumnName("firstname")
                        .HasColumnType("character varying(65)")
                        .HasMaxLength(65);

                    b.Property<string>("Lastname")
                        .HasColumnName("lastname")
                        .HasColumnType("character varying(65)")
                        .HasMaxLength(65);

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnName("token")
                        .HasColumnType("character varying");

                    b.HasKey("Id");

                    b.HasIndex("Card");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("users_email_key");

                    b.HasIndex("Token")
                        .IsUnique()
                        .HasName("users_token_key");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.Cashiers", b =>
                {
                    b.HasOne("StolovkaWebAPI.Domain.Canteen", "Canteen")
                        .WithMany("Cashiers")
                        .HasForeignKey("CanteenId")
                        .HasConstraintName("cashiers_canteen_id_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.Dishes", b =>
                {
                    b.HasOne("StolovkaWebAPI.Domain.Canteen", "Canteen")
                        .WithMany("Dishes")
                        .HasForeignKey("CanteenId")
                        .HasConstraintName("dishes_canteen_id_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.Orders", b =>
                {
                    b.HasOne("StolovkaWebAPI.Domain.Canteen", "Canteen")
                        .WithMany("Orders")
                        .HasForeignKey("CanteenId")
                        .HasConstraintName("orders_canteen_id_fkey")
                        .IsRequired();

                    b.HasOne("StolovkaWebAPI.Domain.Users", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("orders_user_id_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.RefreshToken", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("StolovkaWebAPI.Domain.Users", b =>
                {
                    b.HasOne("StolovkaWebAPI.Domain.Cards", "CardNavigation")
                        .WithMany("Users")
                        .HasForeignKey("Card")
                        .HasConstraintName("users_card_fkey");
                });
#pragma warning restore 612, 618
        }
    }
}

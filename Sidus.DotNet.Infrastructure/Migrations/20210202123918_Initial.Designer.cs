﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sidus.DotNet.Infrastructure.Data;

namespace Sidus.DotNet.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210202123918_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", "Identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("17c090b7-b095-4c64-b950-64782c5ec631"),
                            ConcurrencyStamp = "9ae91b21-e398-4b11-b59e-41a4a542214b",
                            CreatedAt = new DateTime(2021, 2, 2, 12, 39, 18, 72, DateTimeKind.Utc).AddTicks(9879),
                            CreatedById = new Guid("5a1d0cfb-efcc-47a4-9db8-5a80eb69aeec"),
                            LastModifiedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            Name = "admim",
                            State = 1
                        });
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.RoleClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim", "Identity");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("EntityType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NationalIdentificationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("TaxNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User", "Identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5a1d0cfb-efcc-47a4-9db8-5a80eb69aeec"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8c024880-b441-4ec7-b0ad-7d4fe39cef86",
                            CreatedAt = new DateTime(2021, 2, 2, 12, 39, 18, 74, DateTimeKind.Utc).AddTicks(4869),
                            CreatedById = new Guid("5a1d0cfb-efcc-47a4-9db8-5a80eb69aeec"),
                            EmailConfirmed = false,
                            EntityType = 0,
                            FirstName = "System",
                            LastModifiedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            LastName = "User",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            State = 1,
                            TwoFactorEnabled = false,
                            UserName = "systemuser"
                        });
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim", "Identity");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.UserLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", "Identity");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", "Identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa02bbb3-6553-11eb-99aa-038e69e2cfc4"),
                            CreatedAt = new DateTime(2021, 2, 2, 12, 39, 18, 74, DateTimeKind.Utc).AddTicks(8418),
                            CreatedById = new Guid("5a1d0cfb-efcc-47a4-9db8-5a80eb69aeec"),
                            LastModifiedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            RoleId = new Guid("17c090b7-b095-4c64-b950-64782c5ec631"),
                            State = 1,
                            UserId = new Guid("5a1d0cfb-efcc-47a4-9db8-5a80eb69aeec")
                        });
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.UserToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserToken", "Identity");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.System.Action", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HttpMethods")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReturnTypeAndSignature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RouteTemplate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Action", "System");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Test.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Test", "Test");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aa000ba5-6553-11eb-99aa-038e69e2cfc4"),
                            CreatedAt = new DateTime(2021, 2, 2, 12, 39, 17, 375, DateTimeKind.Utc).AddTicks(7162),
                            CreatedById = new Guid("5a1d0cfb-efcc-47a4-9db8-5a80eb69aeec"),
                            Key = "key1",
                            LastModifiedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            State = 1,
                            Value = "value1"
                        },
                        new
                        {
                            Id = new Guid("aa002ec6-6553-11eb-99aa-038e69e2cfc4"),
                            CreatedAt = new DateTime(2021, 2, 2, 12, 39, 17, 376, DateTimeKind.Utc).AddTicks(1775),
                            CreatedById = new Guid("5a1d0cfb-efcc-47a4-9db8-5a80eb69aeec"),
                            Key = "key2",
                            LastModifiedById = new Guid("00000000-0000-0000-0000-000000000000"),
                            State = 1,
                            Value = "value2"
                        });
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.RoleClaim", b =>
                {
                    b.HasOne("Sidus.DotNet.Core.Entities.Identity.Role", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.UserClaim", b =>
                {
                    b.HasOne("Sidus.DotNet.Core.Entities.Identity.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.UserLogin", b =>
                {
                    b.HasOne("Sidus.DotNet.Core.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.UserRole", b =>
                {
                    b.HasOne("Sidus.DotNet.Core.Entities.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sidus.DotNet.Core.Entities.Identity.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.UserToken", b =>
                {
                    b.HasOne("Sidus.DotNet.Core.Entities.Identity.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.System.Action", b =>
                {
                    b.HasOne("Sidus.DotNet.Core.Entities.System.Action", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.Role", b =>
                {
                    b.Navigation("RoleClaims");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.Identity.User", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("Roles");

                    b.Navigation("Tokens");
                });

            modelBuilder.Entity("Sidus.DotNet.Core.Entities.System.Action", b =>
                {
                    b.Navigation("Childs");
                });
#pragma warning restore 612, 618
        }
    }
}

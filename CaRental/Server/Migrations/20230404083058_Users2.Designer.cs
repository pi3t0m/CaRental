﻿// <auto-generated />
using System;
using CaRental.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaRental.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230404083058_Users2")]
    partial class Users2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CaRental.Shared.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Maybach",
                            CategoryId = 1,
                            DateCreated = new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "W223",
                            Featured = true,
                            Image = "https://www.premiumfelgi.pl/userdata/gfx/57200.jpg",
                            IsDeleted = false,
                            IsPublic = false,
                            Views = 0
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Mercedes",
                            CategoryId = 2,
                            DateCreated = new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "AMG GT 63 S E 4-door",
                            Featured = false,
                            Image = "https://motofilm.pl/wp-content/uploads/2022/02/Mercedes-AMG-GT-63-S-E-Performance-4-Drzwiowe-Coupe-1.jpg",
                            IsDeleted = false,
                            IsPublic = false,
                            Views = 0
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Mercedes",
                            CategoryId = 3,
                            DateCreated = new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "SL500",
                            Featured = true,
                            Image = "https://images8.alphacoders.com/114/1142237.jpg",
                            IsDeleted = false,
                            IsPublic = false,
                            Views = 0
                        });
                });

            modelBuilder.Entity("CaRental.Shared.CarVariant", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("EditionId")
                        .HasColumnType("int");

                    b.Property<decimal>("OrginalPrice")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal(18,2)");

                    b.HasKey("CarId", "EditionId");

                    b.HasIndex("EditionId");

                    b.ToTable("CarVariants");

                    b.HasData(
                        new
                        {
                            CarId = 1,
                            EditionId = 2,
                            OrginalPrice = 1000.00m,
                            Price = 900.00m
                        },
                        new
                        {
                            CarId = 1,
                            EditionId = 4,
                            OrginalPrice = 3000.00m,
                            Price = 2500.00m
                        },
                        new
                        {
                            CarId = 1,
                            EditionId = 6,
                            OrginalPrice = 5000.00m,
                            Price = 4000.00m
                        },
                        new
                        {
                            CarId = 2,
                            EditionId = 2,
                            OrginalPrice = 1000.00m,
                            Price = 900.00m
                        },
                        new
                        {
                            CarId = 2,
                            EditionId = 4,
                            OrginalPrice = 3000.00m,
                            Price = 2500.00m
                        },
                        new
                        {
                            CarId = 2,
                            EditionId = 6,
                            OrginalPrice = 5000.00m,
                            Price = 4000.00m
                        },
                        new
                        {
                            CarId = 3,
                            EditionId = 2,
                            OrginalPrice = 1000.00m,
                            Price = 900.00m
                        },
                        new
                        {
                            CarId = 3,
                            EditionId = 4,
                            OrginalPrice = 3000.00m,
                            Price = 2500.00m
                        },
                        new
                        {
                            CarId = 3,
                            EditionId = 6,
                            OrginalPrice = 5000.00m,
                            Price = 4000.00m
                        });
                });

            modelBuilder.Entity("CaRental.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "plus",
                            Name = "Exclusives",
                            Url = "exclusive"
                        },
                        new
                        {
                            Id = 2,
                            Icon = "plus",
                            Name = "Sports",
                            Url = "sport"
                        },
                        new
                        {
                            Id = 3,
                            Icon = "plus",
                            Name = "Oldschool",
                            Url = "oldschool"
                        });
                });

            modelBuilder.Entity("CaRental.Shared.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Editions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "1 day"
                        },
                        new
                        {
                            Id = 4,
                            Name = "3 day"
                        },
                        new
                        {
                            Id = 6,
                            Name = "5 day"
                        });
                });

            modelBuilder.Entity("CaRental.Shared.Stats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("LastVisit")
                        .HasColumnType("datetime2");

                    b.Property<int>("Visits")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("CaRental.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PaswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CaRental.Shared.Car", b =>
                {
                    b.HasOne("CaRental.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CaRental.Shared.CarVariant", b =>
                {
                    b.HasOne("CaRental.Shared.Car", "Car")
                        .WithMany("Variants")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaRental.Shared.Edition", "Edition")
                        .WithMany()
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Edition");
                });

            modelBuilder.Entity("CaRental.Shared.Car", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}

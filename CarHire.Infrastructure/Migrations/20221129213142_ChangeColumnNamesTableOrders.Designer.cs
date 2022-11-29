﻿// <auto-generated />
using System;
using CarHire.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarHire.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221129213142_ChangeColumnNamesTableOrders")]
    partial class ChangeColumnNamesTableOrders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Application user first name");

                    b.Property<string>("LastName")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Application user last name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasComment("Application user: extended AspNetCore IdentityUser");

                    b.HasData(
                        new
                        {
                            Id = "44569627-988b-4096-8397-48cae1a68157",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "55cc89da-4a6e-4940-a8be-3ea340d40213",
                            Email = "John@mail.com",
                            EmailConfirmed = false,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "JOHN@MAIL.COM",
                            NormalizedUserName = "JOHN@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEP7jBd6+HwTAwdTu9hrV9c0tucNQL6jNgzlndC9fneOFrpyzAwGzjS4k8ZgPsO75Hw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4eda3036-46f1-4b55-9263-90866f82307a",
                            TwoFactorEnabled = false,
                            UserName = "John@mail.com"
                        },
                        new
                        {
                            Id = "27fba6ae-8175-4484-9b0d-917d6b32c851",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3461cdb7-3308-4034-8cf4-5f47d9226adb",
                            Email = "Jane@mail.com",
                            EmailConfirmed = false,
                            FirstName = "Jane",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "JANE@MAIL.COM",
                            NormalizedUserName = "JANE@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKAQIU+RK6W0lWzQpB2zqM+tMc+77KtinUPv6+gsbzlTCB/D4nMfHlRwh/xDMtECpA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "114be0a0-bdcc-4d3c-b0d9-03d6eb2600b3",
                            TwoFactorEnabled = false,
                            UserName = "Jane@mail.com"
                        });
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Category name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("Vehicle category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Passenger"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Light comercial"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Heavy-Duty"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bus"
                        });
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Primary key");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time of comment");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Comment of renter for vehicle");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Allows entry showing");

                    b.Property<Guid>("RenterId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key for renter");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key for vehicle");

                    b.HasKey("Id");

                    b.HasIndex("RenterId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Comments");

                    b.HasComment("Comment for vehicle");
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Primary key");

                    b.Property<int>("DiscountSize")
                        .HasColumnType("int")
                        .HasComment("Size of discount");

                    b.Property<DateTime>("ExpireOn")
                        .HasColumnType("datetime2")
                        .HasComment("Expiration of discount");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of discount");

                    b.HasKey("Id");

                    b.ToTable("Discounts");

                    b.HasComment("Discounts for vehicles");
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Primary key");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasComment("End of order");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Allows entry showing");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasComment("Price before discount");

                    b.Property<Guid>("RenterId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key for renter");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasComment("Begining of order");

                    b.Property<int>("TotalDays")
                        .HasColumnType("int")
                        .HasComment("Order total days");

                    b.Property<decimal>("TotalPriceWithDiscounts")
                        .HasColumnType("money")
                        .HasComment("Price after all discounts on vehicle and renter");

                    b.Property<int>("VehicleDiscount")
                        .HasColumnType("int")
                        .HasComment("All discounts of vehicle");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key for vehicle");

                    b.HasKey("Id");

                    b.HasIndex("RenterId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Orders");

                    b.HasComment("Customer orders");
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Renter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Primary key");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Foreign key to ApplicationUser table");

                    b.Property<string>("DrivingLicenseNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Driving license number of renter");

                    b.Property<DateTime>("RegisteredOn")
                        .HasColumnType("datetime2")
                        .HasComment("When became a renter");

                    b.Property<int>("RenterDiscount")
                        .HasColumnType("int")
                        .HasComment("Discount of renter");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("money")
                        .HasComment("Value of all orders of renter");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Renters");

                    b.HasComment("Application renter");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                            ApplicationUserId = "27fba6ae-8175-4484-9b0d-917d6b32c851",
                            DrivingLicenseNumber = "Jane888888Doe",
                            RegisteredOn = new DateTime(2022, 11, 29, 23, 31, 40, 454, DateTimeKind.Local).AddTicks(4957),
                            RenterDiscount = 15,
                            TotalValue = 0m
                        });
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Primary key");

                    b.Property<bool>("AirConditioning")
                        .HasColumnType("bit")
                        .HasComment("Availability of air conditioning");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Foreign key");

                    b.Property<double?>("Consumption")
                        .HasColumnType("float")
                        .HasComment("Vehicle consumption");

                    b.Property<int>("Doors")
                        .HasColumnType("int")
                        .HasComment("Number of doors");

                    b.Property<int>("Fuel")
                        .HasColumnType("int")
                        .HasComment("Vehicle fuel type");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)")
                        .HasComment("Vehicle image");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Allows entry showing");

                    b.Property<bool>("IsRented")
                        .HasColumnType("bit")
                        .HasComment("Indicates whether the vehicle is rented");

                    b.Property<int>("Kilometers")
                        .HasColumnType("int")
                        .HasComment("Vehicle kilometers");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Vehicle Make");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Vehicle Model");

                    b.Property<bool>("NavigationSystem")
                        .HasColumnType("bit")
                        .HasComment("Availability of navigation system");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("money")
                        .HasComment("Vehicle price for 1 day");

                    b.Property<int>("Seats")
                        .HasColumnType("int")
                        .HasComment("Number of seats");

                    b.Property<int>("Suspension")
                        .HasColumnType("int")
                        .HasComment("Type of suspension");

                    b.Property<int?>("TankCapacity")
                        .HasColumnType("int")
                        .HasComment("Vehicle tank capacity");

                    b.Property<int>("Transmission")
                        .HasColumnType("int")
                        .HasComment("Type of transmission");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasComment("Year of manufacture");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Vehicles");

                    b.HasComment("Vehicle for rent");

                    b.HasData(
                        new
                        {
                            Id = new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"),
                            AirConditioning = true,
                            CategoryId = 1,
                            Consumption = 20.0,
                            Doors = 2,
                            Fuel = 2,
                            ImageUrl = "https://mir-s3-cdn-cf.behance.net/project_modules/1400/9a84ff95800693.5e9ff770404b5.jpg",
                            IsDeleted = false,
                            IsRented = false,
                            Kilometers = 10000,
                            Make = "Koenigsegg",
                            Model = "RAW",
                            NavigationSystem = true,
                            PricePerDay = 250m,
                            Seats = 2,
                            Suspension = 1,
                            TankCapacity = 80,
                            Transmission = 1,
                            Year = 2018
                        },
                        new
                        {
                            Id = new Guid("f31db974-2830-410d-b435-66844298846a"),
                            AirConditioning = true,
                            CategoryId = 1,
                            Consumption = 25.0,
                            Doors = 2,
                            Fuel = 2,
                            ImageUrl = "https://s1.cdn.autoevolution.com/images/news/gallery/chevrolet-chevelle-ss-black-panther-looks-wide-and-then-some_3.jpg",
                            IsDeleted = false,
                            IsRented = false,
                            Kilometers = 30000,
                            Make = "Chevrolet",
                            Model = "Chevelle SS black panther",
                            NavigationSystem = true,
                            PricePerDay = 250m,
                            Seats = 4,
                            Suspension = 3,
                            TankCapacity = 100,
                            Transmission = 1,
                            Year = 2014
                        },
                        new
                        {
                            Id = new Guid("82ea3f6a-4782-41d0-bc2d-6ca2f7f9acea"),
                            AirConditioning = true,
                            CategoryId = 2,
                            Consumption = 4.2999999999999998,
                            Doors = 5,
                            Fuel = 4,
                            ImageUrl = "http://3.bp.blogspot.com/-Tq37hVW0jJE/TlTJo5Q9q8I/AAAAAAAAANE/-I5-G8zgZ2w/s1600/Nissan-NV200-Concept-for-professional-photographers-1.jpg",
                            IsDeleted = false,
                            IsRented = false,
                            Kilometers = 60000,
                            Make = "Nissan",
                            Model = "NV200",
                            NavigationSystem = true,
                            PricePerDay = 25m,
                            Seats = 7,
                            Suspension = 3,
                            TankCapacity = 40,
                            Transmission = 1,
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("e0dec8e7-92c7-441e-ad75-55f8234fad59"),
                            AirConditioning = true,
                            CategoryId = 3,
                            Consumption = 30.0,
                            Doors = 2,
                            Fuel = 1,
                            ImageUrl = "https://1.bp.blogspot.com/-rL5k8U1xzKY/VRGEpRQnY4I/AAAAAAAABmE/U66r0OBX5hw/s1600/MB%2BNew%2BActros%2B2014%2BExterior.jpg",
                            IsDeleted = false,
                            IsRented = false,
                            Kilometers = 500000,
                            Make = "Mercedes-Benz",
                            Model = "Actros",
                            NavigationSystem = true,
                            PricePerDay = 150m,
                            Seats = 3,
                            Suspension = 3,
                            TankCapacity = 1000,
                            Transmission = 1,
                            Year = 2015
                        },
                        new
                        {
                            Id = new Guid("b544d7b1-7f17-4213-9823-90e82c66db2e"),
                            AirConditioning = true,
                            CategoryId = 4,
                            Consumption = 20.0,
                            Doors = 3,
                            Fuel = 1,
                            ImageUrl = "https://www.dekalblimo.com/assets/images/mini-charter-bus-825x550.jpg",
                            IsDeleted = false,
                            IsRented = false,
                            Kilometers = 200000,
                            Make = "Ford",
                            Model = "F550 Executive Limo Bus",
                            NavigationSystem = true,
                            PricePerDay = 150m,
                            Seats = 36,
                            Suspension = 3,
                            TankCapacity = 500,
                            Transmission = 1,
                            Year = 2020
                        });
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.VehicleDiscount", b =>
                {
                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key");

                    b.Property<Guid>("DiscountId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign key");

                    b.HasKey("VehicleId", "DiscountId");

                    b.HasIndex("DiscountId");

                    b.ToTable("VehiclesDiscounts");

                    b.HasComment("Mapping table between discount and vehicle");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "5208a8e1-ff35-4845-9cb3-cc19d1434c11",
                            ConcurrencyStamp = "84a67d5b-2f05-487e-9789-9b20768c1549",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "first_name",
                            ClaimValue = "John",
                            UserId = "44569627-988b-4096-8397-48cae1a68157"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "first_name",
                            ClaimValue = "Jane",
                            UserId = "27fba6ae-8175-4484-9b0d-917d6b32c851"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "44569627-988b-4096-8397-48cae1a68157",
                            RoleId = "5208a8e1-ff35-4845-9cb3-cc19d1434c11"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Comment", b =>
                {
                    b.HasOne("CarHire.Infrastructure.Data.Entities.Renter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarHire.Infrastructure.Data.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Renter");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Order", b =>
                {
                    b.HasOne("CarHire.Infrastructure.Data.Entities.Renter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarHire.Infrastructure.Data.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Renter");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Renter", b =>
                {
                    b.HasOne("CarHire.Infrastructure.Data.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Vehicle", b =>
                {
                    b.HasOne("CarHire.Infrastructure.Data.Entities.Category", "Category")
                        .WithMany("Vehicles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.VehicleDiscount", b =>
                {
                    b.HasOne("CarHire.Infrastructure.Data.Entities.Discount", "Discount")
                        .WithMany("VehicleDiscounts")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarHire.Infrastructure.Data.Entities.Vehicle", "Vehicle")
                        .WithMany("VehicleDiscounts")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("Vehicle");
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
                    b.HasOne("CarHire.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CarHire.Infrastructure.Data.Entities.ApplicationUser", null)
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

                    b.HasOne("CarHire.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CarHire.Infrastructure.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Category", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Discount", b =>
                {
                    b.Navigation("VehicleDiscounts");
                });

            modelBuilder.Entity("CarHire.Infrastructure.Data.Entities.Vehicle", b =>
                {
                    b.Navigation("VehicleDiscounts");
                });
#pragma warning restore 612, 618
        }
    }
}

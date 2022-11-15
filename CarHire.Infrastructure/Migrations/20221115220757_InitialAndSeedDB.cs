using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHire.Infrastructure.Migrations
{
    public partial class InitialAndSeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Application user first name"),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true, comment: "Application user last name"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                },
                comment: "Application user: extended AspNetCore IdentityUser");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Vehicle category");

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key"),
                    DiscountSize = table.Column<int>(type: "int", nullable: false, comment: "Size of discount"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of discount"),
                    ExpireOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Expiration of discount")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                },
                comment: "Discounts for vehicles");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key to ApplicationUser table"),
                    RenterDiscount = table.Column<int>(type: "int", nullable: false, comment: "Discount of renter"),
                    TotalValue = table.Column<decimal>(type: "money", nullable: false, comment: "Value of all orders of renter"),
                    DrivingLicenseNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Driving license number of renter"),
                    RegisteredOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "When became a renter")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renters_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Application renter");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key"),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Vehicle Make"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Vehicle Model"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Allows entry showing"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Year of manufacture"),
                    Transmission = table.Column<int>(type: "int", nullable: false, comment: "Type of transmission"),
                    AirConditioning = table.Column<bool>(type: "bit", nullable: false, comment: "Availability of air conditioning"),
                    Seats = table.Column<int>(type: "int", nullable: false, comment: "Number of seats"),
                    Doors = table.Column<int>(type: "int", nullable: false, comment: "Number of doors"),
                    Suspension = table.Column<int>(type: "int", nullable: false, comment: "Type of suspension"),
                    NavigationSystem = table.Column<bool>(type: "bit", nullable: false, comment: "Availability of navigation system"),
                    TankCapacity = table.Column<int>(type: "int", nullable: true, comment: "Vehicle tank capacity"),
                    Consumption = table.Column<double>(type: "float", nullable: true, comment: "Vehicle consumption"),
                    Fuel = table.Column<int>(type: "int", nullable: false, comment: "Vehicle fuel type"),
                    Kilometers = table.Column<int>(type: "int", nullable: false, comment: "Vehicle kilometers"),
                    PricePerDay = table.Column<decimal>(type: "money", nullable: false, comment: "Vehicle price for 1 day"),
                    ImageUrl = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Vehicle image"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key"),
                    RenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "Id");
                },
                comment: "Vehicle for rent");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key"),
                    RenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for renter"),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for vehicle"),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false, comment: "Comment of renter for vehicle"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Allows entry showing"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time of comment")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Comment for vehicle");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Primary key"),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for vehicle"),
                    RenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key for renter"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Allows entry showing"),
                    TotalDays = table.Column<int>(type: "int", nullable: false, comment: "Order total days"),
                    Price = table.Column<decimal>(type: "money", nullable: false, comment: "Price before discount"),
                    Discount = table.Column<int>(type: "int", nullable: false, comment: "All discounts of renter and vehicle"),
                    TotalPriceWithDiscount = table.Column<decimal>(type: "money", nullable: false, comment: "Price after all discounts"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Begining of order"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "End of order")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Customer orders");

            migrationBuilder.CreateTable(
                name: "VehiclesDiscounts",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key"),
                    DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesDiscounts", x => new { x.VehicleId, x.DiscountId });
                    table.ForeignKey(
                        name: "FK_VehiclesDiscounts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclesDiscounts_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Mapping table between discount and vehicle");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "27fba6ae-8175-4484-9b0d-917d6b32c851", 0, "c3558b31-3de8-40a1-b73a-7fe27b8abe66", "Jane@mail.com", false, "Jane", "Doe", false, null, "JANE@MAIL.COM", "JANE@MAIL.COM", "AQAAAAEAACcQAAAAEDU9Ua9rz40kf0RV9qjQK28LYmxXEyytbLDQrKNbWnJyrkxnfAqoPUuu+UY/HII1yA==", null, false, "712a0c05-59c6-4b3c-8485-01120aa5eadd", false, "Jane@mail.com" },
                    { "44569627-988b-4096-8397-48cae1a68157", 0, "11b5ac88-53f0-4c51-b1a0-13a8792654a7", "John@mail.com", false, "John", "Doe", false, null, "JOHN@MAIL.COM", "JOHN@MAIL.COM", "AQAAAAEAACcQAAAAEOZslJVnENtEF2hUXgFQ5Z1G+lB70JezqsrdVoVqpKqkymoLSspfj3wf7B40kkHolg==", null, false, "9fd64b60-ef7e-4d9c-ae7d-047da9e8b968", false, "John@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Passenger" },
                    { 2, "Light comercial" },
                    { 3, "Heavy-Duty" },
                    { 4, "Bus" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "first_name", "John", "44569627-988b-4096-8397-48cae1a68157" },
                    { 2, "first_name", "Jane", "27fba6ae-8175-4484-9b0d-917d6b32c851" }
                });

            migrationBuilder.InsertData(
                table: "Renters",
                columns: new[] { "Id", "ApplicationUserId", "DrivingLicenseNumber", "RegisteredOn", "RenterDiscount", "TotalValue" },
                values: new object[] { new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"), "27fba6ae-8175-4484-9b0d-917d6b32c851", "Jane888888Doe", new DateTime(2022, 11, 16, 0, 7, 57, 142, DateTimeKind.Local).AddTicks(8131), 15, 0m });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AirConditioning", "CategoryId", "Consumption", "Doors", "Fuel", "ImageUrl", "IsDeleted", "Kilometers", "Make", "Model", "NavigationSystem", "PricePerDay", "RenterId", "Seats", "Suspension", "TankCapacity", "Transmission", "Year" },
                values: new object[,]
                {
                    { new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"), true, 1, 20.0, 2, 2, "https://mir-s3-cdn-cf.behance.net/project_modules/1400/9a84ff95800693.5e9ff770404b5.jpg", false, 10000, "Koenigsegg", "RAW", true, 250m, null, 2, 1, 80, 1, 2018 },
                    { new Guid("82ea3f6a-4782-41d0-bc2d-6ca2f7f9acea"), true, 2, 4.2999999999999998, 5, 4, "http://3.bp.blogspot.com/-Tq37hVW0jJE/TlTJo5Q9q8I/AAAAAAAAANE/-I5-G8zgZ2w/s1600/Nissan-NV200-Concept-for-professional-photographers-1.jpg", false, 60000, "Nissan", "NV200", true, 25m, null, 7, 3, 40, 1, 2020 },
                    { new Guid("b544d7b1-7f17-4213-9823-90e82c66db2e"), true, 4, 20.0, 3, 1, "https://www.dekalblimo.com/assets/images/mini-charter-bus-825x550.jpg", false, 200000, "Ford", "F550 Executive Limo Bus", true, 150m, null, 36, 3, 500, 1, 2020 },
                    { new Guid("e0dec8e7-92c7-441e-ad75-55f8234fad59"), true, 3, 30.0, 2, 1, "https://1.bp.blogspot.com/-rL5k8U1xzKY/VRGEpRQnY4I/AAAAAAAABmE/U66r0OBX5hw/s1600/MB%2BNew%2BActros%2B2014%2BExterior.jpg", false, 500000, "Mercedes-Benz", "Actros", true, 150m, null, 3, 3, 1000, 1, 2015 },
                    { new Guid("f31db974-2830-410d-b435-66844298846a"), true, 1, 25.0, 2, 2, "https://s1.cdn.autoevolution.com/images/news/gallery/chevrolet-chevelle-ss-black-panther-looks-wide-and-then-some_3.jpg", false, 30000, "Chevrolet", "Chevelle SS black panther", true, 250m, null, 4, 3, 100, 1, 2014 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RenterId",
                table: "Comments",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VehicleId",
                table: "Comments",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RenterId",
                table: "Orders",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleId",
                table: "Orders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Renters_ApplicationUserId",
                table: "Renters",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RenterId",
                table: "Vehicles",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesDiscounts_DiscountId",
                table: "VehiclesDiscounts",
                column: "DiscountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "VehiclesDiscounts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Renters");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

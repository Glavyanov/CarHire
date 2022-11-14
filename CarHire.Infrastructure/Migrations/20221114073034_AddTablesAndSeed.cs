using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHire.Infrastructure.Migrations
{
    public partial class AddTablesAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Categories_CategoryId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_CategoryId",
                table: "Vehicles",
                newName: "IX_Vehicles_CategoryId");

            migrationBuilder.AlterTable(
                name: "Vehicles",
                comment: "Vehicle for rent",
                oldComment: "Car for rent");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Foreign key",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AirConditioning",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Availability of air conditioning");

            migrationBuilder.AddColumn<double>(
                name: "Consumption",
                table: "Vehicles",
                type: "float",
                nullable: true,
                comment: "Vehicle consumption");

            migrationBuilder.AddColumn<int>(
                name: "Doors",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Number of doors");

            migrationBuilder.AddColumn<int>(
                name: "Fuel",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Vehicle fuel type");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Vehicles",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                defaultValue: "",
                comment: "Vehicle image");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Allows entry showing");

            migrationBuilder.AddColumn<int>(
                name: "Kilometers",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Vehicle kilometers");

            migrationBuilder.AddColumn<bool>(
                name: "NavigationSystem",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Availability of navigation system");

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerDay",
                table: "Vehicles",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                comment: "Vehicle price for 1 day");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Number of seats");

            migrationBuilder.AddColumn<int>(
                name: "Suspension",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Type of suspension");

            migrationBuilder.AddColumn<int>(
                name: "TankCapacity",
                table: "Vehicles",
                type: "int",
                nullable: true,
                comment: "Vehicle tank capacity");

            migrationBuilder.AddColumn<int>(
                name: "Transmission",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Type of transmission");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Year of manufacture");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "27fba6ae-8175-4484-9b0d-917d6b32c851", 0, "7a3138d1-e01d-4c81-89a4-963f56fa40d2", "Jane@mail.com", false, "Jane", "Doe", false, null, "JANE@MAIL.COM", "JANE@MAIL.COM", "AQAAAAEAACcQAAAAENmm7YdWf+cw8ot/Ovhy7UhqJsJj0eMr1GCsklKjBFKH8MUmQ0i8Ny2SN69TX9jVyg==", null, false, "bd41059d-1ae4-4cb7-a12d-69e9f4f783ab", false, "Jane@mail.com" },
                    { "44569627-988b-4096-8397-48cae1a68157", 0, "9649c0ba-538b-4c24-a742-87b2a1ae0426", "John@mail.com", false, "John", "Doe", false, null, "JOHN@MAIL.COM", "JOHN@MAIL.COM", "AQAAAAEAACcQAAAAEEi73CH2Z5DyO8xReWIzdnkfLQ1uLdBm4laGzp4KmghP6k1n8FwGDN0tZv24/vTa8w==", null, false, "10ac6558-2dae-49f8-aa04-f46130106f77", false, "John@mail.com" }
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
                table: "Renters",
                columns: new[] { "Id", "ApplicationUserId", "DrivingLicenseNumber", "RegisteredOn", "RenterDiscount", "TotalValue" },
                values: new object[] { new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"), "27fba6ae-8175-4484-9b0d-917d6b32c851", "Jane888888Doe", new DateTime(2022, 11, 14, 9, 30, 33, 98, DateTimeKind.Local).AddTicks(2043), 15, 0m });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AirConditioning", "CategoryId", "Consumption", "Doors", "Fuel", "ImageUrl", "IsDeleted", "Kilometers", "NavigationSystem", "PricePerDay", "Seats", "Suspension", "TankCapacity", "Transmission", "Year" },
                values: new object[,]
                {
                    { new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"), true, 1, 20.0, 2, 2, "https://www.autocar.co.uk/sites/autocar.co.uk/files/styles/gallery_slide/public/images/car-reviews/first-drives/legacy/2_3.gif?itok=dyWvAKCx", false, 10000, true, 250m, 2, 1, 80, 1, 2018 },
                    { new Guid("82ea3f6a-4782-41d0-bc2d-6ca2f7f9acea"), true, 2, 4.2999999999999998, 5, 4, "http://3.bp.blogspot.com/-Tq37hVW0jJE/TlTJo5Q9q8I/AAAAAAAAANE/-I5-G8zgZ2w/s1600/Nissan-NV200-Concept-for-professional-photographers-1.jpg", false, 60000, true, 25m, 7, 3, 40, 1, 2020 },
                    { new Guid("b544d7b1-7f17-4213-9823-90e82c66db2e"), true, 4, 20.0, 3, 1, "https://www.dekalblimo.com/assets/images/mini-charter-bus-825x550.jpg", false, 200000, true, 150m, 36, 3, 500, 1, 2020 },
                    { new Guid("e0dec8e7-92c7-441e-ad75-55f8234fad59"), true, 3, 30.0, 2, 1, "https://1.bp.blogspot.com/-rL5k8U1xzKY/VRGEpRQnY4I/AAAAAAAABmE/U66r0OBX5hw/s1600/MB%2BNew%2BActros%2B2014%2BExterior.jpg", false, 500000, true, 150m, 3, 3, 1000, 1, 2015 },
                    { new Guid("f31db974-2830-410d-b435-66844298846a"), true, 1, 25.0, 2, 2, "https://s1.cdn.autoevolution.com/images/news/gallery/chevrolet-chevelle-ss-black-panther-looks-wide-and-then-some_3.jpg", false, 30000, true, 250m, 4, 3, 100, 1, 2014 }
                });

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
                name: "IX_VehiclesDiscounts_DiscountId",
                table: "VehiclesDiscounts",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Categories_CategoryId",
                table: "Vehicles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Categories_CategoryId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "VehiclesDiscounts");

            migrationBuilder.DropTable(
                name: "Renters");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44569627-988b-4096-8397-48cae1a68157");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("779bd522-2646-40b0-90a9-af4ddb9551a5"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("82ea3f6a-4782-41d0-bc2d-6ca2f7f9acea"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("b544d7b1-7f17-4213-9823-90e82c66db2e"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("e0dec8e7-92c7-441e-ad75-55f8234fad59"));

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: new Guid("f31db974-2830-410d-b435-66844298846a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27fba6ae-8175-4484-9b0d-917d6b32c851");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "AirConditioning",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Consumption",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Doors",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Fuel",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Kilometers",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "NavigationSystem",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Suspension",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TankCapacity",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicle",
                newName: "IX_Vehicle_CategoryId");

            migrationBuilder.AlterTable(
                name: "Vehicle",
                comment: "Car for rent",
                oldComment: "Vehicle for rent");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Categories_CategoryId",
                table: "Vehicle",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}

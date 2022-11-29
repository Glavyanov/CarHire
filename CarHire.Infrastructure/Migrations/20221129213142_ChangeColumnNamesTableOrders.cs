using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHire.Infrastructure.Migrations
{
    public partial class ChangeColumnNamesTableOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPriceWithDiscount",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceWithDiscounts",
                table: "Orders",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                comment: "Price after all discounts on vehicle and renter");

            migrationBuilder.AddColumn<int>(
                name: "VehicleDiscount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "All discounts of vehicle");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5208a8e1-ff35-4845-9cb3-cc19d1434c11",
                column: "ConcurrencyStamp",
                value: "84a67d5b-2f05-487e-9789-9b20768c1549");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27fba6ae-8175-4484-9b0d-917d6b32c851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3461cdb7-3308-4034-8cf4-5f47d9226adb", "AQAAAAEAACcQAAAAEKAQIU+RK6W0lWzQpB2zqM+tMc+77KtinUPv6+gsbzlTCB/D4nMfHlRwh/xDMtECpA==", "114be0a0-bdcc-4d3c-b0d9-03d6eb2600b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44569627-988b-4096-8397-48cae1a68157",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55cc89da-4a6e-4940-a8be-3ea340d40213", "AQAAAAEAACcQAAAAEP7jBd6+HwTAwdTu9hrV9c0tucNQL6jNgzlndC9fneOFrpyzAwGzjS4k8ZgPsO75Hw==", "4eda3036-46f1-4b55-9263-90866f82307a" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                column: "RegisteredOn",
                value: new DateTime(2022, 11, 29, 23, 31, 40, 454, DateTimeKind.Local).AddTicks(4957));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPriceWithDiscounts",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "VehicleDiscount",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "All discounts of renter and vehicle");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceWithDiscount",
                table: "Orders",
                type: "money",
                nullable: false,
                defaultValue: 0m,
                comment: "Price after all discounts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5208a8e1-ff35-4845-9cb3-cc19d1434c11",
                column: "ConcurrencyStamp",
                value: "7142333b-5aad-4c95-97f6-ff88a0a4c629");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27fba6ae-8175-4484-9b0d-917d6b32c851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "327b074a-79a8-4b26-ac5e-418af415d137", "AQAAAAEAACcQAAAAEMLhnLz8GOe0qZSv9O/XcRl/ea25vf/qvvUv/tXJHtwFSQNqRNTNIXWtumJA0yuI7g==", "33701622-cc50-4bb3-8b86-d1df691cfe85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44569627-988b-4096-8397-48cae1a68157",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb2d6fa9-ee6c-4bd3-aff8-1ba90a17a8f8", "AQAAAAEAACcQAAAAEJJZMtNXjuaCJ9fbd7vSIOtLJvwgEDVPgVz70SjphIHoKsA59XF1CJOQ9SaCfvsPJQ==", "090ed153-08a6-4cc6-ac1b-3baeb37ec1ef" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                column: "RegisteredOn",
                value: new DateTime(2022, 11, 28, 21, 9, 29, 154, DateTimeKind.Local).AddTicks(5690));
        }
    }
}

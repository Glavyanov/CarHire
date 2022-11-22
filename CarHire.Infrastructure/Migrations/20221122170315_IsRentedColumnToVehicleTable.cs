using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHire.Infrastructure.Migrations
{
    public partial class IsRentedColumnToVehicleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Indicates whether the vehicle is rented");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5208a8e1-ff35-4845-9cb3-cc19d1434c11",
                column: "ConcurrencyStamp",
                value: "7a865cbc-6b52-41fc-8300-41c35b9a16c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27fba6ae-8175-4484-9b0d-917d6b32c851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77016208-e3cd-4fd7-8b4c-7f7b594a3719", "AQAAAAEAACcQAAAAEGRrp18+b6TNMiNgaUpGKlBpcnUEcox8j8ygRVDiQe9IjuFmXdyWEskNUG/QZoiEAg==", "b920a0d2-41f8-428a-8670-12ba8ceeb647" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44569627-988b-4096-8397-48cae1a68157",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2780dbee-fcdd-4769-a590-e985ef70361c", "AQAAAAEAACcQAAAAEDEC8vGnxS9vwxv/IydrYjU+Psb62kVIP67Wxmy9LsnmXHVBByuSvQOMqA5TidgcoA==", "5e2d0c72-a339-473c-bcdd-45b2ed2ec9c0" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                column: "RegisteredOn",
                value: new DateTime(2022, 11, 22, 19, 3, 14, 43, DateTimeKind.Local).AddTicks(6148));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "Vehicles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5208a8e1-ff35-4845-9cb3-cc19d1434c11",
                column: "ConcurrencyStamp",
                value: "3d7dc650-8edc-43b7-9397-b2fa725ba5ee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27fba6ae-8175-4484-9b0d-917d6b32c851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19562108-3aef-462d-9d38-3ea89ba391a8", "AQAAAAEAACcQAAAAEPnNm0ob67YuwiQuOcLe5MUudQZ+m7eNetBX0Kq4+mpp5gK35hUuG3xuY/FI+j6aeQ==", "63a25e38-8368-455e-b830-210669f79cdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44569627-988b-4096-8397-48cae1a68157",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00cdf4d7-d2c7-45a9-99fa-723f01fb1e53", "AQAAAAEAACcQAAAAEJaxH8p5kcjBLBAnimSaEDAAl//MWYyNCVrLaz3QmghUCHmLX5Ax1hb2u+08HK0qug==", "30e81fe7-954e-412f-999d-96ccac9215d3" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                column: "RegisteredOn",
                value: new DateTime(2022, 11, 17, 23, 22, 37, 603, DateTimeKind.Local).AddTicks(8914));
        }
    }
}

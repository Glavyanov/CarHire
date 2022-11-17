using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHire.Infrastructure.Migrations
{
    public partial class SeedUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5208a8e1-ff35-4845-9cb3-cc19d1434c11", "3d7dc650-8edc-43b7-9397-b2fa725ba5ee", "Admin", "ADMIN" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5208a8e1-ff35-4845-9cb3-cc19d1434c11", "44569627-988b-4096-8397-48cae1a68157" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5208a8e1-ff35-4845-9cb3-cc19d1434c11", "44569627-988b-4096-8397-48cae1a68157" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5208a8e1-ff35-4845-9cb3-cc19d1434c11");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27fba6ae-8175-4484-9b0d-917d6b32c851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3558b31-3de8-40a1-b73a-7fe27b8abe66", "AQAAAAEAACcQAAAAEDU9Ua9rz40kf0RV9qjQK28LYmxXEyytbLDQrKNbWnJyrkxnfAqoPUuu+UY/HII1yA==", "712a0c05-59c6-4b3c-8485-01120aa5eadd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44569627-988b-4096-8397-48cae1a68157",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11b5ac88-53f0-4c51-b1a0-13a8792654a7", "AQAAAAEAACcQAAAAEOZslJVnENtEF2hUXgFQ5Z1G+lB70JezqsrdVoVqpKqkymoLSspfj3wf7B40kkHolg==", "9fd64b60-ef7e-4d9c-ae7d-047da9e8b968" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                column: "RegisteredOn",
                value: new DateTime(2022, 11, 16, 0, 7, 57, 142, DateTimeKind.Local).AddTicks(8131));
        }
    }
}

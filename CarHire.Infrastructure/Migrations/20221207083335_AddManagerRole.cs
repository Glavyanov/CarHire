using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHire.Infrastructure.Migrations
{
    public partial class AddManagerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5208a8e1-ff35-4845-9cb3-cc19d1434c11",
                column: "ConcurrencyStamp",
                value: "0ba68061-8515-47f7-8fc4-2beed67066e2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc4fdb35-719a-4ac2-8041-2e5034d2bae6", "6205fe1d-57a1-417e-aca1-396dd7bb477b", "Manager", "MANAGER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27fba6ae-8175-4484-9b0d-917d6b32c851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c09f4fe-ac76-4968-9492-7aef248e4c70", "AQAAAAEAACcQAAAAEGd3x/6j9kmA/J1rBFdHbuIabNuOpmtJTrEmJY/piofIK2+xW7cP3yIMMsaO8c+cdg==", "921f9bef-9787-4c70-b350-75c5104b5a10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44569627-988b-4096-8397-48cae1a68157",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48c3a902-a5c1-4afd-84ee-cb5ef24a62c6", "AQAAAAEAACcQAAAAEFzs/oICwbFZEEaYgMwtVIFad7CVZMEYf1XE25r3CrjQvU3gHG4XlcgrGcx5yr0NFw==", "aa3978e4-9365-473f-b0ad-b80ce553963a" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                column: "RegisteredOn",
                value: new DateTime(2022, 12, 7, 10, 33, 33, 455, DateTimeKind.Local).AddTicks(7827));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc4fdb35-719a-4ac2-8041-2e5034d2bae6");

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHire.Infrastructure.Migrations
{
    public partial class RemoveRenterVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Renters_RenterId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_RenterId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RenterId",
                table: "Vehicles");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RenterId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RenterId",
                table: "Vehicles",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Renters_RenterId",
                table: "Vehicles",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "Id");
        }
    }
}

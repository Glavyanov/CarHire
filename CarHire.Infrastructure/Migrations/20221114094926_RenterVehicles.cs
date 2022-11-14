using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarHire.Infrastructure.Migrations
{
    public partial class RenterVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RenterId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27fba6ae-8175-4484-9b0d-917d6b32c851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9db05cb-7617-448b-b6ec-19a8f4b3916e", "AQAAAAEAACcQAAAAEOnNlM/hnJI/9bYDA4gtfV3fqPsRlwUWyvn1nmkHNDjEISYGT0cHiza2jkJUtr5B5Q==", "c44d92e2-2368-462c-8d91-e8f172045b53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44569627-988b-4096-8397-48cae1a68157",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "917c2ea4-bb79-4147-bac3-f19c9da352ca", "AQAAAAEAACcQAAAAEHio1Vi0sKgm3heQq5XF9xbmRzxpjvJujnce6YfnjiyxrPEyXYHtp9ljDZeTUSionw==", "3eed683e-59d2-4215-aafb-d370692755c4" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                column: "RegisteredOn",
                value: new DateTime(2022, 11, 14, 11, 49, 25, 743, DateTimeKind.Local).AddTicks(4494));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27fba6ae-8175-4484-9b0d-917d6b32c851",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a3138d1-e01d-4c81-89a4-963f56fa40d2", "AQAAAAEAACcQAAAAENmm7YdWf+cw8ot/Ovhy7UhqJsJj0eMr1GCsklKjBFKH8MUmQ0i8Ny2SN69TX9jVyg==", "bd41059d-1ae4-4cb7-a12d-69e9f4f783ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44569627-988b-4096-8397-48cae1a68157",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9649c0ba-538b-4c24-a742-87b2a1ae0426", "AQAAAAEAACcQAAAAEEi73CH2Z5DyO8xReWIzdnkfLQ1uLdBm4laGzp4KmghP6k1n8FwGDN0tZv24/vTa8w==", "10ac6558-2dae-49f8-aa04-f46130106f77" });

            migrationBuilder.UpdateData(
                table: "Renters",
                keyColumn: "Id",
                keyValue: new Guid("0d5e7b0b-f3ed-4026-bec8-90ebc90019f8"),
                column: "RegisteredOn",
                value: new DateTime(2022, 11, 14, 9, 30, 33, 98, DateTimeKind.Local).AddTicks(2043));
        }
    }
}

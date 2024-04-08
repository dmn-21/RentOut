using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentOut.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11cfbe70-2298-4832-b90a-fe6102c03f4b", "", "", "AQAAAAEAACcQAAAAENJfDfoO/foM20AeRa3GzqVDMLqgq682dbWfmI1kwdyaIIwtZT9/jGjoTarBjyDVsA==", "f8b11402-c687-4a0c-8d15-3fd61064149f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "132e9335-2e69-4ed5-9c31-815f40234e02", "", "", "AQAAAAEAACcQAAAAEB3cljng9Hm4X6spfVOBUWWIfR1Ukc7d1HjIcI+p7xCsTu3yJJDhi55jtCs2KpEtoQ==", "9dedeef0-f463-4e12-b60d-9cffc9a7da68" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d65086d9-26c4-4ae5-b92a-a2a4d9bbbf26", "AQAAAAEAACcQAAAAEC8ngiUOYYMK0a7djkImqyG8YllRPqlryPOpKlqg3TSCqSojUHDHi/qui5KLrBRPtg==", "468ad5ce-cc1b-41de-a12c-9affd92b4982" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6525d8d3-4ad3-439c-aac6-da964d42a140", "AQAAAAEAACcQAAAAEKHwjnNKoVxnLhrIsrX54QvQEhDhxSzwGsz1RUdVmfYnsC2QyoFj/naK/MQku2l/4w==", "fb041dc9-9548-42bf-912e-2d25dfacb2d8" });
        }
    }
}

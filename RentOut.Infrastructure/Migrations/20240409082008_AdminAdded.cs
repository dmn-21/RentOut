using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentOut.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ccfb217-6b08-4f6d-8a19-112bc046d41c", "AQAAAAEAACcQAAAAEJg3PhxwOBO9+sf84YjGmYmOyMb23HLkGVwPeoZ6cJIntQ9gfyLOLcSxr5QpwnoR6Q==", "2e047ff6-e08d-450a-9db7-e153fa8c45a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff4ef0b0-dbfd-4ba8-8d7b-c8ae0197783c", "AQAAAAEAACcQAAAAEFxdVecuI+rJ5gpZfYEpTpo8DHO/TmJqBPBjhK9oX1FGF9WeHICzOTi4fcfdWWyEKQ==", "f39914e0-5f45-44b5-8431-4af76648c83f" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "999313c4-67e6-492f-ae95-c63caebfc2c7", 0, "6dc95b79-a8a2-477d-8381-d8fba5423290", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEE2uX0SJSUF1Nm95ztLnl/UV+Kpiy6huPPdNESJYGGgmUt5qflcpvbI5oTXDzgiK0w==", null, false, "a2c037b6-cdce-46b0-bf2f-628876a9a7d0", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Rentiers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 4, "+35988888888", "999313c4-67e6-492f-ae95-c63caebfc2c7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rentiers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "999313c4-67e6-492f-ae95-c63caebfc2c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11cfbe70-2298-4832-b90a-fe6102c03f4b", "AQAAAAEAACcQAAAAENJfDfoO/foM20AeRa3GzqVDMLqgq682dbWfmI1kwdyaIIwtZT9/jGjoTarBjyDVsA==", "f8b11402-c687-4a0c-8d15-3fd61064149f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "132e9335-2e69-4ed5-9c31-815f40234e02", "AQAAAAEAACcQAAAAEB3cljng9Hm4X6spfVOBUWWIfR1Ukc7d1HjIcI+p7xCsTu3yJJDhi55jtCs2KpEtoQ==", "9dedeef0-f463-4e12-b60d-9cffc9a7da68" });
        }
    }
}

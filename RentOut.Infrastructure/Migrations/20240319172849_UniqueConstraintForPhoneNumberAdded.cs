using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentOut.Infrastructure.Migrations
{
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25c1aa26-17fa-43ef-88b8-0e753371758d", "AQAAAAEAACcQAAAAEAfQM5E+zwTm4t0n5w9pJC+QUBiqQJwu+OlCnUK9Q0a5O2dC+lD8/NzV7HtfdrDufg==", "00f64fcd-b828-4399-8dee-52f6cb5c832b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e96d4056-860c-4877-9bae-4c5a4ec51ecb", "AQAAAAEAACcQAAAAEPjTi4QriKS3fGyXMafzPhwc1qVkbwo0jb117+ykFFYJoFyqWi2jW7W+M53ak5apkA==", "b5af9806-0fba-4d91-945d-f1922619c2ed" });
        }
    }
}

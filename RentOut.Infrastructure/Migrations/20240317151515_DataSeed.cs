using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentOut.Infrastructure.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Rentiers_RentierId",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "25c1aa26-17fa-43ef-88b8-0e753371758d", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEAfQM5E+zwTm4t0n5w9pJC+QUBiqQJwu+OlCnUK9Q0a5O2dC+lD8/NzV7HtfdrDufg==", null, false, "00f64fcd-b828-4399-8dee-52f6cb5c832b", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "e96d4056-860c-4877-9bae-4c5a4ec51ecb", "rentier@mail.com", false, false, null, "rentier@mail.com", "rentier@mail.com", "AQAAAAEAACcQAAAAEPjTi4QriKS3fGyXMafzPhwc1qVkbwo0jb117+ykFFYJoFyqWi2jW7W+M53ak5apkA==", null, false, "b5af9806-0fba-4d91-945d-f1922619c2ed", false, "rentier@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electric" },
                    { 2, "Hybrid" },
                    { 3, "Sedan" },
                    { 4, "Coupe" },
                    { 5, "Wagon" },
                    { 6, "Convertible" },
                    { 7, "Crossover" },
                    { 8, "SUV" },
                    { 9, "Van" }
                });

            migrationBuilder.InsertData(
                table: "Rentiers",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "+359888888888", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "PricePerDay", "RenterId", "RentierId", "Title", "Town" },
                values: new object[] { 1, 4, "Sports car. 2018y. At 60_000km. Without any remarks on interior and exterior.", "https://images.ams.bg/images/galleries/92496/razkrivat-mansory-mercedes-amg-s63-coup-black-12_big.jpg", 400.00m, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 1, "Mercedes s63", "Varna" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "PricePerDay", "RenterId", "RentierId", "Title", "Town" },
                values: new object[] { 2, 1, "Electric car. 2021y. At 15_000km. Without any remarks on interior and exterior.", "https://www.bristolstreet.co.uk/custom/101374.png", 400.00m, null, 1, "BMW i4", "Varna" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Rentiers_RentierId",
                table: "Cars",
                column: "RentierId",
                principalTable: "Rentiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Rentiers_RentierId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

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
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rentiers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Rentiers_RentierId",
                table: "Cars",
                column: "RentierId",
                principalTable: "Rentiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

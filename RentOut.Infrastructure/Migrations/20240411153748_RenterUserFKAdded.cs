using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentOut.Infrastructure.Migrations
{
    public partial class RenterUserFKAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rentiers_UserId",
                table: "Rentiers");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true,
                comment: "User id of the renter",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User id of the renter");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "633a9f7c-eab1-469e-a71b-d0353ec10beb", "AQAAAAEAACcQAAAAEPeTBW5OK8IyiJQHzDfE+5/W0SLvhSY06fzYLNRqnBgpB2oSEGU7Iom3zD5pLiJ46w==", "e23ad069-b624-4d61-beb7-eb924b9eb71b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "999313c4-67e6-492f-ae95-c63caebfc2c7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "932d10ca-bab4-4da4-8ff4-37d6c6c5614c", "AQAAAAEAACcQAAAAEERhohwzkCg5h4b3Rqn5YGIjKmTlJq5sE4Mu7r8j2ScsKhUauSYvppPwSbDiKQDXTA==", "e2d4d786-5a04-4fd3-89a5-4f87a23f36a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b0b21ab-ce56-4c0a-9243-678363245635", "AQAAAAEAACcQAAAAEInom03oae0G/edpRMCXAFXG4oL3f/HUD3UV59CVQr8a07LXsxtYUi3Cgaa6dVRJSA==", "69b7b5c4-a600-4c1f-a04d-94f3b65d11f5" });

            migrationBuilder.CreateIndex(
                name: "IX_Rentiers_UserId",
                table: "Rentiers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RenterId",
                table: "Cars",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_RenterId",
                table: "Cars",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_RenterId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Rentiers_UserId",
                table: "Rentiers");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RenterId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User id of the renter",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "User id of the renter");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef2c125e-803b-41ea-a476-95173b0e401a", "AQAAAAEAACcQAAAAEMCDXFWWaPYlDfHhJSG5fCAAqwP4BCNZhXUYtNTx4YPUj7TzrKnPrJrgWl+b3eSVYQ==", "b1049c0f-208b-4353-8156-3d620720a90f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "999313c4-67e6-492f-ae95-c63caebfc2c7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b05e87dc-7b26-4875-b991-df29ef87c0de", "AQAAAAEAACcQAAAAEJADMPq/sSUO8wA+ie73flIIrZnJNC1vj+OLVy2cdvXxJq53m858Ij31cclipNCBeA==", "9645e38b-81c1-41c8-9487-c55595622906" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c861c8d6-3168-4980-ad43-bfc1d3f305dc", "AQAAAAEAACcQAAAAEJUSLIoaY7xpIs65UEkVPxu2v4pB1sqr+IaYyveYTi8ahFjTSRoLlskUrRetoZC47g==", "f9e12922-a800-4a5c-b5bd-dff1025a1035" });

            migrationBuilder.CreateIndex(
                name: "IX_Rentiers_UserId",
                table: "Rentiers",
                column: "UserId");
        }
    }
}

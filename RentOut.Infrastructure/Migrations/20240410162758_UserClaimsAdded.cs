using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentOut.Infrastructure.Migrations
{
    public partial class UserClaimsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 44, "user:fullname", "Rentier Rentierov", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 88, "user:fullname", "Great Admin", "999313c4-67e6-492f-ae95-c63caebfc2c7" }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49540adf-3023-4c9e-9d72-e4d36f6af224", "AQAAAAEAACcQAAAAEPqscx2Sm2thAZhedlD8hzJbwjQoxDatsbSwbR2X7hsttSEAFFLfb1OzipDrCUXSBA==", "d5750c1a-cd6d-4c79-90b1-b98c5f60fe52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "999313c4-67e6-492f-ae95-c63caebfc2c7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c005fcfa-c45e-46ff-9151-299b40b6b282", "AQAAAAEAACcQAAAAEKSidlpw0TdyQRr1uGbYsaUYUNYHVxCZ/og8REhNIfA5xI8+/62LiDDTlFYCgYD5QQ==", "720ebae7-c691-49dc-a7df-dddbf4490ed2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc715af8-44df-49ad-89b0-6580242580d5", "AQAAAAEAACcQAAAAEKGXGCUAiJc3jld94y9bttET2lAGfSTIo+/1D7ajzkftqLpk5RlDgvKJSbRu1QxLgA==", "ada6f11e-a06c-4fbc-9ecb-ad0b98d4acc9" });
        }
    }
}

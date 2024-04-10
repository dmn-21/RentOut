using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentOut.Infrastructure.Migrations
{
    public partial class IsApprovedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is car approved by admin");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ccfb217-6b08-4f6d-8a19-112bc046d41c", "AQAAAAEAACcQAAAAEJg3PhxwOBO9+sf84YjGmYmOyMb23HLkGVwPeoZ6cJIntQ9gfyLOLcSxr5QpwnoR6Q==", "2e047ff6-e08d-450a-9db7-e153fa8c45a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "999313c4-67e6-492f-ae95-c63caebfc2c7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6dc95b79-a8a2-477d-8381-d8fba5423290", "AQAAAAEAACcQAAAAEE2uX0SJSUF1Nm95ztLnl/UV+Kpiy6huPPdNESJYGGgmUt5qflcpvbI5oTXDzgiK0w==", "a2c037b6-cdce-46b0-bf2f-628876a9a7d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff4ef0b0-dbfd-4ba8-8d7b-c8ae0197783c", "AQAAAAEAACcQAAAAEFxdVecuI+rJ5gpZfYEpTpo8DHO/TmJqBPBjhK9oX1FGF9WeHICzOTi4fcfdWWyEKQ==", "f39914e0-5f45-44b5-8431-4af76648c83f" });
        }
    }
}

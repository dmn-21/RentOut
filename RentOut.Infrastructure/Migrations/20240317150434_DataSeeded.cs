using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentOut.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Car town",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "Car town");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "Cars",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "Car town",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Car town");
        }
    }
}

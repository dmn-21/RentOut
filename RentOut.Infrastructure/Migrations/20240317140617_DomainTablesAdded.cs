using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentOut.Infrastructure.Migrations
{
    public partial class DomainTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "Car category");

            migrationBuilder.CreateTable(
                name: "Rentiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Rentier identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Rentier's phone"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentiers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Car Rentier");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Car identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Title"),
                    Town = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Car town"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Car description"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Car image url"),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Daily price"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    RentierId = table.Column<int>(type: "int", nullable: false, comment: "Rentier identifier"),
                    RenterId = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "User id of the renter")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Rentiers_RentierId",
                        column: x => x.RentierId,
                        principalTable: "Rentiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Car to rent");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RentierId",
                table: "Cars",
                column: "RentierId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentiers_PhoneNumber",
                table: "Rentiers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentiers_UserId",
                table: "Rentiers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Rentiers");
        }
    }
}

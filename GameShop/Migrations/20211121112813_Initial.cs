using Microsoft.EntityFrameworkCore.Migrations;

namespace GameShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechReq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbGame_DbCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DbCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbGame_CategoryId",
                table: "DbGame",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbGame");

            migrationBuilder.DropTable(
                name: "DbCategory");
        }
    }
}

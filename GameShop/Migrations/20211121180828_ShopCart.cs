using Microsoft.EntityFrameworkCore.Migrations;

namespace GameShop.Migrations
{
    public partial class ShopCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbShopCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ShopCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbShopCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbShopCartItem_DbGame_GameId",
                        column: x => x.GameId,
                        principalTable: "DbGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbShopCartItem_GameId",
                table: "DbShopCartItem",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbShopCartItem");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameShop.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbOrderDetails_DbGame_GameId",
                        column: x => x.GameId,
                        principalTable: "DbGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbOrderDetails_DbOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "DbOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbOrderDetails_GameId",
                table: "DbOrderDetails",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_DbOrderDetails_OrderId",
                table: "DbOrderDetails",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbOrderDetails");

            migrationBuilder.DropTable(
                name: "DbOrder");
        }
    }
}

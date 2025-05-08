using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diploma.Dal.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddTradePairTradeActionRelationі : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tradeAction",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    actAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    actionType = table.Column<int>(type: "int", nullable: false),
                    predictedPrice = table.Column<double>(type: "float", nullable: false),
                    algorithmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tradeAction", x => x.id);
                    table.ForeignKey(
                        name: "FK_tradeAction_algorithm_algorithmId",
                        column: x => x.algorithmId,
                        principalTable: "algorithm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tradePair",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sellActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tradePair", x => x.id);
                    table.ForeignKey(
                        name: "FK_tradePair_tradeAction_buyActionId",
                        column: x => x.buyActionId,
                        principalTable: "tradeAction",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tradePair_tradeAction_sellActionId",
                        column: x => x.sellActionId,
                        principalTable: "tradeAction",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tradeAction_algorithmId",
                table: "tradeAction",
                column: "algorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_tradePair_buyActionId",
                table: "tradePair",
                column: "buyActionId");

            migrationBuilder.CreateIndex(
                name: "IX_tradePair_sellActionId",
                table: "tradePair",
                column: "sellActionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tradePair");

            migrationBuilder.DropTable(
                name: "tradeAction");
        }
    }
}

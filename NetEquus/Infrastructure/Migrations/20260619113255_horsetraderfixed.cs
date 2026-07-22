using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class horsetraderfixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHorseTrader",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentBalance",
                table: "EquineEstates",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "HorseSaleBase",
                columns: table => new
                {
                    HorseSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    BuyerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuyerEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseSaleBase", x => x.HorseSaleId);
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_EquineEstates_BuyerEstateId",
                        column: x => x.BuyerEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EstateId");
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_EquineEstates_SellerEstateId",
                        column: x => x.SellerEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EstateId");
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_Users_BuyerUserId",
                        column: x => x.BuyerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_Users_SellerUserId",
                        column: x => x.SellerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_BuyerEstateId",
                table: "HorseSaleBase",
                column: "BuyerEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_BuyerUserId",
                table: "HorseSaleBase",
                column: "BuyerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_HorseId",
                table: "HorseSaleBase",
                column: "HorseId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_SellerEstateId",
                table: "HorseSaleBase",
                column: "SellerEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_SellerUserId",
                table: "HorseSaleBase",
                column: "SellerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorseSaleBase");

            migrationBuilder.DropColumn(
                name: "IsHorseTrader",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentBalance",
                table: "EquineEstates",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}

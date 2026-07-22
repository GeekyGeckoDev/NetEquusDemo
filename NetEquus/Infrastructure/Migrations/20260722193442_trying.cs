using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class trying : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorseSaleBase_EquineEstates_BuyerEstateId",
                table: "HorseSaleBase");

            migrationBuilder.DropColumn(
                name: "IsHorseTrader",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "EquinsValue",
                table: "Horses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_HorseSaleBase_EquineEstates_BuyerEstateId",
                table: "HorseSaleBase",
                column: "BuyerEstateId",
                principalTable: "EquineEstates",
                principalColumn: "EstateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorseSaleBase_EquineEstates_BuyerEstateId",
                table: "HorseSaleBase");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EquinsValue",
                table: "Horses");

            migrationBuilder.AddColumn<bool>(
                name: "IsHorseTrader",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_HorseSaleBase_EquineEstates_BuyerEstateId",
                table: "HorseSaleBase",
                column: "BuyerEstateId",
                principalTable: "EquineEstates",
                principalColumn: "EstateId");
        }
    }
}

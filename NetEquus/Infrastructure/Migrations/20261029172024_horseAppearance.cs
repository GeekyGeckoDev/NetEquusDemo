using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class horseAppearance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppearanceId",
                table: "Horses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HorseAppearances",
                columns: table => new
                {
                    AppearanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseAppearances", x => x.AppearanceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horses_AppearanceId",
                table: "Horses",
                column: "AppearanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Horses_HorseAppearances_AppearanceId",
                table: "Horses",
                column: "AppearanceId",
                principalTable: "HorseAppearances",
                principalColumn: "AppearanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horses_HorseAppearances_AppearanceId",
                table: "Horses");

            migrationBuilder.DropTable(
                name: "HorseAppearances");

            migrationBuilder.DropIndex(
                name: "IX_Horses_AppearanceId",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "AppearanceId",
                table: "Horses");
        }
    }
}

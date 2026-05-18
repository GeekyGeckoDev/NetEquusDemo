using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BoardingFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorseBoardings_Horses_horseGuidHorseId",
                table: "HorseBoardings");

            migrationBuilder.DropIndex(
                name: "IX_HorseBoardings_horseGuidHorseId",
                table: "HorseBoardings");

            migrationBuilder.DropColumn(
                name: "horseGuidHorseId",
                table: "HorseBoardings");

            migrationBuilder.CreateIndex(
                name: "IX_HorseBoardings_HorseGuidId",
                table: "HorseBoardings",
                column: "HorseGuidId");

            migrationBuilder.AddForeignKey(
                name: "FK_HorseBoardings_Horses_HorseGuidId",
                table: "HorseBoardings",
                column: "HorseGuidId",
                principalTable: "Horses",
                principalColumn: "GuidHorseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorseBoardings_Horses_HorseGuidId",
                table: "HorseBoardings");

            migrationBuilder.DropIndex(
                name: "IX_HorseBoardings_HorseGuidId",
                table: "HorseBoardings");

            migrationBuilder.AddColumn<Guid>(
                name: "horseGuidHorseId",
                table: "HorseBoardings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_HorseBoardings_horseGuidHorseId",
                table: "HorseBoardings",
                column: "horseGuidHorseId");

            migrationBuilder.AddForeignKey(
                name: "FK_HorseBoardings_Horses_horseGuidHorseId",
                table: "HorseBoardings",
                column: "horseGuidHorseId",
                principalTable: "Horses",
                principalColumn: "GuidHorseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

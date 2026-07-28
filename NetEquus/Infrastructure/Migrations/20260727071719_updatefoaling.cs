using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatefoaling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foalings_Horses_FoalId",
                table: "Foalings");

            migrationBuilder.DropIndex(
                name: "IX_Foalings_FoalId",
                table: "Foalings");

            migrationBuilder.DropColumn(
                name: "FoalingDate",
                table: "Foalings");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BreedingCoolDown",
                table: "Horses",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CompetitionCoolDown",
                table: "Horses",
                type: "date",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FoalId",
                table: "Foalings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BirthTime",
                table: "Foalings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Foalings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_FoalId",
                table: "Foalings",
                column: "FoalId",
                unique: true,
                filter: "[FoalId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Foalings_Horses_FoalId",
                table: "Foalings",
                column: "FoalId",
                principalTable: "Horses",
                principalColumn: "GuidHorseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foalings_Horses_FoalId",
                table: "Foalings");

            migrationBuilder.DropIndex(
                name: "IX_Foalings_FoalId",
                table: "Foalings");

            migrationBuilder.DropColumn(
                name: "BreedingCoolDown",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "CompetitionCoolDown",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "BirthTime",
                table: "Foalings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Foalings");

            migrationBuilder.AlterColumn<Guid>(
                name: "FoalId",
                table: "Foalings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "FoalingDate",
                table: "Foalings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_FoalId",
                table: "Foalings",
                column: "FoalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foalings_Horses_FoalId",
                table: "Foalings",
                column: "FoalId",
                principalTable: "Horses",
                principalColumn: "GuidHorseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysWillBeTheDeath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foalings_Users_User",
                table: "Foalings");

            migrationBuilder.DropIndex(
                name: "IX_Foalings_User",
                table: "Foalings");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Foalings");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FoalingDate",
                table: "Foalings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_BreederId",
                table: "Foalings",
                column: "BreederId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foalings_Users_BreederId",
                table: "Foalings",
                column: "BreederId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foalings_Users_BreederId",
                table: "Foalings");

            migrationBuilder.DropIndex(
                name: "IX_Foalings_BreederId",
                table: "Foalings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FoalingDate",
                table: "Foalings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<Guid>(
                name: "User",
                table: "Foalings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_User",
                table: "Foalings",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_Foalings_Users_User",
                table: "Foalings",
                column: "User",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

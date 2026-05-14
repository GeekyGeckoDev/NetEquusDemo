using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Yes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailedLoginCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LockedUntil",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AgingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsFoal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.GuidHorseId);
                });

            migrationBuilder.CreateTable(
                name: "HorseOwnerships",
                columns: table => new
                {
                    HorseOwnershipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorseGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseOwnerships", x => x.HorseOwnershipId);
                    table.ForeignKey(
                        name: "FK_HorseOwnerships_Horses_HorseGuidId",
                        column: x => x.HorseGuidId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseOwnerships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorseOwnerships_HorseGuidId",
                table: "HorseOwnerships",
                column: "HorseGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseOwnerships_UserId",
                table: "HorseOwnerships",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorseOwnerships");

            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropColumn(
                name: "FailedLoginCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockedUntil",
                table: "Users");
        }
    }
}

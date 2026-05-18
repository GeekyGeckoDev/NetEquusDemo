using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Praying : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Foalings",
                columns: table => new
                {
                    FoalingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoalingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreederId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foalings", x => x.FoalingId);
                    table.ForeignKey(
                        name: "FK_Foalings_EquineEstates_EquineEstateId",
                        column: x => x.EquineEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Foalings_Horses_DamId",
                        column: x => x.DamId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId");
                    table.ForeignKey(
                        name: "FK_Foalings_Horses_FoalId",
                        column: x => x.FoalId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Foalings_Horses_SireId",
                        column: x => x.SireId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId");
                    table.ForeignKey(
                        name: "FK_Foalings_Users_User",
                        column: x => x.User,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorseBoardings",
                columns: table => new
                {
                    HorseBoardingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorseGuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    horseGuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardingEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseBoardings", x => x.HorseBoardingId);
                    table.ForeignKey(
                        name: "FK_HorseBoardings_EquineEstates_BoardingEstateId",
                        column: x => x.BoardingEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseBoardings_Horses_horseGuidHorseId",
                        column: x => x.horseGuidHorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                });

  
            migrationBuilder.CreateIndex(
                name: "IX_Foalings_DamId",
                table: "Foalings",
                column: "DamId");

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_EquineEstateId",
                table: "Foalings",
                column: "EquineEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_FoalId",
                table: "Foalings",
                column: "FoalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_SireId",
                table: "Foalings",
                column: "SireId");

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_User",
                table: "Foalings",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_HorseBoardings_BoardingEstateId",
                table: "HorseBoardings",
                column: "BoardingEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseBoardings_horseGuidHorseId",
                table: "HorseBoardings",
                column: "horseGuidHorseId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horses_Breeds_BreedId",
                table: "Horses");

            migrationBuilder.DropTable(
                name: "Foalings");

            migrationBuilder.DropTable(
                name: "HorseBoardings");

            migrationBuilder.DropIndex(
                name: "IX_Horses_BreedId",
                table: "Horses");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Horses");
        }
    }
}

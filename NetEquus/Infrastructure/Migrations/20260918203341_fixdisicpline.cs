using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixdisicpline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetitionDisciplines",
                columns: table => new
                {
                    CompetitionDisciplineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discipline = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionDisciplines", x => x.CompetitionDisciplineId);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionClasses",
                columns: table => new
                {
                    CompetitionClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionDisciplineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionClasses", x => x.CompetitionClassId);
                    table.ForeignKey(
                        name: "FK_CompetitionClasses_CompetitionDisciplines_CompetitionDisciplineId",
                        column: x => x.CompetitionDisciplineId,
                        principalTable: "CompetitionDisciplines",
                        principalColumn: "CompetitionDisciplineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionDisciplineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionId);
                    table.ForeignKey(
                        name: "FK_Competitions_CompetitionDisciplines_CompetitionDisciplineId",
                        column: x => x.CompetitionDisciplineId,
                        principalTable: "CompetitionDisciplines",
                        principalColumn: "CompetitionDisciplineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionStatRequirements",
                columns: table => new
                {
                    CompetitionStatRequirementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stat = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionStatRequirements", x => x.CompetitionStatRequirementId);
                    table.ForeignKey(
                        name: "FK_CompetitionStatRequirements_CompetitionClasses_CompetitionClassId",
                        column: x => x.CompetitionClassId,
                        principalTable: "CompetitionClasses",
                        principalColumn: "CompetitionClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionEntries",
                columns: table => new
                {
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionEntries", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_CompetitionEntries_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionEntries_Horses_GuidHorseId",
                        column: x => x.GuidHorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionResults",
                columns: table => new
                {
                    ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placement = table.Column<int>(type: "int", nullable: false),
                    PlacementPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionResults", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetitionResults_Horses_GuidHorseId",
                        column: x => x.GuidHorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionClasses_CompetitionDisciplineId",
                table: "CompetitionClasses",
                column: "CompetitionDisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionEntries_CompetitionId",
                table: "CompetitionEntries",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionEntries_GuidHorseId",
                table: "CompetitionEntries",
                column: "GuidHorseId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_CompetitionId",
                table: "CompetitionResults",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionResults_GuidHorseId",
                table: "CompetitionResults",
                column: "GuidHorseId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CompetitionDisciplineId",
                table: "Competitions",
                column: "CompetitionDisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionStatRequirements_CompetitionClassId",
                table: "CompetitionStatRequirements",
                column: "CompetitionClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionEntries");

            migrationBuilder.DropTable(
                name: "CompetitionResults");

            migrationBuilder.DropTable(
                name: "CompetitionStatRequirements");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "CompetitionClasses");

            migrationBuilder.DropTable(
                name: "CompetitionDisciplines");
        }
    }
}

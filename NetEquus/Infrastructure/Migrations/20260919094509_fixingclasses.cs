using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixingclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_CompetitionDisciplines_CompetitionDisciplineId",
                table: "Competitions");

            migrationBuilder.RenameColumn(
                name: "CompetitionDisciplineId",
                table: "Competitions",
                newName: "CompetitionClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitions_CompetitionDisciplineId",
                table: "Competitions",
                newName: "IX_Competitions_CompetitionClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_CompetitionClasses_CompetitionClassId",
                table: "Competitions",
                column: "CompetitionClassId",
                principalTable: "CompetitionClasses",
                principalColumn: "CompetitionClassId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_CompetitionClasses_CompetitionClassId",
                table: "Competitions");

            migrationBuilder.RenameColumn(
                name: "CompetitionClassId",
                table: "Competitions",
                newName: "CompetitionDisciplineId");

            migrationBuilder.RenameIndex(
                name: "IX_Competitions_CompetitionClassId",
                table: "Competitions",
                newName: "IX_Competitions_CompetitionDisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_CompetitionDisciplines_CompetitionDisciplineId",
                table: "Competitions",
                column: "CompetitionDisciplineId",
                principalTable: "CompetitionDisciplines",
                principalColumn: "CompetitionDisciplineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

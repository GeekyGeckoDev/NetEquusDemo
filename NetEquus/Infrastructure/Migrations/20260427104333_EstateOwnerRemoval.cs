using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EstateOwnerRemoval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateOwners");

            migrationBuilder.CreateTable(
                name: "EstateOwnerships",
                columns: table => new
                {
                    OwnershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrimaryOwner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateOwnerships", x => x.OwnershipId);
                    table.ForeignKey(
                        name: "FK_EstateOwnerships_EquineEstates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstateOwnerships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstateOwnerships_EstateId",
                table: "EstateOwnerships",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_EstateOwnerships_UserId",
                table: "EstateOwnerships",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateOwnerships");

            migrationBuilder.CreateTable(
                name: "EstateOwners",
                columns: table => new
                {
                    OwnershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrimaryOwner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateOwners", x => x.OwnershipId);
                    table.ForeignKey(
                        name: "FK_EstateOwners_EquineEstates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstateOwners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstateOwners_EstateId",
                table: "EstateOwners",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_EstateOwners_UserId",
                table: "EstateOwners",
                column: "UserId");
        }
    }
}

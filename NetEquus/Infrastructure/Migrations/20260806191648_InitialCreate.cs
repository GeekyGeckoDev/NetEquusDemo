using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    BreedID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedAbbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisciplineAffinity = table.Column<double>(type: "float", nullable: false),
                    MinHeight = table.Column<int>(type: "int", nullable: false),
                    MaxHeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.BreedID);
                });

            migrationBuilder.CreateTable(
                name: "ConformationAttributes",
                columns: table => new
                {
                    ConfId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Legs = table.Column<double>(type: "float", nullable: false),
                    Shoulders = table.Column<double>(type: "float", nullable: false),
                    Hindquarters = table.Column<double>(type: "float", nullable: false),
                    Pasterns = table.Column<double>(type: "float", nullable: false),
                    BackAndLoin = table.Column<double>(type: "float", nullable: false),
                    Head = table.Column<double>(type: "float", nullable: false),
                    Neck = table.Column<double>(type: "float", nullable: false),
                    ChestAndBarrel = table.Column<double>(type: "float", nullable: false),
                    BackAndTopline = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConformationAttributes", x => x.ConfId);
                });

            migrationBuilder.CreateTable(
                name: "EquineEstates",
                columns: table => new
                {
                    EstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedEstateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstateDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorseCapacity = table.Column<int>(type: "int", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false),
                    IsSytemEstate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquineEstates", x => x.EstateId);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceAttributes",
                columns: table => new
                {
                    PerfId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gaits = table.Column<double>(type: "float", nullable: false),
                    Scope = table.Column<double>(type: "float", nullable: false),
                    Speed = table.Column<double>(type: "float", nullable: false),
                    Agility = table.Column<double>(type: "float", nullable: false),
                    Endurance = table.Column<double>(type: "float", nullable: false),
                    Stride = table.Column<double>(type: "float", nullable: false),
                    Trainability = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceAttributes", x => x.PerfId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password_Hash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsNpc = table.Column<bool>(type: "bit", nullable: false),
                    UserTypeEnum = table.Column<int>(type: "int", nullable: false),
                    CanLogin = table.Column<bool>(type: "bit", nullable: false),
                    FailedLoginCount = table.Column<int>(type: "int", nullable: false),
                    LockedUntil = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BreedGenerationStats",
                columns: table => new
                {
                    BreedGenerationStatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedGenerationStats", x => x.BreedGenerationStatsId);
                    table.ForeignKey(
                        name: "FK_BreedGenerationStats_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "BreedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AgingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EquinsValue = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: false),
                    IsFoal = table.Column<bool>(type: "bit", nullable: false),
                    CompetitionCoolDown = table.Column<DateOnly>(type: "date", nullable: true),
                    BreedingCoolDown = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.GuidHorseId);
                    table.ForeignKey(
                        name: "FK_Horses_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "BreedID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorseArtists",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmissionsAwaiting = table.Column<int>(type: "int", nullable: false),
                    SubmissionAccepted = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseArtists", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_HorseArtists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreedMinMaxStats",
                columns: table => new
                {
                    BreedMinMaxStatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreedGenerationStatsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Attribute = table.Column<int>(type: "int", nullable: false),
                    Min = table.Column<double>(type: "float", nullable: false),
                    Max = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedMinMaxStats", x => x.BreedMinMaxStatId);
                    table.ForeignKey(
                        name: "FK_BreedMinMaxStats_BreedGenerationStats_BreedGenerationStatsId",
                        column: x => x.BreedGenerationStatsId,
                        principalTable: "BreedGenerationStats",
                        principalColumn: "BreedGenerationStatsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfPerfTempAttributes",
                columns: table => new
                {
                    CPTId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerfId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Trainability = table.Column<double>(type: "float", nullable: false),
                    GuidHorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfPerfTempAttributes", x => x.CPTId);
                    table.ForeignKey(
                        name: "FK_ConfPerfTempAttributes_ConformationAttributes_ConfId",
                        column: x => x.ConfId,
                        principalTable: "ConformationAttributes",
                        principalColumn: "ConfId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfPerfTempAttributes_Horses_GuidHorseId",
                        column: x => x.GuidHorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfPerfTempAttributes_PerformanceAttributes_PerfId",
                        column: x => x.PerfId,
                        principalTable: "PerformanceAttributes",
                        principalColumn: "PerfId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foalings",
                columns: table => new
                {
                    FoalingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquineEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreederId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    DateBred = table.Column<DateOnly>(type: "date", nullable: false),
                    DamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SireId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BirthTime = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "GuidHorseId");
                    table.ForeignKey(
                        name: "FK_Foalings_Horses_SireId",
                        column: x => x.SireId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId");
                    table.ForeignKey(
                        name: "FK_Foalings_Users_BreederId",
                        column: x => x.BreederId,
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
                        name: "FK_HorseBoardings_Horses_HorseGuidId",
                        column: x => x.HorseGuidId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "HorseSaleBase",
                columns: table => new
                {
                    HorseSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HorseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    BuyerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuyerEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseSaleBase", x => x.HorseSaleId);
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_EquineEstates_BuyerEstateId",
                        column: x => x.BuyerEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_EquineEstates_SellerEstateId",
                        column: x => x.SellerEstateId,
                        principalTable: "EquineEstates",
                        principalColumn: "EstateId");
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_Horses_HorseId",
                        column: x => x.HorseId,
                        principalTable: "Horses",
                        principalColumn: "GuidHorseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_Users_BuyerUserId",
                        column: x => x.BuyerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_HorseSaleBase_Users_SellerUserId",
                        column: x => x.SellerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedGenerationStats_BreedId",
                table: "BreedGenerationStats",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedMinMaxStats_BreedGenerationStatsId",
                table: "BreedMinMaxStats",
                column: "BreedGenerationStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfPerfTempAttributes_ConfId",
                table: "ConfPerfTempAttributes",
                column: "ConfId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfPerfTempAttributes_GuidHorseId",
                table: "ConfPerfTempAttributes",
                column: "GuidHorseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfPerfTempAttributes_PerfId",
                table: "ConfPerfTempAttributes",
                column: "PerfId");

            migrationBuilder.CreateIndex(
                name: "IX_EstateOwnerships_EstateId",
                table: "EstateOwnerships",
                column: "EstateId");

            migrationBuilder.CreateIndex(
                name: "IX_EstateOwnerships_UserId",
                table: "EstateOwnerships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_BreederId",
                table: "Foalings",
                column: "BreederId");

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
                unique: true,
                filter: "[FoalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Foalings_SireId",
                table: "Foalings",
                column: "SireId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseBoardings_BoardingEstateId",
                table: "HorseBoardings",
                column: "BoardingEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseBoardings_HorseGuidId",
                table: "HorseBoardings",
                column: "HorseGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseOwnerships_HorseGuidId",
                table: "HorseOwnerships",
                column: "HorseGuidId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseOwnerships_UserId",
                table: "HorseOwnerships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Horses_BreedId",
                table: "Horses",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_BuyerEstateId",
                table: "HorseSaleBase",
                column: "BuyerEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_BuyerUserId",
                table: "HorseSaleBase",
                column: "BuyerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_HorseId",
                table: "HorseSaleBase",
                column: "HorseId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_SellerEstateId",
                table: "HorseSaleBase",
                column: "SellerEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_HorseSaleBase_SellerUserId",
                table: "HorseSaleBase",
                column: "SellerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedMinMaxStats");

            migrationBuilder.DropTable(
                name: "ConfPerfTempAttributes");

            migrationBuilder.DropTable(
                name: "EstateOwnerships");

            migrationBuilder.DropTable(
                name: "Foalings");

            migrationBuilder.DropTable(
                name: "HorseArtists");

            migrationBuilder.DropTable(
                name: "HorseBoardings");

            migrationBuilder.DropTable(
                name: "HorseOwnerships");

            migrationBuilder.DropTable(
                name: "HorseSaleBase");

            migrationBuilder.DropTable(
                name: "BreedGenerationStats");

            migrationBuilder.DropTable(
                name: "ConformationAttributes");

            migrationBuilder.DropTable(
                name: "PerformanceAttributes");

            migrationBuilder.DropTable(
                name: "EquineEstates");

            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Breeds");
        }
    }
}

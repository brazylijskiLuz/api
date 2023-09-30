using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackyeah.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changefieldnamefixQueries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Voivodeship = table.Column<string>(type: "text", nullable: false),
                    X = table.Column<string>(type: "text", nullable: false),
                    Y = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_universityData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstitutionName = table.Column<string>(type: "text", nullable: false),
                    CreationDateOrEntryDate = table.Column<string>(type: "text", nullable: false),
                    Address_Province = table.Column<string>(type: "text", nullable: false),
                    Address_District = table.Column<string>(type: "text", nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_PostCode = table.Column<string>(type: "text", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: false),
                    Address_BuildingNumber = table.Column<string>(type: "text", nullable: false),
                    MapLocalization_X = table.Column<string>(type: "text", nullable: false),
                    MapLocalization_Y = table.Column<string>(type: "text", nullable: false),
                    REGON = table.Column<string>(type: "text", nullable: false),
                    NIP = table.Column<string>(type: "text", nullable: false),
                    KRS = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    InstitutionType = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<int>(type: "integer", nullable: false),
                    RateCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__universityData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_directions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<int>(type: "integer", nullable: false),
                    RateCount = table.Column<int>(type: "integer", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__directions", x => x.Id);
                    table.ForeignKey(
                        name: "FK__directions__universityData_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "_universityData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__directions_Id",
                table: "_directions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX__directions_UniversityId",
                table: "_directions",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX__universityData_Id",
                table: "_universityData",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_cities");

            migrationBuilder.DropTable(
                name: "_directions");

            migrationBuilder.DropTable(
                name: "_universityData");
        }
    }
}

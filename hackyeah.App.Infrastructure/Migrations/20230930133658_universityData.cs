using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackyeah.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class universityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    MapLocalization_X = table.Column<double>(type: "double precision", nullable: false),
                    MapLocalization_Y = table.Column<double>(type: "double precision", nullable: false),
                    REGON = table.Column<string>(type: "text", nullable: false),
                    NIP = table.Column<string>(type: "text", nullable: false),
                    KRS = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    InstitutionType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__universityData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_universityData");
        }
    }
}

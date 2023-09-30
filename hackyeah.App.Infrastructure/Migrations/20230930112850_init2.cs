using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackyeah.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_institutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false),
                    RSPO = table.Column<string>(type: "text", nullable: false),
                    Regon = table.Column<string>(type: "text", nullable: false),
                    Nip = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Address_Province = table.Column<string>(type: "text", nullable: false),
                    Address_District = table.Column<string>(type: "text", nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_PostCode = table.Column<string>(type: "text", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: false),
                    Address_StreetProps = table.Column<string>(type: "text", nullable: false),
                    Address_BuildingNumber = table.Column<string>(type: "text", nullable: false),
                    Address_FlatNumber = table.Column<string>(type: "text", nullable: false),
                    Contact_RSPO = table.Column<string>(type: "text", nullable: false),
                    Contact_Email = table.Column<string>(type: "text", nullable: false),
                    Contact_Fax = table.Column<string>(type: "text", nullable: false),
                    Contact_Phone = table.Column<string>(type: "text", nullable: false),
                    Director_Name = table.Column<string>(type: "text", nullable: false),
                    Director_Surname = table.Column<string>(type: "text", nullable: false),
                    MapLocalization_X = table.Column<double>(type: "double precision", nullable: false),
                    MapLocalization_Y = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__institutions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_institutions");
        }
    }
}

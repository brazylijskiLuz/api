using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackyeah.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDirections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "_universityData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RateCount",
                table: "_universityData",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Direction",
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
                    table.PrimaryKey("PK_Direction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direction__universityData_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "_universityData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__universityData_Id",
                table: "_universityData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Direction_Id",
                table: "Direction",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Direction_UniversityId",
                table: "Direction",
                column: "UniversityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direction");

            migrationBuilder.DropIndex(
                name: "IX__universityData_Id",
                table: "_universityData");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "_universityData");

            migrationBuilder.DropColumn(
                name: "RateCount",
                table: "_universityData");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackyeah.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class doubletopstrin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MapLocalization_Y",
                table: "_universityData",
                type: "text",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "MapLocalization_X",
                table: "_universityData",
                type: "text",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MapLocalization_Y",
                table: "_universityData",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<double>(
                name: "MapLocalization_X",
                table: "_universityData",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}

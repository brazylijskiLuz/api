using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackyeah.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direction__universityData_UniversityId",
                table: "Direction");

            migrationBuilder.DropTable(
                name: "_university");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Direction",
                table: "Direction");

            migrationBuilder.RenameTable(
                name: "Direction",
                newName: "_directions");

            migrationBuilder.RenameIndex(
                name: "IX_Direction_UniversityId",
                table: "_directions",
                newName: "IX__directions_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_Direction_Id",
                table: "_directions",
                newName: "IX__directions_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__directions",
                table: "_directions",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK__directions__universityData_UniversityId",
                table: "_directions",
                column: "UniversityId",
                principalTable: "_universityData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__directions__universityData_UniversityId",
                table: "_directions");

            migrationBuilder.DropTable(
                name: "_cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK__directions",
                table: "_directions");

            migrationBuilder.RenameTable(
                name: "_directions",
                newName: "Direction");

            migrationBuilder.RenameIndex(
                name: "IX__directions_UniversityId",
                table: "Direction",
                newName: "IX_Direction_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX__directions_Id",
                table: "Direction",
                newName: "IX_Direction_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Direction",
                table: "Direction",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "_university",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressHistoryAddress = table.Column<string>(type: "text", nullable: false),
                    AddressHistoryReceiptDate = table.Column<string>(type: "text", nullable: false),
                    AddressNumber = table.Column<string>(type: "text", nullable: false),
                    AddressStreet = table.Column<string>(type: "text", nullable: false),
                    AuthorityHistoryAssignmentDate = table.Column<string>(type: "text", nullable: false),
                    AuthorityHistorySupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    CreationDateOrEntryDate = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EntryNumberForPrivateUniversities = table.Column<string>(type: "text", nullable: false),
                    FederationEndDate = table.Column<string>(type: "text", nullable: false),
                    FederationMemberInstitutionIdentifier = table.Column<string>(type: "text", nullable: false),
                    FederationMemberInstitutionName = table.Column<string>(type: "text", nullable: false),
                    FederationStartDate = table.Column<string>(type: "text", nullable: false),
                    HeadPersonData = table.Column<string>(type: "text", nullable: false),
                    HeadPersonIdentifier = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsID = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsKRS = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsNIP = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsName = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsPANRegisterNumber = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsPrivateUniversityEntryNumber = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsREGON = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsSupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsTransformationDate = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsTransformationType = table.Column<string>(type: "text", nullable: false),
                    InstitutionName = table.Column<string>(type: "text", nullable: false),
                    InstitutionType = table.Column<string>(type: "text", nullable: false),
                    KRS = table.Column<string>(type: "text", nullable: false),
                    LiquidationDate = table.Column<string>(type: "text", nullable: false),
                    LiquidationStartDate = table.Column<string>(type: "text", nullable: false),
                    MailingAddress = table.Column<string>(type: "text", nullable: false),
                    NIP = table.Column<string>(type: "text", nullable: false),
                    NamesDateOfNaming = table.Column<string>(type: "text", nullable: false),
                    NamesName = table.Column<string>(type: "text", nullable: false),
                    PANInstituteRegisterNumber = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsID = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsKRS = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsNIP = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsName = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsPANRegisterNumber = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsPrivateUniversityEntryNumber = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsREGON = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsSupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsTransformationDate = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsTransformationType = table.Column<string>(type: "text", nullable: false),
                    REGON = table.Column<string>(type: "text", nullable: false),
                    ScientificInstitutionType = table.Column<string>(type: "text", nullable: false),
                    StateResearchInstitute = table.Column<string>(type: "text", nullable: false),
                    StatusHistoryStatus = table.Column<string>(type: "text", nullable: false),
                    StatusHistoryStatusDate = table.Column<string>(type: "text", nullable: false),
                    SupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    TypeHistoryType = table.Column<string>(type: "text", nullable: false),
                    TypeHistoryTypeDate = table.Column<string>(type: "text", nullable: false),
                    UniversityNumberByMinister = table.Column<string>(type: "text", nullable: false),
                    UniversityType = table.Column<string>(type: "text", nullable: false),
                    Voivodeship = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    YearOfStateResearchInstitute = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__university", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Direction__universityData_UniversityId",
                table: "Direction",
                column: "UniversityId",
                principalTable: "_universityData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

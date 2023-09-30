using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackyeah.App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class university : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_institutions");

            migrationBuilder.CreateTable(
                name: "_university",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstitutionName = table.Column<string>(type: "text", nullable: false),
                    CreationDateOrEntryDate = table.Column<string>(type: "text", nullable: false),
                    SupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    InstitutionType = table.Column<string>(type: "text", nullable: false),
                    StateResearchInstitute = table.Column<string>(type: "text", nullable: false),
                    YearOfStateResearchInstitute = table.Column<string>(type: "text", nullable: false),
                    LiquidationStartDate = table.Column<string>(type: "text", nullable: false),
                    LiquidationDate = table.Column<string>(type: "text", nullable: false),
                    UniversityType = table.Column<string>(type: "text", nullable: false),
                    ScientificInstitutionType = table.Column<string>(type: "text", nullable: false),
                    REGON = table.Column<string>(type: "text", nullable: false),
                    NIP = table.Column<string>(type: "text", nullable: false),
                    KRS = table.Column<string>(type: "text", nullable: false),
                    UniversityNumberByMinister = table.Column<string>(type: "text", nullable: false),
                    EntryNumberForPrivateUniversities = table.Column<string>(type: "text", nullable: false),
                    PANInstituteRegisterNumber = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    MailingAddress = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Voivodeship = table.Column<string>(type: "text", nullable: false),
                    AddressStreet = table.Column<string>(type: "text", nullable: false),
                    AddressNumber = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    HeadPersonData = table.Column<string>(type: "text", nullable: false),
                    HeadPersonIdentifier = table.Column<string>(type: "text", nullable: false),
                    FederationMemberInstitutionName = table.Column<string>(type: "text", nullable: false),
                    FederationMemberInstitutionIdentifier = table.Column<string>(type: "text", nullable: false),
                    FederationStartDate = table.Column<string>(type: "text", nullable: false),
                    FederationEndDate = table.Column<string>(type: "text", nullable: false),
                    NamesName = table.Column<string>(type: "text", nullable: false),
                    NamesDateOfNaming = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsName = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsID = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsREGON = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsNIP = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsKRS = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsPANRegisterNumber = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsPrivateUniversityEntryNumber = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsSupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsTransformationType = table.Column<string>(type: "text", nullable: false),
                    PrecedingInstitutionsTransformationDate = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsName = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsID = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsREGON = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsNIP = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsKRS = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsPANRegisterNumber = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsPrivateUniversityEntryNumber = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsSupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsTransformationType = table.Column<string>(type: "text", nullable: false),
                    InheritingInstitutionsTransformationDate = table.Column<string>(type: "text", nullable: false),
                    AuthorityHistorySupervisoryAuthority = table.Column<string>(type: "text", nullable: false),
                    AuthorityHistoryAssignmentDate = table.Column<string>(type: "text", nullable: false),
                    StatusHistoryStatus = table.Column<string>(type: "text", nullable: false),
                    StatusHistoryStatusDate = table.Column<string>(type: "text", nullable: false),
                    TypeHistoryType = table.Column<string>(type: "text", nullable: false),
                    TypeHistoryTypeDate = table.Column<string>(type: "text", nullable: false),
                    AddressHistoryAddress = table.Column<string>(type: "text", nullable: false),
                    AddressHistoryReceiptDate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__university", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_university");

            migrationBuilder.CreateTable(
                name: "_institutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Nip = table.Column<string>(type: "text", nullable: false),
                    RSPO = table.Column<string>(type: "text", nullable: false),
                    Regon = table.Column<string>(type: "text", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Address_BuildingNumber = table.Column<string>(type: "text", nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_District = table.Column<string>(type: "text", nullable: false),
                    Address_FlatNumber = table.Column<string>(type: "text", nullable: false),
                    Address_PostCode = table.Column<string>(type: "text", nullable: false),
                    Address_Province = table.Column<string>(type: "text", nullable: false),
                    Address_Street = table.Column<string>(type: "text", nullable: false),
                    Address_StreetProps = table.Column<string>(type: "text", nullable: false),
                    Contact_Email = table.Column<string>(type: "text", nullable: false),
                    Contact_Fax = table.Column<string>(type: "text", nullable: false),
                    Contact_Phone = table.Column<string>(type: "text", nullable: false),
                    Contact_RSPO = table.Column<string>(type: "text", nullable: false),
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
    }
}

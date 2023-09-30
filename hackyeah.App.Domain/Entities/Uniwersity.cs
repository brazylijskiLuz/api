using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Domain.Entities;

public class University : Entity
{
    public string InstitutionName { get; set; }
    public string CreationDateOrEntryDate { get; set; }
    public string SupervisoryAuthority { get; set; }
    public string InstitutionType { get; set; }
    public string StateResearchInstitute { get; set; }
    public string YearOfStateResearchInstitute { get; set; }
    public string LiquidationStartDate { get; set; }
    public string LiquidationDate { get; set; }
    public string UniversityType { get; set; }
    public string ScientificInstitutionType { get; set; }
    public string REGON { get; set; }
    public string NIP { get; set; }
    public string KRS { get; set; }
    public string UniversityNumberByMinister { get; set; }
    public string EntryNumberForPrivateUniversities { get; set; }
    public string PANInstituteRegisterNumber { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string MailingAddress { get; set; }
    public string Country { get; set; }
    public string Voivodeship { get; set; }
    public string AddressStreet { get; set; }
    public string AddressNumber { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string HeadPersonData { get; set; }
    public string HeadPersonIdentifier { get; set; }
    public string FederationMemberInstitutionName { get; set; }
    public string FederationMemberInstitutionIdentifier { get; set; }
    public string FederationStartDate { get; set; }
    public string FederationEndDate { get; set; }
    public string NamesName { get; set; }
    public string NamesDateOfNaming { get; set; }
    public string PrecedingInstitutionsName { get; set; }
    public string PrecedingInstitutionsID { get; set; }
    public string PrecedingInstitutionsREGON { get; set; }
    public string PrecedingInstitutionsNIP { get; set; }
    public string PrecedingInstitutionsKRS { get; set; }
    public string PrecedingInstitutionsPANRegisterNumber { get; set; }
    public string PrecedingInstitutionsPrivateUniversityEntryNumber { get; set; }
    public string PrecedingInstitutionsSupervisoryAuthority { get; set; }
    public string PrecedingInstitutionsTransformationType { get; set; }
    public string PrecedingInstitutionsTransformationDate { get; set; }
    public string InheritingInstitutionsName { get; set; }
    public string InheritingInstitutionsID { get; set; }
    public string InheritingInstitutionsREGON { get; set; }
    public string InheritingInstitutionsNIP { get; set; }
    public string InheritingInstitutionsKRS { get; set; }
    public string InheritingInstitutionsPANRegisterNumber { get; set; }
    public string InheritingInstitutionsPrivateUniversityEntryNumber { get; set; }
    public string InheritingInstitutionsSupervisoryAuthority { get; set; }
    public string InheritingInstitutionsTransformationType { get; set; }
    public string InheritingInstitutionsTransformationDate { get; set; }
    public string AuthorityHistorySupervisoryAuthority { get; set; }
    public string AuthorityHistoryAssignmentDate { get; set; }
    public string StatusHistoryStatus { get; set; }
    public string StatusHistoryStatusDate { get; set; }
    public string TypeHistoryType { get; set; }
    public string TypeHistoryTypeDate { get; set; }
    public string AddressHistoryAddress { get; set; }
    public string AddressHistoryReceiptDate { get; set; }

    public University(IReadOnlyList<string> param)
    {
        this.InstitutionName = param[0 + 2];
        this.CreationDateOrEntryDate = param[1 + 2];
        this.SupervisoryAuthority = param[2 + 2];
        this.InstitutionType = param[3 + 2];
        this.StateResearchInstitute = param[4 + 2];
        this.YearOfStateResearchInstitute = param[5 + 2];
        this.LiquidationStartDate = param[6 + 2];
        this.LiquidationDate = param[7 + 2];
        this.UniversityType = param[8 + 2];
        this.ScientificInstitutionType = param[9 + 2];
        this.REGON = param[10 + 2];
        this.NIP = param[11 + 2];
        this.KRS = param[12 + 2];
        this.UniversityNumberByMinister = param[13 + 2];
        this.EntryNumberForPrivateUniversities = param[14 + 2];
        this.PANInstituteRegisterNumber = param[15 + 2];
        this.Website = param[16 + 2];
        this.Email = param[17 + 2];
        this.PhoneNumber = param[18 + 2];
        this.MailingAddress = param[19 + 2];
        this.Country = param[20 + 2];
        this.Voivodeship = param[21 + 2];
        this.AddressStreet = param[22 + 2];
        this.AddressNumber = param[23 + 2];
        this.PostalCode = param[24 + 2];
        this.City = param[25 + 2];
        this.HeadPersonData = param[26 + 2];
        this.HeadPersonIdentifier = param[27 + 2];
        this.FederationMemberInstitutionName = param[28 + 2];
        this.FederationMemberInstitutionIdentifier = param[29 + 2];
        this.FederationStartDate = param[30 + 2];
        this.FederationEndDate = param[31 + 2];
        this.NamesName = param[32 + 2];
        this.NamesDateOfNaming = param[33 + 2];
        this.PrecedingInstitutionsName = param[34 + 2];
        this.PrecedingInstitutionsID = param[35 + 2];
        this.PrecedingInstitutionsREGON = param[36 + 2];
        this.PrecedingInstitutionsNIP = param[37 + 2];
        this.PrecedingInstitutionsKRS = param[38 + 2];
        this.PrecedingInstitutionsPANRegisterNumber = param[39 + 2];
        this.PrecedingInstitutionsPrivateUniversityEntryNumber = param[40 + 2];
        this.PrecedingInstitutionsSupervisoryAuthority = param[41 + 2];
        this.PrecedingInstitutionsTransformationType = param[42 + 2];
        this.PrecedingInstitutionsTransformationDate = param[43 + 2];
        this.InheritingInstitutionsName = param[44 + 2];
        this.InheritingInstitutionsID = param[45 + 2];
        this.InheritingInstitutionsREGON = param[46 + 2];
        this.InheritingInstitutionsNIP = param[47 + 2];
        this.InheritingInstitutionsKRS = param[48 + 2];
        this.InheritingInstitutionsPANRegisterNumber = param[49 + 2];
        this.InheritingInstitutionsPrivateUniversityEntryNumber = param[50 + 2];
        this.InheritingInstitutionsSupervisoryAuthority = param[51 + 2];
        this.InheritingInstitutionsTransformationType = param[52 + 2];
        this.InheritingInstitutionsTransformationDate = param[53 + 2];
        this.AuthorityHistorySupervisoryAuthority = param[54 + 2];
        this.AuthorityHistoryAssignmentDate = param[55 + 2];
        this.StatusHistoryStatus = param[56 + 2];
        this.StatusHistoryStatusDate = param[57 + 2];
        this.TypeHistoryType = param[58 + 2];
        this.TypeHistoryTypeDate = param[59 + 2];
        this.AddressHistoryAddress = param[60 + 2];
        this.AddressHistoryReceiptDate = param[61 + 2];
    }

    public University()
    {
        
    }
}

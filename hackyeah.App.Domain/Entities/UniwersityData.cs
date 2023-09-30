using hackyeah.App.Domain.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Domain.Entities;

public class UniversityData : Entity
{
    public string InstitutionName { get; set; }
    public string CreationDateOrEntryDate { get; set; }
    public Address Address { get; set; }
    public MapLocalization MapLocalization { get; set; }
    public string REGON { get; set; }
    public string NIP { get; set; }
    public string KRS { get; set; }
    public string Website { get; set; }
    public string InstitutionType { get; set; }
}
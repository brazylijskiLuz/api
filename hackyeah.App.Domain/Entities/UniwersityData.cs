using hackyeah.App.Domain.Enums;
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
    public int Rate { get; set; }
    public int RateCount { get; set; }
    public string Description { get; set; }
    public InstitutionType Type { get; set; }
    public ICollection<DegreeCourse> DegreeCourse { get; set; }
}
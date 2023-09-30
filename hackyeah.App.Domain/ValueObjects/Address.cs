using Shared.Definitions;

namespace hackyeah.App.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Province { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public string Street { get; set; }
    public string BuildingNumber { get; set; }

    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        
        yield return Province;
        yield return District;
        yield return City;
        yield return PostCode;
        yield return Street;
        yield return BuildingNumber;
    }
}
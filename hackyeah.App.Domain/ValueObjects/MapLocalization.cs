using Shared.Definitions;

namespace hackyeah.App.Domain.ValueObjects;

public class MapLocalization : ValueObject
{
    public string X { get; set; }
    public string Y { get; set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return X;
        yield return Y;
    }
}
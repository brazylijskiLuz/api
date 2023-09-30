using Shared.Definitions;

namespace hackyeah.App.Domain.ValueObjects;

public class MapLocalization : ValueObject
{
    public double X { get; set; }
    public double Y { get; set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return X;
        yield return Y;
    }
}
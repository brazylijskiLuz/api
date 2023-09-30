using Shared.Definitions;

namespace hackyeah.App.Domain.ValueObjects;

public class Person : ValueObject
{
    public string Name { get; set; }
    public string Surname { get; set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Surname;
    }
}
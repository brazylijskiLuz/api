using Shared.Definitions;

namespace hackyeah.App.Domain.ValueObjects;

public class Contact : ValueObject
{
    
    public string RSPO { get; set; }
    public string Email { get; set; }
    public string Fax { get; set; }
    public string Phone { get; set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
using hackyeah.App.Domain.ValueObjects;
using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Domain.Entities;

public class Institution : Entity
{
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string RSPO { get; set; }
    public string Regon { get; set; }
    public string Nip { get; set; }
    public string City { get; set; }
    public string Status { get; set; }

    public Address Address { get; set; }
    public Contact Contact { get; set; }
    public Person Director { get; set; }
    public MapLocalization MapLocalization { get; set; }

    public Institution(string name, string shortName, string postCode, string rspo, string email,
        string fax, string phone, string street, string streetProps, string regon, string nip, string city,
        string buildingNumber, string flatNumber, string province, string city2Xd, string district,
        string directorName, string directorSurname, string status)
    {
        Address = new Address();
        Contact = new Contact();
        Director = new Person();
        MapLocalization = new MapLocalization();
        Name = name;
        ShortName = shortName;
        Address.PostCode = postCode;
        RSPO = rspo;
        Contact.Email = email;
        Contact.Fax = fax;
        Contact.Phone = phone;
        Address.Street = street;
        Address.StreetProps = streetProps;
        Regon = regon;
        Nip = nip;
        City = city;
        Address.BuildingNumber = buildingNumber;
        Address.FlatNumber = flatNumber;
        Address.Province = province;
        Address.City = city2Xd;
        Address.District = district;
        Director.Name = directorName;
        Director.Surname = directorSurname;
        Status = status;
        MapLocalization.X = 0;
        MapLocalization.Y = 0;
    }

    public Institution()
    {
        throw new NotImplementedException();
    }
}

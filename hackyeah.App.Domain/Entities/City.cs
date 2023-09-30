using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Domain.Entities;

public class City : Entity
{
    public string Name { get; set; }
    public string Voivodeship { get; set; }
    public string X { get; set; }
    public string Y { get; set; }
}
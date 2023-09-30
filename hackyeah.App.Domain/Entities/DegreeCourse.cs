using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Domain.Entities;

public class DegreeCourse : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Rate { get; set; }
    public int RateCount { get; set; }
    public int Price { get; set; }
    public Guid UniversityId { get; set; }
    public UniversityData University { get; set; }
}
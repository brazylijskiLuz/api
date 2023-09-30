using hackyeah.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Application.Repository;

public interface ICityRepository : IBaseRepository<City>
{
    Task<List<City>> GetCityAsync(string query, int page, int pageSize, CancellationToken cancellationToken);
}
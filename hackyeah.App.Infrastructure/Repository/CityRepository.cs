using hackyeah.App.Application.Repository;
using hackyeah.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Infrastructure.Repository;

public class CityRepository : BaseRepository<City> , ICityRepository
{
    public CityRepository(DbSet<City>? entities) : base(entities)
    {
    }

    public Task<List<City>> GetCityAsync(string query, int page, int pageSize, CancellationToken cancellationToken) =>
        _entities.Where(c => c.Name.Contains(query)).Skip(pageSize * page).Take(pageSize)
            .ToListAsync(cancellationToken);

    public Task<City> GetByNamesAsync(string s, CancellationToken cancellationToken) =>
        _entities.FirstOrDefaultAsync(c => c.Name == s);
}
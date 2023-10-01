using hackyeah.App.Application.Repository;
using hackyeah.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Infrastructure.Repository;

public class DegreeCourseRepository : BaseRepository<DegreeCourse> , IDegreeCourseRepository
{
    public DegreeCourseRepository(DbSet<DegreeCourse>? entities) : base(entities)
    {
    }

    public Task<List<DegreeCourse>> GetByNameAsync(string s, int page, int pageSize, CancellationToken cancellationToken) =>
        _entities.Where(c => c.Name.ToLower().Contains(s.ToLower()))
            .Skip(pageSize * page)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
}
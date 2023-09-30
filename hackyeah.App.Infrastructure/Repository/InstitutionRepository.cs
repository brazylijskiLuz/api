using System.Linq.Expressions;
using hackyeah.App.Application.Repository;
using hackyeah.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Infrastructure.Repository;

public class InstitutionRepository<T> : BaseRepository<T>, IInstitutionRepository<T> where T : UniversityData, new()
{
    public InstitutionRepository(DbSet<T> entities) : base(entities)
    {
        
    }

    public Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> ex, int page, int pageSize, CancellationToken cancellationToken) => _entities
        .Include(c => c.Directions)
        .Where(ex)
        .Skip(page * pageSize).Take(pageSize).ToListAsync<T>(cancellationToken: cancellationToken);
}
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

    public Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> ex, int page, int pageSize, CancellationToken cancellationToken) => 
        _entities
        .Include(c => c.Directions)
        .Where(ex)
        .Skip(page * pageSize).Take(pageSize).ToListAsync<T>(cancellationToken: cancellationToken);

    public Task<List<T>> GetByQueryAsync(string query, int page, int pageSize, CancellationToken cancellationToken)
    {
        string sql = "SELECT * FROM _universityData Where InstitutionName Like ";
        var charList = query.ToCharArray();
        foreach (var c in charList)
        {
            sql += $"%{c}% OR InstitutionName Like ";
        }
        foreach (var c in charList)
        {
            sql += $"%{c}% OR Website Like ";
        }        
        foreach (var c in charList)
        {
            sql += $"%{c}% OR Address_City Like ";
        }

        sql += ";";
        
        return _entities
            .FromSqlRaw(sql)
            .Include(c => c.Directions)
            .Skip(page * pageSize).Take(pageSize).ToListAsync<T>(cancellationToken: cancellationToken);
    }

    public Task<List<T>> GetByCityAsync(string city, int page, int pageSize, CancellationToken cancellationToken) => 
        _entities
            .Include(c => c.Directions)
            .Where(c => c.Address.City == city).ToListAsync<T>(cancellationToken: cancellationToken);
}
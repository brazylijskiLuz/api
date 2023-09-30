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
        .Include(c => c.DegreeCourse)
        .Where(ex)
        .Skip(page * pageSize).Take(pageSize).ToListAsync<T>(cancellationToken: cancellationToken);

    public Task<List<T>> GetByQueryAsync(string query, int page, int pageSize, CancellationToken cancellationToken)
    {
        string sql = "SELECT * FROM \"_universityData\" WHERE ";
        var charList = query.Split(' ').ToList();
        int i = 0;

        sql += "(";
        
        foreach (var c in charList)
        {
            if (i != 0)
                sql += $" AND Lower(\"InstitutionName\") Like Lower('%{c}%') ";
            else
                sql += $" Lower(\"InstitutionName\") Like Lower('%{c}%') ";
            i++;

        }

        i = 0;
        sql += ") OR (";

        foreach (var c in charList)
        {
            if (i != 0)
                sql += $" AND Lower(\"Website\") Like Lower('%{c}%') ";
            else
                sql += $" Lower(\"Website\") Like Lower('%{c}%') ";
            i++;
        }

        i = 0;
        sql += ") OR (";

        foreach (var c in charList)
        {
            if (i != 0)
                sql += $" AND Lower(\"Address_City\") Like Lower('%{c}%')";
            else
                sql += $" Lower(\"Address_City\") Like Lower('%{c}%')";
            i++;
        }

        sql += $") OFFSET  {page * pageSize} limit {pageSize}";

        Console.WriteLine(sql);
        return _entities.FromSqlRaw(sql)
            .Include(c => c.DegreeCourse)
            .ToListAsync<T>(cancellationToken: cancellationToken);
    }

    public Task<List<T>> GetByCityAsync(string city, int page, int pageSize, CancellationToken cancellationToken) => 
        _entities
            .Include(c => c.DegreeCourse)
            .Where(c => c.Address.City == city).ToListAsync<T>(cancellationToken: cancellationToken);
}
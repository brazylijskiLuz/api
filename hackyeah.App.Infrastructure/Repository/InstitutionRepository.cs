using System.Diagnostics;
using System.Linq.Expressions;
using hackyeah.App.Application.Repository;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.Enums;
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
    
    public Task<List<T>> GetByQueryAsync(string query, int page, List<InstitutionType> institutionTypes,
        int minPrice, int maxPrice, int pageSize, ModeOfStudy mode, string city,
        CancellationToken cancellationToken)
    {
        if (maxPrice == 0)
        {
            maxPrice = 999999;
        }
        var sql = "SELECT * FROM \"_universityData\" WHERE ";
        var charList = query.Split(' ').ToList();
        var i = 0;

        sql += "((";
        
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

        i = 0;
        if (institutionTypes.Count == 0 || institutionTypes is null)
        {
            sql += ")";
        }
        else
        {
            sql += ")) AND ";
        }
        

        foreach (var c in institutionTypes)
        {
            if (i != 0)
                sql += $" OR (\"Type\" = '{(int)c}')";
            else
                sql += $" ((\"Type\" = '{(int)c}') ";
            i++;        
        }

        sql += $") AND Lower(\"Address_City\") LIKE '%{city.ToLower()}%' order by \"Rate\" DESC OFFSET  {page * pageSize} limit {pageSize} ";

        Console.WriteLine(sql);
        return _entities.FromSqlRaw(sql)
            .Include(c => c
                .DegreeCourse
                .Where(c => 
                    (c.Price >= minPrice && c.Price <= maxPrice) && c.ModeOfStudy == mode || mode == ModeOfStudy.All))
            
        .ToListAsync<T>(cancellationToken: cancellationToken);
    }

    public Task<List<T>> GetByCityAsync(string city, int page, int pageSize, CancellationToken cancellationToken) => 
        _entities
            .Include(c => c.DegreeCourse)
            .Where(c => string.Equals(c.Address.City, city, StringComparison.CurrentCultureIgnoreCase)).ToListAsync<T>(cancellationToken: cancellationToken);
}
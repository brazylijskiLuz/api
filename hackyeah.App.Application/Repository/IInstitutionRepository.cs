using System.Linq.Expressions;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.Enums;
using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Application.Repository;

public interface IInstitutionRepository<T> : IBaseRepository<T> where T : Entity
{
    Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> ex, int page, int pageSize, CancellationToken cancellationToken);
    Task<List<T>> GetByQueryAsync(string query, int page, List<InstitutionType> institutionTypes, int requestMinPrice,
        int requestMaxPrice, int pageSize, ModeOfStudy mode,
        string requestCity,
        CancellationToken cancellationToken);
    Task<List<T>> GetByCityAsync(string city, int page, int pageSize, CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(Guid? id, CancellationToken cancellationToken = default);

}
using System.Linq.Expressions;
using hackyeah.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Application.Repository;

public interface IInstitutionRepository<T> : IBaseRepository<T> where T : Entity
{
    Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> ex, int page, int pageSize, CancellationToken cancellationToken);
}
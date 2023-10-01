using System.Linq.Expressions;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.Enums;
using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Application.Repository;

public interface IDegreeCourseRepository : IBaseRepository<DegreeCourse>
{
    Task<List<DegreeCourse>> GetByNameAsync(string s, int page, int pageSize, CancellationToken cancellationToken);
}
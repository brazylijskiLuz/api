using hackyeah.App.Application.Repository;
using hackyeah.App.Domain.Entities;
using Shared.BaseModels.BaseEntities;

namespace hackyeah.App.Application.DataAccess;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    IInstitutionRepository<UniversityData> UniversityData { get; }
    
    ICityRepository Cities { get; }
    IBaseRepository<Direction> Directions { get; }
}
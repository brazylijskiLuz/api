using hackyeah.App.Application.Repository;
using hackyeah.App.Domain.Entities;

namespace hackyeah.App.Application.DataAccess;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    IInstitutionRepository<University> University { get; }
    IInstitutionRepository<UniversityData> UniversityData { get; }
}
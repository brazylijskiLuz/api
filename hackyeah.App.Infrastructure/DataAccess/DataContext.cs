using hackyeah.App.Application.DataAccess;
using hackyeah.App.Application.Repository;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.ValueObjects;
using hackyeah.App.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace hackyeah.App.Infrastructure.DataAccess;

public class DataContext : DbContext, IUnitOfWork
{
    private DbSet<UniversityData> _universityData { get; set; }
    public IInstitutionRepository<UniversityData> UniversityData => new InstitutionRepository<UniversityData>(_universityData);

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UniversityData>().OwnsOne(c => c.Address);
        modelBuilder.Entity<UniversityData>().OwnsOne(c => c.MapLocalization);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
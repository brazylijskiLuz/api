using hackyeah.App.Application.DataAccess;
using hackyeah.App.Application.Repository;
using hackyeah.App.Domain.Entities;
using hackyeah.App.Domain.ValueObjects;
using hackyeah.App.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace hackyeah.App.Infrastructure.DataAccess;

public class DataContext : DbContext, IUnitOfWork
{
    private DbSet<University> _university { get; set; }
    public IInstitutionRepository<University> University => new InstitutionRepository<University>(_university);

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
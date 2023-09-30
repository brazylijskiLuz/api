using hackyeah.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hackyeah.App.Infrastructure.EntityConfigs;

public class UniversityConfig : IEntityTypeConfiguration<UniversityData>
{
    public void Configure(EntityTypeBuilder<UniversityData> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasMany(c => c.DegreeCourse)
            .WithOne(c => c.University)
            .HasForeignKey(c => c.UniversityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
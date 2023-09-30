using hackyeah.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hackyeah.App.Infrastructure.EntityConfigs;

public class DegreeCourseConfig: IEntityTypeConfiguration<DegreeCourse>
{
    public void Configure(EntityTypeBuilder<DegreeCourse> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasOne(c => c.University)
            .WithMany(c => c.DegreeCourse)
            .HasForeignKey(c => c.UniversityId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
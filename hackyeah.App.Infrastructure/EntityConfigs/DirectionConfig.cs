using hackyeah.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hackyeah.App.Infrastructure.EntityConfigs;

public class DirectionConfig: IEntityTypeConfiguration<Direction>
{
    public void Configure(EntityTypeBuilder<Direction> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasOne(c => c.University)
            .WithMany(c => c.Directions)
            .HasForeignKey(c => c.UniversityId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
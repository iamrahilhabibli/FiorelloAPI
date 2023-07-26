using Fiorello.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Persistence.Configurations;

public class BlogConficurations : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(400);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(40);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(1500);
    }
}

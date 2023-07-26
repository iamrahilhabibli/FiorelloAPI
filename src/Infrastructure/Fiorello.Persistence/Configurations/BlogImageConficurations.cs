using Fiorello.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Persistence.Configurations;

public class BlogImageConficurations : IEntityTypeConfiguration<BlogImage>
{
    public void Configure(EntityTypeBuilder<BlogImage> builder)
    {
        builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(400);
    }
}

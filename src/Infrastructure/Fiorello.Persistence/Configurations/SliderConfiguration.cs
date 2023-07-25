using Fiorello.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiorello.Persistence.Configurations;

public class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(s=>s.Title).IsRequired().HasMaxLength(50);
        builder.Property(s=>s.Description).IsRequired().HasMaxLength(150);
        builder.Property(s => s.ImagePath).IsRequired().HasMaxLength(255);
    }
}

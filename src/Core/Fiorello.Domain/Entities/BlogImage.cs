using Fiorello.Domain.Entities.Common;

namespace Fiorello.Domain.Entities;

public class BlogImage:BaseEntity
{
    public string ImagePath { get; set; }
    public Guid BlogId { get; set; }
    public Blog Blog { get; set; }
}

using Fiorello.Application.Abstraction.Repository;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Contexts;

namespace Fiorello.Persistence.Implementations.Repositories;

public class BlogImageReadReopsitory : ReadRepository<BlogImage>, IBlogImageReadReopsitory
{
    public BlogImageReadReopsitory(AppDbContext context) : base(context)
    {
    }
}

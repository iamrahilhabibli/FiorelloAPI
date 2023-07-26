using Fiorello.Application.Abstraction.Repository;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Contexts;

namespace Fiorello.Persistence.Implementations.Repositories;

public class BlogWriteReopsitory : WriteRepository<Blog>, IBlogWriteReopsitory
{
    public BlogWriteReopsitory(AppDbContext context) : base(context)
    {
    }
}

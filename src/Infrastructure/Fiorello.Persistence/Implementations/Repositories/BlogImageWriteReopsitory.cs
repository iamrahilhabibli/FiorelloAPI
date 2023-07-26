using Fiorello.Application.Abstraction.Repository;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Contexts;

namespace Fiorello.Persistence.Implementations.Repositories;

public class BlogImageWriteReopsitory : WriteRepository<BlogImage>, IBlogImageWriteReopsitory
{
    public BlogImageWriteReopsitory(AppDbContext context) : base(context)
    {
    }
}

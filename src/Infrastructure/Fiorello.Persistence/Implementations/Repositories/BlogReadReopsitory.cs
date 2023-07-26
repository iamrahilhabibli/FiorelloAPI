using Fiorello.Application.Abstraction.Repository;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Contexts;

namespace Fiorello.Persistence.Implementations.Repositories;

public class BlogReadReopsitory : ReadRepository<Blog>, IBlogReadReopsitory
{
    public BlogReadReopsitory(AppDbContext context) : base(context)
    {
    }
}

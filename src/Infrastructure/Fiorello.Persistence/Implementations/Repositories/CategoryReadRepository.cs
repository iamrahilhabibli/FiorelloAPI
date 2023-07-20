using Fiorello.Application.Abstraction.Repository;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Contexts;

namespace Fiorello.Persistence.Implementations.Repositories;

public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(AppDbContext context) : base(context)
    {
    }
}

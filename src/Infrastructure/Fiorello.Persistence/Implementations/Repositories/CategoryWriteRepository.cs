using Fiorello.Application.Abstraction.Repository;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Contexts;

namespace Fiorello.Persistence.Implementations.Repositories;

public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(AppDbContext context) : base(context)
    {
    }
}

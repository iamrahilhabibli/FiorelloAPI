using Fiorello.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Fiorello.Application.Abstraction.Repository;

public interface IRepository<T> where T : BaseEntity, new()
{
    public DbSet<T> Table { get; }
    

  
}

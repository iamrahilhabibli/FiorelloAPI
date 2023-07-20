using Fiorello.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Fiorello.Application.Abstraction.Repository;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll(bool isTracking = true, params string[] inculdes);
    IQueryable<T> GetAllExpression(Expression<Func<T, bool>> expression, int Skip, int Take, bool isTracking = true, params string[] inculdes);
    IQueryable<T> GetAllExpressionOrderBy(Expression<Func<T, bool>> expression, int Skip, int Take, Expression<Func<T, object>> expressionOrder, bool isOrdered = true, bool isTracking = true, params string[] inculdes);
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = true);

}

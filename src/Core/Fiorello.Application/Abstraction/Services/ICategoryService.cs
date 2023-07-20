using Fiorello.Domain.Entities;

namespace Fiorello.Application.Abstraction.Services
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(Guid Id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> CreateCategory(string name, string description);
        Task<Category> UpdateCategory(Guid Id, string name, string description);
        Task DeleteCategory(Guid Id);
        Task<Category> GetCategoryByName(string name);
        //Task<IEnumerable<Category>> GetTopNCategoriesOrderedByNewest(int n);
    }
}

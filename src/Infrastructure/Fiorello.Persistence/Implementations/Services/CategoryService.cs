using Fiorello.Application.Abstraction.Repository;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiorello.Persistence.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IReadRepository<Category> _categoryReadRepository;
        private readonly IWriteRepository<Category> _categoryWriteRepository;

        public CategoryService(IReadRepository<Category> categoryReadRepository,
                               IWriteRepository<Category> categoryWriteRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }
        public async Task<Category> GetByIdAsync(Guid Id)
        {
            return await _categoryReadRepository.GetByIdAsync(Id);
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryReadRepository.GetAll().ToListAsync();
        }
        public async Task<Category> CreateCategory(string name, string description)
        {
            var category = new Category
            {
                Name = name,
                Description = description
            };

            await _categoryWriteRepository.AddAsync(category);
            await _categoryWriteRepository.SaveChangesAsync();
            return category;
        }
        public async Task<Category> UpdateCategory(Guid Id, string name, string description)
        {
            var category = await _categoryReadRepository.GetByIdAsync(Id);
            if (category == null)
            {
                throw new();
            }

            category.Name = name;
            category.Description = description;

            _categoryWriteRepository.Update(category);
            await _categoryWriteRepository.SaveChangesAsync();
            return category;
        }
        public async Task DeleteCategory(Guid Id)
        {
            var category = await _categoryReadRepository.GetByIdAsync(Id);
            if (category != null)
            {
                _categoryWriteRepository.Remove(category);
                await _categoryWriteRepository.SaveChangesAsync();
            }
            // Null Check!
        }
        public async Task<Category> GetCategoryByName(string name)
        {
            return await _categoryReadRepository.GetByExpressionAsync(c => c.Name == name);
        }
        //public async Task<IEnumerable<Category>> GetTopNCategoriesOrderedByNewest(int n)
        //{
        //    return await _categoryReadRepository.GetAllFilteredOrderBy(c => true, n, 0, c => c.DateCreated, false).ToListAsync();
        //}

    }
}

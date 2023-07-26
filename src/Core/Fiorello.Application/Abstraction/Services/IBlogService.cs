using Fiorello.Application.DTOs.Blog;

namespace Fiorello.Application.Abstraction.Services;

public interface IBlogService
{
    Task<List<BlogGetDTO>> GetAllAsync();
    Task AddAsync(BlogCreateDTO blogCreateDTO);
    Task<BlogGetDTO> GetByIdAsync(Guid Id);
    Task UpdateAsync(Guid Id, BlogUpdateDTo blogUpdateDTo);
    Task RemoveAsync(Guid Id);
}

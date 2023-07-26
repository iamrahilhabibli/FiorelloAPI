using Fiorello.Application.DTOs.Blog;

namespace Fiorello.Application.Abstraction.Services;

public interface IBlogImageService
{
    Task AddAsync(BlogImageCreateDTO blogImageCreateDTO);
    Task Update(Guid BlogID, BlogImageUpdateDTO blogImageUpdateDTO);
}

using Microsoft.AspNetCore.Http;

namespace Fiorello.Application.DTOs.Blog;

public record BlogCreateDTO(IFormFile imagePath,
                            string title,
                            string description,
                            Guid CatagoryId,
                            BlogImageGetDTO BlogImageGetDTO);
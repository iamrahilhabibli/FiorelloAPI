using Microsoft.AspNetCore.Http;

namespace Fiorello.Application.DTOs.Blog;

public record BlogUpdateDTo(IFormFile imagePath,
                            string title,
                            string description,
                            Guid catagoryId,
                            BlogImageGetDTO BlogImageGetDTO);
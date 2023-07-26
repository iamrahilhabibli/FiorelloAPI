using AutoMapper;
using Fiorello.Application.DTOs.Blog;
using Fiorello.Domain.Entities;

namespace Fiorello.Persistence.MapperProfiles;

public class BlogImageProfile : Profile
{
    public BlogImageProfile()
    {
        CreateMap<BlogImage, BlogImageCreateDTO>().ReverseMap();
        CreateMap<BlogImage, BlogImageUpdateDTO>().ReverseMap();
        CreateMap<BlogImage, BlogImageGetDTO>().ReverseMap();
        CreateMap<NewBlogDto, BlogImageCreateDTO>().ReverseMap();
        CreateMap<BlogImage, BlogImageGetAllDTO>().ReverseMap();
    }
}
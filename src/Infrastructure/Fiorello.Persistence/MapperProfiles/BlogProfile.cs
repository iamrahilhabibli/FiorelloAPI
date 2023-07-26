using AutoMapper;
using Fiorello.Application.DTOs.Blog;
using Fiorello.Domain.Entities;

namespace Fiorello.Persistence.MapperProfiles;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<Blog, BlogGetDTO>().ReverseMap();
        CreateMap<Blog, BlogCreateDTO>().ReverseMap();
        CreateMap<Blog, BlogUpdateDTo>().ReverseMap();
    }
}

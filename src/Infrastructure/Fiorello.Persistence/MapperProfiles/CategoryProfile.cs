using AutoMapper;
using Fiorello.Application.DTOs.CategoryDTOs;
using Fiorello.Domain.Entities;

namespace Fiorello.Persistence.MapperProfiles;

public class CategoryProfile:Profile
{
	public CategoryProfile()
	{
		CreateMap<Category, CategoryCreateDto>().ReverseMap();
		CreateMap<Category, CategoryGetDto>().ReverseMap();
		CreateMap<Category, CategoryUpdateDto>().ReverseMap();
	}
}

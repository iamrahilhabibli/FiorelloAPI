using AutoMapper;
using Fiorello.Application.DTOs.CategoryDTOs;
using Fiorello.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

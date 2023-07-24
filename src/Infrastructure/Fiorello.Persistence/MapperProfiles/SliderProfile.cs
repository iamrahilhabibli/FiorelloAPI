using AutoMapper;
using Fiorello.Application.DTOs.SliderDTOs;
using Fiorello.Domain.Entities;

namespace Fiorello.Persistence.MapperProfiles;

public class SliderProfile : Profile
{
    public SliderProfile()
    {
        CreateMap<Slider, SliderCreateDto>().ReverseMap();
        CreateMap<Slider, SliderUpdateDto>().ReverseMap();
        CreateMap<Slider, SliderGetDto>().ReverseMap();
    }
}

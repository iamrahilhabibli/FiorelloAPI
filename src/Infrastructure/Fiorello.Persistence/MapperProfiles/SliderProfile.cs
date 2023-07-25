using AutoMapper;
using Fiorello.Application.DTOs.Slider;
using Fiorello.Domain.Entities;

namespace Fiorello.Persistence.MapperProfiles;

public class SliderProfile : Profile
{
    public SliderProfile()
    {
        CreateMap<Slider, SliderCreateDTO>().ReverseMap();
        CreateMap<Slider, SliderUptadeDTO>().ReverseMap();
        CreateMap<Slider, SliderGetDTO>().ReverseMap();
    }
}

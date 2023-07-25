using Fiorello.Application.DTOs.SliderDTOs;

namespace Fiorello.Application.Abstraction.Services;

public interface ISliderService
{
    Task CreateAsync(SliderCreateDto sliderCreateDto);
    Task<SliderGetDto> GetByIdAsync(Guid Id);
    Task<List<SliderGetDto>> GetAllAsync();
    //Task DeleteAsync(Guid Id);
}

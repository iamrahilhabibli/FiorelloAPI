using Fiorello.Application.DTOs.Slider;

namespace Fiorello.Application.Abstraction.Services;

public interface ISliderService
{
    Task<List<SliderGetDTO>> GetAllAsync();
    Task CreateAsync(SliderCreateDTO sliderCreateDTO);
    Task<SliderGetDTO> GetByIdAsync(Guid Id);
    Task UpdateAsync(Guid id, SliderUptadeDTO sliderUptadeDTO);
    Task RemoveAsync(Guid id);
}

using AutoMapper;
using Fiorello.Application.Abstraction.Repository;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.SliderDTOs;

namespace Fiorello.Persistence.Implementations.Services;

public class SliderService : ISliderService
{
    private readonly ISliderReadRepository _sliderReadRepository;
    private readonly ISliderWriteRepository _sliderWriteRepository;
    private readonly IMapper   _mapper;

    public SliderService(ISliderReadRepository sliderReadRepository,
                         ISliderWriteRepository sliderWriteRepository,
                         IMapper mapper)
    {
        _sliderReadRepository = sliderReadRepository;
        _sliderWriteRepository = sliderWriteRepository;
        _mapper = mapper;
    }

    public Task CreateAsync(SliderCreateDto sliderCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<SliderGetDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SliderGetDto> GetByIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }
}

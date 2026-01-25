
using AutoMapper;

public class SpeciesService : ISpeciesService
{
    private readonly ISpeciesRepository _repository;

    private readonly IMapper _mapper;

    public SpeciesService(ISpeciesRepository repository, IMapper mapper){
        _repository = repository;
        _mapper = mapper;
    }

    public Task<SpeciesDto> CreateAsync(SpeciesCreateDto createDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SpeciesDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<SpeciesDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, SpeciesUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }
}
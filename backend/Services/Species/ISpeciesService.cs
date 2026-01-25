public interface ISpeciesService
{
    Task<SpeciesDto> GetByIdAsync(int id);
    Task<IEnumerable<SpeciesDto>> GetAllAsync();
    Task<SpeciesDto> CreateAsync(SpeciesCreateDto createDto);
    Task UpdateAsync(int id, SpeciesUpdateDto updateDto);
    Task DeleteAsync(int id);
}
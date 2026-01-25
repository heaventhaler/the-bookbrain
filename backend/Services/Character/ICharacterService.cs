public interface ICharacterService
{
    Task<CharacterDetailDto> GetByIdAsync(int id);
    Task<IEnumerable<CharacterDetailDto>> GetAllAsync();
    Task<CharacterDetailDto> CreateAsync(CharacterCreateDto createDto);
    Task UpdateAsync(int id, CharacterCreateDto updateDto);
    Task DeleteAsync(int id);
}
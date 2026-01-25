public interface IBookService
{
    Task<BookReadDto> GetByIdAsync(int id);
    Task<IEnumerable<BookReadDto>> GetAllAsync();
    Task<BookReadDto> CreateAsync(BookCreateDto createDto);
    Task UpdateAsync(int id, BookUpdateDto updateDto);
    Task DeleteAsync(int id);
    Task<IEnumerable<CharacterDetailDto>> GetBookWithCharactersAsync(int id);
}
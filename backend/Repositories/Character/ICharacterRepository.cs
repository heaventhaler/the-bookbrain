public interface ICharacterRepository
{
    Task<Character?> GetByIdAsync(int id);
    Task<IEnumerable<Character>> GetAllAsync();
    Task<Character> AddAsync(Character character);
    Task UpdateAsync(Character character);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
public interface ISpeciesRepository
{
    Task<Species?> GetByIdAsync(int id);
    Task<IEnumerable<Species>> GetAllAsync();
    Task<Species> AddAsync(Species species);
    Task UpdateAsync(Species species);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
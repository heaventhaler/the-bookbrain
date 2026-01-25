

using Microsoft.EntityFrameworkCore;

public class SpeciesRepository : ISpeciesRepository
{
    private readonly ApplicationDbContext _context;

    public SpeciesRepository(ApplicationDbContext context){
        _context = context;
    }

    public async Task<Species> AddAsync(Species species)
    {
        await _context.Species.AddAsync(species);
        await _context.SaveChangesAsync();
        return species;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Species>> GetAllAsync()
    {
        return await _context.Species.ToListAsync();
    }

    public async Task<Species?> GetByIdAsync(int id)
    {
        return await _context.Species
            .FirstOrDefaultAsync(b => b.SpeciesId == id);
    }

    public Task UpdateAsync(Species species)
    {
        throw new NotImplementedException();
    }
}
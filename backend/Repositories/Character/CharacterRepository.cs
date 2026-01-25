
using Microsoft.EntityFrameworkCore;

public class CharacterRepository : ICharacterRepository
{
    private readonly ApplicationDbContext _context;

    public CharacterRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Character> AddAsync(Character character)
    {
        await _context.Characters.AddAsync(character);
        await _context.SaveChangesAsync();  // Save changes to the database
        return character;
    }

    public async Task DeleteAsync(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character != null)
        {
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Characters.AnyAsync(b => b.CharacterId == id);
    }

    public async Task<IEnumerable<Character>> GetAllAsync()
    {
         return await _context.Characters
            .ToListAsync();
    }

    public async Task<Character?> GetByIdAsync(int id)
    {
        return await _context.Characters
            .FirstOrDefaultAsync(b => b.CharacterId == id);
    }

    public async Task UpdateAsync(Character character)
    {
         _context.Characters.Update(character);
        await _context.SaveChangesAsync();
    }
}
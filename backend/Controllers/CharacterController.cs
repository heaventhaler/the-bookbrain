using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/characters")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;
    private readonly ILogger<CharacterController> _logger;


    public CharacterController(ICharacterService characterService, ILogger<CharacterController> logger)
    {
        _characterService = characterService;
         _logger = logger;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CharacterDetailDto>>> GetAll()
    {
        var characters = await _characterService.GetAllAsync();
        return Ok(characters);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CharacterDetailDto>> GetById(int id)
    {
        var character = await _characterService.GetByIdAsync(id);
        
        if (character == null)
        {
            _logger.LogWarning($"Character with ID {id} not found.");
            return NotFound(); 
        }

        return Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<CharacterDetailDto>> CreateCharacter(CharacterCreateDto createDto)
    {
           if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);  
    }

    var createdCharacter = await _characterService.CreateAsync(createDto);

    return CreatedAtAction(nameof(GetById), new { id = createdCharacter.CharacterId }, createdCharacter); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCharacter(int id)
    {
        await _characterService.DeleteAsync(id);
        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/species")]
public class SpeciesController : ControllerBase
{
    private readonly ISpeciesService _speciesService;
    private readonly ILogger<SpeciesController> _logger;


    public SpeciesController(ISpeciesService speciesService, ILogger<SpeciesController> logger)
    {
        _speciesService = speciesService;
         _logger = logger;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SpeciesDto>>> GetAll()
    {
        var species = await _speciesService.GetAllAsync();
        return Ok(species);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SpeciesDto>> GetById(int id)
    {
        var species = await _speciesService.GetByIdAsync(id);
        
        if (species == null)
        {
            _logger.LogWarning($"Species with ID {id} not found.");
            return NotFound(); 
        }

        return Ok(species);
    }

    [HttpPost]
    public async Task<ActionResult<SpeciesDto>> CreateSpecies(SpeciesCreateDto createDto)
    {
           if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);  
    }

    var createdSpecies = await _speciesService.CreateAsync(createDto);

    return CreatedAtAction(nameof(GetById), new { id = createdSpecies.SpeciesId }, createdSpecies); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSpecies(int id, SpeciesUpdateDto updateDto)
    {
        await _speciesService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSpecies(int id)
    {
        await _speciesService.DeleteAsync(id);
        return NoContent();
    }
}
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ILogger<BooksController> _logger;


    public BooksController(IBookService bookService, ILogger<BooksController> logger)
    {
        _bookService = bookService;
         _logger = logger;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookReadDto>>> GetBooks()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookReadDto>> GetBook(int id)
    {
        var book = await _bookService.GetByIdAsync(id);
        
        if (book == null)
        {
            _logger.LogWarning($"Book with ID {id} not found.");
            return NotFound(); 
        }

        return Ok(book);
    }

    [HttpGet("{id}/characters")]
    public async Task<ActionResult<BookReadDto>> GetCharactersByBookId(int id)
    {
        
    try
    {
        var characters = await _bookService.GetBookWithCharactersAsync(id);

        var characterDtos = characters.Select(c => new CharacterDetailDto
        {
            CharacterId = c.CharacterId,
            Name = c.Name,
            Description = c.Description,
            Profession = c.Profession,
            Species = c.Species != null ? new SpeciesDto
            {
                SpeciesId = c.Species.SpeciesId,
                Name = c.Species.Name
            } : null
        });

        return Ok(characterDtos);
    }
    catch (KeyNotFoundException ex)
    {
        return NotFound(ex.Message);
    }
    }

    [HttpPost]
    public async Task<ActionResult<BookReadDto>> CreateBook([FromBody] BookCreateDto createDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);  
        }

        var createdBook = await _bookService.CreateAsync(createDto);

        return CreatedAtAction(nameof(GetBook), new { id = createdBook.BookId }, createdBook); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, BookUpdateDto updateDto)
    {
        await _bookService.UpdateAsync(id, updateDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _bookService.DeleteAsync(id);
        return NoContent();
    }
}
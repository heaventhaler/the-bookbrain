using AutoMapper;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BookReadDto> GetByIdAsync(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        
        if (book == null)
            throw new NotFoundException("Book", id);

        return _mapper.Map<BookReadDto>(book);
    }

    public async Task<IEnumerable<BookReadDto>> GetAllAsync()
    {
        var books = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<BookReadDto>>(books);
    }

    public async Task<BookReadDto> CreateAsync(BookCreateDto createDto)
    {
        var book = _mapper.Map<Book>(createDto);
        var createdBook = await _repository.AddAsync(book);
        var bookReadDto = _mapper.Map<BookReadDto>(createdBook); 
        return bookReadDto;
    }

    public async Task UpdateAsync(int id, BookUpdateDto updateDto)
    {
        var existingBook = await _repository.GetByIdAsync(id);
        
        if (existingBook == null)
            throw new NotFoundException("Book", id);

        _mapper.Map(updateDto, existingBook);
        await _repository.UpdateAsync(existingBook);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await _repository.ExistsAsync(id))
            throw new NotFoundException("Book", id);

        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CharacterDetailDto>> GetBookWithCharactersAsync(int id)
    {
        var book = await _repository.GetBookWithCharactersAsync(id);

        if (book == null)
        {
            throw new KeyNotFoundException($"Book with ID {id} not found.");
        }

        // Map characters to CharacterReadDto
        return book.Characters.Select(c => new CharacterDetailDto
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
    }
}
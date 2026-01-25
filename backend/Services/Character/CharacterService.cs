using AutoMapper;

public class CharacterService : ICharacterService{
    private readonly ICharacterRepository _repository;
    private readonly IMapper _mapper;


    public CharacterService(ICharacterRepository repository, IMapper mapper){
         _repository = repository;
        _mapper = mapper;
    }

    public async Task<CharacterDetailDto> CreateAsync(CharacterCreateDto createDto)
    {
        var character = _mapper.Map<Character>(createDto);
        var createdCharacter = await _repository.AddAsync(character);
        var characterReadDto = _mapper.Map<CharacterDetailDto>(createdCharacter); 
        return characterReadDto;
    }

    public async Task DeleteAsync(int id)
    {
        if (!await _repository.ExistsAsync(id))
        throw new NotFoundException("Character", id);

        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CharacterDetailDto>> GetAllAsync()
    {
        var characters = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<CharacterDetailDto>>(characters);
    }

    public async Task<CharacterDetailDto> GetByIdAsync(int id)
    {
        var character = await _repository.GetByIdAsync(id);
        
        if (character == null)
            throw new NotFoundException("Character", id);

        return _mapper.Map<CharacterDetailDto>(character);
    }

    public async Task UpdateAsync(int id, CharacterCreateDto updateDto)
    {
         var existingCharacter = await _repository.GetByIdAsync(id);
        
        if (existingCharacter == null)
            throw new NotFoundException("Character", id);

        _mapper.Map(updateDto, existingCharacter);
        await _repository.UpdateAsync(existingCharacter);
    }
}
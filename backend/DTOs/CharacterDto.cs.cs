public class CharacterDetailDto
{
    public int CharacterId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    public string? Profession { get; set;} 
    public SpeciesDto? Species {get; set;}
}

public class CharacterCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
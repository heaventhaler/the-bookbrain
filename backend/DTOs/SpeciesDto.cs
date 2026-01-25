public class SpeciesDto
{
    public int SpeciesId {get; set;}
    public required string Name {get; set;}
    public string? Description {get; set;}
}

public class SpeciesCreateDto
{
    public required string Name {get; set;}
    public string? Description {get; set;}
}

public class SpeciesUpdateDto
{
    public required string Name {get; set;}
    public string? Description {get; set;}
}
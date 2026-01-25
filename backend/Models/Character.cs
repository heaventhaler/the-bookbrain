public class Character
{
    public int CharacterId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Profession {get; set;}
    public Species? Species { get; set; }
    public required int BookId {get; set;}
    public Book Book {get; set;} = null!;

}
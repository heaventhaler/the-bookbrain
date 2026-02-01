using System.Collections;

public class Book
{
    public int BookId { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public int? Pages {get; set;}
    public string? Genre { get; set; }
    public string? Description { get; set; }
    public ICollection<Character> Characters { get; set; } = new List<Character>();

}

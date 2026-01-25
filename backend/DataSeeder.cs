public class DataSeeder
{
    private readonly ApplicationDbContext _context;

    public DataSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    
    public void SeedBooks(){

        Console.WriteLine("SeedBooks method started.");
    

        var species = new List<Species>{
            new Species { SpeciesId=1, Name="Elves", Description="Graceful and long-lived beings often associated with magic and nature." },
            new Species { SpeciesId=2, Name="Dwarves", Description="Sturdy, short, and skilled in mining and crafting." },
            new Species { SpeciesId=3, Name="Humans", Description="Versatile and resourceful, dominating much of the known world." },
        };

        var characters = new List<Character>{
            new Character { 
                CharacterId = 1, 
                Name = "Harry Potter", 
                Description = "The Boy Who Lived", 
                Profession = "Wizard", 
                Species = species.First(s => s.Name == "Humans"),
                BookId = 1

            },
            new Character { 
                CharacterId = 2, 
                Name = "Hermione Granger", 
                Description = "Brilliant witch and loyal friend", 
                Profession = "Witch", 
                Species = species.First(s => s.Name == "Humans"),
                BookId = 1
            },
           
        };

        var books = new List<Book>{
                new Book
                {
                    BookId = 1,
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    Pages = 310,
                    Genre = "Fantasy",
                    Description = "A young hobbit embarks on a journey to reclaim treasure guarded by the dragon Smaug.",
                    Characters = characters
                },
                new Book
                {
                    BookId = 2,
                    Title = "1984",
                    Author = "George Orwell",
                    Pages = 328,
                    Genre = "Dystopian",
                    Description = "A dystopian novel set in a totalitarian society where surveillance and propaganda dominate."
                },
                new Book
                {
                    BookId = 3,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Pages = 281,
                    Genre = "Fiction",
                    Description = "A young girl grows up in the racially charged American South and learns about justice and prejudice."
                },
                new Book
                {
                    BookId = 4,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Author = "J.K. Rowling",
                    Pages = 309,
                    Genre = "Fantasy",
                    Description = "A young boy discovers he's a wizard and attends a magical school, where he uncovers dark secrets.",
                    Characters = characters
                },
                new Book
                {
                    BookId = 5,
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    Pages = 180,
                    Genre = "Classic",
                    Description = "A story of love, wealth, and betrayal set in the Roaring Twenties."
                },
                
            };


    

        if (!_context.Species.Any()){
            _context.Species.AddRange(species);
            _context.SaveChanges();
        }
        if (!_context.Books.Any()){
            _context.Books.AddRange(books);
            _context.SaveChanges();
            }
        if (!_context.Characters.Any()){
            _context.Characters.AddRange(characters);
            _context.SaveChanges();
        }
        
    }
}
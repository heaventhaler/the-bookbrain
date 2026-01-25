using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;

    public DbSet<Species> Species { get; set; } = null!;

    public DbSet<Character> Characters { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Species>();

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Characters);

        modelBuilder.Entity<Character>()
            .HasOne(c => c.Species)
            .WithMany()
            .IsRequired(false); 
    }
}
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Repositories
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Services
builder.Services.AddScoped<IBookService, BookService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// PostgreSQL Konfiguration
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

builder.Logging.AddConsole();

// Swagger/OpenAPI (optional, aber empfohlen)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection für Services
// builder.Services.AddScoped<IYourService, YourService>();

var app = builder.Build();

// Datenbank-Migration beim Start
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();

    var seeder = new DataSeeder(dbContext);
    try
        {
            seeder.SeedBooks();
        }
    catch (Exception ex)
        {
            Console.WriteLine($"Error seeding database: {ex.Message}");
        }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
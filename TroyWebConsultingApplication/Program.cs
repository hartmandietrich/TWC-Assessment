using Microsoft.EntityFrameworkCore;
using TroyWebConsultingApplication;
using TroyWebConsultingApplication.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(
        "data source=DESKTOP-S6KJK1Q\\SQLEXPRESS;initial catalog=master;trusted_connection=true;TrustServerCertificate=True").
    UseSeeding((context, _) =>
    {
        Book[] initialBooks = [new Book
            {
                Title = "The Shining"
            },
            new Book
            {
                Title = "Jaws"
            },
            new Book
            {
                Title = "Wild Seed"
            }
        ];
    
        if (!context.Set<Book>().Any())
        {
            context.Set<Book>().AddRange(initialBooks);
            context.SaveChanges();
        }
    } );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
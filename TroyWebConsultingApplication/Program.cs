using Microsoft.EntityFrameworkCore;
using TroyWebConsultingApplication;
using TroyWebConsultingApplication.Entities;
using TroyWebConsultingApplication.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LibraryDbContextConnection") ?? throw new InvalidOperationException("Connection string 'LibraryDbContextConnection' not found.");

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
                Title = "The Shining",
                Author = "Stephen King",
                Description = "Scary book oooooh",
                Publisher = "I dunno",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 666,
                IsCheckedOut = false
            },
            new Book
            {
                Title = "Jaws",
                Author = "The Author of Jaws",
                Description = "Ooooooh he'll bite ya",
                Publisher = "Someone probably",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 400,
                IsCheckedOut = false
            },
            new Book
            {
                Title = "Wild Seed",
                Author = "Octavia Butler",
                Description = "Immortal lady, real cool",
                Publisher = "This book was in fact published",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Science Fiction",
                PageCount = 300,
                IsCheckedOut = false
            }
        ];
    
        if (!context.Set<Book>().Any())
        {
            context.Set<Book>().AddRange(initialBooks);
            context.SaveChanges();
        }
    } );
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LibraryDbContext>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

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
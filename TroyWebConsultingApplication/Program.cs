using Microsoft.EntityFrameworkCore;
using TroyWebConsultingApplication;
using TroyWebConsultingApplication.Entities;
using TroyWebConsultingApplication.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("LibraryDbContextConnection") ?? throw new InvalidOperationException("Connection string 'LibraryDbContextConnection' not found.");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseSqlServer(
        "data source=DESKTOP-S6KJK1Q\\SQLEXPRESS;initial catalog=master;trusted_connection=true;TrustServerCertificate=True");
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddUserManager<UserManager<IdentityUser>>()
    .AddDefaultUI()
    .AddSignInManager<SignInManager<IdentityUser>>()
    .AddEntityFrameworkStores<LibraryDbContext>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddAuthorization();

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
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roles = ["Customer", "Librarian"];
    foreach (var role in roles)
    {
        var hasRole = await roleManager.RoleExistsAsync(role);
        if (!hasRole)
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
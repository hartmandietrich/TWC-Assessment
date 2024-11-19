using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TroyWebConsultingApplication.Entities;

namespace TroyWebConsultingApplication;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : IdentityDbContext(options)
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
using Microsoft.EntityFrameworkCore;
using TroyWebConsultingApplication.Entities;

namespace TroyWebConsultingApplication;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Librarian> Librarians { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
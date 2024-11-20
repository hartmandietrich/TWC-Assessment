using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TroyWebConsultingApplication.Entities;

namespace TroyWebConsultingApplication;

public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book {
                Id = 1,
                Title = "The Shining",
                Author = "Stephen King",
                Description = "Scary book oooooh",
                Publisher = "I dunno",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 666,
                IsCheckedOut = false
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}

// UseSeeding((context, _) =>
// {
//     Book[] initialBooks = [new Book
//         {
//             Title = "The Shining",
//             Author = "Stephen King",
//             Description = "Scary book oooooh",
//             Publisher = "I dunno",
//             PublicationDate = DateOnly.FromDateTime(DateTime.Now),
//             Category = "Horror",
//             PageCount = 666,
//             IsCheckedOut = false
//         },
//         new Book
//         {
//             Title = "Jaws",
//             Author = "The Author of Jaws",
//             Description = "Ooooooh he'll bite ya",
//             Publisher = "Someone probably",
//             PublicationDate = DateOnly.FromDateTime(DateTime.Now),
//             Category = "Horror",
//             PageCount = 400,
//             IsCheckedOut = false
//         },
//         new Book
//         {
//             Title = "Wild Seed",
//             Author = "Octavia Butler",
//             Description = "Immortal lady, real cool",
//             Publisher = "This book was in fact published",
//             PublicationDate = DateOnly.FromDateTime(DateTime.Now),
//             Category = "Science Fiction",
//             PageCount = 300,
//             IsCheckedOut = false
//         }
//     ];
//
//     if (!context.Set<Book>().Any())
//     {
//         context.Set<Book>().AddRange(initialBooks);
//         context.SaveChanges();
//     }
// });
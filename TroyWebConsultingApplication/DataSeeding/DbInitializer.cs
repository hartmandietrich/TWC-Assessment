using Microsoft.EntityFrameworkCore;
using TroyWebConsultingApplication.Entities;

namespace TroyWebConsultingApplication.DataSeeding;

public class DbInitializer(ModelBuilder modelBuilder)
{
    public void Seed()
    {
        modelBuilder.Entity<Book>().HasData(
            new Book {
                Id = 1,
                Title = "The Shining",
                Author = "Stephen King",
                Description = "Classic horror novel",
                Publisher = "Test Publisher",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 500,
                IsCheckedOut = false
            },
            new Book {
                Id = 2,
                Title = "Jaws",
                Author = "Peter Benchley",
                Description = "Book about a shark",
                Publisher = "Test Publisher",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 400,
                IsCheckedOut = false
            },
            new Book {
                Id = 3,
                Title = "Wild Seed",
                Author = "Octavia Butler",
                Description = "It's about an immortal woman",
                Publisher = "Test Publisher",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Science Fiction",
                PageCount = 300,
                IsCheckedOut = false
            },
            new Book {
                Id = 4,
                Title = "Giedeon the Ninth",
                Author = "Tamsyn Muir",
                Description = "Necromancers in space!",
                Publisher = "Test Publisher",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Fiction",
                PageCount = 450,
                IsCheckedOut = false
            },
            new Book {
                Id = 5,
                Title = "The Fifth Season",
                Author = "NK Jemisin",
                Description = "People with rock powers try to survive the apocalypse",
                Publisher = "Test Publisher",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Fantasy",
                PageCount = 550,
                IsCheckedOut = false
            },
            new Book {
                Id = 6,
                Title = "Slaughterhouse 5",
                Author = "Kurt Vonnegut",
                Description = "Billy Pilgrim is unstuck in time",
                Publisher = "Test Publisher",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Science Fiction",
                PageCount = 330,
                IsCheckedOut = false
            }
        );
    }
}
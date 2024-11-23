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
                Description = "Scary book oooooh",
                Publisher = "I dunno",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 666,
                IsCheckedOut = false
            },
            new Book {
                Id = 2,
                Title = "Jaws",
                Author = "author",
                Description = "Scary book oooooh",
                Publisher = "I dunno",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 666,
                IsCheckedOut = false
            },
            new Book {
                Id = 3,
                Title = "Wild Seed",
                Author = "Octavia Butler",
                Description = "Scary book oooooh",
                Publisher = "I dunno",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 666,
                IsCheckedOut = false
            },
            new Book {
                Id = 4,
                Title = "Giedeon the Ninth",
                Author = "Tamsyn Muir",
                Description = "Scary book oooooh",
                Publisher = "I dunno",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 666,
                IsCheckedOut = false
            },
            new Book {
                Id = 5,
                Title = "Broken Earth",
                Author = "NK Jemisin",
                Description = "Scary book oooooh",
                Publisher = "I dunno",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 666,
                IsCheckedOut = false
            },
            new Book {
                Id = 6,
                Title = "Slaughterhouse 5",
                Author = "Kurt Vonnegut",
                Description = "Scary book oooooh",
                Publisher = "I dunno",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now),
                Category = "Horror",
                PageCount = 666,
                IsCheckedOut = false
            }
        );
    }
}
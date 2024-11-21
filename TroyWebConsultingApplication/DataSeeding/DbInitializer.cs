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
            }
        );
    }
}
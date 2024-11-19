using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using TroyWebConsultingApplication.Entities;
using TroyWebConsultingApplication.Requests;

namespace TroyWebConsultingApplication.Repositories;

public interface IBookRepository
{
    public IQueryable<Book> GetBooks();
    public IEnumerable<Book> GetBooksByTitle(string title);
    public Book AddBook(Book book);
    public Book UpdateBook(Book book);
    public Book DeleteBook(Book book);
}

public class BookRepository(LibraryDbContext context) : IBookRepository
{
    public IQueryable<Book> GetBooks()
    {
        return context.Set<Book>();
    }

    public IEnumerable<Book> GetBooksByTitle(string title)
    {
        return context.Set<Book>().Where(book => book.Title.Contains(title));
    }

    public Book AddBook(Book book)
    {
        var addedBook = context.Set<Book>().Add(book).Entity;
        context.SaveChanges();
        return addedBook;
    }

    public Book UpdateBook(Book book)
    {
        var updatedBook = context.Set<Book>().Update(book).Entity;
        context.SaveChanges();
        return updatedBook;
    }

    public Book DeleteBook(Book book)
    {
        var deletedBook = context.Set<Book>().Remove(book).Entity;
        context.SaveChanges();
        return deletedBook;
    }

    // public IQueryable<Book> FilterBooks(BookFilterRequest filterRequest)
    // {
    //     return context.Set<Book>().Where((book) => (filterRequest.Title.IsNullOrEmpty() ? true : book.Title.Contains(filterRequest.Title)) &&
    //                                                (filterRequest.Author.IsNullOrEmpty() ? true : book.Author.Contains(filterRequest.Author)) &&
    //                                                (filterRequest.IsAvailable.IsNullOrEmpty() || !book.IsCheckedOut.Equals(filterRequest.IsAvailable)));
    // }
    
}
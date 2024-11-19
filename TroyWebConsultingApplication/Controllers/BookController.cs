using Microsoft.AspNetCore.Mvc;
using TroyWebConsultingApplication.Entities;
using TroyWebConsultingApplication.Repositories;

namespace TroyWebConsultingApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookRepository repository) : ControllerBase
{
    [HttpGet(Name = "GetBooks")]
    public IEnumerable<Book> Get()
    {
        return repository.GetBooks();
    }

    [HttpGet("/getByTitle/{title}", Name = "GetBooksByTitle")]
    public IEnumerable<Book> GetBooksByTitle(string title)
    {
        return repository.GetBooksByTitle(title);
    }
    
    [HttpPost(Name = "AddBook")]
    public Book AddBook(Book book)
    {
        return repository.AddBook(book);
    }

    [HttpPut(Name = "UpdateBook")]
    public Book UpdateBook(Book book)
    {
        return repository.UpdateBook(book);
    }

    [HttpDelete(Name = "DeleteBook")]
    public Book DeleteBook(Book book)
    {
        return repository.DeleteBook(book);
    }
}
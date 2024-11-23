using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TroyWebConsultingApplication.Entities;
using TroyWebConsultingApplication.Repositories;

namespace TroyWebConsultingApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(
    IBookRepository repository,
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager
    ) : ControllerBase
{
    [HttpGet("getall",Name = "GetBooks")]
    [Authorize]
    public IEnumerable<Book> Get()
    {
        return repository.GetBooks();
    }

    [HttpGet("getByTitle/{title}", Name = "GetBooksByTitle")]
    public IEnumerable<Book> GetBooksByTitle(string title)
    {
        return repository.GetBooksByTitle(title);
    }
    
    [HttpPost("create", Name = "AddBook")]
    [Authorize(Roles = "Librarian")]
    public Book AddBook(Book book)
    {
        return repository.AddBook(book);
    }

    [HttpPut("update", Name = "UpdateBook")]
    [Authorize(Roles = "Librarian")]
    public Book UpdateBook(Book book)
    {
        return repository.UpdateBook(book);
    }

    [HttpDelete("delete", Name = "DeleteBook")]
    [Authorize(Roles = "Librarian")]
    public Book DeleteBook(Book book)
    {
        return repository.DeleteBook(book);
    }
    
    [HttpPost("checkout", Name = "CheckoutBook")]
    [Authorize(Roles = "Customer")]
    public async Task CheckOutBook(Book checkoutBook)
    {
        var book = repository.GetBookById(checkoutBook.Id);
        if (book.IsCheckedOut)
        {
            throw new Exception($"Book titled {checkoutBook.Title} is not available");
        }
        var currentUser = await userManager.GetUserAsync(HttpContext.User);
        book.CheckedOutBy = currentUser;
        book.LastCheckedOut = DateTime.Now;
        book.IsCheckedOut = true;
        repository.UpdateBook(book);
    }

    [HttpPost("makeavailable", Name = "MakeBookAvailable")]
    [Authorize(Roles = "Librarian")]
    public void MakeBookAvailable(Book book)
    {
        book.IsCheckedOut = false;
        book.CheckedOutBy = null;
        repository.UpdateBook(book);
    }
}
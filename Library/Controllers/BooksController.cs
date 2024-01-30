using Library.Model;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BooksService _bookService;

    public BooksController(BooksService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [Route("getBooks")]
    public IEnumerable<BookModel> GetBooks()
    {
        return _bookService.GetBooks();
    }

    [HttpPost]
    [Route("addBook")]
    public async Task<BookModel> AddBook(BookModel book)
    {
        return await _bookService.AddBook(book);
    }

    [HttpPut]
    [Route("update/{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookModel updatedBook)
    {
        return await _bookService.UpdateBook(id, updatedBook);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        return await _bookService.DeleteBook(id);
    }
}

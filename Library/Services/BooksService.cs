using Library.Data;
using Library.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BooksService
    {
        private readonly ApplicationDbContext _dbContext;

        public BooksService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<BookModel> GetBooks()
        {
            return _dbContext.Books.ToList();
        }

        public async Task<BookModel> AddBook(BookModel book)
        {
            book.Year = DateTime.UtcNow.Year;

            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();

            return book;
        }

        public async Task<IActionResult> UpdateBook(int id, BookModel updatedBook)
        {
            if (id != updatedBook.Id)
                return new BadRequestResult();

            _dbContext.Entry(updatedBook).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Books.Any(b => b.Id == id))
                    return new NotFoundResult();
                else
                    throw;
            }

            return new NoContentResult();
        }

        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
                return new NotFoundResult();

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}

using Book.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext dbContext;

        public BookController(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetBooks()
        {
            try
            {
                var books = await dbContext.Books.ToListAsync();
                return Ok(books);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async ValueTask<IActionResult> UpdateBook(int id, BookDto updateBook)
        {
            try
            {
                var book = await dbContext.Books.FirstOrDefaultAsync(x=>x.Id == id);
                book.Title = updateBook.Title;
                book.Description = updateBook.Description;
                if(updateBook.AuthorId >0)
                {
                    book.AuthorId = updateBook.AuthorId;
                }
                await dbContext.SaveChangesAsync();
                return Ok(book);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteBook(int id)
        {
            try
            {
                var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Remove(book);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

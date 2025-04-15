using BookCrud.DTOs;
using BookCrud.Mapper;
using BookCrud.Models;
using BookCrud.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCrud.Controllers
{
    [ApiController]
    [Route("api/books/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<BookDTO>> GetBooks()
        {
            var books = bookService.getBooks();
            var booksDTO = new List<BookDTO>();
            foreach(var book in books) {
                booksDTO.Add(BookMapper.MapToDTO(book));
            }
            return Ok(booksDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> GetBook(int id)
        {
            try
            {
                var book = bookService.getBook(id);
                var bookDTO = BookMapper.MapToDTO(book);
                return Ok(bookDTO);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bookService.createBook(book.Title, book.Author, book.Price);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                bookService.updateBook(id, book);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            try
            {
                bookService.deleteBook(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

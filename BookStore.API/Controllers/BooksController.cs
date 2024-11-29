using BookStore.Models.DataTransferObjects;
using BookStore.Models.Interfaces;
using BookStore.Utility.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books.Select(b => _mapper.MapBookToBookDto(b)));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(_mapper.MapBookToBookDto(book));
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(BookDto bookDto)
        {
            var book = _mapper.MapBookDtoToBook(bookDto);
            await _bookRepository.CreateBookAsync(book);
            return CreatedAtAction("GetBookById", new { id = book.book_id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            if (id != bookDto.BookId)
            {
                return BadRequest();
            }
            var book = _mapper.MapBookDtoToBook(bookDto);
            await _bookRepository.UpdateBookAsync(book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return NoContent();

        }

    }
}

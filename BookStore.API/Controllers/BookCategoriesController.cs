using BookStore.Models.DataTransferObjects;
using BookStore.Models.Interfaces;
using BookStore.Utility.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookCategoriesController : ControllerBase
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;
        private readonly IMapper _mapper;

        public BookCategoriesController(IBookCategoryRepository bookCategoryRepository, IMapper mapper)
        {
            _bookCategoryRepository = bookCategoryRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCategoryDto>>> GetAllBookCategories()
        {
            var bookCategories = await _bookCategoryRepository.GetAllBookCategoriesAsync();
            return Ok(bookCategories.Select(bc => _mapper.MapBookCategoryToBookCategoryDto(bc)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookCategoryDto>> GetBookCategoryById(int id)
        {
            var bookCategory = await _bookCategoryRepository.GetBookCategoryByIdAsync(id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            return Ok(_mapper.MapBookCategoryToBookCategoryDto(bookCategory));
        }

        [HttpPost]
        public async Task<ActionResult<BookCategoryDto>> CreateBookCategory(BookCategoryDto bookCategoryDto)
        {
            var bookCategory = _mapper.MapBookCategoryDtoToBookCategory(bookCategoryDto);
            await _bookCategoryRepository.CreateBookCategoryAsync(bookCategory);
            return CreatedAtAction("GetBookCategoryById", new { id = bookCategory.category_id }, bookCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookCategory(int id, BookCategoryDto bookCategoryDto)
        {
            if (id != bookCategoryDto.CategoryId)
            {
                return BadRequest();
            }
            var bookCategory = _mapper.MapBookCategoryDtoToBookCategory(bookCategoryDto);
            await _bookCategoryRepository.UpdateBookCategoryAsync(bookCategory);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookCategory(int id)
        {
            await _bookCategoryRepository.DeleteBookCategoryAsync(id);
            return NoContent();
        }
    }
}
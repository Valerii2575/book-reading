using AutoMapper;
using BookReading.API.Dtos.Book;
using BookReading.DomainLayer.Interfaces;
using BookReading.DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookReading.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : MainController
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<BookResultDto>>(books));
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _bookService.GetById(id);

            if (book == null)
                return NotFound();

            return Ok(_mapper.Map<BookResultDto>(book));
        }

        [HttpGet]
        [Route("book-category/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBooksByCategory(Guid id)
        {
            var books = await _bookService.GetBookByCategoryAsync(id);

            if (!books.Any())
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<BookResultDto>>(books));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(BookAddDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = _mapper.Map<Book>(bookDto);

            var bookResult = await _bookService.AddAsync(book);

            if (bookResult == null)
                return BadRequest();

            return Ok(_mapper.Map<BookResultDto>(bookResult));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, BookEditDto bookEdit)
        {
            if (id != bookEdit.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            await _bookService.UpdateAsync(_mapper.Map<Book>(bookEdit));

            return Ok(bookEdit);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await _bookService.GetById(id);
            if (book == null)
                return NotFound();

            await _bookService.DeleteAsync(book);

            return Ok();
        }

        [HttpGet]
        [Route("search/{bookName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Search(string bookName)
        {
            if (string.IsNullOrEmpty(bookName))
                return BadRequest();

            var book = await _bookService.SearchAsync(bookName);
            if (book == null)
                return NotFound();

            var booksResult = _mapper.Map<IEnumerable<BookResultDto>>(book);

            return Ok(booksResult);
        }

        [HttpGet]
        [Route("search-book-category/{searchedValue}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Book>>> SearchBookWithCategory(string searchedValue)
        {
            var books = _mapper.Map<List<Book>>(await _bookService.SearchBookWithCategoryAsync(searchedValue));

            if (!books.Any()) return NotFound("None book was founded");

            return Ok(_mapper.Map<IEnumerable<BookResultDto>>(books));
        }
    }
}

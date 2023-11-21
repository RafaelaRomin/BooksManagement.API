using BooksManagement.API.Entities;
using BooksManagement.API.MappingViewModels;
using BooksManagement.API.Models.InputModels;
using BooksManagement.API.Models.ViewModels;
using BooksManagement.API.Persistence;
using BooksManagement.API.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksManagementDbContext _booksManagementDbContext;

        public BooksController(BooksManagementDbContext booksManagementDbContext)
        {
            _booksManagementDbContext = booksManagementDbContext;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<BookViewModel>>> GetAll()
        {
            var books = await _booksManagementDbContext.Books.ToListAsync();

            if (books is null)
            {
                return BadRequest();
            }

            var booksViewModel = books.ConvertBookViewModel();

            return Ok(booksViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookViewModel>> GetById(int id)
        {

            var book = await _booksManagementDbContext.Books.SingleOrDefaultAsync(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }
            
            var bookViewModel = book.ConvertBookViewModelById();

            return Ok(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookInputModel bookInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var book = new Book(bookInputModel.Title, bookInputModel.Author, bookInputModel.ISBN, bookInputModel.PublicationYear);

            await _booksManagementDbContext.AddAsync(book);

            await _booksManagementDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = book.Id}, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookInputModel bookUpdated)
        {

            var book = await _booksManagementDbContext
                             .Books
                             .SingleOrDefaultAsync(b => b.Id == id);

            if (book is null)
            {
                return BadRequest();
            }

            book.UpdateBook(bookUpdated.Title, bookUpdated.Author, bookUpdated.ISBN, bookUpdated.PublicationYear);

            await _booksManagementDbContext.SaveChangesAsync();

            return Ok(book);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _booksManagementDbContext.Books.SingleOrDefaultAsync(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            _booksManagementDbContext.Remove(book);

            await _booksManagementDbContext.SaveChangesAsync();

            return Ok(book);
        }

    }
}

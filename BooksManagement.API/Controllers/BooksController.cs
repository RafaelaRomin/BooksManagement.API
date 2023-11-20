using BooksManagement.API.Entities;
using BooksManagement.API.Models.InputModels;
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
        public async Task<IActionResult> GetAll()
        {
            var books = await _booksManagementDbContext.Books
                              .ToListAsync();

            if (books is null)
            {
                return BadRequest();
            }
            
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var book = await _booksManagementDbContext.Books.SingleOrDefaultAsync(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookInputModel bookInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isbnDb = _booksManagementDbContext.Books.Any(b => b.ISBN == bookInputModel.ISBN);

            if (isbnDb)
            {
                return BadRequest("Este ISBN já existe, não é possivel cadastrar novamente!");
            }

            var book = new Book(bookInputModel.Title, bookInputModel.Author, bookInputModel.ISBN, bookInputModel.PublicationYear);

            await _booksManagementDbContext.AddAsync(book);

            await _booksManagementDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = book.Id}, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookInputModel bookUpdated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

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

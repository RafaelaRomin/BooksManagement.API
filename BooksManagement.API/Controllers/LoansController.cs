using BooksManagement.API.Entities;
using BooksManagement.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly BooksManagementDbContext _booksManagementDbContext;

        public LoansController(BooksManagementDbContext booksManagementDbContext)
        {
            _booksManagementDbContext = booksManagementDbContext;
        }

        [HttpGet("loans")]

        public async Task<IActionResult> GetAll()
        {
            var loans = await _booksManagementDbContext.BookLoans.ToListAsync();

            if (loans is null)
            {
                return NotFound();
            }

            return Ok(loans);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GeById(int id)
        {
            var loan = await _booksManagementDbContext
                .BookLoans
                .Include(e => e.Book)
                .Include(e => e.Client)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (loan is null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost]

        public async Task<IActionResult> Post(BookLoan bookLoan)
        {
            var client = await _booksManagementDbContext.Users.FirstOrDefaultAsync(u => u.Id == bookLoan.IdClient);

            if (client is null)
            {
                return NotFound();
            }
            
            await _booksManagementDbContext.BookLoans.AddAsync(bookLoan);

            await _booksManagementDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GeById), new { id = bookLoan.Id }, bookLoan);

        }

    }
}

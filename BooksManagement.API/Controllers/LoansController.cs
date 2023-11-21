using BooksManagement.API.Entities;
using BooksManagement.API.MappingViewModels;
using BooksManagement.API.Models.InputModels;
using BooksManagement.API.Models.ViewModels;
using BooksManagement.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Sockets;

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

        [HttpGet]

        public async Task<ActionResult<IEnumerable<LoanViewModel>>> GetAll()
        {
            var loans = await _booksManagementDbContext
                .BookLoans
                .Include(e => e.Book)
                .Include(e => e.Client)
                .ToListAsync();

            var loanViewModel = loans.ConvertLoanViewModel();

            return Ok(loanViewModel);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<LoanViewModel>> GeById(int id)
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

            var loanViewModel = loan.ConvertLoanViewModelById();

            return Ok(loanViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Post(LoanInputModel inputModel)
        {
            var client = await _booksManagementDbContext.Users.FirstOrDefaultAsync(u => u.Id == inputModel.IdClient);

            if (client is null)
            {
                return NotFound();
            }

            var loan = new BookLoan(inputModel.IdClient, inputModel.IdBook);

            await _booksManagementDbContext.BookLoans.AddAsync(loan);

            await _booksManagementDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GeById), new { id = loan.Id }, loan);

        }

        [HttpPut("edit-loan/{id}")]

        public async Task<IActionResult> Update (int id, LoanInputModel inputModel)
        {
            var loan = await _booksManagementDbContext.BookLoans.FirstOrDefaultAsync(e => e.Id == id);
            
            if (loan is null)
            {
                return BadRequest();
            }

            loan.UpdateLoan(inputModel.IdClient, inputModel.IdBook);

            await _booksManagementDbContext.SaveChangesAsync();

            return Ok(loan);
        }

        [HttpPut("renewal-book/{id}")]

        public async Task<IActionResult> RenewalBook(int id)
        {
            var loan = await _booksManagementDbContext.BookLoans.FirstOrDefaultAsync(e => e.Id == id);

            if (loan is null)
            {
                return BadRequest();
            }

            if (DateTime.Now >= loan.Devolution)
            {
                return BadRequest("Não é possível renovar um livro no dia de devolução dele ou com atraso, devolva e crie um novo empréstimo!");
            }

            var newDate = loan.Devolution.Date.AddDays(7);

            loan.Renewal(newDate);

            _booksManagementDbContext.Update(loan);

            await _booksManagementDbContext.SaveChangesAsync();

            return Ok(loan);
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete (int id)
        {
            var loan = await _booksManagementDbContext.BookLoans.SingleOrDefaultAsync(e => e.Id == id);

            if (loan is null)
            {
                return NotFound();
            }

            _booksManagementDbContext.Remove(loan);

            await _booksManagementDbContext.SaveChangesAsync();

            return Ok(loan);

        }
        

    }
}

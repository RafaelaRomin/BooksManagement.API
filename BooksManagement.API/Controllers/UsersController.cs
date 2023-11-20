using BooksManagement.API.Entities;
using BooksManagement.API.Models.InputModels;
using BooksManagement.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly BooksManagementDbContext _booksManagementDbContext;

        public UsersController(BooksManagementDbContext booksManagementDbContext)
        {
            _booksManagementDbContext = booksManagementDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _booksManagementDbContext.Users.ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var user = await _booksManagementDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]

        public async Task<IActionResult> Post(UserInputModel userInputModel)
        {

            var user = new User(userInputModel.Name, userInputModel.Email);

            await _booksManagementDbContext.AddAsync(user);

            await _booksManagementDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        
        }

        [HttpPut("{id}")]
        
        public async Task<IActionResult> Update(int id, UserInputModel userInputModel)
        {

            var user = await _booksManagementDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                return BadRequest();
            }

            user.UpdateUser(userInputModel.Name, userInputModel.Email);
            
            await _booksManagementDbContext.SaveChangesAsync();

            return Ok(user);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var user = _booksManagementDbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return BadRequest();
            }

            _booksManagementDbContext.Remove(user);

            await _booksManagementDbContext.SaveChangesAsync();

            return Ok(user);

        }

    }
}

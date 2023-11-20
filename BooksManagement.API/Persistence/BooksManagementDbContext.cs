using BooksManagement.API.Entities;
using BooksManagement.API.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BooksManagement.API.Persistence
{
    public class BooksManagementDbContext : DbContext
    {
        public BooksManagementDbContext(DbContextOptions<BooksManagementDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet <BookLoan> BookLoans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

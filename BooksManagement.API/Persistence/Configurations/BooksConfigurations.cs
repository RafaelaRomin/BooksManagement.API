using BooksManagement.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksManagement.API.Persistence.Configurations
{
    public class BooksConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.Id);

            //builder
            //    .HasOne(b => b.Client)
            //    .WithMany()
            //    .HasForeignKey(b => b.IdClient);

            //builder
            //    .HasOne(b => b.Loan)
            //    .WithMany()
            //    .HasForeignKey(b => b.IdLoan);
            
        }
    }
}

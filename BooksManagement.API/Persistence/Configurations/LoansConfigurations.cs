using BooksManagement.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksManagement.API.Persistence.Configurations
{
    public class LoansConfigurations : IEntityTypeConfiguration<BookLoan>
    {
        public void Configure(EntityTypeBuilder<BookLoan> builder)
        {
            builder 
                .HasKey(x => x.Id);

            builder
                .HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.IdClient);

            builder
                .HasOne(b => b.Book)
                .WithMany()
                .HasForeignKey(b => b.IdBook);
                
        }
    }
}

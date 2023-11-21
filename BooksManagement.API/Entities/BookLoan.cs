using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BooksManagement.API.Entities
{
    public class BookLoan
    {
        public BookLoan()
        {
            
        }
        public BookLoan(int idClient, int idBook)
        {
            IdClient = idClient;
            IdBook = idBook;
        }

        public int Id { get; private set; }
        public int IdClient { get; private set; }
        [JsonIgnore]
        public User? Client { get; private set; }
        public int IdBook { get; private set; }
        [JsonIgnore]
        public Book? Book { get; private set; }

        public DateTime LoanDate { get; private set; } = DateTime.Now.Date;

        public DateTime Devolution { get; private set; } = DateTime.Now.Date.AddDays(7);

        public void UpdateLoan(int idClient, int idBook)
        {
            IdClient = idClient;
            IdBook = idBook;
        }

        public void Renewal(DateTime date)
        {
            Devolution = date;
        }
    }
}

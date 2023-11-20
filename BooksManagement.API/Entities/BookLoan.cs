namespace BooksManagement.API.Entities
{
    public class BookLoan
    {
        public BookLoan(int idClient, int idBook)
        {
            IdClient = idClient;
            IdBook = idBook;
        }

        public int Id { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; } = DateTime.Now;
        public DateTime Devolution { get; private set; }
    }
}

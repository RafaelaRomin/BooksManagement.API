namespace BooksManagement.API.Models.InputModels
{
    public class BookInputModel
    {
        public string Title { get;  set; }
        public string Author { get;  set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
    }
}

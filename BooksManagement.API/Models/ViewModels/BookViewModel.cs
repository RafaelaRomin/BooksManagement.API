namespace BooksManagement.API.Models.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public int PublicationYear { get; private set; }
    }
}

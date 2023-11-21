using BooksManagement.API.Models.InputModels;
using System.Text.Json.Serialization;

namespace BooksManagement.API.Entities
{
    public class Book
    {
        public Book()
        {
        }
        public Book(string title, string author, string isbn, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
        }
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }


        public void UpdateBook(string title, string author, string isbn, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
        }

    }

}

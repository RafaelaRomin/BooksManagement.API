using BooksManagement.API.Models.InputModels;
using System.Text.Json.Serialization;

namespace BooksManagement.API.Entities
{
    public class Book
    {
        protected Book() { }

        public Book(string title, string author, string isbn, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
        }
        [JsonIgnore]
        public int Id { get; private set; }
        [JsonIgnore]
        public string Title { get; private set; }
        [JsonIgnore]
        public string Author { get; private set; }
        [JsonIgnore]
        public string ISBN { get; private set; }
        [JsonIgnore]
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

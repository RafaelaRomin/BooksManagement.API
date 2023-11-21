using BooksManagement.API.Entities;
using BooksManagement.API.Models.ViewModels;

namespace BooksManagement.API.MappingViewModels
{
    public static class MappingBooksViewModel
    {
        public static IEnumerable<BookViewModel> ConvertBookViewModel(
            this IEnumerable<Book> books)
        {
            return (from book in books
                    select new BookViewModel
                    {
                       Author = book.Author,
                       ISBN = book.ISBN,
                       PublicationYear = book.PublicationYear,
                       Title = book.Title,

                    }).ToList();
        }

        public static BookViewModel ConvertBookViewModelById(
            this Book books)
        {
            return new BookViewModel

            {
               Author = books.Author,
               ISBN = books.ISBN,
               PublicationYear = books.PublicationYear,
               Title = books.Title,
            };
        }
    }
}

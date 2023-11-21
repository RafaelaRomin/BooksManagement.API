using BooksManagement.API.Entities;
using BooksManagement.API.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagement.API.MappingViewModels
{
    public static class MappingLoanViewModel
    {
        public static IEnumerable<LoanViewModel> ConvertLoanViewModel(
            this IEnumerable<BookLoan> bookLoans)
        {
            return (from bookLoan in bookLoans
                    select new LoanViewModel
                    {
                        BookName = bookLoan.Book.Title,
                        ClientName = bookLoan.Client.Name,
                        Devolution = bookLoan.Devolution.ToString("dd/MM/yyyy"),
                        LoanDate = bookLoan.LoanDate.ToString("dd/MM/yyyy"),

                    }).ToList();
        }

        public static LoanViewModel ConvertLoanViewModelById(
            this BookLoan bookLoans)
        {
            return new LoanViewModel

            {
                BookName = bookLoans.Book.Title,
                ClientName = bookLoans.Client.Name,
                Devolution = bookLoans.Devolution.ToString("dd/MM/yyyy"),
                LoanDate = bookLoans.LoanDate.ToString("dd/MM/yyyy"),
            };
        }



    }
}

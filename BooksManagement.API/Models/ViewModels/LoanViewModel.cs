using BooksManagement.API.Entities;
using System.Text.Json.Serialization;

namespace BooksManagement.API.Models.ViewModels
{
    public class LoanViewModel
    {
        public string? ClientName { get;  set; }
        public string ? BookName { get;  set; }
        public string LoanDate { get;  set; } 
        public string Devolution { get;  set; } 
    }
   
}

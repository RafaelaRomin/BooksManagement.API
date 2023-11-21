using BooksManagement.API.Entities;
using System.Text.Json.Serialization;

namespace BooksManagement.API.Models.InputModels
{
    public class LoanInputModel
    {
        public int IdClient { get;  set; }
        public int IdBook { get;  set; }
 
    }
}

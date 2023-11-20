namespace BooksManagement.API.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}

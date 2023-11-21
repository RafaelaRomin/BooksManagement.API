using BooksManagement.API.Entities;
using BooksManagement.API.Models.ViewModels;

namespace BooksManagement.API.MappingViewModels
{
    public static class MappingUsersViewModel
    {
        public static IEnumerable<UserViewModel> ConvertUserToViewModel(
            this IEnumerable<User> users)
        {
            return (from user in users
                    select new UserViewModel
                    {
                        Name = user.Name,

                    }).ToList();
        }

        public static UserViewModel ConvertUserByIdViewModel(
            this User users)
        {
            return new UserViewModel
            {
                Name = users.Name,
            };
        }

    }  
}

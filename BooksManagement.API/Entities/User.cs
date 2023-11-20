using System.Text.Json.Serialization;

namespace BooksManagement.API.Entities
{
    public class User
    {
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
        [JsonIgnore]
        public int Id { get; private set; }
        [JsonIgnore]
        public string Name { get; private set; }
        [JsonIgnore]
        public string Email { get; private set; }

        public void UpdateUser(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

}

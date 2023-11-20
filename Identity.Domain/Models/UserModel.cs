using System.Text.Json.Serialization;

namespace Identity.Domain.Models
{
    public class UserModel
    {
        public UserModel(string username, string firstName, string lastName, string email)
        {
            Username = username;
            Enabled = true;
            EmailVerified = true;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("emailVerified")]
        public bool EmailVerified { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}

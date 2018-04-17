using System.ComponentModel.DataAnnotations;
using Contract.Enums;

namespace SI_Platform.Models.Users
{
    public class AddUserModel
    {
        public UserType Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
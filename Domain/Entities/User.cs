using System;
using Contract.Enums;

namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public UserType Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
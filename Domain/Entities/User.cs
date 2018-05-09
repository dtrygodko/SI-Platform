using System;
using System.Collections.Generic;
using Contract.Enums;

namespace Domain.Entities
{
    public class User
    {
        public User()
        {
            Ideas = new HashSet<Idea>();
        }

        public Guid Id { get; set; }
        public UserType Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Idea> Ideas { get; set; }
    }
}
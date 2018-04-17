using System;
using Abstractions.CQRS;
using Contract.Enums;

namespace Contract.Responses.Users
{
    public class UserDTO : IResponse
    {
        public UserDTO(Guid id, UserType type, string firstName, string lastName, string password, string city, string phone, string email)
        {
            Id = id;
            Type = type;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            City = city;
            Phone = phone;
            Email = email;
        }

        public Guid Id { get; }
        public UserType Type { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Password { get; }
        public string City { get; }
        public string Phone { get; }
        public string Email { get; }
    }
}
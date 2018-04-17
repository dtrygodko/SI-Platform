using System;
using Abstractions.CQRS;
using Contract.Responses.Users;

namespace Contract.Requests.Users
{
    public class UserRequest : IRequest<UserDTO>
    {
        public UserRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
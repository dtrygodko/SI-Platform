using System.Collections.Generic;
using Abstractions.CQRS;

namespace Contract.Responses.Users
{
    public class UsersDTO : IResponse
    {
        public UsersDTO(IEnumerable<UserDTO> users)
        {
            Users = users;
        }

        public IEnumerable<UserDTO> Users { get; }
    }
}
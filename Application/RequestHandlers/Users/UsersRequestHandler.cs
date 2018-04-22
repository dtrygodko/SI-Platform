using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.CQRS;
using AutoMapper;
using Contract.Requests.Users;
using Contract.Responses.Users;
using Domain.Repositories.Read;

namespace Application.RequestHandlers.Users
{
    public class UsersRequestHandler : IRequestHandler<UsersRequest, UsersDTO>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersRequestHandler(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UsersDTO> ExecuteAsync(UsersRequest request)
        {
            var usersFromRepo = await _usersRepository.GetAllUsers();

            if (usersFromRepo == null)
            {
                throw new Exception("Users not found");
            }

            var mappedUsers = _mapper.Map<IEnumerable<UserDTO>>(usersFromRepo);

            return new UsersDTO(mappedUsers);
        }
    }
}
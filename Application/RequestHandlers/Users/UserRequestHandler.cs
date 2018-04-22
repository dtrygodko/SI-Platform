using System;
using System.Threading.Tasks;
using Abstractions.CQRS;
using AutoMapper;
using Contract.Requests.Users;
using Contract.Responses.Users;
using Domain.Repositories.Read;

namespace Application.RequestHandlers.Users
{
    public class UserRequestHandler : IRequestHandler<UserRequest, UserDTO>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserRequestHandler(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> ExecuteAsync(UserRequest request)
        {
            var user = await _usersRepository.GetUser(request.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var dto = _mapper.Map<UserDTO>(user);

            return dto;
        }
    }
}
using System;
using System.Threading.Tasks;
using Abstractions.CQRS;
using AutoMapper;
using Contract.Commands.Users;
using Domain.Entities;
using Domain.Repositories.Write;

namespace Application.CommandHandlers.Users
{
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand>
    {
        private readonly Domain.Repositories.Read.IUsersRepository _usersReadRepository;
        private readonly IUsersRepository _usersWriteRepository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(Domain.Repositories.Read.IUsersRepository usersReadRepository, IUsersRepository usersWriteRepository, IMapper mapper)
        {
            _usersReadRepository = usersReadRepository;
            _usersWriteRepository = usersWriteRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(AddUserCommand command)
        {
            if (await _usersReadRepository.GetUser(command.Id) != null)
            {
                throw new Exception("User with same Id already exists");
            }

            if (await _usersReadRepository.GetUser(command.Email.ToLowerInvariant()) != null)
            {
                throw new Exception("User with same Email already exists");
            }

            var entity = _mapper.Map<User>(command);

            await _usersWriteRepository.Add(entity);
        }
    }
}
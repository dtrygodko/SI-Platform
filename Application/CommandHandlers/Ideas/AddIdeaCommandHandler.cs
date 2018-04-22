using System;
using System.Threading.Tasks;
using Abstractions.CQRS;
using AutoMapper;
using Contract.Commands.Ideas;
using Domain.Entities;
using Domain.Repositories.Read;

namespace Application.CommandHandlers.Ideas
{
    public class AddIdeaCommandHandler : ICommandHandler<AddIdeaCommand>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IIdeasRepository _ideasReadRepository;
        private readonly Domain.Repositories.Write.IIdeasRepository _ideasWriteRepository;
        private readonly IMapper _mapper;

        public AddIdeaCommandHandler(IUsersRepository usersRepository, IIdeasRepository ideasReadRepository, Domain.Repositories.Write.IIdeasRepository ideasWriteRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _ideasReadRepository = ideasReadRepository;
            _ideasWriteRepository = ideasWriteRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(AddIdeaCommand command)
        {
            if (await _usersRepository.GetUser(command.AuthorId) == null)
            {
                throw new Exception("User not found");
            }

            if (await _ideasReadRepository.GetIdea(command.Id) != null)
            {
                throw new Exception("Idea with same Id already exists");
            }

            var idea = _mapper.Map<Idea>(command);

            await _ideasWriteRepository.Add(idea);
        }
    }
}
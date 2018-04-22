using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.CQRS;
using AutoMapper;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;
using Domain.Repositories.Read;

namespace Application.RequestHandlers.Ideas
{
    public class GetIdeasForAuthorRequestHandler : IRequestHandler<GetIdeasForAuthorRequest, IdeasDTO>
    {
        private readonly IIdeasRepository _ideasRepository;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public GetIdeasForAuthorRequestHandler(IIdeasRepository ideasRepository, IMapper mapper, IUsersRepository usersRepository)
        {
            _ideasRepository = ideasRepository;
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task<IdeasDTO> ExecuteAsync(GetIdeasForAuthorRequest request)
        {
            var author = await _usersRepository.GetUser(request.AuthorId);

            if (author == null)
            {
                throw new Exception("User not found");
            }

            var ideasFromRepo = await _ideasRepository.GetIdeasForAuthor(request.AuthorId);

            if (ideasFromRepo == null)
            {
                throw new Exception("Ideas not found");
            }

            var mappedIdeas = _mapper.Map<IEnumerable<IdeaDTO>>(ideasFromRepo);

            return new IdeasDTO(mappedIdeas);
        }
    }
}
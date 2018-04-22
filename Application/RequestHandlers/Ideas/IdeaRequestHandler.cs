using System;
using System.Threading.Tasks;
using Abstractions.CQRS;
using AutoMapper;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;
using Domain.Repositories.Read;

namespace Application.RequestHandlers.Ideas
{
    public class IdeaRequestHandler : IRequestHandler<IdeaRequest, IdeaDTO>
    {
        private readonly IIdeasRepository _ideasRepository;
        private readonly IMapper _mapper;

        public IdeaRequestHandler(IIdeasRepository ideasRepository, IMapper mapper)
        {
            _ideasRepository = ideasRepository;
            _mapper = mapper;
        }

        public async Task<IdeaDTO> ExecuteAsync(IdeaRequest request)
        {
            var idea = await _ideasRepository.GetIdea(request.Id);

            if (idea == null)
            {
                throw new Exception("Idea not found");
            }

            var mappedIdea = _mapper.Map<IdeaDTO>(idea);

            return mappedIdea;
        }
    }
}
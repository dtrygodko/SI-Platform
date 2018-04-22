using System;
using Abstractions.CQRS;
using Contract.Responses.Ideas;

namespace Contract.Requests.Ideas
{
    public class IdeaRequest : IRequest<IdeaDTO>
    {
        public IdeaRequest(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; }
    }
}
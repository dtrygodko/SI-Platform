using System;
using Abstractions.CQRS;
using Contract.Responses.Ideas;

namespace Contract.Requests.Ideas
{
    public class GetIdeaForAuthorRequest : IRequest<IdeaDTO>
    {
        public GetIdeaForAuthorRequest(Guid authorId, Guid id)
        {
            AuthorId = authorId;
            Id = id;
        }

        public Guid AuthorId { get; }
        public Guid Id { get; }
    }
}
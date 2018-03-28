using System;
using Abstractions.CQRS;
using Contract.Responses.Ideas;

namespace Contract.Requests.Ideas
{
    public class GetIdeasForAuthorRequest : IRequest<IdeasDTO>
    {
        public GetIdeasForAuthorRequest(Guid authorId)
        {
            AuthorId = authorId;
        }

        public Guid AuthorId { get; private set; }
    }
}
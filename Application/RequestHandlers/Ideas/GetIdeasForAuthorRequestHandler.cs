using System.Threading.Tasks;
using Abstractions.CQRS;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;

namespace Application.RequestHandlers.Ideas
{
    public class GetIdeasForAuthorRequestHandler : IRequestHandler<GetIdeasForAuthorRequest, IdeasDTO>
    {
        public Task<IdeasDTO> ExecuteAsync(GetIdeasForAuthorRequest request)
        {
            return Task.FromResult(new IdeasDTO(null));
        }
    }
}
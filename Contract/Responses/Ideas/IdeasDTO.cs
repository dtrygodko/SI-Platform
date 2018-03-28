using System.Collections.Generic;
using Abstractions.CQRS;

namespace Contract.Responses.Ideas
{
    public class IdeasDTO : IResponse
    {
        public IdeasDTO(IEnumerable<IdeaDTO> ideas)
        {
            Ideas = ideas;
        }

        public IEnumerable<IdeaDTO> Ideas { get; private set; }
    }
}
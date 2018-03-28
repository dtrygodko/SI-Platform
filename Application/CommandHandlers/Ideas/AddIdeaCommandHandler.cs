using System.Threading.Tasks;
using Abstractions.CQRS;
using Contract.Commands.Ideas;

namespace Application.CommandHandlers.Ideas
{
    public class AddIdeaCommandHandler : ICommandHandler<AddIdeaCommand>
    {
        public Task ExecuteAsync(AddIdeaCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
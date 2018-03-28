using System;
using Abstractions.CQRS;

namespace Contract.Commands.Ideas
{
    public class AddIdeaCommand : ICommand
    {
        public AddIdeaCommand(Guid id, string title, string description, Guid authorId, DateTime startFundingDate, DateTime stopFundingDate)
        {
            Id = id;
            Title = title;
            Description = description;
            AuthorId = authorId;
            StartFundingDate = startFundingDate;
            StopFundingDate = stopFundingDate;
        }

        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }
        
        public Guid AuthorId { get; private set; }
        
        public DateTime StartFundingDate { get; private set; }
        
        public DateTime StopFundingDate { get; private set; }
    }
}
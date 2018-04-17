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

        public Guid Id { get; }

        public string Title { get; }

        public string Description { get; }
        
        public Guid AuthorId { get; }
        
        public DateTime StartFundingDate { get; }
        
        public DateTime StopFundingDate { get; }
    }
}
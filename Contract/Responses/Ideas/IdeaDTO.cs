using System;
using Abstractions.CQRS;
using Contract.Enums;

namespace Contract.Responses.Ideas
{
    public class IdeaDTO : IResponse
    {
        public IdeaDTO(Guid id, string title, string description, Guid authorId, DateTime startFundingDate, DateTime stopFundingDate, IdeaStatus status)
        {
            Id = id;
            Title = title;
            Description = description;
            AuthorId = authorId;
            StartFundingDate = startFundingDate;
            StopFundingDate = stopFundingDate;
            Status = status;
        }

        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public Guid AuthorId { get; private set; }

        public DateTime StartFundingDate { get; private set; }

        public DateTime StopFundingDate { get; private set; }

        public IdeaStatus Status { get; private set; }
    }
}
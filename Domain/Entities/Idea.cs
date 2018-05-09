using System;
using Contract.Enums;

namespace Domain.Entities
{
    public class Idea
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        public User Author { get; set; }

        public DateTime StartFundingDate { get; set; }

        public DateTime StopFundingDate { get; set; }

        public IdeaStatus Status { get; set; }
    }
}
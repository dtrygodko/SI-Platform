using System;
using System.Collections.Generic;
using Contract.Enums;

namespace Domain.Entities
{
    public class Idea
    {
        public Guid Id { get; set; }

        public string Title { get; private set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        public User Author { get; private set; }

        public DateTime StartFundingDate { get; private set; }

        public DateTime StopFundingDate { get; private set; }

        public IdeaStatus Status { get; private set; }

        public double Target { get; private set; }

        public double Fullfillment { get; private set; }

        public ICollection<Transaction> Transactions { get; private set; }

        public void Fill(double amount)
        {
            Fullfillment += amount;

            if (Fullfillment >= Target)
            {
                Status = IdeaStatus.Finished;
            }
        }
    }
}
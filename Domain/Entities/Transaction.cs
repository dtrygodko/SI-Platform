using System;

namespace Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public Guid IdeaId { get; set; }

        public Idea Idea { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
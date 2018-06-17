using System;
using Abstractions.CQRS;

namespace Contract.Commands.Ideas
{
    public class FundIdeaCommand : ICommand
    {
        public FundIdeaCommand(Guid ideaId, Guid transactionId, double amount, DateTime date)
        {
            IdeaId = ideaId;
            TransactionId = transactionId;
            Amount = amount;
            Date = date;
        }

        public Guid IdeaId { get; }

        public Guid TransactionId { get; }

        public double Amount { get; }

        public DateTime Date { get; }
    }
}
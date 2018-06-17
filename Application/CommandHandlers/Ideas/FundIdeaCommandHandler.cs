using System;
using System.Threading.Tasks;
using Abstractions.CQRS;
using AutoMapper;
using Contract.Commands.Ideas;
using Domain.Entities;
using Domain.Repositories.Write;

namespace Application.CommandHandlers.Ideas
{
    public class FundIdeaCommandHandler : ICommandHandler<FundIdeaCommand>
    {
        private readonly IIdeasRepository _ideasWriteRepository;
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IMapper _mapper;

        public FundIdeaCommandHandler(
            IIdeasRepository ideasWriteRepository,
            ITransactionsRepository transactionsRepository, IMapper mapper)
        {
            _ideasWriteRepository = ideasWriteRepository;
            _transactionsRepository = transactionsRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(FundIdeaCommand command)
        {
            var idea = await _ideasWriteRepository.Get(command.IdeaId);

            if (idea == null)
            {
                throw new Exception("Idea not found");
            }

            var transaction = _mapper.Map<Transaction>(command);

            await _transactionsRepository.Add(transaction);

            idea.Fill(transaction.Amount);

            await _ideasWriteRepository.Save(idea);
        }
    }
}
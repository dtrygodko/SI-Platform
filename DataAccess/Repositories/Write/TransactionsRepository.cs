using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories.Write;

namespace DataAccess.Repositories.Write
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly SIPlatformDbContext _dbContext;

        public TransactionsRepository(SIPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);

            await _dbContext.SaveChangesAsync();
        }
    }
}
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories.Write;

namespace DataAccess.Repositories.Write
{
    public class IdeasRepository : IIdeasRepository
    {
        private readonly SIPlatformDbContext _dbContext;

        public IdeasRepository(SIPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Idea idea)
        {
            await _dbContext.Ideas.AddAsync(idea);

            await _dbContext.SaveChangesAsync();
        }
    }
}
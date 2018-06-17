using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories.Write;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Write
{
    public class IdeasRepository : IIdeasRepository
    {
        private readonly SIPlatformDbContext _dbContext;

        public IdeasRepository(SIPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Save(Idea idea)
        {
            _dbContext.AddOrUpdate(idea);

           await _dbContext.SaveChangesAsync();
        }

        public async Task<Idea> Get(Guid id)
        {
            return await _dbContext.Ideas.SingleOrDefaultAsync(i => i.Id == id);
        }
    }
}
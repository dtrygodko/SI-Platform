using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories.Read;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Read
{
    public class IdeasRepository : IIdeasRepository
    {
        private readonly SIPlatformDbContext _dbContext;

        public IdeasRepository(SIPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Idea>> GetIdeasForAuthor(Guid authorId)
        {
            return await _dbContext.Set<Idea>().AsNoTracking().Where(i => i.AuthorId == authorId).ToListAsync();
        }

        public async Task<Idea> GetIdea(Guid id)
        {
            return await _dbContext.Set<Idea>().AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories.Read;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Read
{
    public class UsersRepository : IUsersRepository
    {
        private readonly SIPlatformDbContext _dbContext;

        public UsersRepository(SIPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dbContext.Set<User>().AsNoTracking().ToListAsync();
        }

        public async Task<User> GetUser(Guid id)
        {
            return await _dbContext.Set<User>().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUser(string email)
        {
            return await _dbContext.Set<User>().AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
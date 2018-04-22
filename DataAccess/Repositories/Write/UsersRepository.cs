using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories.Write;

namespace DataAccess.Repositories.Write
{
    public class UsersRepository : IUsersRepository
    {
        private readonly SIPlatformDbContext _dbContext;

        public UsersRepository(SIPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess
{
    public class TestDbContextFactory : IDesignTimeDbContextFactory<SIPlatformDbContext>
    {
        public SIPlatformDbContext CreateDbContext(string[] args)
        {
            DbContextOptions<SIPlatformDbContext> options = new DbContextOptionsBuilder<SIPlatformDbContext>()
                .UseSqlServer("Server=.\\SQLEXPRESS;Database=SI-Platform;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=SSPI").Options;

            return new SIPlatformDbContext(options);
        }
    }
}
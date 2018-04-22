using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SIPlatformDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Idea> Ideas { get; set; }

        public SIPlatformDbContext(DbContextOptions<SIPlatformDbContext> options) : base(options)
        {
            
        }
    }

    public class MockedDbContext
    {
        public static SIPlatformDbContext Create()
        {
            DbContextOptions<SIPlatformDbContext> options = new DbContextOptionsBuilder<SIPlatformDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var mockedContext = new SIPlatformDbContext(options);

            return mockedContext;
        }
    }
}
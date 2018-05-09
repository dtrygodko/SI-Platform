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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Idea>(entity =>
            {
                entity.HasOne(i => i.Author).WithMany(u => u.Ideas).HasForeignKey(i => i.AuthorId).HasPrincipalKey(u => u.Id);
                entity.Property(e => e.Id).ValueGeneratedNever().IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
                {
                    entity.HasMany(u => u.Ideas).WithOne(i => i.Author).HasPrincipalKey(u => u.Id)
                        .HasForeignKey(i => i.AuthorId);
                    entity.Property(e => e.Id).ValueGeneratedNever().IsRequired();
                });

            base.OnModelCreating(modelBuilder);
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
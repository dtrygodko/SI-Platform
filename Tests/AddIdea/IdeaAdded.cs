using System;
using System.Linq;
using Contract.Commands.Ideas;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.AddIdea
{
    public class IdeaAdded : BaseScenario
    {
        private readonly Guid _ideaId = Guid.NewGuid();
        private readonly Guid _authorId = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Users.Add(new User
            {
                Id = _authorId
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendCommand(new AddIdeaCommand(_ideaId, "Test", "Test", _authorId, DateTime.UtcNow.AddMinutes(-5), DateTime.UtcNow.AddMinutes(5)));
        }

        [Test]
        public void IdeaAddedSuccessfully()
        {
            var context = Resolve<SIPlatformDbContext>();

            var idea = context.Ideas.FirstOrDefault(i => i.Id == _ideaId && i.AuthorId == _authorId);

            Assert.IsNotNull(idea);
        }

        public void NoException()
        {
            Assert.IsNull(Exception);
        }
    }
}
using System;
using System.Linq;
using Contract.Commands.Ideas;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.AddIdea
{
    public class SameId : BaseScenario
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

            context.Ideas.Add(new Idea
            {
                Id = _ideaId,
                AuthorId = _authorId
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendCommand(new AddIdeaCommand(_ideaId, "Test1", "Test", _authorId, DateTime.UtcNow.AddMinutes(-5), DateTime.UtcNow.AddMinutes(5)));
        }

        [Test]
        public void IdeaNotAdded()
        {
            var context = Resolve<SIPlatformDbContext>();

            var idea = context.Ideas.FirstOrDefault(i => i.Title == "Test1");

            Assert.IsNull(idea);
        }

        [Test]
        public void HasException()
        {
            Assert.AreEqual("Idea with same Id already exists", Exception.Message);
        }
    }
}
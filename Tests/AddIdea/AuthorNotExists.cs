using System;
using System.Linq;
using Contract.Commands.Ideas;
using DataAccess;
using NUnit.Framework;

namespace Tests.AddIdea
{
    public class AuthorNotExists : BaseScenario
    {
        private readonly Guid _ideaId = Guid.NewGuid();

        protected override void Given()
        {
            
        }

        protected override void When()
        {
            SendCommand(new AddIdeaCommand(_ideaId, "Test", "Test", Guid.NewGuid(), DateTime.UtcNow.AddMinutes(-5), DateTime.UtcNow.AddMinutes(5)));
        }

        [Test]
        public void IdeaNotAdded()
        {
            var context = Resolve<SIPlatformDbContext>();

            var idea = context.Ideas.FirstOrDefault(i => i.Id == _ideaId);

            Assert.IsNull(idea);
        }

        [Test]
        public void HasException()
        {
            Assert.AreEqual("User not found", Exception.Message);
        }
    }
}
using System;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.SingleIdeaRequest
{
    public class SuccessRequest : BaseScenario
    {
        private readonly Guid _ideaId = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Ideas.Add(new Idea
            {
                Id = _ideaId,
                Description = "Test"
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendRequest<IdeaRequest, IdeaDTO>(new IdeaRequest(_ideaId));
        }

        [Test]
        public void IdeaFound()
        {
            var response = Response as IdeaDTO;

            Assert.AreEqual(_ideaId, response.Id);
            Assert.AreEqual("Test", response.Description);
        }

        [Test]
        public void NoExceptions()
        {
            Assert.IsNull(Exception);
        }
    }
}
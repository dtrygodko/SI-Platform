using System;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.SingleIdeaRequest
{
    public class WrongId : BaseScenario
    {
        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Ideas.Add(new Idea
            {
                Id = Guid.NewGuid(),
                AuthorId = Guid.NewGuid()
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendRequest<IdeaRequest, IdeaDTO>(new IdeaRequest(Guid.NewGuid()));
        }

        [Test]
        public void IdeaNotFound()
        {
            Assert.IsNull(Response);
        }

        [Test]
        public void HasException()
        {
            Assert.AreEqual("Idea not found", Exception.Message);
        }
    }
}
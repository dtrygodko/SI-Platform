using System;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;
using NUnit.Framework;

namespace Tests.SingleIdeaRequest
{
    public class NoIdeas : BaseScenario
    {
        protected override void Given()
        {
            
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
using System;
using System.Linq;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;
using NUnit.Framework;

namespace Tests.IdeasForAuthorRequest
{
    public class NoIdeas : BaseScenario
    {
        protected override void Given()
        {

        }

        protected override void When()
        {
            SendRequest<GetIdeasForAuthorRequest, IdeasDTO>(new GetIdeasForAuthorRequest(Guid.NewGuid()));
        }

        [Test]
        public void IdeaNotFound()
        {
            Assert.IsNull(Response);
        }

        [Test]
        public void HasException()
        {
            Assert.AreEqual("User not found", Exception.Message);
        }
    }
}
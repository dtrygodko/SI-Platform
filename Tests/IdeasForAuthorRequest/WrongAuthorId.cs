using System;
using System.Linq;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.IdeasForAuthorRequest
{
    public class WrongAuthorId : BaseScenario
    {
        private readonly Guid _authorId = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Ideas.Add(new Idea
            {
                Id = Guid.NewGuid(),
                AuthorId = _authorId
            });

            context.Users.Add(new User
            {
                Id = _authorId
            });

            context.SaveChanges();
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
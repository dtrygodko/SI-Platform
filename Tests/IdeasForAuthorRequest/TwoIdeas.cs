using System;
using System.Linq;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.IdeasForAuthorRequest
{
    public class TwoIdeas : BaseScenario
    {
        private readonly Guid _authorId = Guid.NewGuid();
        private readonly Guid _ideaId1 = Guid.NewGuid();
        private readonly Guid _ideaId2 = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Ideas.Add(new Idea
            {
                Id = _ideaId1,
                AuthorId = _authorId,
                Description = "Test"
            });
            context.Ideas.Add(new Idea
            {
                Id = _ideaId2,
                AuthorId = _authorId,
                Description = "Test"
            });

            context.Users.Add(new User
            {
                Id = _authorId
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendRequest<GetIdeasForAuthorRequest, IdeasDTO>(new GetIdeasForAuthorRequest(_authorId));
        }

        [Test]
        public void TwoIdeasFound()
        {
            var response = Response as IdeasDTO;

            Assert.AreEqual(2, response.Ideas.Count());
        }

        [Test]
        public void IdeasFound()
        {
            var response = Response as IdeasDTO;

            Assert.IsNotNull(response.Ideas.FirstOrDefault(i => i.Id == _ideaId1));
            Assert.IsNotNull(response.Ideas.FirstOrDefault(i => i.Id == _ideaId2));
        }

        [Test]
        public void NoExceptions()
        {
            Assert.IsNull(Exception);
        }
    }
}
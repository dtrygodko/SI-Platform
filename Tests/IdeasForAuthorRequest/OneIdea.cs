using System;
using System.Linq;
using Contract.Requests.Ideas;
using Contract.Responses.Ideas;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.IdeasForAuthorRequest
{
    public class OneIdea : BaseScenario
    {
        private readonly Guid _authorId = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Ideas.Add(new Idea
            {
                Id = Guid.NewGuid(),
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
        public void OneIdeaFound()
        {
            var response = Response as IdeasDTO;

            Assert.AreEqual(1, response.Ideas.Count());
        }

        [Test]
        public void IdeaFound()
        {
            var response = Response as IdeasDTO;

            var idea = response.Ideas.First();

            Assert.AreEqual("Test", idea.Description);
        }

        [Test]
        public void NoExceptions()
        {
            Assert.IsNull(Exception);
        }
    }
}
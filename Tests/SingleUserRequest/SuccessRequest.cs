using System;
using Contract.Requests.Users;
using Contract.Responses.Users;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.SingleUserRequest
{
    public class SuccessRequest : BaseScenario
    {
        private readonly Guid _userId = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Users.Add(new User
            {
                Id = _userId,
                FirstName = "Test"
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendRequest<UserRequest, UserDTO>(new UserRequest(_userId));
        }

        [Test]
        public void IdeaFound()
        {
            var response = Response as UserDTO;

            Assert.AreEqual(_userId, response.Id);
            Assert.AreEqual("Test", response.FirstName);
        }

        [Test]
        public void NoExceptions()
        {
            Assert.IsNull(Exception);
        }
    }
}
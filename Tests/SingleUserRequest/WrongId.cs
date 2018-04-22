using System;
using Contract.Requests.Users;
using Contract.Responses.Users;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.SingleUserRequest
{
    public class WrongId : BaseScenario
    {
        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Users.Add(new User
            {
                Id = Guid.NewGuid()
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendRequest<UserRequest, UserDTO>(new UserRequest(Guid.NewGuid()));
        }

        [Test]
        public void UserNotFound()
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
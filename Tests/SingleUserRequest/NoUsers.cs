using System;
using Contract.Requests.Users;
using Contract.Responses.Users;
using NUnit.Framework;

namespace Tests.SingleUserRequest
{
    public class NoUsers : BaseScenario
    {
        protected override void Given()
        {
            
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
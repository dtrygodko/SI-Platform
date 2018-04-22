using System.Linq;
using Contract.Requests.Users;
using Contract.Responses.Users;
using NUnit.Framework;

namespace Tests.AllUsersRequest
{
    public class NoUsers : BaseScenario
    {
        protected override void Given()
        {
            
        }

        protected override void When()
        {
            SendRequest<UsersRequest, UsersDTO>(new UsersRequest());
        }

        [Test]
        public void UserNotFound()
        {
            var response = Response as UsersDTO;

            Assert.AreEqual(0, response.Users.Count());
        }

        [Test]
        public void NoExceptions()
        {
            Assert.IsNull(Exception);
        }
    }
}
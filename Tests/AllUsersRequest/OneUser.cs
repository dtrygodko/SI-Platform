using System;
using System.Linq;
using Contract.Requests.Users;
using Contract.Responses.Users;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.AllUsersRequest
{
    public class OneUser : BaseScenario
    {
        private readonly Guid _userId = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Users.Add(new User
            {
                Id = _userId
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendRequest<UsersRequest, UsersDTO>(new UsersRequest());
        }

        [Test]
        public void OneUserFound()
        {
            var response = Response as UsersDTO;

            Assert.AreEqual(1, response.Users.Count());

            var user = response.Users.First();

            Assert.AreEqual(_userId, user.Id);
        }

        [Test]
        public void NoExceptions()
        {
            Assert.IsNull(Exception);
        }
    }
}
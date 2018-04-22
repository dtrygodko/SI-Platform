using System;
using System.Linq;
using Contract.Requests.Users;
using Contract.Responses.Users;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.AllUsersRequest
{
    public class TwoUsers : BaseScenario
    {
        private readonly Guid _userId1 = Guid.NewGuid();
        private readonly Guid _userId2 = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Users.Add(new User
            {
                Id = _userId1
            });
            context.Users.Add(new User
            {
                Id = _userId2
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendRequest<UsersRequest, UsersDTO>(new UsersRequest());
        }

        [Test]
        public void TwoUsersFound()
        {
            var response = Response as UsersDTO;

            Assert.AreEqual(2, response.Users.Count());

            Assert.IsNotNull(response.Users.SingleOrDefault(u => u.Id == _userId1));
            Assert.IsNotNull(response.Users.SingleOrDefault(u => u.Id == _userId2));
        }

        [Test]
        public void NoExceptions()
        {
            Assert.IsNull(Exception);
        }
    }
}
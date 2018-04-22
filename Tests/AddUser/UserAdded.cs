using System;
using System.Linq;
using Contract.Commands.Users;
using Contract.Enums;
using DataAccess;
using NUnit.Framework;

namespace Tests.AddUser
{
    public class UserAdded : BaseScenario
    {
        private readonly Guid _userId = Guid.NewGuid();

        protected override void Given()
        {
            
        }

        protected override void When()
        {
            SendCommand(new AddUserCommand(_userId, UserType.RegularUser, "Test", "Test", "Test", "Test", "Test", "teSt@mail.com"));
        }

        [Test]
        public void UserAddedSuccessfully()
        {
            var context = Resolve<SIPlatformDbContext>();

            var user = context.Users.FirstOrDefault(u => u.Id == _userId);

            Assert.IsNotNull(user);
        }

        [Test]
        public void NoException()
        {
            Assert.IsNull(Exception);
        }
    }
}
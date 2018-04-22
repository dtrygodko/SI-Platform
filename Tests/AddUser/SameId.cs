using System;
using System.Linq;
using Contract.Commands.Users;
using Contract.Enums;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.AddUser
{
    public class SameId : BaseScenario
    {
        private readonly Guid _userId = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Users.Add(new User
            {
                Id = _userId,
                FirstName = "Test",
                Email = "test@mail.com"
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendCommand(new AddUserCommand(_userId, UserType.RegularUser, "Test", "Test", "Test", "Test", "Test", "test1@mail.com"));
        }

        [Test]
        public void UserNotAdded()
        {
            var context = Resolve<SIPlatformDbContext>();

            var user = context.Users.FirstOrDefault(u => u.Email == "test1@mail.com");

            Assert.IsNull(user);
        }

        [Test]
        public void HasException()
        {
            Assert.AreEqual("User with same Id already exists", Exception.Message);
        }
    }
}
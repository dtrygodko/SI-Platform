using System;
using System.Linq;
using Contract.Commands.Users;
using Contract.Enums;
using DataAccess;
using Domain.Entities;
using NUnit.Framework;

namespace Tests.AddUser
{
    public class SameEmail : BaseScenario
    {
        private readonly string _userEmail = "test@mail.com";
        private readonly Guid _newUserId = Guid.NewGuid();

        protected override void Given()
        {
            var context = Resolve<SIPlatformDbContext>();

            context.Users.Add(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                Email = _userEmail
            });

            context.SaveChanges();
        }

        protected override void When()
        {
            SendCommand(new AddUserCommand(_newUserId, UserType.RegularUser, "Test", "Test", "Test", "Test", "Test", _userEmail.ToUpperInvariant()));
        }

        [Test]
        public void UserNotAdded()
        {
            var context = Resolve<SIPlatformDbContext>();

            var user = context.Users.FirstOrDefault(u => u.Id == _newUserId);

            Assert.IsNull(user);
        }

        [Test]
        public void HasException()
        {
            Assert.AreEqual("User with same Email already exists", Exception.Message);
        }
    }
}
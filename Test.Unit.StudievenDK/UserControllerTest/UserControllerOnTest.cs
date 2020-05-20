using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using NSubstitute;
using NuGet.Frameworks;
using NUnit.Framework;
using StudievenDK.Controllers;
using StudievenDK.Data;
using StudievenDK.Models;
using StudievenDK.Models.Login;


namespace Test.Unit.StudievenDK.UserControllerTest
{
    [TestFixture]
    public class UserControllerOnTest
    {
        private IApplicationDbContext _context;
        private UserController _userController;
        private IUserRepository _userRepository;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IApplicationDbContext>();
            _userRepository = Substitute.For<IUserRepository>();
            _userController = new UserController(_context, _userRepository);
        }


        [Test]
        public async Task Test_Searching_For_A_User()
        {
            var user = new ApplicationUser()
            {
                UserName = "au555555@uni.au.dk"
            };

            _userRepository.getUser(user.UserName).Returns(user);

            var response = await (_userController.Search("au555555@uni.au.dk"));
            var test = (ViewResult) response;

            Assert.AreEqual(test.Model.ToString(), user.UserName);
        }

        [Test]
        public async Task Test_Searching_For_A_User_Who_Does_Not_Exist()
        {
            var user = new ApplicationUser()
            {
                UserName = "au555555@uni.au.dk"
            };

            _userRepository.getUser(user.UserName).Returns(user);

            var response = await (_userController.Search("au200000@uni.au.dk"));
            var test = (IStatusCodeActionResult)response;

            Assert.AreEqual(404, test.StatusCode);
        }
    }
}
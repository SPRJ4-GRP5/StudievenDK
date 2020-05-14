using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using NSubstitute;
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
        private IApplicationDbContext context;
        private UserController _userController;
        private IUserRepository _userRepository;

        [SetUp]
        public void setup()
        {
            context = Substitute.For<IApplicationDbContext>();
            _userRepository = Substitute.For<IUserRepository>();
            _userController = new UserController(context, _userRepository);

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
            //Assert.ThaThatt(resp);
            //Assert.AreEqual(1,1);
            //Assert.That(response, );

            //var mockContext = Substitute.For<IApplicationDbContext>();
            //mockContext.MApplicationUsers.Return




            //var controller = new UserController(db);
            //var result = controller.Search("au555555@uni.au.dk") as ViewResult;
            //Assert.AreEqual("Search", result.ViewName);
        }
    }
}

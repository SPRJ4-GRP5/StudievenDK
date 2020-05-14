﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        protected DbContextOptions<User> ContextOptions { get; }

        public UserControllerOnTest(DbContextOptions<User> contextOptions)
        {
            ContextOptions = contextOptions;
        }



        [Test]
        public void Test_Searching_For_A_User()
        {
            var user = new ApplicationUser()
            {
                UserName = "au555555@uni.au.dk"
            };

            var db = new Mock<>(user);


            var controller = new UserController(db);
            var result = controller.Search("au555555@uni.au.dk") as ViewResult;
            Assert.AreEqual("Search", result.ViewName);
        }
    }
}

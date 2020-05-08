using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using StudievenDK.Data;
using StudievenDK.Models;
using StudievenDK.Controllers;
using Microsoft.AspNetCore.Mvc;
using Assert = NUnit.Framework.Assert;
using Microsoft.VisualBasic.CompilerServices;

namespace Test.Unit.StudievenDK
{
    [TestFixture]
    public class MainListControllerTest
    {
        private readonly ApplicationDbContext _context;
        private MainlistController uut;
        [SetUp]
        public void Setup()
        {
            uut = new MainlistController(_context); // make a new instance of mainlistcontroller
        }

        [TestMethod]
        public void TestMainlistIndex()
        {
               
            var result = uut.Index() as ViewResult; //invoker controllerens action method
            Assert.AreEqual("Index", result.);       //checks whether or not th view returns index() action in index view.

        }

        [TestMethod]
        public void TestMainlistDetails()
        {
            var result = uut.Details(2) as ViewResult; //invoker controllerens action method
            Assert.AreEqual("Details", result.ViewName);       //checks whether or not th view returns details() action in index view.

        }




    }
}

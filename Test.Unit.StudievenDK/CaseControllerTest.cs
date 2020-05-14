using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using NUnit.Framework;
using StudievenDK.Controllers;
using StudievenDK.Data;
using NSubstitute;

namespace Test.Unit.StudievenDK
{
    class CaseControllerTest
    {
        [SetUp]
        public void Setup()
        {
            ApplicationDbContext _applicationDbContext = Substitute.For<ApplicationDbContext>();
            IWebHostEnvironment _webHostEnvironment = Substitute.For<IWebHostEnvironment>();

            CasesController _uut = new CasesController(_applicationDbContext, _webHostEnvironment);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}

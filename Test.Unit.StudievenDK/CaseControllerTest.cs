using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudievenDK.Controllers;
using StudievenDK.Data;
using NSubstitute;
using StudievenDK.Models;

namespace Test.Unit.StudievenDK
{
    class CaseControllerTest
    {
        private ApplicationDbContext _applicationDbContext;
        private IWebHostEnvironment _webHostEnvironment;
        private CasesController _uut;

        [SetUp]
        public void Setup()
        {
            _applicationDbContext = Substitute.For<ApplicationDbContext>();
            _webHostEnvironment = Substitute.For<IWebHostEnvironment>();

            _uut = new CasesController(_applicationDbContext, _webHostEnvironment);
        }

        [Test]
        public async void Index_Get_View()
        {
            var _result = await _uut.Index();

            Assert.IsInstanceOf(typeof(CasesController), _uut);
        }
    }
}

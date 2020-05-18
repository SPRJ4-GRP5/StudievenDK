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

            var test = (ViewResult) _result;

            Assert.AreEqual(test.Model.ToString(), );
        }


        private List<Case> dummydata()
        {
            var _case = new List<Case>();
            var _course = new Course();

            _case.Add(new Case()
            {
                CaseId = 1,
                Text = "I need help for this button on my interface",
                Subject = "GUI",
                Deadline = new DateTime(2020, 5, 27),
                Course = _course
            });

            _case.Add(new Case()
            {
                CaseId = 1,
                Text = "What is this thread communication doing",
                Subject = "ISU",
                Deadline = new DateTime(2021, 5, 27),
                Course = _course
            });

            return _case;
        }
    }
}

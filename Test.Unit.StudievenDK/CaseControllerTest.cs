﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudievenDK.Controllers;
using StudievenDK.Data;
using NSubstitute;
using StudievenDK.Models;
using Assert = NUnit.Framework.Assert;
using Microsoft.VisualBasic.CompilerServices;
using System.Linq;
using NUnit.Framework.Constraints;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test.Unit.StudievenDK
{
    class CaseControllerTest
    {
        private ApplicationDbContext _applicationDbContext;
        private SqliteConnection _connection;
        private DbContextOptions<ApplicationDbContext> _options;

        private IWebHostEnvironment _webHostEnvironment;
        private CasesController _uut;

        [SetUp]
        public void Setup()
        {
            //_applicationDbContext = Substitute.For<ApplicationDbContext>();
            _webHostEnvironment = Substitute.For<IWebHostEnvironment>();
            
            _connection = new SqliteConnection("DataSource=:memory");   // ...
            _connection.Open();
            _options = new DbContextOptions<ApplicationDbContext>().UseSqlite(_connection).Options;

            _uut = new CasesController(_applicationDbContext, _webHostEnvironment);
        }

        [Test]
        public async Task IndexCase_GetView()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                var _result = (ViewResult)await _uut.Index();

                Assert.That(_result.ViewName, Is.EqualTo("Index"));
            }
            
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
                CaseId = 2,
                Text = "What is this thread communication doing",
                Subject = "ISU",
                Deadline = new DateTime(2021, 5, 27),
                Course = _course
            });

            return _case;
        }
    }
}

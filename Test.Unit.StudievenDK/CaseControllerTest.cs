using System;
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
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.CodeAnalysis.Differencing;
using NUnit.Framework.Constraints;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test.Unit.StudievenDK
{
    public class CaseControllerTest
    {
        private ApplicationDbContext _applicationDbContext;
        private SqliteConnection _connection;
        private DbContextOptions<ApplicationDbContext> _options;

        private IWebHostEnvironment _webHostEnvironment;
        private CasesController _uut;

        //arrange
        [SetUp]
        public void Setup()
        {
            _webHostEnvironment = Substitute.For<IWebHostEnvironment>();
            
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(_connection).Options;
            _applicationDbContext = new ApplicationDbContext(_options);

            _uut = new CasesController(_applicationDbContext, _webHostEnvironment);
        }

        [Test]
        public async Task IndexCase_GetAmountOfCases()
        {
            await using var context = _applicationDbContext;
            context.Database.EnsureCreated();

            var result = await _uut.Index() as ViewResult;
            var model = result.Model as List<Case>;

            Assert.That(model.Count().Equals(5));
        }

        [Test]
        public async Task HttpGet_GetCases_AmountOfCases()
        {
            await using var context = _applicationDbContext;
            context.Database.EnsureCreated();

            var result = _uut.GetCases().GetAwaiter().GetResult();
            var model = result.Value as List<Case>;

            Assert.That(model.Count.Equals(5));
        }

        [TestCase(5)]
        public async Task HttpGet_GetCaseInfo(int id)
        {
            await using var context = _applicationDbContext;
            context.Database.EnsureCreated();

            var result = _uut.GetCaseInfo(id).Result;
            var model = result.Value as Case;

            Assert.That(model.CaseId, Is.EqualTo(id));
        }

        [Test]
        public void HttpGetCreateCaseView()
        {
            var result = _uut.Create();
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task HttpPostCreateCase()
        {

        }

        [Test]
        public async Task HttpGetEditCase()
        {
            
            await using var context = _applicationDbContext;
            context.Database.EnsureCreated();


            //var result = _uut.Edit(edit).Result as ViewResult;
            //var test = (IStatusCodeActionResult) result;

            //Assert.AreEqual(200, test.StatusCode);

            EditDTO _edit = new EditDTO();

            var result = _uut.Edit(_edit);
            var ressss = result.Id;

            Assert.IsTrue();

        }

        [Test]
        public async Task HttpPostEditCase(Case _case)
        {
	        
        }




        [Test]
        public async Task AssignedCases_getAmountOfCases()
        {
	        await using var context = _applicationDbContext;
            context.Database.EnsureCreated();

            var result = await _uut.AssignedCases() as ViewResult;
            var model = result.Model as List<Case>;

            Assert.That(model.Count().Equals(5));
        }


        [TestCase(2 )]
        public async Task GetCase_ReturnSpecificCase(EditDTO idDto)
        {
	        await using var context = _applicationDbContext;
	        context.Database.EnsureCreated();

            //var result = await _uut.GetCase(idDto).ConfigureAwait().GetAwaiter().GetResult();
            //EditDTO tempIdDto = new EditDTO()
            //{
            // id = idDto
            //};


            var result = _uut.GetCase(idDto).Result;
            var model = result.Value as Case;
            Assert.That(model.CaseId,Is.EqualTo(idDto.id));
        }

        [Test]
        public async Task HttpGetDeleteCase(EditDTO delete)
        {

        }

        [Test]
        public async Task HttpPostDeleteCaseConfirmed(Case _case)
        {

        }

          

        [Test]
        public async Task HttpGet_TestLeaveAssignedCase(EditDTO delete)
        {
            
        }
    }
}

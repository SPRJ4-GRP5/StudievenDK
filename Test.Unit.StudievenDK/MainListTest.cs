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
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.Linq;
using NUnit.Framework.Constraints;
using System.Threading.Tasks;
namespace Test.Unit.StudievenDK
{
    public class MainlistTest
    {
        private DbContextOptions<ApplicationDbContext> _options;
        private SqliteConnection _connection;
        private MainlistController _uut;

        public MainlistTest()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(_connection).Options;
        }

        [Test]
        public void CourseDataIsSeeded()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureCreated();
                Assert.IsNotEmpty(context.Course.ToList());
            }
        }

        [Test]
        public async Task GetNoParametersAsync()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index() as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.That(model.Cases.Count().Equals(5));
            }
        }

        [Test]
        public async Task GetSearchString()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index("hjaelp") as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.That(model.Cases.Count().Equals(2));
            }
        }

        [Test]
        public async Task GetSearchStringPlusProgramme()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index("hjaelp", "IKT", "0", "0", 0) as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.AreEqual(2, model.Cases.Count());

            }

        }

        [Test]
        public async Task GetSearchStringPlusFaculty()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index("hjaelp", "0", "Technical Sciences", "0", 0) as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.AreEqual(2, model.Cases.Count());

            }

        }

        [Test]
        public async Task GetSearchStringPlusCourse()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index("hjaelp", "0", "0", "GUI", 0) as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.AreEqual(1, model.Cases.Count());

            }

        }


        [Test]
        public async Task GetSearchStringPlusTerm()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index("Jeg", "0", "0", "0", 4) as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.AreEqual(2, model.Cases.Count());
            }

        }

        //Fejl i at kalde Index() med searchString = null eller "" -Trang og Alexander
        string JegString = "Jeg";

        [Test]
        public async Task Get_ProgrammePlusFaculty()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index(JegString, "IKT", "Technical Sciences", "0", 0) as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.AreEqual(2, model.Cases.Count());
            }
        }

        [Test]
        public async Task Get_ProgrammePlusCourse()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                var JegString = "Jeg";
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index(JegString, "IKT", "0", "GUI", 4) as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.AreEqual(1, model.Cases.Count());
            }
        }

        [Test]
        public async Task Get_ProgrammePlusTerm()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                var JegString = "Jeg";
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index(JegString, "IKT", "0", "0", 4) as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.AreEqual(2, model.Cases.Count());
            }
        }

        [Test]
        public async Task Get_FacultyPlusCourse()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                var JegString = "Jeg";
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index(JegString, "0", "Technical Sciences", "GUI", 0) as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.AreEqual(1, model.Cases.Count());
            }
        }

        [Test]
        public async Task Get_FacultyPlusTerm()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                var JegString = "Jeg";
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index(JegString, "0", "Technical Sciences", "0", 4) as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.AreEqual(2, model.Cases.Count());
            }
        }

        [Test]
        public async Task Get_CoursePlusTerm()
        {
            using (var context = new ApplicationDbContext(_options))
            {
                var JegString = "Jeg";
                context.Database.EnsureCreated();
                _uut = new MainlistController(context);
                var result = await _uut.Index(JegString, "0", "0", "GUI", 4) as ViewResult;
                var model = result.Model as MainlistViewModel;
                Assert.AreEqual(1, model.Cases.Count());
            }
        }
    }
}

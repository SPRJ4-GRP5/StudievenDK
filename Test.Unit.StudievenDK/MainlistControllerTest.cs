using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudievenDK.Controllers;
using StudievenDK.Data;

namespace Test.Unit.StudievenDK
{
    public class MainlistControllerTest : MainlistControllerTestClass
    {
        public MainlistControllerTest()
        : base(
            new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Filename=Test.db")
                .Options)
        {
        }

        [SetUp]
        public void Setup()
        {
            // arrange
            var controller = new MainlistControllerTest();
        }

        [Test]
        public void EverthingWorksAsExpected()
        {
            Assert.Pass();
        }

        [Test]
        public void ReturnsViewModel()
        {
            using (var context = new ApplicationDbContext(ContextOptions))
            {
                var controller = new MainlistController(context);

                // act
                var result = controller.Index().Result;
                var temp = (ViewResult)result;

                var model = temp.Model;

                Assert.IsInstanceOf<MainlistViewModel>(model);
            }
        }
    }
}
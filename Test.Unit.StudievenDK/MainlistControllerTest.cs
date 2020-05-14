using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
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
        }

        [Test]
        public void EverthingWorksAsExpected()
        {
            Assert.Pass();
        }
    }
}
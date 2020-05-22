using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using StudievenDK.Controllers;
using StudievenDK.Data;
using StudievenDK.Models.Login;
using LoginModel = StudievenDK.Areas.Identity.Pages.Account.LoginModel;

namespace Test.Integration.StudievenDK
{
    public class LoginMainlistControllerTest
    {
        private ApplicationDbContext _applicationDbContext;
        private SqliteConnection _connection;
        private DbContextOptions<ApplicationDbContext> _options;

        private LoginModel _loginModel;
        private MainlistController _mainlistController;


        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ILogger<LoginModel> _logger;

        [SetUp]
        public void Setup()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            _options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(_connection).Options;
            _applicationDbContext = new ApplicationDbContext(_options);


            _userManager = Substitute.For<UserManager<ApplicationUser>>();      //can't make this because there isn't any interfaces
            _signInManager = Substitute.For<SignInManager<ApplicationUser>>();  //can't make this because there isn't any interfaces
            _logger = Substitute.For<ILogger<LoginModel>>();

            _loginModel = new global::StudievenDK.Areas.Identity.Pages.Account.LoginModel(_signInManager, _logger, _userManager);
            _mainlistController = new MainlistController(_applicationDbContext);

        }

        [Test]
        public async Task PostAsyncLogin_returnsMainlistIndex()
        {
            await using var context = _applicationDbContext;
            context.Database.EnsureCreated();

            _loginModel.Input.Email = "2008@uni.au.dk";
            _loginModel.Input.Password = "Hej123!";
            _loginModel.Input.RememberMe = false;

            var result = await _signInManager.PasswordSignInAsync(_loginModel.Input.Email, _loginModel.Input.Password,
                _loginModel.Input.RememberMe, lockoutOnFailure: false);


            //Assert.AreEqual(result, Is.EqualTo());
        }
    }
}
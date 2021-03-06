﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NSubstitute;
using NUnit.Framework;
using StudievenDK.Controllers;
using StudievenDK.Data;
using StudievenDK.Models.Login;

namespace Test.Unit.StudievenDK.RegisterControllerTest
{

    public class RegisterControllerOntest
    {
        private IApplicationDbContext _context;
        private IUserRepository _userRepository;

        [SetUp]
        public void setup()
        {
            _context = Substitute.For<IApplicationDbContext>();
            _userRepository = Substitute.For<IUserRepository>();


            var mockStore = Mock.Of<IUserStore<ApplicationUser>>();
            var mockUserManger = new Mock<UserManager<ApplicationUser>>(mockStore, null, null, null, null, null, null, null, null);


        }



    }


    //public class FakeUserManager : UserManager<ApplicationUser>
    //{
    //    public FakeUserManager()
    //        : base(new Mock<IUserStore<ApplicationUser>>().Object,
    //            new Mock<IOptions<IdentityOptions>>().Object,
    //            new Mock<IPasswordHasher<ApplicationUser>>().Object,
    //            new IUserValidator<ApplicationUser>[0],
    //            new IPasswordValidator<ApplicationUser>[0],
    //            new Mock<ILookupNormalizer>().Object,
    //            new Mock<IdentityErrorDescriber>().Object,
    //            new Mock<IServiceProvider>().Object,
    //            new Mock<ILogger<UserManager<ApplicationUser>>>().Object)
    //    {
    //    }
    //}

}

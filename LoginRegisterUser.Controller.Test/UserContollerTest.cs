using System;
using System.Runtime.CompilerServices;
using StudievenDK.Controllers;
using StudievenDK.Data;
using StudievenDK.Models.Login;
using Xunit;


namespace LoginRegisterUser.Controller.Test
{
    public class UserContollerTest
    {
        [Fact]
        public void SearchingForAUser_Name()
        {
            // Arrange


            var user = new ApplicationUser()
            {
                Name = "Carl Andersen",
                Birthday = "23-07-2000",
                FieldOfStudy = "Softwareteknologi",
                Faculty = "BSS",
                Term = 2
            };

            var controller = new UserController();


            // Act


        }
    }
}

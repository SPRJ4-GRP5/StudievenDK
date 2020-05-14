using Microsoft.EntityFrameworkCore;
using StudievenDK.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Unit.StudievenDK
{
    public class MainlistControllerTestClass
    {
        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        protected MainlistControllerTestClass(DbContextOptions<ApplicationDbContext> contextOptions)
        {
            ContextOptions = contextOptions;
        }
    }
}

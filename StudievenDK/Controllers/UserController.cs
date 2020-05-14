using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudievenDK.Data;
using StudievenDK.Models.Login;

namespace StudievenDK.Controllers
{
    public class UserController : Controller
    {
        private readonly IApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private string statusCode404 = "404";

        public UserController(IApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string userName)
        {
            var sUser = await _userRepository.getUser(userName);

            if (sUser == null)
            {
                return NotFound();
            }

            return View(sUser);
        }
    }

    public interface IUserRepository
    {
        Task<ApplicationUser> getUser(string userName);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;
        public UserRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> getUser(string userName)
        {
            var user = await _context.MApplicationUsers.FirstOrDefaultAsync(x => x.UserName == userName);
            return user;
        }
    }
}
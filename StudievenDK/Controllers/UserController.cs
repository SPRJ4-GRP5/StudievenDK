using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudievenDK.Data;

namespace StudievenDK.Controllers
{
    public class UserController : Controller
    {
        private readonly IApplicationDbContext _context;

        public UserController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string userName)
        {
            if (userName == null)
            {
                return NotFound();
            }

            var sUser = await _context.MApplicationUsers
                .FirstOrDefaultAsync(u => u.UserName == userName);
            if (sUser == null)
            {
                return NotFound();
            }

            return View(sUser);
        }
    }
}
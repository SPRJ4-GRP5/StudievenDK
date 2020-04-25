using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudievenDK.Data;
using StudievenDK.Models;

namespace StudievenDK.Controllers
{
    public class CasesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CasesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Cases
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Cases.Include(@ => @.Course).Include(@ => @.UserHelper).Include(@ => @.UserSeeker);
            return View(await _context.Cases.ToListAsync());
            //applicationDbContext.ToListAsync()
        }

        // GET: Cases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Cases
                //.Include(@ => @.Course)
                //.Include(@ => @.UserHelper)
                //.Include(@ => @.UserSeeker)
                .FirstOrDefaultAsync(m => m.CaseId == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // GET: Cases/Create
        public IActionResult Create()
        {
            ViewData["CourseName_fk"] = new SelectList(_context.Course, "CourseName", "CourseName");
            ViewData["UserHelper_fk"] = new SelectList(_context.Users, "Email", "Email");
            ViewData["UserSeeker_fk"] = new SelectList(_context.Users, "Email", "Email");

            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaseId,Text,Subject,UserHelper_fk,UserSeeker_fk,CourseName_fk,Picture")] Case @case)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photos property on the incoming model object is not null and if count > 0,
                // then the user has selected at least one file to upload

                if (@case.Pictures != null && @case.Pictures.Count > 0)
                {
                    // Loop thru each selected file
                    foreach (IFormFile photo in @case.Pictures)
                    {
                        // The file must be uploaded to the images folder in wwwroot
                        // To get the path of the wwwroot folder we are using the injected
                        // IHostingEnvironment service provided by ASP.NET Core
                        string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Image");
                        // To make sure the file name is unique we are appending a new
                        // GUID value and and an underscore to the file name
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        // Use CopyTo() method provided by IFormFile interface to
                        // copy the file to wwwroot/images folder
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }

                _context.Add(@case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


                // save image to folder image
                //string wwwRootPath = _hostEnvironment.WebRootPath;
                //string fileName = Path.GetFileNameWithoutExtension(@case.Pictures.FileName);
                //string extension = Path.GetExtension(@case.Pictures.FileName);
                //@case.PictureName = fileName += extension;
                //string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                //using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    await @case.Pictures.CopyToAsync(fileStream);
                //}


                //_context.Add(@case);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            ViewData["CourseName_fk"] = new SelectList(_context.Course, "CourseName", "CourseName", @case.CourseName_fk);
            ViewData["UserHelper_fk"] = new SelectList(_context.Users, "Email", "Email", @case.UserHelper_fk);
            ViewData["UserSeeker_fk"] = new SelectList(_context.Users, "Email", "Email", @case.UserSeeker_fk);
            return View(@case);
        }

        // GET: Cases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Cases.FindAsync(id);
            if (@case == null)
            {
                return NotFound();
            }
            ViewData["CourseName_fk"] = new SelectList(_context.Course, "CourseName", "CourseName", @case.CourseName_fk);
            ViewData["UserHelper_fk"] = new SelectList(_context.Users, "Email", "Email", @case.UserHelper_fk);
            ViewData["UserSeeker_fk"] = new SelectList(_context.Users, "Email", "Email", @case.UserSeeker_fk);
            return View(@case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaseId,Text,Subject,UserHelper_fk,UserSeeker_fk,CourseName_fk,PictureName")] Case @case)
        {
            if (id != @case.CaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(@case.CaseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseName_fk"] = new SelectList(_context.Course, "CourseName", "CourseName", @case.CourseName_fk);
            ViewData["UserHelper_fk"] = new SelectList(_context.Users, "Email", "Email", @case.UserHelper_fk);
            ViewData["UserSeeker_fk"] = new SelectList(_context.Users, "Email", "Email", @case.UserSeeker_fk);
            return View(@case);
        }

        // GET: Cases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Cases
                //.Include(@ => @.Course)
                //.Include(@ => @.UserHelper)
                //.Include(@ => @.UserSeeker)
                .FirstOrDefaultAsync(m => m.CaseId == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @case = await _context.Cases.FindAsync(id);
            _context.Cases.Remove(@case);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaseExists(int id)
        {
            return _context.Cases.Any(e => e.CaseId == id);
        }
    }
}

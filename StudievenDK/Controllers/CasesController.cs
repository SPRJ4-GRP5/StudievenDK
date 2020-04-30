using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
            var CaseList = await _context.Cases.ToListAsync();
            return View(CaseList);
            //applicationDbContext.ToListAsync()
        }

        // GET: Cases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _case = await _context.Cases
                //.Include(@ => @.Course)
                //.Include(@ => @.UserHelper)
                //.Include(@ => @.UserSeeker)
                .FirstOrDefaultAsync(m => m.CaseId == id);
            if (_case == null)
            {
                return NotFound();
            }

            return View(_case);
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
        public async Task<IActionResult> Create([Bind("CaseId,Text,Subject,UserHelper_fk,UserSeeker_fk,CourseName_fk,Picture, Deadline")] Case @case)
        {
            if (ModelState.IsValid)
            {
                // save image to folder image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                
                if (@case.Picture != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(@case.Picture.FileName);
                    string extension = Path.GetExtension(@case.Picture.FileName);
                    @case.PictureName = fileName += extension;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await @case.Picture.CopyToAsync(fileStream);
                    }
                }
                

                
                _context.Add(@case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseName_fk"] = new SelectList(_context.Course, "CourseName", "CourseName", @case.CourseName_fk);
            ViewData["UserHelper_fk"] = new SelectList(_context.Users, "Email", "Email", @case.UserHelper_fk);
            ViewData["UserSeeker_fk"] = new SelectList(_context.Users, "Email", "Email", @case.UserSeeker_fk);
            return View(@case);
        }

        // GET: Cases/Edit/5
        public async Task<IActionResult> Edit(EditDTO edit)
        {
            if (edit.id == null)
            {
                return NotFound();
            }

            var _case = await _context.Cases.FindAsync(edit.id);
            //sætter default til den første i listen a cases
            if (edit.id == 0)
            {
                edit = new EditDTO()
                {
                    id = 1
                };
            }
            _case = await _context.Cases.FindAsync(edit.id);


            if (_case == null)
            {
                return NotFound();
            }
            ViewData["CourseName_fk"] = new SelectList(_context.Course, "CourseName", "CourseName", _case.CourseName_fk);
            ViewData["UserHelper_fk"] = new SelectList(_context.Users, "Email", "Email", _case.UserHelper_fk);
            ViewData["UserSeeker_fk"] = new SelectList(_context.Users, "Email", "Email", _case.UserSeeker_fk);
            return View(_case);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Case _case)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(_case);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseExists(_case.CaseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CourseName_fk"] = new SelectList(_context.Course, "CourseName", "CourseName", _case.CourseName_fk);
            ViewData["UserHelper_fk"] = new SelectList(_context.Users, "Email", "Email", _case.UserHelper_fk);
            ViewData["UserSeeker_fk"] = new SelectList(_context.Users, "Email", "Email", _case.UserSeeker_fk);
            return View(_case);
        }

        // GET: Cases/Delete/5
        public async Task<IActionResult> Delete(EditDTO delete)
        {
            if (delete.id == null)
            {
                return NotFound();
            }

            var _case = await _context.Cases
                //.Include(@ => @.Course)
                //.Include(@ => @.UserHelper)
                //.Include(@ => @.UserSeeker)
                .FirstOrDefaultAsync(m => m.CaseId == delete.id);
            if (delete.id == 0)
            {
                delete = new EditDTO()
                {
                    id = 1
                };
            }
            _case = await _context.Cases.FindAsync(delete.id);
            if (_case == null)
            {
                return NotFound();
            }

            return View(_case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Case _case)
        {
            var temp_case = await _context.Cases.FindAsync(_case.CaseId);
            _context.Cases.Remove(temp_case);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CaseExists(int id)
        {
            return _context.Cases.Any(e => e.CaseId == id);
        }
    }
}

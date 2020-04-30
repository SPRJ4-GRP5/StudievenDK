using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudievenDK.Data;
using StudievenDK.Models;

namespace StudievenDK.Controllers
{
    public class MainlistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainlistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mainlist
        public async Task<IActionResult> Index(string searchString, string Subject, string Course, string Programme, string faculty)
        {
            
            var vm = new MainlistViewModel();

            var Case = from s in _context.Cases
                       select s;

            var subjectQuery= from s in _context.Cases
                select s.Subject;

            var fagQuery = from s in _context.Course
                           select s.CourseName;

            var programmeQuery = from s in _context.Programmes
                                 select s.ProgrammeName;

            var facultyQuery = from s in _context.Faculties
                               select s.FacultyName;

            vm.Subjects = await subjectQuery.ToListAsync();
            vm.Courses = await fagQuery.ToListAsync();
            vm.Programmes = await programmeQuery.ToListAsync();
            vm.Faculties = await facultyQuery.ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                Case = Case.Where(s => s.Subject.Contains(searchString)
                                         || s.Text.Contains(searchString));
            }

            if(faculty!=null)
            {
                Case = Case.Where(s => s.Subject.Equals(faculty));
            }

            if(Programme!=null)
            {
                Case = Case.Where(s => s.Subject.Equals(Programme));
            }

            if (Subject != null)
            {
                Case = Case.Where(s=>s.Subject.Equals(Subject));
            }

            if(Course!=null)
            {
                Case = Case.Where(s => s.Course.Equals(Course));
            }

            vm.Cases = await Case.ToListAsync();
            return View(vm);
        }

        // GET: Mainlist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Cases
                .FirstOrDefaultAsync(m => m.CaseId == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // GET: Mainlist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mainlist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaseId,Text,Subject,PictureName")] Case @case)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@case);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@case);
        }

        // GET: Mainlist/Edit/5
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
            return View(@case);
        }

        // POST: Mainlist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaseId,Text,Subject,PictureName")] Case @case)
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
            return View(@case);
        }

        // GET: Mainlist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @case = await _context.Cases
                .FirstOrDefaultAsync(m => m.CaseId == id);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // POST: Mainlist/Delete/5
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

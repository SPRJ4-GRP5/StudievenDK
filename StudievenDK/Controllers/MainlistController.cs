using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudievenDK.Data;
using StudievenDK.Models;

namespace StudievenDK.Controllers
{
    [Authorize]
    public class MainlistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainlistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mainlist
        public async Task<IActionResult> Index(string searchString = null, string programme = "0", string faculty = "0", string course = "0", int term = 0)
        {
            var vm = new MainlistViewModel();

            //var cases = from s in _context.Cases
            //           select s;

            var cases2 = _context.Cases.Include(c => c.Course).ThenInclude(c => c.Faculty)
                .Include(c => c.Course).ThenInclude(c => c.CourseProgrammes);

            //2 led
            //in-direkte reference 

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
            IQueryable<Case> cases=null;

            if (!String.IsNullOrEmpty(searchString))
            {
                cases = cases2.Where(s => s.Subject.Contains(searchString)
                                         || s.Text.Contains(searchString));
            }

            if(faculty!="0")
            {
                if(cases==null)
                {
                    cases = cases2.Include(c => c.Course).Where(c => c.Course.FacultyName_fk.Equals(faculty));
                }
                else
                cases = cases.Include(c => c.Course).Where(c => c.Course.FacultyName_fk.Equals(faculty));
            }

            if (term != 0)
            {
                if (cases == null)
                {
                    cases = cases2.Where(c => c.Course.Term.TermYear.Equals(term));
                }
                else
                    cases = cases.Where(c => c.Course.Term.TermYear.Equals(term));
            }

            if (course!="0")
            {
                if(cases==null)
                {
                    cases = cases2.Where(s => s.Course.CourseName.Equals(course));
                }
                else
                cases = cases.Where(s => s.Course.CourseName.Equals(course));
            }

            if (programme != "0")
            {
                List<Case> tempCases = new List<Case>();

                var courseProgrammes = _context.CourseProgrammes_ST.Where(cp => cp.ProgrammeName_fk == programme).Select(cp => cp.CourseName_fk).ToList();
                foreach (var c in courseProgrammes)
                {
                    tempCases.AddRange(cases.Include(c => c.Course).Where(s => s.Course.CourseName.Equals(c)).ToList());
                }

                vm.Cases = tempCases;
                //if(cases==null)
                //{

                //    //cases = cases2.Where(c => c.Course.CourseProgrammes.Contains()));
                //}
                //else
                //cases = cases.Where(s => s.Subject.Equals(programme));
            }
            else
            {
                if (cases == null)
                {
                    cases = cases2;
                }
                vm.Cases = await cases.ToListAsync();
            }
 
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

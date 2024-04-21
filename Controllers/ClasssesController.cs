using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockholmSchool5.Data;
using StockholmSchool5.Models;

namespace StockholmSchool5.Controllers
{
    public class ClasssesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClasssesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Classses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Classses.Include(c => c.Course);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Classses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classs = await _context.Classses
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.ClasssId == id);
            if (classs == null)
            {
                return NotFound();
            }

            return View(classs);
        }

        // GET: Classses/Create
        public IActionResult Create()
        {
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            return View();
        }

        // POST: Classses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClasssId,Title,FkCourseId")] Classs classs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", classs.FkCourseId);
            return View(classs);
        }

        // GET: Classses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classs = await _context.Classses.FindAsync(id);
            if (classs == null)
            {
                return NotFound();
            }
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", classs.FkCourseId);
            return View(classs);
        }

        // POST: Classses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClasssId,Title,FkCourseId")] Classs classs)
        {
            if (id != classs.ClasssId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasssExists(classs.ClasssId))
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
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", classs.FkCourseId);
            return View(classs);
        }

        // GET: Classses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classs = await _context.Classses
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.ClasssId == id);
            if (classs == null)
            {
                return NotFound();
            }

            return View(classs);
        }

        // POST: Classses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classs = await _context.Classses.FindAsync(id);
            if (classs != null)
            {
                _context.Classses.Remove(classs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasssExists(int id)
        {
            return _context.Classses.Any(e => e.ClasssId == id);
        }
    }
}

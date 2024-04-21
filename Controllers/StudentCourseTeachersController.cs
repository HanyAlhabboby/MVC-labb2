
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockholmSchool5.Data;
using StockholmSchool5.Models;

namespace StockholmSchool5.Controllers
{
    public class StudentCourseTeachersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentCourseTeachersController(ApplicationDbContext context)
        {
            _context = context;
        }


        //Show all teachers
        public async Task<IActionResult> ViewAllTeachers()
        {
            var teacherslist = _context.StudentCourseTeachers
                .Include(e => e.Teacher)
                .Include(e => e.Course)
                .Where(e => e.FkCourseId == 3)
                .ToListAsync();

            return View(await teacherslist);
        }

        //Show students and teachers
        public async Task<IActionResult> ViewStudentsTeachers()
        {
            var studentsTeachersList = _context.StudentCourseTeachers
                .Include(e => e.Teacher)
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();

            return View(await studentsTeachersList );
        }

        //Show teachers and students with Programing A
        public async Task<IActionResult> ProgrammingStudentsTeachers()
        {
            var programmingList = _context.StudentCourseTeachers
                .Include(e => e.Student)
                .Include(e => e.Teacher)
                .Include(e => e.Course)
                .Where(e => e.FkCourseId == 3)
                .ToListAsync();

            return View( await programmingList);
        }
        //public async Task<IActionResult> UpdateTeacher()
        //{
        //    var StudentTeacherList = _context.StudentCourseTeachers
        //       .Include(e => e.Student)
        //       .Include(e => e.Teacher)
        //       .Include(e => e.Course)
        //       .Where(e => e.FkCourseId == 3)
        //       .ToList();
        //    var teachers = _context.Teachers.ToList();

        //    var viewModel = new studentTeacher
        //    {
        //        StudentCourseTeacher = StudentTeacherList,
        //        Teachers = teachers
        //    };

        //    return View(viewModel);
        //}


     


        // GET: StudentCourseTeachers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentCourseTeachers.Include(s => s.Course).Include(s => s.Student).Include(s => s.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentCourseTeachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourseTeacher = await _context.StudentCourseTeachers
                .Include(s => s.Course)
                .Include(s => s.Student)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.StudentCouseTeacherId == id);
            if (studentCourseTeacher == null)
            {
                return NotFound();
            }

            return View(studentCourseTeacher);
        }

        // GET: StudentCourseTeachers/Create
        public IActionResult Create()
        {
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["FkStudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId");
            return View();
        }

        // POST: StudentCourseTeachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentCouseTeacherId,Grade,FkCourseId,FkStudentId,FkTeacherId")] StudentCourseTeacher studentCourseTeacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCourseTeacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", studentCourseTeacher.FkCourseId);
            ViewData["FkStudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentCourseTeacher.FkStudentId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", studentCourseTeacher.FkTeacherId);
            return View(studentCourseTeacher);
        }

        // GET: StudentCourseTeachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourseTeacher = await _context.StudentCourseTeachers.FindAsync(id);
            if (studentCourseTeacher == null)
            {
                return NotFound();
            }
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", studentCourseTeacher.FkCourseId);
            ViewData["FkStudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentCourseTeacher.FkStudentId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", studentCourseTeacher.FkTeacherId);
            return View(studentCourseTeacher);
        }

        // POST: StudentCourseTeachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentCouseTeacherId,Grade,FkCourseId,FkStudentId,FkTeacherId")] StudentCourseTeacher studentCourseTeacher)
        {
            if (id != studentCourseTeacher.StudentCouseTeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCourseTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCourseTeacherExists(studentCourseTeacher.StudentCouseTeacherId))
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
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", studentCourseTeacher.FkCourseId);
            ViewData["FkStudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", studentCourseTeacher.FkStudentId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", studentCourseTeacher.FkTeacherId);
            return View(studentCourseTeacher);
        }

        // GET: StudentCourseTeachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourseTeacher = await _context.StudentCourseTeachers
                .Include(s => s.Course)
                .Include(s => s.Student)
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(m => m.StudentCouseTeacherId == id);
            if (studentCourseTeacher == null)
            {
                return NotFound();
            }

            return View(studentCourseTeacher);
        }

        // POST: StudentCourseTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCourseTeacher = await _context.StudentCourseTeachers.FindAsync(id);
            if (studentCourseTeacher != null)
            {
                _context.StudentCourseTeachers.Remove(studentCourseTeacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseTeacherExists(int id)
        {
            return _context.StudentCourseTeachers.Any(e => e.StudentCouseTeacherId == id);
        }
    }
}

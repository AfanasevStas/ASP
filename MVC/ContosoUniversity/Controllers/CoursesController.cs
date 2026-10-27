
using ContosoUniversity;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class CoursesController : Controller
{
    private readonly ContosoUniversityContext _context;

    public CoursesController(ContosoUniversityContext context)
    {
        _context = context;
    }

    // GET: COURSES
    public async Task<IActionResult> Index
        (
        string sortOrder,
        string searchString,
        int? pageIndex,
        int itemsPerPage = 3
        )
    {
        ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        ViewData["DateSortParam"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
        ViewData["CurrentFilter"] = searchString;
        IQueryable<Course> courses = from course in _context.Courses select course;
        if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrWhiteSpace(searchString))
        {
            pageIndex = 1;
            courses = courses.Where
                (
                    cours => cours.Title.Contains(searchString)
                );
        }

        switch (sortOrder)
        {
            case "name_desc": courses = courses.OrderByDescending(s => s.Title); break;
            default: courses = courses.OrderBy(s => s.Title); break;
        }

        ViewData["ItemsPerPage"] = itemsPerPage;
        int pageSize = itemsPerPage;

        return View(await PaginatedList<Course>.CreateAsync(courses.AsNoTracking(), pageIndex ?? 1, pageSize));
    }


    // GET: COURSES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await _context.Courses
            .FirstOrDefaultAsync(m => m.CourseID == id);
        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    // GET: COURSES/Create
    public IActionResult Create()
    {
        PopulateDepartmentsDropdownList();
        return View();
    }

    // POST: COURSES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CourseID,Title,Credits,DepartmentID")] Course course)
    {
        if (ModelState.IsValid)
        {
            _context.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(course);
    }

    // GET: COURSES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var course = await _context.Courses.FindAsync(id);
        if (course == null)
        {
            return NotFound();
        }
        PopulateDepartmentsDropdownList(course.DepartmentID);
        return View(course);
    }

    // POST: COURSES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? courseid, [Bind("CourseID,Title,Credits,DepartmentID")] Course course)
    {
        if (courseid != course.CourseID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(course.CourseID))
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
        return View(course);
    }

    // GET: COURSES/Delete/5
    public async Task<IActionResult> Delete(int? courseid)
    {
        if (courseid == null)
        {
            return NotFound();
        }

        var course = await _context.Courses
            .FirstOrDefaultAsync(m => m.CourseID == courseid);
        if (course == null)
        {
            return NotFound();
        }

        return View(course);
    }

    // POST: COURSES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? courseid)
    {
        var course = await _context.Courses.FindAsync(courseid);
        if (course != null)
        {
            _context.Courses.Remove(course);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CourseExists(int? courseid)
    {
        return _context.Courses.Any(e => e.CourseID == courseid);
    }

    void PopulateDepartmentsDropdownList(object selectedDepartment = null)
    {
        IQueryable<Department> departments = 
            from department in _context.Departments
            orderby department.Name
            select department;
        ViewBag.DepartmentID = new SelectList
            (
                departments.AsNoTracking(),
                "DepartmentID",
                "Name",
                selectedDepartment
            );
    }
}

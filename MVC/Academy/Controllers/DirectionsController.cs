
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academy.Models;
using Academy.Models.VievModels;

public class DirectionsController : Controller
{
    private readonly AcademyContext _context;

    public DirectionsController(AcademyContext context)
    {
        _context = context;
    }

    // GET: DIRECTIONS
    //public async Task<IActionResult> Index()    
    //{
    //    var directions = await _context.Directions.ToListAsync();
    //    return View(directions);
    //}

    public async Task<IActionResult> Index(int? id, int? groupID)
    {
        DirectionsGroupsStudents viewModel = new DirectionsGroupsStudents();
        viewModel.Directions = await _context
            .Directions
            .AsNoTracking()
            .OrderBy(i => i.direction_name)
            .ToListAsync();
        //viewModel.Groups = await _context
        //    .Groups
        //    .AsNoTracking()
        //    .OrderBy(i => i.group_name)
        //    .ToListAsync();
        //viewModel.Students = await _context
        //    .Students
        //    .AsNoTracking()
        //    .OrderBy(i => i.last_name)
        //    .ToListAsync();

        if (id != null)
        {
            ViewData["DirectionID"] = id.Value;
            viewModel.Groups = await _context
                .Groups
                .Where(i => i.direction == id.Value)
                .Include(i => i.Direction)
                .AsNoTracking()
                .OrderBy(i => i.group_name)
                .ToListAsync();
        }

        if (groupID != null)
        {
            ViewData["GroupID"] = groupID.Value;
            viewModel.Students = await _context
                .Students
                .Where(i => i.group == groupID.Value)
                .Include(i => i.Group)
                .AsNoTracking()
                .OrderBy(i => i.last_name)
                .ToListAsync();
        }

        return View(viewModel);
    }


    // GET: DIRECTIONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var direction = await _context.Directions
            .FirstOrDefaultAsync(m => m.direction_id == id);
        if (direction == null)
        {
            return NotFound();
        }

        return View(direction);
    }

    // GET: DIRECTIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DIRECTIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("direction_id,direction_name")] Direction direction)
    {
        if (ModelState.IsValid)
        {
            _context.Add(direction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(direction);
    }

    // GET: DIRECTIONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var direction = await _context.Directions.FindAsync(id);
        if (direction == null)
        {
            return NotFound();
        }
        return View(direction);
    }

    // POST: DIRECTIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? direction_id, [Bind("direction_id,direction_name")] Direction direction)
    {
        if (direction_id != direction.direction_id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(direction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectionExists(direction.direction_id))
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
        return View(direction);
    }

    // GET: DIRECTIONS/Delete/5
    public async Task<IActionResult> Delete(int? direction_id)
    {
        if (direction_id == null)
        {
            return NotFound();
        }

        var direction = await _context.Directions
            .FirstOrDefaultAsync(m => m.direction_id == direction_id);
        if (direction == null)
        {
            return NotFound();
        }

        return View(direction);
    }

    // POST: DIRECTIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? direction_id)
    {
        var direction = await _context.Directions.FindAsync(direction_id);
        if (direction != null)
        {
            _context.Directions.Remove(direction);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DirectionExists(int? direction_id)
    {
        return _context.Directions.Any(e => e.direction_id == direction_id);
    }
}

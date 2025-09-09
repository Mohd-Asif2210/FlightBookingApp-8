using Microsoft.AspNetCore.Mvc;
using FlightBookingApp.ApplicationDbContext;
using FlightBookingApp.Models;
using Microsoft.EntityFrameworkCore;
 
namespace FlightBookingApp.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly AppDbContext _context;
 
        public AdminLoginController(AppDbContext context)
        {
            _context = context;
        }
 
        // GET: AdminLogin
        public async Task<IActionResult> Index()
        {
            return _context.admins != null ?
                        View(await _context.admins.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.admins'  is null.");
        }
 
        // GET: AdminLogin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.admins == null)
            {
                return NotFound();
            }
 
            var admin = await _context.admins
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (admin == null)
            {
                return NotFound();
            }
 
            return View(admin);
        }
 
        // GET: AdminLogin/Create
        public IActionResult Create()
        {
            return View();
        }
 
        // POST: AdminLogin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,AName,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }
 
        // GET: AdminLogin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.admins == null)
            {
                return NotFound();
            }
 
            var admin = await _context.admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }
 
        // POST: AdminLogin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId,AName,Password")] Admin admin)
        {
            if (id != admin.AdminId)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.AdminId))
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
            return View(admin);
        }
 
        // GET: AdminLogin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.admins == null)
            {
                return NotFound();
            }
 
            var admin = await _context.admins
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (admin == null)
            {
                return NotFound();
            }
 
            return View(admin);
        }
 
        // POST: AdminLogin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.admins == null)
            {
                return Problem("Entity set 'AppDbContext.admins'  is null.");
            }
            var admin = await _context.admins.FindAsync(id);
            if (admin != null)
            {
                _context.admins.Remove(admin);
            }
 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
 
        private bool AdminExists(int id)
        {
            return (_context.admins?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
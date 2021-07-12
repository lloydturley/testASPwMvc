using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testASPwMvc.Data;

namespace testASPwMvc.Controllers
{
    public class HelpController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HelpController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Help
        public async Task<IActionResult> Index()
        {
            return View(await _context.Help.ToListAsync());
        }

        // GET: Help/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help = await _context.Help
                .FirstOrDefaultAsync(m => m.Id == id);
            if (help == null)
            {
                return NotFound();
            }

            return View(help);
        }

        // GET: Help/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Help/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Instructions")] Help help)
        {
            if (ModelState.IsValid)
            {
                _context.Add(help);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(help);
        }

        // GET: Help/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help = await _context.Help.FindAsync(id);
            if (help == null)
            {
                return NotFound();
            }
            return View(help);
        }

        // POST: Help/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Instructions")] Help help)
        {
            if (id != help.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(help);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelpExists(help.Id))
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
            return View(help);
        }

        // GET: Help/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var help = await _context.Help
                .FirstOrDefaultAsync(m => m.Id == id);
            if (help == null)
            {
                return NotFound();
            }

            return View(help);
        }

        // POST: Help/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var help = await _context.Help.FindAsync(id);
            _context.Help.Remove(help);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelpExists(int id)
        {
            return _context.Help.Any(e => e.Id == id);
        }
    }
}

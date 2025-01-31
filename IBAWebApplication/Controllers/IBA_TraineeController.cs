using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IBAWebApplication.Data;
using IBAWebApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace IBAWebApplication.Controllers
{
    public class IBA_TraineeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IBA_TraineeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IBA_Trainee
        public async Task<IActionResult> Index()
        {
            return View(await _context.IBA_Trainee.ToListAsync());
        }

        // GET: IBA_Trainee/ShowSearchform
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // POST: IBA_Trainee/ShowSearchresult
        public async Task<IActionResult> ShowSearchResult(string Name, string Role)
        {
            return View("Index", await _context.IBA_Trainee.Where(x => x.Name == Name || x.Role == Role).
                ToListAsync());
        }

        // GET: IBA_Trainee/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iBA_Trainee = await _context.IBA_Trainee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iBA_Trainee == null)
            {
                return NotFound();
            }

            return View(iBA_Trainee);
        }

        // GET: IBA_Trainee/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }



        // POST: IBA_Trainee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Role,AssignedProducts,TrainingProgram")] IBA_Trainee iBA_Trainee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iBA_Trainee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iBA_Trainee);
        }

        // GET: IBA_Trainee/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iBA_Trainee = await _context.IBA_Trainee.FindAsync(id);
            if (iBA_Trainee == null)
            {
                return NotFound();
            }
            return View(iBA_Trainee);
        }

        // POST: IBA_Trainee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Role,AssignedProducts,TrainingProgram")] IBA_Trainee iBA_Trainee)
        {
            if (id != iBA_Trainee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iBA_Trainee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IBA_TraineeExists(iBA_Trainee.Id))
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
            return View(iBA_Trainee);
        }

        // GET: IBA_Trainee/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iBA_Trainee = await _context.IBA_Trainee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iBA_Trainee == null)
            {
                return NotFound();
            }

            return View(iBA_Trainee);
        }

        // POST: IBA_Trainee/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iBA_Trainee = await _context.IBA_Trainee.FindAsync(id);
            if (iBA_Trainee != null)
            {
                _context.IBA_Trainee.Remove(iBA_Trainee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IBA_TraineeExists(int id)
        {
            return _context.IBA_Trainee.Any(e => e.Id == id);
        }
    }
}

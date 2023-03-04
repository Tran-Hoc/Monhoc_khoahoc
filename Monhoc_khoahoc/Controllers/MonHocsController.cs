using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monhoc_khoahoc.Data;
using Monhoc_khoahoc.DataContext;

namespace Monhoc_khoahoc.Controllers
{
    public class MonHocsController : Controller
    {
        private readonly HocphanContext _context;

        public MonHocsController(HocphanContext context)
        {
            _context = context;
        }

        // GET: MonHocs
        public async Task<IActionResult> Index()
        {
            var hocphanContext = _context.MonHocs.Include(m => m.IdkhoahocNavigation);
            return View(await hocphanContext.ToListAsync());
        }

        // GET: MonHocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MonHocs == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs
                .Include(m => m.IdkhoahocNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // GET: MonHocs/Create
        public IActionResult Create()
        {
            ViewData["Idkhoahoc"] = new SelectList(_context.KhoaHocs, "Id", "Id");
            return View();
        }

        // POST: MonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tenmon,Idkhoahoc")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idkhoahoc"] = new SelectList(_context.KhoaHocs, "Id", "Id", monHoc.Idkhoahoc);
            return View(monHoc);
        }

        // GET: MonHocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MonHocs == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            ViewData["Idkhoahoc"] = new SelectList(_context.KhoaHocs, "Id", "Id", monHoc.Idkhoahoc);
            return View(monHoc);
        }

        // POST: MonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tenmon,Idkhoahoc")] MonHoc monHoc)
        {
            if (id != monHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonHocExists(monHoc.Id))
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
            ViewData["Idkhoahoc"] = new SelectList(_context.KhoaHocs, "Id", "Id", monHoc.Idkhoahoc);
            return View(monHoc);
        }

        // GET: MonHocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MonHocs == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs
                .Include(m => m.IdkhoahocNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // POST: MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MonHocs == null)
            {
                return Problem("Entity set 'HocphanContext.MonHocs'  is null.");
            }
            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc != null)
            {
                _context.MonHocs.Remove(monHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonHocExists(int id)
        {
          return _context.MonHocs.Any(e => e.Id == id);
        }
    }
}

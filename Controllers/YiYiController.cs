using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class YiYiController : Controller
    {
        private readonly ApplicationDBContext _context;

        public YiYiController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: YiYi
        public async Task<IActionResult> Index()
        {
            return View(await _context.YoYo.ToListAsync());
        }

        // GET: YiYi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yoYo = await _context.YoYo
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (yoYo == null)
            {
                return NotFound();
            }

            return View(yoYo);
        }

        // GET: YiYi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YiYi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDYoYo,UniversityYoYo,PersonID,FullName")] YoYo yoYo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yoYo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yoYo);
        }

        // GET: YiYi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yoYo = await _context.YoYo.FindAsync(id);
            if (yoYo == null)
            {
                return NotFound();
            }
            return View(yoYo);
        }

        // POST: YiYi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDYoYo,UniversityYoYo,PersonID,FullName")] YoYo yoYo)
        {
            if (id != yoYo.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yoYo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YoYoExists(yoYo.PersonID))
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
            return View(yoYo);
        }

        // GET: YiYi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yoYo = await _context.YoYo
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (yoYo == null)
            {
                return NotFound();
            }

            return View(yoYo);
        }

        // POST: YiYi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yoYo = await _context.YoYo.FindAsync(id);
            _context.YoYo.Remove(yoYo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YoYoExists(int id)
        {
            return _context.YoYo.Any(e => e.PersonID == id);
        }
    }
}

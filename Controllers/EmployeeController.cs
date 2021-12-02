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
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext _context;

        public EmployeeController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Employee
      
    public async Task<IActionResult> Index(string EmployGenre, string searchString)
    {
        // Use LINQ to get list of genres.
        IQueryable<string> genreQuery = from m in _context.Employee
                                        orderby m.EmployName
                                        select m.EmployeeID;

        var employees = from m in _context.Employee
                    select m;

        if (!string.IsNullOrEmpty(searchString))
        {
            employees = employees.Where(s => s.EmployName.Contains(searchString));
        }

        if (!string.IsNullOrEmpty(EmployGenre))
        {
            employees = employees.Where(x => x.EmployName == EmployGenre);
        }
//ô tìm kiếm à uh trc cái bảng employee vẫn chạy đc ý bh lại báo ko có table
        var EmployGenreVM = new EmployGenreViewModel
        {
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
            Employees = await employees.ToListAsync()
        };

        return View(EmployGenreVM);
    }
            // GET: Employee/Details/5
            public async Task<IActionResult> Details(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _context.Employee
                    .FirstOrDefaultAsync(m => m.EmployeeID == id);
                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
            }

            // GET: Employee/Create
            public IActionResult Create()
            {
                return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,EmployName,PhoneNumber")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeID,EmployName,PhoneNumber")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
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
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employee.Any(e => e.EmployeeID == id);
        }
    }
}

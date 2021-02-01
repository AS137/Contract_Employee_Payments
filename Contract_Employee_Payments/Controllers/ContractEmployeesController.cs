using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contract_Employee_Payments.Data;
using Contract_Employee_Payments.Models;

namespace Contract_Employee_Payments.Controllers
{
    public class ContractEmployeesController : Controller
    {
        private readonly Contract_Employee_PaymentsContext _context;

        public ContractEmployeesController(Contract_Employee_PaymentsContext context)
        {
            _context = context;
        }

        // GET: ContractEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContractEmployee.ToListAsync());
        }

        // GET: ContractEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractEmployee = await _context.ContractEmployee
                .FirstOrDefaultAsync(m => m.ContractEmployeeId == id);
            if (contractEmployee == null)
            {
                return NotFound();
            }

            return View(contractEmployee);
        }

        // GET: ContractEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContractEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContractEmployeeId,Name,HourlyRate")] ContractEmployee contractEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contractEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contractEmployee);
        }

        // GET: ContractEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractEmployee = await _context.ContractEmployee.FindAsync(id);
            if (contractEmployee == null)
            {
                return NotFound();
            }
            return View(contractEmployee);
        }

        // POST: ContractEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContractEmployeeId,Name,HourlyRate")] ContractEmployee contractEmployee)
        {
            if (id != contractEmployee.ContractEmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contractEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractEmployeeExists(contractEmployee.ContractEmployeeId))
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
            return View(contractEmployee);
        }

        // GET: ContractEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractEmployee = await _context.ContractEmployee
                .FirstOrDefaultAsync(m => m.ContractEmployeeId == id);
            if (contractEmployee == null)
            {
                return NotFound();
            }

            return View(contractEmployee);
        }

        // POST: ContractEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contractEmployee = await _context.ContractEmployee.FindAsync(id);
            _context.ContractEmployee.Remove(contractEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractEmployeeExists(int id)
        {
            return _context.ContractEmployee.Any(e => e.ContractEmployeeId == id);
        }
    }
}

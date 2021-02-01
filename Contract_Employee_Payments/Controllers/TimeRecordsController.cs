using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contract_Employee_Payments.Data;
using Contract_Employee_Payments.Models;
using Microsoft.AspNetCore.Authorization;

namespace Contract_Employee_Payments.Controllers
{
    public class TimeRecordsController : Controller
    {
        private readonly Contract_Employee_PaymentsContext _context;

        public TimeRecordsController(Contract_Employee_PaymentsContext context)
        {
            _context = context;
        }

        // GET: TimeRecords
        public async Task<IActionResult> Index()
        {
            var contract_Employee_PaymentsContext = _context.TimeRecord.Include(t => t.ContractEmployee).Include(t => t.Project);
            return View(await contract_Employee_PaymentsContext.ToListAsync());
        }

        // GET: TimeRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRecord = await _context.TimeRecord
                .Include(t => t.ContractEmployee)
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeRecord == null)
            {
                return NotFound();
            }

            return View(timeRecord);
        }

        [Authorize]
        // GET: TimeRecords/Create
        public IActionResult Create()
        {
            ViewData["ContractEmployeeId"] = new SelectList(_context.ContractEmployee, "ContractEmployeeId", "Name");
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName");
            return View();
        }

        // POST: TimeRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,ContractEmployeeId,StartTime,EndTime")] TimeRecord timeRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractEmployeeId"] = new SelectList(_context.ContractEmployee, "ContractEmployeeId", "ContractEmployeeId", timeRecord.ContractEmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", timeRecord.ProjectId);
            return View(timeRecord);
        }

        [Authorize]
        // GET: TimeRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRecord = await _context.TimeRecord.FindAsync(id);
            if (timeRecord == null)
            {
                return NotFound();
            }
            ViewData["ContractEmployeeId"] = new SelectList(_context.ContractEmployee, "ContractEmployeeId", "Name", timeRecord.ContractEmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectName", timeRecord.ProjectId);
            return View(timeRecord);
        }

        // POST: TimeRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,ContractEmployeeId,StartTime,EndTime")] TimeRecord timeRecord)
        {
            if (id != timeRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeRecordExists(timeRecord.Id))
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
            ViewData["ContractEmployeeId"] = new SelectList(_context.ContractEmployee, "ContractEmployeeId", "ContractEmployeeId", timeRecord.ContractEmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", timeRecord.ProjectId);
            return View(timeRecord);
        }


        [Authorize]
        // GET: TimeRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeRecord = await _context.TimeRecord
                .Include(t => t.ContractEmployee)
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeRecord == null)
            {
                return NotFound();
            }

            return View(timeRecord);
        }

        // POST: TimeRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeRecord = await _context.TimeRecord.FindAsync(id);
            _context.TimeRecord.Remove(timeRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeRecordExists(int id)
        {
            return _context.TimeRecord.Any(e => e.Id == id);
        }
    }
}

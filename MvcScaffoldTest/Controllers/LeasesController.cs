using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetScaffoldTest.Data;
using AspNetScaffoldTest.Data.Models;

namespace MvcScaffoldTest.Controllers
{
    public class LeasesController : Controller
    {
        private readonly MmsContext _context;

        public LeasesController(MmsContext context)
        {
            _context = context;
        }

        // GET: Leases
        public async Task<IActionResult> Index()
        {
              return View(await _context.tblLeases.ToListAsync());
        }

        // GET: Leases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblLeases == null)
            {
                return NotFound();
            }

            var lease = await _context.tblLeases
                .FirstOrDefaultAsync(m => m.fldLeaseID == id);
            if (lease == null)
            {
                return NotFound();
            }

            return View(lease);
        }

        // GET: Leases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fldLeaseID,fldCustomerID,fldVIN,fldLeaseTermsID,fldBeginOdometer,fldContractStartDate,fldPaymentStartDate,fldMonthlyPayment,fldNumberOfPayments,fldEndOdometer,fldLTRThankYou,fldLTRExpiry,fldLTRTermination,fldTerminationDate")] Lease lease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lease);
        }

        // GET: Leases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblLeases == null)
            {
                return NotFound();
            }

            var lease = await _context.tblLeases.FindAsync(id);
            if (lease == null)
            {
                return NotFound();
            }
            return View(lease);
        }

        // POST: Leases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("fldLeaseID,fldCustomerID,fldVIN,fldLeaseTermsID,fldBeginOdometer,fldContractStartDate,fldPaymentStartDate,fldMonthlyPayment,fldNumberOfPayments,fldEndOdometer,fldLTRThankYou,fldLTRExpiry,fldLTRTermination,fldTerminationDate")] Lease lease)
        {
            if (id != lease.fldLeaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaseExists(lease.fldLeaseID))
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
            return View(lease);
        }

        // GET: Leases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblLeases == null)
            {
                return NotFound();
            }

            var lease = await _context.tblLeases
                .FirstOrDefaultAsync(m => m.fldLeaseID == id);
            if (lease == null)
            {
                return NotFound();
            }

            return View(lease);
        }

        // POST: Leases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblLeases == null)
            {
                return Problem("Entity set 'MmsContext.tblLeases'  is null.");
            }
            var lease = await _context.tblLeases.FindAsync(id);
            if (lease != null)
            {
                _context.tblLeases.Remove(lease);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaseExists(int id)
        {
          return _context.tblLeases.Any(e => e.fldLeaseID == id);
        }
    }
}

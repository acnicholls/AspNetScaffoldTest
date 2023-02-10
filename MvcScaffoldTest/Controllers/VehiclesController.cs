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
    public class VehiclesController : Controller
    {
        private readonly MmsContext _context;

        public VehiclesController(MmsContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
              return View(await _context.tblVehicles.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.tblVehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.tblVehicles
                .FirstOrDefaultAsync(m => m.fldVIN == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fldVIN,fldModelID,fldTypeID,fldColourID,fldYear,fldOdometer,fldPreviousLease,fldBookValue,fldAutomatic,fldAir,fldPowerLocks,fldINLot,fldINGarage")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.tblVehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.tblVehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("fldVIN,fldModelID,fldTypeID,fldColourID,fldYear,fldOdometer,fldPreviousLease,fldBookValue,fldAutomatic,fldAir,fldPowerLocks,fldINLot,fldINGarage")] Vehicle vehicle)
        {
            if (id != vehicle.fldVIN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.fldVIN))
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
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.tblVehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.tblVehicles
                .FirstOrDefaultAsync(m => m.fldVIN == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.tblVehicles == null)
            {
                return Problem("Entity set 'MmsContext.tblVehicles'  is null.");
            }
            var vehicle = await _context.tblVehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.tblVehicles.Remove(vehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(string id)
        {
          return _context.tblVehicles.Any(e => e.fldVIN == id);
        }
    }
}

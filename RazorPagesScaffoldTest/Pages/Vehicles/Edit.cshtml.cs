using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetScaffoldTest.Data;
using AspNetScaffoldTest.Data.Models;

namespace AspNetScaffoldTest.RazorPages.Pages.Vehicles
{
    public class EditModel : PageModel
    {
        private readonly AspNetScaffoldTest.Data.MmsContext _context;

        public EditModel(AspNetScaffoldTest.Data.MmsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.tblVehicles == null)
            {
                return NotFound();
            }

            var vehicle =  await _context.tblVehicles.FirstOrDefaultAsync(m => m.fldVIN == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            Vehicle = vehicle;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleExists(Vehicle.fldVIN))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VehicleExists(string id)
        {
          return _context.tblVehicles.Any(e => e.fldVIN == id);
        }
    }
}

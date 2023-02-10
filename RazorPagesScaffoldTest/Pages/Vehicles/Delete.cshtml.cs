using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetScaffoldTest.Data;
using AspNetScaffoldTest.Data.Models;

namespace AspNetScaffoldTest.RazorPages.Pages.Vehicles
{
    public class DeleteModel : PageModel
    {
        private readonly AspNetScaffoldTest.Data.MmsContext _context;

        public DeleteModel(AspNetScaffoldTest.Data.MmsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Vehicle Vehicle { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.tblVehicles == null)
            {
                return NotFound();
            }

            var vehicle = await _context.tblVehicles.FirstOrDefaultAsync(m => m.fldVIN == id);

            if (vehicle == null)
            {
                return NotFound();
            }
            else 
            {
                Vehicle = vehicle;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.tblVehicles == null)
            {
                return NotFound();
            }
            var vehicle = await _context.tblVehicles.FindAsync(id);

            if (vehicle != null)
            {
                Vehicle = vehicle;
                _context.tblVehicles.Remove(Vehicle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

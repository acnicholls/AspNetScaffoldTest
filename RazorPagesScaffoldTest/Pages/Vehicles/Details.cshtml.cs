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
    public class DetailsModel : PageModel
    {
        private readonly AspNetScaffoldTest.Data.MmsContext _context;

        public DetailsModel(AspNetScaffoldTest.Data.MmsContext context)
        {
            _context = context;
        }

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
    }
}

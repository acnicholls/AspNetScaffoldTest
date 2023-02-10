using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetScaffoldTest.Data;
using AspNetScaffoldTest.Data.Models;

namespace AspNetScaffoldTest.RazorPages.Pages.Leases
{
    public class DetailsModel : PageModel
    {
        private readonly AspNetScaffoldTest.Data.MmsContext _context;

        public DetailsModel(AspNetScaffoldTest.Data.MmsContext context)
        {
            _context = context;
        }

      public Lease Lease { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblLeases == null)
            {
                return NotFound();
            }

            var lease = await _context.tblLeases.FirstOrDefaultAsync(m => m.fldLeaseID == id);
            if (lease == null)
            {
                return NotFound();
            }
            else 
            {
                Lease = lease;
            }
            return Page();
        }
    }
}

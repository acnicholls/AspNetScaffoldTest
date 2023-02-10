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

namespace AspNetScaffoldTest.RazorPages.Pages.Leases
{
    public class EditModel : PageModel
    {
        private readonly AspNetScaffoldTest.Data.MmsContext _context;

        public EditModel(AspNetScaffoldTest.Data.MmsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lease Lease { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblLeases == null)
            {
                return NotFound();
            }

            var lease =  await _context.tblLeases.FirstOrDefaultAsync(m => m.fldLeaseID == id);
            if (lease == null)
            {
                return NotFound();
            }
            Lease = lease;
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

            _context.Attach(Lease).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaseExists(Lease.fldLeaseID))
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

        private bool LeaseExists(int id)
        {
          return _context.tblLeases.Any(e => e.fldLeaseID == id);
        }
    }
}

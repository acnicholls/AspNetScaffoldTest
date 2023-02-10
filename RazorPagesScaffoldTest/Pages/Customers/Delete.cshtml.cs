using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetScaffoldTest.Data;
using AspNetScaffoldTest.Data.Models;

namespace AspNetScaffoldTest.RazorPages.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly AspNetScaffoldTest.Data.MmsContext _context;

        public DeleteModel(AspNetScaffoldTest.Data.MmsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.tblCustomers == null)
            {
                return NotFound();
            }

            var customer = await _context.tblCustomers.FirstOrDefaultAsync(m => m.fldCustomerID == id);

            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.tblCustomers == null)
            {
                return NotFound();
            }
            var customer = await _context.tblCustomers.FindAsync(id);

            if (customer != null)
            {
                Customer = customer;
                _context.tblCustomers.Remove(Customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

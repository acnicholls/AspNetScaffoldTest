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
    public class IndexModel : PageModel
    {
        private readonly AspNetScaffoldTest.Data.MmsContext _context;

        public IndexModel(AspNetScaffoldTest.Data.MmsContext context)
        {
            _context = context;
        }

        public IList<Lease> Lease { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.tblLeases != null)
            {
                Lease = await _context.tblLeases.ToListAsync();
            }
        }
    }
}

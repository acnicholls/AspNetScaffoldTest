using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspNetScaffoldTest.Data.Models;

namespace AspNetScaffoldTest.Data
{
    public class MmsContext : DbContext
    {
        public MmsContext (DbContextOptions<MmsContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> tblCustomers { get; set; } = default!;

        public DbSet<Lease> tblLeases { get; set; }

        public DbSet<Vehicle> tblVehicles { get; set; }
    }
}

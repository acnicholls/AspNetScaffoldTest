using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetScaffoldTest.Data
{
	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<MmsContext>
	{
		public MmsContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<MmsContext>();
			optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true");

			return new MmsContext(optionsBuilder.Options);
		}
	}
}

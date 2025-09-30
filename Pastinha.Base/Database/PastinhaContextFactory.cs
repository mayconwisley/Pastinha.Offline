using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pastinha.Base.Database;

public class PastinhaContextFactory : IDesignTimeDbContextFactory<PastinhaContext>
{
	public PastinhaContext CreateDbContext(string[] args)
	{
		var connectionString = PastinhaStringConnection.ConnectionString();

		var optionsBuilder = new DbContextOptionsBuilder<PastinhaContext>();
		optionsBuilder.UseSqlite(connectionString);

		return new PastinhaContext(optionsBuilder.Options);
	}
}

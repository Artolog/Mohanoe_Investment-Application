using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MIP_API.Data
{
    public class MIPDbContextFactory : IDesignTimeDbContextFactory<MIPDbContext>
    {
        public MIPDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MIPDbContext>();
            optionsBuilder.UseSqlServer("Server=;Database=MohanoeInvestmentPortal;Trusted_Connection=True;TrustServerCertificate=True;");

            return new MIPDbContext(optionsBuilder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MIP_API.Models;

namespace MIP_API.Data
{
    public class MIPDbContext : DbContext
    {
        public MIPDbContext(DbContextOptions<MIPDbContext> options) : base(options) { }

        // ✅ Tell EF Core which tables exist
        public DbSet<User> Users { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}



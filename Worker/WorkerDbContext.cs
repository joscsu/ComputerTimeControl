using Microsoft.EntityFrameworkCore;
using Shared;

namespace Worker
{
    public class WorkerDbContext : DbContext
    {
        public DbSet<ComputerTime> ComputerTimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DatabasePath.Get()}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

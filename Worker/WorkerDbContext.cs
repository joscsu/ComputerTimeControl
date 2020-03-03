using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared;
using Worker.Configuration;

namespace Worker
{
    public class WorkerDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public WorkerDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<ComputerTime> ComputerTimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databaseSettings = configuration.GetSection("databaseSettings").Get<DatabaseSettings>();
            optionsBuilder.UseSqlite($"Filename={databaseSettings.Path}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared;


namespace WpfClient
{
    public class ClientDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ClientDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<ComputerTime.Shared.ComputerTime> ComputerTimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var appSettings = configuration.GetSection("appSettings").Get<AppSettings>();
            optionsBuilder.UseSqlite($"Filename={appSettings.DatabasePath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

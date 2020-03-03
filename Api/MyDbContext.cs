using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class MyDbContext : DbContext
    {
        public DbSet<ComputerTime> ComputerTimes { get; set; }
        public DbSet<ComputerTimeRule> ComputerTimeRules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=computertime.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

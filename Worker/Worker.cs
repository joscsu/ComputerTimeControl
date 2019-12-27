using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SetComputerTime();
                await Task.Delay(60000, stoppingToken);
            }
        }

        private async Task SetComputerTime()
        {
            var now = DateTime.Now;
            var maxDiff = TimeSpan.FromSeconds(70);
            using (var context = new WorkerDbContext())
            {
                var computerTime = context.ComputerTimes.OrderByDescending(x => x.Stop).FirstOrDefault();
                if (computerTime == null)
                {
                    context.ComputerTimes.Add(new Shared.ComputerTime() { Start = now, Stop = now });
                }
                else
                {
                    if (now - computerTime.Stop > maxDiff)
                    {
                        context.ComputerTimes.Add(new Shared.ComputerTime() { Start = now, Stop = now });
                    }
                    else
                    {
                        computerTime.Stop = now;
                    }
                }
                await context.SaveChangesAsync();
            }
        }
    }
}

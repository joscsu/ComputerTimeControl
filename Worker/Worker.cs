using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Worker.Configuration;

namespace Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                CheckTime();
                await SetComputerTime();
                await Task.Delay(60000, stoppingToken);
            }
        }

        private void CheckTime()
        {
            var timeControl = configuration.GetSection("ComputerTimeControl").Get<Computertimecontrol>();
            var now = DateTime.Now;
            var dayOfWeek = now.DayOfWeek.ToString();
            var config = timeControl.Days.FirstOrDefault(x => x.Name == dayOfWeek);
            if (config == null)
            {
                ShutDownComputer();
            }
            var allowedPeriods = config.AllowedPeriods;
            var timeIsAllowed = allowedPeriods.Any(x => x.TimeIsAllowed(now));
            if (!timeIsAllowed)
            {
                ShutDownComputer();
            }
        }
        
        private void ShutDownComputer()
        {
            var shutDownInfo = configuration.GetSection("ShutDownInfo").Get<ShutDownInfo>();
            var info = new ProcessStartInfo()
            {
                Arguments = shutDownInfo.Arguments,
                FileName = shutDownInfo.Path
            };
            Process.Start(info);
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

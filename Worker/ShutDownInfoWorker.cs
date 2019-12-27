using Google.Protobuf;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Worker
{
    public class ShutDownInfoWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ShutDownInfoHolder.ShutDownInfo = new Shared.ShutDownInfo()
            {
                Duration = Google.Protobuf.WellKnownTypes.Duration.FromTimeSpan(TimeSpan.FromSeconds(100)),
                IsShuttingDown = true
            };

            using (NamedPipeServerStream pipeServer =
                new NamedPipeServerStream("shutdowninfopipe", PipeDirection.Out, 2, PipeTransmissionMode.Byte, PipeOptions.CurrentUserOnly))
            {
                pipeServer.WaitForConnection();

                try
                {
                    var info = ShutDownInfoHolder.ShutDownInfo;
                    using (var googleStream = new CodedOutputStream(pipeServer))
                    {
                        await Task.Run(() => info.WriteTo(googleStream));
                    }
                }
                catch
                {
                    //TODO: Logging
                }
            }
        }
    }
}

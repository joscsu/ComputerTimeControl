using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;
        public static IServiceProvider ServiceProvider { get; private set; }
        public App()
        {
            host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   ConfigureServices(context.Configuration, services);
               })
               .Build();
            ServiceProvider = host.Services;
        }
        private void ConfigureServices(IConfiguration configuration,
                IServiceCollection services)
        {
            //services.Configure<AppSettings>(configuration
            //    .GetSection(nameof(AppSettings)));
            //services.AddScoped<ISampleService, SampleService>();

            // Register all ViewModels.
            services.AddSingleton<MainViewModel>();

            // Register all the Windows of the applications.
            services.AddTransient<MainWindow>();

            services.AddTransient<ClientDbContext>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            base.OnStartup(e);
        }

        protected override async  void OnExit(ExitEventArgs e)
        {
            if (host != null)
            {
                await host.StopAsync();
                host.Dispose();
            }
            base.OnExit(e);
        }
    }

    public class ViewModelLocator
    {
        public MainViewModel MainViewModel
            => App.ServiceProvider.GetRequiredService<MainViewModel>();
    }
}

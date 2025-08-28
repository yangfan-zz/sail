using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace Sail.Abp.Wpf
{
    public class WpfApplicationBuilder(string[]? args) : IHostApplicationBuilder
    {
        private readonly HostApplicationBuilder _hostApplicationBuilder = new HostApplicationBuilder(args);

        public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory,
            Action<TContainerBuilder>? configure = null) where TContainerBuilder : notnull
        {
            _hostApplicationBuilder.ConfigureContainer(factory, configure);
        }

        public IDictionary<object, object> Properties => ((IHostApplicationBuilder)_hostApplicationBuilder).Properties;

        public IConfigurationManager Configuration => _hostApplicationBuilder.Configuration;
        public IHostEnvironment Environment => _hostApplicationBuilder.Environment;
        public ILoggingBuilder Logging => _hostApplicationBuilder.Logging;
        public IMetricsBuilder Metrics => _hostApplicationBuilder.Metrics;
        public IServiceCollection Services => _hostApplicationBuilder.Services;

        public IHost Build<TApplication, TWindow>() where TApplication : Application
            where TWindow : Window,new()
        {
            if (!Thread.CurrentThread.TrySetApartmentState(ApartmentState.STA))
            {
                Thread.CurrentThread.SetApartmentState(ApartmentState.Unknown);
                Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
            }

          
            Services.AddHostedService<WpfHostedService<TApplication, TWindow>>();
            
            var host = _hostApplicationBuilder.Build();

            Ioc.Default.ConfigureServices(host.Services);

            return host;
        }
    }
}

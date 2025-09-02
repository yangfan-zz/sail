using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sail.Abp.Avalonia.Hosting
{
    public class AvaloniaApplicationBuilder(string[] args) : IHostApplicationBuilder
    {
        private readonly HostApplicationBuilder _hostBuilder = Host.CreateApplicationBuilder();

        public void ConfigureContainer<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory,
            Action<TContainerBuilder>? configure = null) where TContainerBuilder : notnull
        {
            _hostBuilder.ConfigureContainer(factory, configure);
        }

        public IDictionary<object, object> Properties => ((IHostApplicationBuilder)_hostBuilder).Properties;

        public IConfigurationManager Configuration => _hostBuilder.Configuration;
        public IHostEnvironment Environment => _hostBuilder.Environment;
        public ILoggingBuilder Logging => _hostBuilder.Logging;
        public IMetricsBuilder Metrics => _hostBuilder.Metrics;
        public IServiceCollection Services => _hostBuilder.Services;


        public IHost Build<TApplication, TWindow>(Func<AppBuilder>? builderFactory = null,
            Action<IClassicDesktopStyleApplicationLifetime>? lifetimeBuilder = null)
            where TApplication : Application, new()
            where TWindow : Window, new()
        {

            // For `top level statements`
            Thread.CurrentThread.TrySetApartmentState(ApartmentState.Unknown);
            Thread.CurrentThread.TrySetApartmentState(ApartmentState.STA);

            var appBuilder = (builderFactory ?? AppBuilder.Configure<TApplication>).Invoke();
            // Will create the `Application` instance
            appBuilder.SetupWithClassicDesktopLifetime(args, lifetimeBuilder);

            Services.AddHostedService<AvaloniaHostedService<TApplication, TWindow>>();
            
            // 使用单例注册
            Services.AddSingleton(x => (TApplication)Application.Current!);

            var host = _hostBuilder.Build();

            //  Ioc.Default.ConfigureServices(host.Services);

            return host;
        }
    }
}

using Avalonia;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sail.Abp.Avalonia.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Threading.Tasks;
using AvaloniaApplication1.Views;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace AvaloniaApplication1
{
    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static async Task<int> Main(string[] args)
        {
            //BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
                .WriteTo.Async(c => c.Console())
                .CreateLogger();


            try
            {
                Log.Information("Starting Avalonia host.");

                // 构建默认主机
                var builder = new AvaloniaApplicationBuilder(args);

                builder.Configuration.AddAppSettingsSecretsJson();
                builder.Logging.ClearProviders().AddSerilog();

                // Autofac
                builder.ConfigureContainer(builder.Services.AddAutofacServiceProviderFactory());

                await builder.Services.AddApplicationAsync<AvaloniaApplication1Module>();

                var app = builder.Build<App, MainWindow>(BuildAvaloniaApp);

                await app.InitializeAsync();

                await app.RunAsync();

                return 0;

            }
            catch (Exception ex)
            {
                if (ex is HostAbortedException)
                {
                    throw;
                }

                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                await Log.CloseAndFlushAsync();
            }

        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace()
                .UseReactiveUI();
    }
}

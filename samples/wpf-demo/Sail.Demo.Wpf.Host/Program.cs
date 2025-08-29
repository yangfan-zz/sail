using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sail.Demo.Wpf.Views;
using Sail.Demo.Wpf.Views.ToolkitMessages;
using Serilog;
using Serilog.Events;
using Volo.Abp;

namespace Sail.Demo.Wpf
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
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
                Log.Information("Starting WPF host.");

                // 构建默认主机
                var builder = WpfHost.CreateBuilder(args);

                builder.Configuration.AddAppSettingsSecretsJson();
                builder.Logging.ClearProviders().AddSerilog();

                // Autofac
                builder.ConfigureContainer(builder.Services.AddAutofacServiceProviderFactory());

                await builder.Services.AddApplicationAsync<DemoWpfHostModule>();

                var app = builder.Build<App, StudentMan>();
                

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
    }
}

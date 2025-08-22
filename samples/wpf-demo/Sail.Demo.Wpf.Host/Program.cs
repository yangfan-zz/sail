using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sail.Wpf.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Volo.Abp;

namespace Sail.Demo.Wpf.Host
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
                //.WriteTo.Async(c => c.Console())
                .CreateBootstrapLogger();

            try
            {
                Log.Information("Starting WPF host.");


                // 构建默认主机
                var builder = WpfApplication<App, MainWindow>.CreateBuilder(args);


                builder.Host
                    .AddAppSettingsSecretsJson()
                    .UseAutofac()
                    .UseSerilog((context, services, loggerConfiguration) =>
                    {
                        loggerConfiguration
#if DEBUG
                            .MinimumLevel.Debug()
#else
                        .MinimumLevel.Information()
#endif
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                            .Enrich.FromLogContext()
                            .WriteTo.Async(c => c.File("Logs/logs.txt"))
                            //.WriteTo.Async(c => c.Console())
                            ;
                    });
                await builder.AddApplicationAsync<DemoWpfHostModule>();

                var app = builder.Build();
                //await app.InitializeApplicationAsync();
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

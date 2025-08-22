using Microsoft.Extensions.DependencyInjection;
using Sail.Wpf.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Sail.Demo.Wpf.Host
{
    public static  class WpfApplicationBuilderExtensions
    {
        public static async Task<IAbpApplicationWithExternalServiceProvider> AddApplicationAsync<TStartupModule>(
            this IWpfApplicationBuilder builder,
            Action<AbpApplicationCreationOptions>? optionsAction = null)
            where TStartupModule : IAbpModule
        {
            return await builder.Services.AddApplicationAsync<TStartupModule>(options =>
            {
                options.Services.ReplaceConfiguration(builder.Configuration);
                optionsAction?.Invoke(options);
                if (options.Environment.IsNullOrWhiteSpace())
                {
                    options.Environment = builder.Environment.EnvironmentName;
                }
            });
        }

        public static async Task<IAbpApplicationWithExternalServiceProvider> AddApplicationAsync(
            this IWpfApplicationBuilder builder,
            Type startupModuleType,
            Action<AbpApplicationCreationOptions>? optionsAction = null)
        {
            return await builder.Services.AddApplicationAsync(startupModuleType, options =>
            {
                options.Services.ReplaceConfiguration(builder.Configuration);
                optionsAction?.Invoke(options);
                if (options.Environment.IsNullOrWhiteSpace())
                {
                    options.Environment = builder.Environment.EnvironmentName;
                }
            });
        }
    }
}

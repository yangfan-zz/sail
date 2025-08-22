using Sail.Abp.Wpf;

namespace Microsoft.Extensions.Hosting
{
    public static class WpfHost
    {
        public static WpfApplicationBuilder CreateBuilder(string[]? args) => new(args);

        public static IHost Host { get; set; }
    }
}

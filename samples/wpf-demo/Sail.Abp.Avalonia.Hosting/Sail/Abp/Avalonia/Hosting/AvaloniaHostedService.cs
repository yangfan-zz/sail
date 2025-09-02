using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using Microsoft.Extensions.Hosting;

namespace Sail.Abp.Avalonia.Hosting
{
    public class AvaloniaHostedService<TApplication, TWindow>(
        TApplication application,
        TWindow? window,
        IHostApplicationLifetime hostLifeTime)
        : IHostedService
        where TApplication : Application
        where TWindow : Window
    {
        private ClassicDesktopStyleApplicationLifetime AppLifeTime =>
            (ClassicDesktopStyleApplicationLifetime)application.ApplicationLifetime!;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Dispatcher.UIThread.VerifyAccess();

            if (application.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = window;
            }

            AppLifeTime.Start();
            hostLifeTime.StopApplication();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // 结束
            hostLifeTime.StopApplication();
            return Task.CompletedTask;
        }
    }
}

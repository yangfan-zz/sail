// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Windows;
using Microsoft.Extensions.Hosting;

namespace Sail.Abp.Wpf;

internal class WpfHostedService<TApplication, TWindow>(
    TApplication application,
    TWindow? window,
    IHostApplicationLifetime hostApplicationLifetime
)
    : IHostedService
    where TApplication : Application
    where TWindow : Window
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        application.Run(window);
        hostApplicationLifetime.StopApplication();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        // 结束
        application.Shutdown();
        return Task.CompletedTask;
    }
}
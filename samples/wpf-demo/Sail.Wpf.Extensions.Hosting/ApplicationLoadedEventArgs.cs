// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Windows;

namespace Sail.Wpf.Extensions.Hosting;

/// <summary>
/// Argument for the WPF application loaded event.
/// </summary>
/// <typeparam name="TApplication"></typeparam>
/// <typeparam name="TWindow"></typeparam>
public class ApplicationLoadedEventArgs<TApplication, TWindow>(TApplication application, TWindow window) : EventArgs
    where TApplication : Application
    where TWindow : Window
{
    public TApplication Application { get; } = application;
    public TWindow Window { get; } = window;
}
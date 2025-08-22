using Microsoft.Extensions.DependencyInjection;
using Sail.Abp.Wpf;
using Sail.Demo.Wpf.ViewModels;
using Sail.Demo.Wpf.Views;
using System;
using System.Windows;
using Volo.Abp.Autofac;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;

namespace Sail.Demo.Wpf;

[DependsOn(
    typeof(DemoWpfApplicationModule),
    typeof(AbpAutofacModule),
    typeof(SailWpfHostingModule))]
public class DemoWpfHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        AddWindow<MainWindow, MainWindowViewModel>(context);
    }

    public void AddWindow<TWindow, TViewModel>(ServiceConfigurationContext context) where TWindow : BaseWindow<TViewModel>,new()
    {
        context.Services.AddTransient<TWindow>(serviceProvider =>
        {
            var window = new TWindow
            {
                LazyServiceProvider = serviceProvider.GetRequiredService<IAbpLazyServiceProvider>()
            };
            window.DataContext = window.LazyServiceProvider.LazyGetRequiredService<TViewModel>();
            return window;
        });
    }
}

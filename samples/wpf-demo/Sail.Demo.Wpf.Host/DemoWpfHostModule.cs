using Microsoft.Extensions.DependencyInjection;
using Sail.Abp.Wpf;
using Sail.Abp.Wpf.Mvvm.ViewModels;
using Sail.Abp.Wpf.Windows;
using Sail.Demo.Wpf.ViewModels;
using Sail.Demo.Wpf.Views;
using Volo.Abp.Autofac;
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

    public void AddWindow<TWindow, TViewModel>(ServiceConfigurationContext context)
        where TViewModel : BaseViewModel
        where TWindow : SailWindow<TViewModel>, new()
    {
        // 使用 ABP 扫描模式，
        // 只有一个无参构造，
        // 或多个构造
        context.Services.AddTransient<TWindow>(serviceProvider =>
        {
            var window = new TWindow
            {
                //  LazyServiceProvider = serviceProvider.GetRequiredService<IAbpLazyServiceProvider>()
            };
            //var ff = window.LazyServiceProvider;

            var viewModel = serviceProvider.GetRequiredService<TViewModel>();

            window.DataContext = viewModel;
            return window;
        });
    }
}

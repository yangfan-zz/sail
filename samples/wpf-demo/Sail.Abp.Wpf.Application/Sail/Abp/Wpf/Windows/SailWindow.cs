using CommunityToolkit.Mvvm.DependencyInjection;
using Sail.Abp.Wpf.Mvvm.ViewModels;
using System.Windows;
using Volo.Abp.DependencyInjection;

namespace Sail.Abp.Wpf.Windows
{
    public class SailWindow<TViewModel> : Window, ITransientDependency where TViewModel : BaseViewModel
    {
        public SailWindow()
        {
            DataContext = Ioc.Default.GetRequiredService<TViewModel>();
        }
    }
}

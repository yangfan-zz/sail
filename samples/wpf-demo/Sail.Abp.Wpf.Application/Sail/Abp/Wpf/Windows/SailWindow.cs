using System.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Sail.Abp.Wpf.Mvvm.ViewModels;
using System.Windows;
using Volo.Abp.DependencyInjection;

namespace Sail.Abp.Wpf.Windows
{
    public class SailWindow<TViewModel> : Window, ITransientDependency
        where TViewModel : class, IBaseViewModel
    {
        public SailWindow()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = Ioc.Default.GetRequiredService<TViewModel>();
            }
        }
    }
}

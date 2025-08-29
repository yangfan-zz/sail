using CommunityToolkit.Mvvm.DependencyInjection;
using Sail.Abp.Wpf.Mvvm.ViewModels;
using System.Windows.Controls;
using Volo.Abp.DependencyInjection;

namespace Sail.Abp.Wpf.Windows.Controls
{
    public class SailUserControl<TViewModel> : UserControl, ITransientDependency
        where TViewModel : class, IBaseViewModel

    {
        public SailUserControl()
        {
            DataContext = Ioc.Default.GetRequiredService<TViewModel>();
        }
    }
}

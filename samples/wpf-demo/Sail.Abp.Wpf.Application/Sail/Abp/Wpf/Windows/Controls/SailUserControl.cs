using CommunityToolkit.Mvvm.DependencyInjection;
using Sail.Abp.Wpf.Mvvm.ViewModels;
using System.ComponentModel;
using System.Windows.Controls;
using Volo.Abp.DependencyInjection;

namespace Sail.Abp.Wpf.Windows.Controls
{
    public class SailUserControl<TViewModel> : UserControl, ITransientDependency
        where TViewModel : class, IBaseViewModel

    {
        public SailUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = Ioc.Default.GetRequiredService<TViewModel>();
            }
        }
    }
}

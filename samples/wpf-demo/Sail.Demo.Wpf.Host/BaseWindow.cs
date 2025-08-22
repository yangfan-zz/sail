using Microsoft.Extensions.Hosting;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Sail.Demo.Wpf
{
    public class BaseWindow<TViewModel> : Window
    {
        public BaseWindow()
        {
            DataContext = WpfHost.Host.Services.GetRequiredService<TViewModel>();
        }
    }
}

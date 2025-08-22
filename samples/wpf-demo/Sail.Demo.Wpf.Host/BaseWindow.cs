using System.Windows;
using Volo.Abp.DependencyInjection;

namespace Sail.Demo.Wpf
{
    public interface IBaseWindow
    {
         IAbpLazyServiceProvider LazyServiceProvider { get;  }
    }

    public class BaseWindow<TViewModel> : Window, IBaseWindow
    {
        public IAbpLazyServiceProvider LazyServiceProvider { get; internal set; }
    }
}

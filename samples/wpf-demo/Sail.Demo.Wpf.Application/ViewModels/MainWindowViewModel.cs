using Volo.Abp.DependencyInjection;

namespace Sail.Demo.Wpf.ViewModels
{
    public class MainWindowViewModel : ITransientDependency
    {
        public string Message => "Hello, Generic Host!";
    }
}

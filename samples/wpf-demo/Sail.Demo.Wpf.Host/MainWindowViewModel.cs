using Volo.Abp.DependencyInjection;

namespace Sail.Demo.Wpf.Host
{
    public class MainWindowViewModel : ITransientDependency
    {
        public string Message => "Hello, Generic Host!";
    }
}

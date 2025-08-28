using CommunityToolkit.Mvvm.ComponentModel;
using Sail.Abp.Wpf.Mvvm.ViewModels;

namespace Sail.Demo.Wpf.ViewModels
{
    public partial class MainWindowViewModel : BaseViewModel
    {
        [ObservableProperty]
        public partial string Message { get; protected set; } = "Hello, Generic Host!";
    }
}

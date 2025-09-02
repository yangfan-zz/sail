using Avalonia.Controls;
using AvaloniaApplication1.ViewModels;
using Volo.Abp.DependencyInjection;

namespace AvaloniaApplication1.Views
{
    public partial class MainWindow : Window,ITransientDependency
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
            
        }
    }
}
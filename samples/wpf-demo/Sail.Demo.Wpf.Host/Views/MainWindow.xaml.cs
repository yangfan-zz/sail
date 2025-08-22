using System.Windows;
using Sail.Demo.Wpf.ViewModels;

namespace Sail.Demo.Wpf.Views
{
    public interface IWindowWithViewModel<TWindow, ViewModel>
    {

    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindowWithViewModel<MainWindow, MainWindowViewModel>
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }
    }
}
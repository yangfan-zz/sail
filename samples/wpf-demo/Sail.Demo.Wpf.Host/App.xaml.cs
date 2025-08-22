using System.Windows;
using Volo.Abp.DependencyInjection;

namespace Sail.Demo.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, ISingletonDependency
    {
        public App()
        {
            InitializeComponent();
        }
    }
}

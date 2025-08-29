using Sail.Demo.Wpf.ViewModels.ToolkitMessages;
using System.ComponentModel;

namespace Sail.Demo.Wpf.Views.ToolkitMessages
{
    /// <summary>
    /// StudentList.xaml 的交互逻辑
    /// </summary>
    public partial class StudentList
    {
        public StudentList()
        {
            InitializeComponent();

            //if (DesignerProperties.GetIsInDesignMode(this))
            //{
                DataContext = new StudentListViewModel();
            //}
        }
    }
}

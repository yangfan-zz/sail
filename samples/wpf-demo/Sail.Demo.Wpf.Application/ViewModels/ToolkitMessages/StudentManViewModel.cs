using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Sail.Abp.Wpf.Mvvm.ViewModels;

namespace Sail.Demo.Wpf.ViewModels.ToolkitMessages
{
    public partial class StudentManViewModel : BaseViewModelWithRecipient,
        IRecipient<PropertyChangedMessage<string>>
    {
        [ObservableProperty]
        public partial string Information { get; set; } = "INSERT INTO Students ...";

        public void Receive(PropertyChangedMessage<string> message)
        {
            if (message.Sender is StudentFormViewModel vm)
                Information = vm.SqlQuery;
        }
    }
}

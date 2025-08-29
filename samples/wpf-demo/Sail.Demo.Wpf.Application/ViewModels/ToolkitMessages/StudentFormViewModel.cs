using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Sail.Abp.Wpf.Mvvm.ViewModels;
using Sail.Demo.Wpf.Models;

namespace Sail.Demo.Wpf.ViewModels.ToolkitMessages
{
    public partial class StudentFormViewModel : BaseViewModelWithRecipient, IRecipient<ValueChangedMessage<bool>>
    {
        private bool AllowAddNew { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        public partial string Name { get; set; } = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        public partial string Class { get; set; } = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        public partial string Phone { get; set; } = string.Empty;

        public string SqlQuery =>
            $"INSERT INTO Students (Name, Class, Phone) VALUES ('{Name}', '{Class}', '{Phone}')";

        public void Receive(ValueChangedMessage<bool> message)
        {
            AllowAddNew = message.Value;
            AddNewCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand(CanExecute = nameof(AllowAddNew))]
        public void AddNew()
        {
            WeakReferenceMessenger.Default.Send(
                new ValueChangedMessage<Student>(new(Name, Class, Phone))
            );
        }
    }
}

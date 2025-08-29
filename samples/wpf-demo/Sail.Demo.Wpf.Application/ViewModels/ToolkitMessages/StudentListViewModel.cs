using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Sail.Abp.Wpf.Mvvm.ViewModels;
using Sail.Demo.Wpf.Models;
using System.Collections.ObjectModel;

namespace Sail.Demo.Wpf.ViewModels.ToolkitMessages
{
    public partial class StudentListViewModel : BaseViewModelWithRecipient, IRecipient<ValueChangedMessage<Student>>
    {
        public StudentListViewModel()
        {
            IsActive = true;
            Students.CollectionChanged += (_, _) => OnPropertyChanged(nameof(StudentCount));
        }


        public ObservableCollection<Student> Students { get;  } = [];

        [ObservableProperty]
        public partial bool AllowAddNew { get; set; }

        public int StudentCount => Students.Count;

        partial void OnAllowAddNewChanged(bool value)
        {
            WeakReferenceMessenger.Default.Send(new ValueChangedMessage<bool>(value));
        }

        public void Receive(ValueChangedMessage<Student> message)
        {
            Students.Add(message.Value);
        }
    }
}

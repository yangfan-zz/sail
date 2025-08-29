using CommunityToolkit.Mvvm.ComponentModel;

namespace Sail.Abp.Wpf.Mvvm.ViewModels
{
    public abstract class BaseViewModel : ObservableObject, IBaseViewModel
    {

    }

    public abstract class BaseViewModelWithRecipient : ObservableRecipient, IBaseViewModel
    {

    }
}

using System.Windows.Input;
using XamarinMobileApp.Helpers;

namespace XamarinMobileApp.BL.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        public ICommand GoToProfileEditCommand => MakeNavigateToCommand(Pages.ProfileEdit);
    }
}

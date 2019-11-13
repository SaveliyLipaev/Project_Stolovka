using System.Windows.Input;

namespace XamarinMobileApp.BL.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        public ICommand GoToProfileEditCommand => MakeNavigateToCommand(Pages.ProfileEdit);
    }
}

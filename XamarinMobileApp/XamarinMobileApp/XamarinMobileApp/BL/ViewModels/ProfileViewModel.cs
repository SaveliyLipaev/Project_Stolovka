using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace XamarinMobileApp.BL.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        public ICommand GoToProfileEditCommand => MakeNavigateToCommand(Pages.ProfileEdit);
    }
}

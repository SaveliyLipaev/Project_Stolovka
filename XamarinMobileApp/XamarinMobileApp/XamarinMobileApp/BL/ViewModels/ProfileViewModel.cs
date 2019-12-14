using Akavache;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Reactive.Linq;
using XamarinMobileApp.Helpers;
using XamarinMobileApp.DAL.DataObjects;

namespace XamarinMobileApp.BL.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        public string Name
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Family
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Email
        {
            get => Get<string>();
            set => Set(value);
        }

        public override async Task OnPageAppearing()
        {
            var user = await BlobCache.UserAccount.GetObject<LoginResultDataObject>("login");
            Name = user.FirstName;
            Family = user.LastName;
            Email = user.Email;
        }

        public ICommand GoToProfileEditCommand => MakeNavigateToCommand(Pages.ProfileEdit);
    }
}

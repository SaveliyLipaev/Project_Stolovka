using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMobileApp.BL.ViewModels;

namespace XamarinMobileApp.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPaymentPage : PopupPage
    {
        protected BaseViewModel BaseViewModel => BindingContext as BaseViewModel;

        public OrderPaymentPage()
        {
            InitializeComponent();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return Content.FadeTo(0.5);
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return Content.FadeTo(1);
        }

        public void Dispose()
        {
            BaseViewModel?.Dispose();
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (Parent == null)
            {
                Dispose();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Task.Run(async () => {
                await Task.Delay(50); // Allow UI to handle events loop

                if (BaseViewModel != null)
                {
                    await BaseViewModel.OnPageAppearing();
                    BaseViewModel.StartLoadData();
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Task.Run(async () => {
                await Task.Delay(50); // Allow UI to handle events loop

                if (BaseViewModel != null)
                {
                    await BaseViewModel.OnPageDisappearing();
                }
            });
        }
    }
}
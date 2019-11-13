using System.Windows.Input;

namespace XamarinMobileApp.BL.ViewModels
{
    class BasketViewModel : BaseViewModel
    {
        public ICommand GoToOrderPaymentCommand => MakeNavigateToCommand(Pages.OrderPayment);
    }
}

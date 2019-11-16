using System.Windows.Input;

namespace XamarinMobileApp.BL.ViewModels
{
    class SearchViewModel : BaseViewModel
    {
        private int count = 0;
        public string text
        {
            get => Get<string>();
            set => Set(value);
        }

        public ICommand buttonPresed => MakeCommand(async () =>
        {
            count++;
            text = count.ToString();
        });


    }
}

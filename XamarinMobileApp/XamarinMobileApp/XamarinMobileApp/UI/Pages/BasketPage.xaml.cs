using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMobileApp.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasketPage : BasePage
    {
        public BasketPage()
        {
            InitializeComponent();
            dishList.ItemSelected += DeselectItem;
        }

        public void DeselectItem(object sender, EventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
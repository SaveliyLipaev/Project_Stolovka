using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinMobileApp.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodMenuPage : BasePage
    {
        public FoodMenuPage()
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
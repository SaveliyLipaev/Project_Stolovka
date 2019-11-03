using System;
using Xamarin.Forms;

namespace XamarinMobileApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs args)
        {
            Navigation.InsertPageBefore(new MenuMainPage(), this);
            await Navigation.PopAsync();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
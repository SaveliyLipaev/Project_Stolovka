namespace XamarinMobileApp.Helpers
{
	public enum Pages 
    {
        SignIn,
		Profile,
		ProfileEdit,
        Canteens,
        Basket,
        Menu,
        FoodMenu,
        OrderPayment
    }

	public enum NavigationMode 
    {
		Normal,
		Modal,
		Custom,
        RootPage
    }

	public enum PageState 
    {
		Clean,
		Loading,
		Normal,
		NoData,
		Error,
		NoInternet
	}
}

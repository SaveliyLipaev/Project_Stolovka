namespace XamarinMobileApp
{
	public enum Pages 
    {
        Login,
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

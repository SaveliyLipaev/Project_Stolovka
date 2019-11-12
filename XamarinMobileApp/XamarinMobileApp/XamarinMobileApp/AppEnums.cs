namespace XamarinMobileApp
{
	public enum Pages {
		Menu,
		Login,
		Profile,
		ProfileEdit,
        Search,
        Basket,
        Favourites,
        FoodMenu,
        OrderPayment
    }

	public enum NavigationMode {
		Normal,
		Modal,
		RootPage,
		Custom
	}

	public enum PageState {
		Clean,
		Loading,
		Normal,
		NoData,
		Error,
		NoInternet
	}
}

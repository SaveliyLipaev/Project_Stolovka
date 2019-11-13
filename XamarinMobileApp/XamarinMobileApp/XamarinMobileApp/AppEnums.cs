namespace XamarinMobileApp
{
	public enum Pages {
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

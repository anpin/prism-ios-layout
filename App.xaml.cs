namespace ios_layout;

public partial class App : Application
{

	static NavigationPage GetPage()
	{
		var nav = new NavigationPage(new Splash());
		
		Task.Run(async () =>
		{
					await Task.Delay(1000);
					var model = new PageModel();
					var page = new MainPage() { BindingContext = model };
					// await nav
					await Current!.Dispatcher.DispatchAsync( async () => await nav.Navigation.PushAsync(page));
					await Task.Delay(1000);
					await model.RefreshCommand.ExecuteAsync(default);
		});
		return nav;
	}
	public App()
	{
		InitializeComponent();
		#if __NO_PRISM__
		MainPage = GetPage();
		#endif 
	}
}

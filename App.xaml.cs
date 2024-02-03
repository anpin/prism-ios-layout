namespace ios_layout;

public partial class App : Application
{

	
	public App()
	{
		InitializeComponent();
		#if __NO_PRISM__
		MainPage = new NavigationPage(new AppShell_MAUI());
		#endif 
	}
}

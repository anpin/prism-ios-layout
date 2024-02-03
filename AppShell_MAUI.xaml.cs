namespace ios_layout;

public partial class AppShell_MAUI : ContentPage
{
	public AppShell_MAUI()
	{
		InitializeComponent();
	}
	private async void Button_OnClicked(object? sender, EventArgs e)
	{
			
		var model = new PageModel();
		var page = new MainPage() { BindingContext = model };
		// await nav
		await this.Navigation.PushAsync(page);
		// await Current!.Dispatcher.DispatchAsync( async () => await nav.Navigation.PushAsync(page));
		// await Task.Delay(1000);
		await model.RefreshCommand.ExecuteAsync(default);
	}
}

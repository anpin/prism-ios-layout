using Microsoft.Extensions.Logging;
using Prism.Navigation;
using Prism;
using Prism.Navigation.Builder;
using Prism.Navigation.Builder;
namespace ios_layout;

public static class MauiProgram
{
	public const string NavigationPage = nameof(NavigationPage);
    
	public const string PathSeparator = "/";
	
	public const string Root = "";
	public const string Shell = "s";
	public const string Page = "p";
	public static string BuildRoute(params string[] parts) => string.Join(PathSeparator, parts);
	public static MauiApp CreateMauiApp()
	{
		

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			#if !__NO_PRISM__
			.UsePrism(b =>
			{
				b
					.ConfigureLogging(l => l.AddDebug())
					.RegisterTypes(x => x
						.RegisterForNavigation<AppShell, ShellModel>(Shell)
						.RegisterForNavigation<MainPage, PageModel>(Page)
					)
					.OnAppStart(w =>
						
						w.NavigateAsync(BuildRoute(Root,NavigationPage,Shell)));
			})
			#endif 
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		#if __NO_PRISM__
		builder.Logging.AddDebug();
		#endif 

		return builder.Build();
	}
	
}
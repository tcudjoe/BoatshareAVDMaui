using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiAVDApp2.Data;
using MauiAVDApp2.Services;

namespace MauiAVDApp2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		
		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<IBoatService, BoatService>();

		return builder.Build();
	}
}

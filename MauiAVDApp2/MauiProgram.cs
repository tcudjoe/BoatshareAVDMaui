using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiAVDApp2.Services;

namespace MauiAVDApp2;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiMaps()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif
        builder.Services.AddSingleton<IBoatService, BoatService>();
        builder.Services.AddSingleton<IGeocodingService, GeocodingService>();
        builder.Services.AddScoped<IGeocodingService, GeocodingService>();


        return builder.Build();
    }
}

using Microsoft.Extensions.Logging;
using GoOutBurgas.Pages;
using GoOutBurgas.Data;
namespace GoOutBurgas;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<LoginPage>();

        builder.Services.AddSingleton<MapPage>();

        builder.Services.AddTransient<RegisterPage>();

        builder.Services.AddSingleton<Database>();
        return builder.Build();
	}
}

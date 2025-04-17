using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using WeatherAppGroupProject.MVVM.Views;

namespace WeatherAppGroupProject
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })

                ;


#if DEBUG
            builder.Logging.AddDebug();
#endif

            // creates a new page instance each time it is called, this is a depency injection preventition step
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<WeatherPage>();


            return builder.Build();
        }
    }
}

using Microsoft.Extensions.Logging;
using PeliculasApp.DataAccess;
using PeliculasApp.Services;
using PeliculasApp.ViewModels;
using PeliculasApp.Views;

namespace PeliculasApp
{
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
                    fonts.AddFont("COMICATE.TTF", "Comicate");
                });

            PeliculaDbContext dbContext = new();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

            builder.Services.AddDbContext<PeliculaDbContext>();

            builder.Services.AddTransient<PeliculasPage>();
            builder.Services.AddTransient<PeliculasViewModel>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();

            Routing.RegisterRoute(nameof(PeliculasPage), typeof(PeliculasPage));

            //builder.Services.AddSingleton<IMovieService, MoviesService>();
            //builder.Services.AddTransient<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

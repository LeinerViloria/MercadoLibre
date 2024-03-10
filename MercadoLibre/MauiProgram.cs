using Microsoft.Extensions.Logging;
using DevExpress.Maui;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Licensing;

namespace MercadoLibre
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            SyncfusionLicenseProvider.RegisterLicense("MzE1MTYxM0AzMjM0MmUzMDJlMzBDMm1jL3lsRHo2Uk5YZE9Ub2xLeDlsQnJRV2Nmdm9tWGo2YjFVQWNGT0NBPQ==");

            builder
                .UseMauiApp<App>()
                .UseDevExpress()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
